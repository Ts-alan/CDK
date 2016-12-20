using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using CDK.BusinessLogic.Core.DTO.CMS;
using CDK.BusinessLogic.Core.Extenstions;
using CDK.BusinessLogic.Core.Extenstions.MergeExtensions;
using CDK.BusinessLogic.Core.Helpers;
using LinqKit;
using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Db = CDK.DataAccess.Models.cdk;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS.CRUD
{
    internal class DevelopmentCRUDService : BaseEntityCRUDService<Development, Db.Development>
    {
        private readonly IBlobManager BlobManager;

        private readonly string ContainerName;

        public DevelopmentCRUDService(IUnitOfWorkAsync unitOfWork, IBlobManager blobManager) : base(unitOfWork)
        {
            this.BlobManager = blobManager;
            this.ContainerName = ConfigurationManager.AppSettings["developmentsContainerName"];
        }

        public override IList<Development> GetAll()
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            this.Mapper.Map<IList<Db.Development>, IList<Development>>(
                uow.Repository<Db.Development>()
                .Query()
                .Include(d => d.Developer)
                .Include(d => d.DevelopmentAddress)
                .Include(d => d.DevelopmentAmenities)
                .Include(d => d.DevelopmentFloorPlans)
                .Include(d => d.DevelopmentPhotos)
                .Include(d => d.DevelopmentVideos)
                .Select()
                .ToList()));
        }

        public override void Create(Development model)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var dbModel = this.Mapper.Map<Db.Development>(model);

                dbModel.DevelopmentFloorPlans = new HashSet<Db.DevelopmentFloorPlan>();
                dbModel.DevelopmentPhotos = new HashSet<Db.DevelopmentPhoto>();
                dbModel.DevelopmentVideos = new HashSet<Db.DevelopmentVideo>();
                dbModel.DevelopmentAmenities = new HashSet<Db.DevelopmentAmenities>();
                dbModel.DevelopmentPhotos = new HashSet<Db.DevelopmentPhoto>();

                //add new photos
                model.DevelopmentPhotos.ForEach(z =>
                {
                    var newPhoto = this.Mapper.Map<Db.DevelopmentPhoto>(z);

                    this.UploadPhoto(model, z, newPhoto);

                    newPhoto.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                    dbModel.DevelopmentPhotos.Add(newPhoto);
                });

                //add new photos
                model.DevelopmentFloorPlans.ForEach(z =>
                {
                    var newPhoto = this.Mapper.Map<Db.DevelopmentFloorPlan>(z);

                    this.UploadFloor(model, z, newPhoto);

                    newPhoto.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                    dbModel.DevelopmentFloorPlans.Add(newPhoto);
                });

                dbModel.DevelopmentAmenities = uow.Repository<Db.DevelopmentAmenities>()
                .Query(x => model.DevelopmentAmenitiesIds.Any(y => y == x.Id))
                .Select()
                .ToList();

                //add new videos
                model.DevelopmentVideos.Where(x => !x.Id.HasValue).ForEach(z =>
                {
                    var newVideo = this.Mapper.Map<Db.DevelopmentVideo>(z);
                    newVideo.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                    dbModel.DevelopmentVideos.Add(newVideo);
                });

                uow.Repository<Db.Development>().Insert(dbModel);
                uow.Repository<Db.DevelopmentAddress>().Insert(dbModel.DevelopmentAddress);

                uow.SaveChanges();
            });
        }

        public override Development GetById(long id)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var development = uow.Repository<Db.Development>()
                .Query(x => x.Id == id)
                .Include(d => d.Developer)
                .Include(d => d.DevelopmentAddress)
                .Include(d => d.DevelopmentAmenities)
                .Include(d => d.DevelopmentFloorPlans)
                .Include(d => d.DevelopmentPhotos)
                .Include(d => d.DevelopmentVideos)
                .Select().FirstOrDefault();

                if (development == null)
                {
                    return null;
                }

                return this.Mapper.Map<Development>(development);
            });
        }

        public override void Update(Development model)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var dbModel = uow.Repository<Db.Development>()
                .Query(x => x.Id == model.Id)
                .Include(d => d.Developer)
                .Include(d => d.DevelopmentAddress)
                .Include(d => d.DevelopmentAmenities)
                .Include(d => d.DevelopmentFloorPlans)
                .Include(d => d.DevelopmentPhotos)
                .Include(d => d.DevelopmentVideos)
                .Select()
                .FirstOrDefault();

                var newAmenities = uow.Repository<Db.DevelopmentAmenities>()
                .Query(x => model.DevelopmentAmenitiesIds.Any(y => y == x.Id))
                .Select()
                .ToList();

                var amenitiesToRemove = dbModel.DevelopmentAmenities.Where(x => !newAmenities.Any(y => y.Id == x.Id)).ToList();

                amenitiesToRemove.ForEach(x => dbModel.DevelopmentAmenities.Remove(x));

                newAmenities.ForEach(x =>
                {
                    if (dbModel.DevelopmentAmenities.All(z => z.Id != x.Id))
                    {
                        dbModel.DevelopmentAmenities.Add(x);
                    }
                });

                this.MergePhotoChangesForExistingRecord(model, dbModel);
                this.MergeFloorChangesForExistingRecord(model, dbModel);
                dbModel.Merge(model);
                dbModel.MergeVideosForExistingRecord(model, this.Mapper);

                uow.Repository<Db.Development>().Update(dbModel);
                uow.Repository<Db.DevelopmentAddress>().Update(dbModel.DevelopmentAddress);
                uow.SaveChanges();
            });
        }

        public override void DeleteById(long id)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var repo = uow.Repository<Db.Development>();
                var development = repo.Find(id);

                if (development != null)
                {
                    repo.Delete(development);
                    uow.SaveChanges();
                }
            });
        }

        #region Floors

        private void MergeFloorChangesForExistingRecord(Development model, Db.Development dbModel)
        {
            //remove deleted floors
            this.DeleteFloor(model, dbModel);

            //add new floors
            this.AddFloors(model, dbModel);

            //merge floors
            this.MegreFloors(model, dbModel);
        }

        private void MegreFloors(Development model, Db.Development dbModel)
        {
            model.DevelopmentFloorPlans.Where(x => x.Id.HasValue).ForEach(z =>
            {
                var original = dbModel.DevelopmentFloorPlans.FirstOrDefault(x => x.Id == z.Id.Value);

                if (original != null)
                {
                    if (original.PhotoName.Trim().ToLower() != z.PhotoName.Trim().ToLower() ||
                    model.Name.Trim().ToLower() != dbModel.Name.Trim().ToLower() || !string.IsNullOrEmpty(z.Base64String))
                    {
                        if (!string.IsNullOrEmpty(z.Base64String))
                        {
                            this.UploadFloor(model, z, original);
                        }
                        else
                        {
                            this.RenameFloor(model, z, original);
                        }

                        original.PhotoName = z.PhotoName;
                        original.PhotoType = z.PhotoType;
                    }

                    original.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                    original.SequenceNumber = z.SequenceNumber;
                    original.PhotoDescription = z.PhotoDescription;
                    original.AltText = z.PhotoAlt;

                    original.MergeSeo(z);

                    original.Name = z.Name;
                    original.Type = z.Type;
                    original.Beds = z.Beds;
                    original.Baths = z.Baths;
                    original.PropertyTaxe = z.PropertyTaxe;
                    original.InteriorSize = z.InteriorSize;
                    original.OwnershipType = z.OwnershipType;
                    original.CondoMonthlyFees = z.CondoMonthlyFees;
                    original.BalconeySize = z.BalconeySize;
                    original.PropertyTaxePeriod = z.PropertyTaxePeriod;
                    original.CondoFeesPeriod = z.CondoFeesPeriod;
                    original.InteriorSizeType = z.InteriorSizeType;
                    original.BalconeySizeType = z.BalconeySizeType;
                    original.BalconeySize = z.BalconeySize;
                }
            });
        }

        private void AddFloors(Development model, Db.Development dbModel)
        {
            model.DevelopmentFloorPlans.Where(x => !x.Id.HasValue).ToList().ForEach(z =>
            {
                var newPhoto = this.Mapper.Map<Db.DevelopmentFloorPlan>(z);

                this.UploadFloor(model, z, newPhoto);

                newPhoto.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                dbModel.DevelopmentFloorPlans.Add(newPhoto);
            });
        }

        private void DeleteFloor(Development model, Db.Development dbModel)
        {
            var toDelete = dbModel.DevelopmentFloorPlans.Where(x => !model.DevelopmentFloorPlans.Any(y => y.Id == x.Id)).ToList();
            toDelete.ForEach(z =>
            {
                this.BlobManager.Delete(this.ContainerName, z.LargeUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));
                this.BlobManager.Delete(this.ContainerName, z.ThumbnailUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));
                this.BlobManager.Delete(this.ContainerName, z.SmallUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));

                z.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Deleted;
            });
        }

        private void UploadFloor(Development model, DevelopmentFloorPlan photo, Db.DevelopmentFloorPlan newPhoto)
        {
            string imageUri;
            this.BlobManager.Upload(
                     this.ContainerName,
                photo.ScaleByPercentFromByteArray(100),
                     GenerateFloorUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "large", this.ContainerName, out imageUri));
            newPhoto.LargeUri = imageUri;

            this.BlobManager.Upload(
                this.ContainerName,
                photo.ScaleByPercentFromByteArray(50),
                GenerateFloorUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "small", this.ContainerName, out imageUri));
            newPhoto.SmallUri = imageUri;

            this.BlobManager.Upload(
                this.ContainerName,
                photo.ScaleByPercentFromByteArray(25),
                GenerateFloorUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "thumbnail", this.ContainerName, out imageUri));
            newPhoto.ThumbnailUri = imageUri;
        }

        private void RenameFloor(Development model, DevelopmentFloorPlan photo, Db.DevelopmentFloorPlan oldPhoto)
        {
            string imageUri;
            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.LargeUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GenerateFloorUrl(model.Name, photo.PhotoName, photo.PhotoType, "large", this.ContainerName, out imageUri));
            oldPhoto.LargeUri = imageUri;

            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.SmallUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GenerateFloorUrl(model.Name, photo.PhotoName, photo.PhotoType, "small", this.ContainerName, out imageUri));
            oldPhoto.SmallUri = imageUri;

            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.ThumbnailUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GenerateFloorUrl(model.Name, photo.PhotoName, photo.PhotoType, "thumbnail", this.ContainerName, out imageUri));
            oldPhoto.ThumbnailUri = imageUri;
        }

        private static string GenerateFloorUrl(string folder, string photoName, string photoType, string imageSize, string containerName, out string imageUri)
        {
            //{main_url}/unit-photos/{development_name_slugged}/floorplan/{photo_name_slugged}-large.{photo_type}
            //{main_url}/unit-photos/{development_name_slugged}/floorplan/{photo_name_slugged}-small.{photo_type}
            //{main_url}/unit-photos/{development_name_slugged}/floorplan/{photo_name_slugged}-thumbnail.{photo_type}

            var pathForImage = string.Format(
                                    "{0}/floorplan/{1}-{2}.{3}",
                                    folder.GenerateSlug(),
                                    photoName.GenerateSlug(),
                                    imageSize,
                                    photoType.Replace(@"image/", "").ToLower());

            imageUri = string.Format(@"{0}/{1}", containerName, pathForImage);
            return pathForImage;
        }

        #endregion Floors

        #region Photos

        private void MergePhotoChangesForExistingRecord(Development model, Db.Development dbModel)
        {
            //remove deleted photos
            this.DeletePhotos(model, dbModel);

            //add new photos
            this.AddPhotos(model, dbModel);

            //merge photos
            this.MegrePhotos(model, dbModel);
        }

        private void MegrePhotos(Development model, Db.Development dbModel)
        {
            model.DevelopmentPhotos.Where(x => x.Id.HasValue).ForEach(z =>
            {
                var original = dbModel.DevelopmentPhotos.FirstOrDefault(x => x.Id == z.Id.Value);

                if (original != null)
                {
                    if (original.PhotoName.Trim().ToLower() != z.PhotoName.Trim().ToLower() ||
                    model.Name.Trim().ToLower() != dbModel.Name.Trim().ToLower() || !string.IsNullOrEmpty(z.Base64String))
                    {
                        if (!string.IsNullOrEmpty(z.Base64String))
                        {
                            this.UploadPhoto(model, z, original);
                        }
                        else
                        {
                            this.RenamePhoto(model, z, original);
                        }

                        original.PhotoName = z.PhotoName;
                        original.PhotoType = z.PhotoType;
                    }

                    original.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                    original.SequenceNumber = z.SequenceNumber;
                    original.PhotoDescription = z.PhotoDescription;
                    original.AltText = z.PhotoAlt;

                    original.MergeSeo(z);
                }
            });
        }

        private void AddPhotos(Development model, Db.Development dbModel)
        {
            model.DevelopmentPhotos.Where(x => !x.Id.HasValue).ToList().ForEach(z =>
            {
                var newPhoto = this.Mapper.Map<Db.DevelopmentPhoto>(z);

                this.UploadPhoto(model, z, newPhoto);

                newPhoto.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                dbModel.DevelopmentPhotos.Add(newPhoto);
            });
        }

        private void DeletePhotos(Development model, Db.Development dbModel)
        {
            var toDelete = dbModel.DevelopmentPhotos.Where(x => !model.DevelopmentPhotos.Any(y => y.Id == x.Id)).ToList();
            toDelete.ForEach(z =>
            {
                this.BlobManager.Delete(this.ContainerName, z.LargeUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));
                this.BlobManager.Delete(this.ContainerName, z.ThumbnailUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));
                this.BlobManager.Delete(this.ContainerName, z.SmallUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));

                z.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Deleted;
            });
        }

        private void UploadPhoto(Development model, DevelopmentPhoto photo, Db.DevelopmentPhoto newPhoto)
        {
            string imageUri;
            this.BlobManager.Upload(
                     this.ContainerName,
                photo.ScaleByPercentFromByteArray(100),
                     GeneratePhotoUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "large", this.ContainerName, out imageUri));
            newPhoto.LargeUri = imageUri;

            this.BlobManager.Upload(
                this.ContainerName,
                photo.ScaleByPercentFromByteArray(50),
                GeneratePhotoUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "small", this.ContainerName, out imageUri));
            newPhoto.SmallUri = imageUri;

            this.BlobManager.Upload(
                this.ContainerName,
                photo.ScaleByPercentFromByteArray(25),
                GeneratePhotoUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "thumbnail", this.ContainerName, out imageUri));
            newPhoto.ThumbnailUri = imageUri;
        }

        private void RenamePhoto(Development model, DevelopmentPhoto photo, Db.DevelopmentPhoto oldPhoto)
        {
            string imageUri;
            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.LargeUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GeneratePhotoUrl(model.Name, photo.PhotoName, photo.PhotoType, "large", this.ContainerName, out imageUri));
            oldPhoto.LargeUri = imageUri;

            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.SmallUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GeneratePhotoUrl(model.Name, photo.PhotoName, photo.PhotoType, "small", this.ContainerName, out imageUri));
            oldPhoto.SmallUri = imageUri;

            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.ThumbnailUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GeneratePhotoUrl(model.Name, photo.PhotoName, photo.PhotoType, "thumbnail", this.ContainerName, out imageUri));
            oldPhoto.ThumbnailUri = imageUri;
        }

        private static string GeneratePhotoUrl(string folder, string photoName, string photoType, string imageSize, string containerName, out string imageUri)
        {
            //{main_url}/unit-photos/{development_name_slugged}/{photo_name_slugged}-large.{photo_type}
            //{main_url}/unit-photos/{development_name_slugged}/{photo_name_slugged}-small.{photo_type}
            //{main_url}/unit-photos/{development_name_slugged}/{photo_name_slugged}-thumbnail.{photo_type}

            var pathForImage = string.Format(
                                    "{0}/{1}-{2}.{3}",
                                    folder.GenerateSlug(),
                                    photoName.GenerateSlug(),
                                    imageSize,
                                    photoType.Replace(@"image/", "").ToLower());

            imageUri = string.Format(@"{0}/{1}", containerName, pathForImage);
            return pathForImage;
        }

        #endregion Photos
    }
}
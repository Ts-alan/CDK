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
    internal class NeighborhoodGuideCRUDService : BaseEntityCRUDService<NeighborhoodGuide, Db.NeighborhoodGuide>
    {
        private readonly IBlobManager BlobManager;

        private readonly string ContainerName;

        public NeighborhoodGuideCRUDService(IUnitOfWorkAsync unitOfWork, IBlobManager blobManager) : base(unitOfWork)
        {
            this.BlobManager = blobManager;
            this.ContainerName = ConfigurationManager.AppSettings["guiedsContainerName"];
        }

        public override IList<NeighborhoodGuide> GetAll()
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            this.Mapper.Map<IList<Db.NeighborhoodGuide>, IList<NeighborhoodGuide>>(
                uow.Repository<Db.NeighborhoodGuide>()
                .Query()
                .Include(d => d.NeighborhoodArea)
                .Include(k => k.NeighborhoodGuidePhotos)
                .Include(k => k.NeighborhoodGuideVideos)
                .Select()
                .ToList()));
        }

        public override NeighborhoodGuide GetById(long id)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var model = uow.Repository<Db.NeighborhoodGuide>()
                .Query(x => x.Id == id)
                .Include(z => z.NeighborhoodArea)
                .Include(k => k.NeighborhoodGuidePhotos)
                .Include(k => k.NeighborhoodGuideVideos)
                .Select()
                .FirstOrDefault();

                if (model == null)
                {
                    return null;
                }

                return this.Mapper.Map<NeighborhoodGuide>(model);
            });
        }

        public override void Create(NeighborhoodGuide model)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var guide = this.Mapper.Map<Db.NeighborhoodGuide>(model);

                guide.NeighborhoodGuidePhotos = new HashSet<Db.NeighborhoodGuidePhoto>();
                guide.NeighborhoodGuideVideos = new HashSet<Db.NeighborhoodGuideVideo>();

                //add new photos
                model.NeighborhoodGuidePhotos.ForEach(z =>
                {
                    var newPhoto = this.Mapper.Map<Db.NeighborhoodGuidePhoto>(z);

                    this.UploadPhoto(model, z, newPhoto);

                    newPhoto.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                    guide.NeighborhoodGuidePhotos.Add(newPhoto);
                });

                //add new videos
                model.NeighborhoodGuideVideos.Where(x => !x.Id.HasValue).ForEach(z =>
                {
                    var newVideo = this.Mapper.Map<Db.NeighborhoodGuideVideo>(z);
                    newVideo.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                    guide.NeighborhoodGuideVideos.Add(newVideo);
                });

                uow.Repository<Db.NeighborhoodGuide>().Insert(guide);

                uow.SaveChanges();
            });
        }

        public override void Update(NeighborhoodGuide model)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var guide = uow.Repository<Db.NeighborhoodGuide>()
                .Query(x => x.Id == model.Id)
                .Include(z => z.NeighborhoodArea)
                .Include(k => k.NeighborhoodGuidePhotos)
                .Include(k => k.NeighborhoodGuideVideos)
                .Select()
                .FirstOrDefault();

                this.MergeVideoChangesForExistingRecord(model, guide);
                this.MergePhotoChangesForExistingRecord(model, guide);

                guide.Name = model.Name;
                guide.WhatToExpect = model.WhatToExpect;
                guide.TagLine = model.TagLine;
                guide.WhatToExpect = model.WhatToExpect;
                guide.Demographics = model.Demographics;
                guide.Lifestyle = model.Lifestyle;
                guide.WhatYoullLove = model.WhatYoullLove;
                guide.Source = model.Source;

                guide.MergeSeo(model);

                uow.Repository<Db.NeighborhoodGuide>().Update(guide);
                uow.SaveChanges();
            });
        }

        #region Videos

        private void MergeVideoChangesForExistingRecord(NeighborhoodGuide model, Db.NeighborhoodGuide guide)
        {
            //remove deleted videos
            guide.NeighborhoodGuideVideos.Where(x => !model.NeighborhoodGuideVideos.Any(y => y.Id == x.Id)).ToList().ForEach(z => z.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Deleted);

            //add new videos
            model.NeighborhoodGuideVideos.Where(x => !x.Id.HasValue).ForEach(z =>
            {
                var newVideo = this.Mapper.Map<Db.NeighborhoodGuideVideo>(z);
                newVideo.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                guide.NeighborhoodGuideVideos.Add(newVideo);
            });

            //merge videos
            model.NeighborhoodGuideVideos.Where(x => x.Id.HasValue).ForEach(z =>
            {
                var original = guide.NeighborhoodGuideVideos.FirstOrDefault(x => x.Id == z.Id.Value);

                if (original != null)
                {
                    original.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                    original.SequenceNumber = z.SequenceNumber;
                    original.Name = z.Name;
                    original.Type = z.Type;
                    original.Uri = z.Uri;
                    original.Description = z.Description;    
                    original.AltText = z.AltText;

                    original.MergeSeo(z);
                }
            });
        }

        #endregion Videos

        #region Photos

        private void MergePhotoChangesForExistingRecord(NeighborhoodGuide model, Db.NeighborhoodGuide guide)
        {
            //remove deleted photos
            this.DeletePhotos(model, guide);

            //add new photos
            this.AddPhotos(model, guide);

            //merge photos
            this.MegrePhotos(model, guide);
        }

        private void MegrePhotos(NeighborhoodGuide model, Db.NeighborhoodGuide guide)
        {
            model.NeighborhoodGuidePhotos.Where(x => x.Id.HasValue).ForEach(z =>
            {
                var original = guide.NeighborhoodGuidePhotos.FirstOrDefault(x => x.Id == z.Id.Value);

                if (original != null)
                {
                    if (original.PhotoName.Trim().ToLower() != z.PhotoName.Trim().ToLower() ||
                    model.Name.Trim().ToLower() != guide.Name.Trim().ToLower() || !string.IsNullOrEmpty(z.Base64String))
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

        private void AddPhotos(NeighborhoodGuide model, Db.NeighborhoodGuide guide)
        {
            model.NeighborhoodGuidePhotos.Where(x => !x.Id.HasValue).ToList().ForEach(z =>
            {
                var newPhoto = this.Mapper.Map<Db.NeighborhoodGuidePhoto>(z);

                this.UploadPhoto(model, z, newPhoto);

                newPhoto.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                guide.NeighborhoodGuidePhotos.Add(newPhoto);
            });
        }

        private void DeletePhotos(NeighborhoodGuide model, Db.NeighborhoodGuide guide)
        {
            var toDelete = guide.NeighborhoodGuidePhotos.Where(x => !model.NeighborhoodGuidePhotos.Any(y => y.Id == x.Id)).ToList();
            toDelete.ForEach(z =>
            {
                this.BlobManager.Delete(this.ContainerName, z.LargeUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));
                this.BlobManager.Delete(this.ContainerName, z.ThumbnailUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));
                this.BlobManager.Delete(this.ContainerName, z.SmallUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty));

                z.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Deleted;
            });
        }

        private void UploadPhoto(NeighborhoodGuide model, NeighborhoodGuidePhoto photo, Db.NeighborhoodGuidePhoto newPhoto)
        {
            string imageUri;
            this.BlobManager.Upload(
                     this.ContainerName,
                photo.ScaleByPercentFromByteArray(100),
                     GenerateImageUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "large", this.ContainerName, out imageUri));
            newPhoto.LargeUri = imageUri;

            this.BlobManager.Upload(
                this.ContainerName,
                photo.ScaleByPercentFromByteArray(50),
                GenerateImageUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "small", this.ContainerName, out imageUri));
            newPhoto.SmallUri = imageUri;

            this.BlobManager.Upload(
                this.ContainerName,
                photo.ScaleByPercentFromByteArray(25),
                GenerateImageUrl(model.Name, newPhoto.PhotoName, newPhoto.PhotoType, "thumbnail", this.ContainerName, out imageUri));
            newPhoto.ThumbnailUri = imageUri;
        }

        private void RenamePhoto(NeighborhoodGuide model, NeighborhoodGuidePhoto photo, Db.NeighborhoodGuidePhoto oldPhoto)
        {
            string imageUri;
            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.LargeUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GenerateImageUrl(model.Name, photo.PhotoName, photo.PhotoType, "large", this.ContainerName, out imageUri));
            oldPhoto.LargeUri = imageUri;

            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.SmallUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GenerateImageUrl(model.Name, photo.PhotoName, photo.PhotoType, "small", this.ContainerName, out imageUri));
            oldPhoto.SmallUri = imageUri;

            this.BlobManager.Rename(
                this.ContainerName,
                oldPhoto.ThumbnailUri.Replace(string.Format(@"{0}/", this.ContainerName), string.Empty),
                GenerateImageUrl(model.Name, photo.PhotoName, photo.PhotoType, "thumbnail", this.ContainerName, out imageUri));
            oldPhoto.ThumbnailUri = imageUri;
        }

        private static string GenerateImageUrl(string folder, string photoName, string photoType, string imageSize, string containerName, out string imageUri)
        {
            //{main_url}/neiborhood-guide-photos/{neiborhood_guide_name_slugged}/{photo_name_slugged}-large.{photo_type}
            //{main_url}/neiborhood-guide-photos/{neiborhood_guide_name_slugged}/{photo_name_slugged}-small.{photo_type}
            //{main_url}/neiborhood-guide-photos/{neiborhood_guide_name_slugged}/{photo_name_slugged}-thumbnail.{photo_type}

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
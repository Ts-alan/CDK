using CDK.DataAccess.Models.ddf;
using CDK.DataAccess.Repositories;
using CDK.ETL.Core.Managers;
using CDK.ETL.DDF.DdfRawModel;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDK.ETL.Core.SpecialPocos;
using CDK.ETL.Core.Extenstions;
using System.IO;
using CDK.ETL.DDF;
using CDK.DataAccess.Models.cdk;
using CDK.ETL.Core.Utils;
using CDK.ETL.DDF.ExternalTools.MultipartParser;
using System.Data.Entity.Spatial;

namespace CDK.ETL.Core.Services
{
    class UnitCRUDService
    {

        BlobManager blobManager;
        DdfAddressManager ddfAddressManager;
        DdfCoreManager ddfCoreManager;
        GeographyManager geographyManager;

        public static string _Success = "SUCCESS";
        public static string _NoNh = "NO NH";
        public static string _BadAddress = "BAD ADDRESS";

        public UnitCRUDService(RestSession session)
        {
            this.blobManager = new BlobManager(ConfigurationManager.AppSettings["storageString"], ConfigurationManager.AppSettings["storageUnitPhotoContainerName"]);
            this.ddfAddressManager = new DdfAddressManager();
            this.ddfCoreManager = new DdfCoreManager(session);
            this.geographyManager = new GeographyManager();
        }

        public List<Unit> GetAll()
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                return uow.Repository<Unit>()
                .Query()
                .Select()
                .ToList();
            }
        }

        public Unit GetById(long id)
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                return uow.Repository<Unit>()
                .Query(x => x.Id == id)
                .Select()
                .FirstOrDefault();
            }
        }

        public void DeleteById(long id)
        {
            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {
                var repo = uow.Repository<Unit>();
                var Unit = repo.Find(id);

                if (Unit != null)
                {
                    repo.Delete(Unit);
                    uow.SaveChanges();
                }
            }
        }

        public string CreateOrUpdate(Property model)
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                try
                {

                    var dbModel = uow.Repository<Unit>()
                    .Query(x => x.DdfUnitId == model.DdfPropertyId)
                    .Include(x => x.Building)
                    .Include(x => x.Features)
                    .Include(x => x.UnitPhotos)
                    .Include(x => x.UnitAgents)
                    .Include(x => x.UnitRooms)
                    .Select()
                    .FirstOrDefault();

                    List<UnitPhoto> unitPhotosToRemove = new List<UnitPhoto>();

                    //Transform the address from DDF from external api (google..., geocoder...)
                    AddressResultPoco transformedAddress = ddfAddressManager.TransformAddressFromDdf(model);

                    //If there is not address we discard the unit
                    if (transformedAddress != null)
                    {

                        //Bind a neighborhood to the building
                        NeighborhoodArea nh = null;
                        List<NeighborhoodArea> neighborhoodAreas = null;

                        if (transformedAddress.Lon != null && transformedAddress.Lat != null)
                        {
                            neighborhoodAreas = geographyManager.GetAssociatedNeighborhoods(transformedAddress.Lon, transformedAddress.Lat);
                            if (neighborhoodAreas != null && neighborhoodAreas.Count > 0)
                            {
                                nh = NeighborhoodAreaUtils.GetHigherLevelNeighborhood(neighborhoodAreas);
                            }
                        }

                        if (nh != null)
                        {

                            if (dbModel == null)
                            {
                                dbModel = new Unit();
                                dbModel.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                            }

                            //Map the units
                            dbModel.Map(model);

                            //Create or update building
                            this.CreateOrUpdateBuilding(model, dbModel, transformedAddress, neighborhoodAreas, uow);

                            //SEO for unit
                            dbModel.SeoTitle = UnitUtils.GetSeoTitle(transformedAddress.StreetAddress, nh.MetroArea.ShortName);
                            dbModel.SeoCaption = UnitUtils.GetSeoCaption(transformedAddress.StreetAddress, nh.MetroArea.ShortName, dbModel.ListingId);
                            dbModel.SeoDescription = UnitUtils.GetSeoDescription(transformedAddress.StreetAddress, 
                                                                                 transformedAddress.City, 
                                                                                 nh.ShortName, 
                                                                                 dbModel.TransactionType, 
                                                                                 dbModel?.Price.ToString(), 
                                                                                 dbModel?.Lease.ToString(), 
                                                                                 dbModel.LeasePerTime, 
                                                                                 dbModel?.Building.Type,
                                                                                 dbModel?.BedroomsTotal.ToString(),
                                                                                 dbModel?.BathroomTotal.ToString(),
                                                                                 dbModel.SizeInterior,
                                                                                 dbModel?.MaintenanceFee.ToString(), 
                                                                                 dbModel.MaintenanceFeePaymentUnit, 
                                                                                 dbModel?.ParkingSpaceTotal.ToString(), 
                                                                                 dbModel.Created);
                            dbModel.SeoKeywords = UnitUtils.GetSeoKeywords(transformedAddress.StreetAddress, nh, dbModel.ListingId);
                            dbModel.SeoSlug = UnitUtils.GetSeoSlug(transformedAddress.StreetAddress, nh.MetroArea.ShortName, dbModel.ListingId);
                            dbModel.SeoMetaDescription = UnitUtils.GetSeoMetaDescription(transformedAddress.StreetAddress,
                                                                                        transformedAddress.City,
                                                                                        nh.ShortName,
                                                                                        dbModel?.Building.Type,
                                                                                        dbModel?.Price.ToString(),
                                                                                        dbModel?.Lease.ToString(),
                                                                                        dbModel.LeasePerTime,
                                                                                        dbModel.Created);
                            dbModel.SeoURI = UnitUtils.GetUri(nh, dbModel.Building.BuildingAddress, dbModel.ListingId);
                            dbModel.UnitUri = UnitUtils.GetUri(nh, dbModel.Building.BuildingAddress, dbModel.ListingId);

                            //Merge features
                            this.MegreFeatures(model.Features, dbModel);

                            //Merge unitRooms
                            this.MergeUnitRooms(model, dbModel, uow);

                            //Merge unit agent
                            this.MergeUnitAgents(model, dbModel, uow);

                            //Update or craete
                            if (dbModel.ObjectState == Repository.Pattern.Infrastructure.ObjectState.Added)
                            {

                                //Merge unit Photo
                                this.MergeUnitPhotos(model, dbModel, transformedAddress, nh, uow);

                                uow.Repository<Unit>().Insert(dbModel);
                                uow.SaveChanges();
                                InsertMultipleUnitPhotoIntoStorage(dbModel.UnitPhotos.ToList());

                            }
                            else
                            {

                                //Merge unit Photo
                                this.MergeUnitPhotos(model, dbModel, transformedAddress, nh, uow);

                                uow.Repository<Unit>().Update(dbModel);
                                uow.SaveChanges();

                                if (dbModel.UnitPhotos != null)
                                    RemoveUnitPhotoFromStorage(dbModel.UnitPhotos.ToList());

                                InsertMultipleUnitPhotoIntoStorage(dbModel.UnitPhotos.ToList());

                            }
                            return _Success;
                        }
                        return _NoNh;
                    }
                    return _BadAddress;
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("Can't create or update <{0}>", typeof(Unit)), e);
                }
            }
        }

        private void CreateOrUpdateBuilding(Property model, Unit dbModel, AddressResultPoco transformedAddress, List<NeighborhoodArea> nhas, UnitOfWork uow)
        {

            var building = uow.Repository<Building>()
            .Query(b => b.BuildingAddress.StreetAddress.Trim() == transformedAddress.StreetAddress.Trim())
            .Include(b => b.BuildingAddress)
            .Include(b => b.Amenities)
            .Select()
            .FirstOrDefault();

            //Define the neighborhood for the SEO
            NeighborhoodArea currentNh = null;

            //Create building if there is no building existing
            if (building == null)
            {

                building = new Building();
                building.Map(model);

                BuildingAddress buildingAddress = new BuildingAddress();
                buildingAddress.Map(model, transformedAddress);

                buildingAddress.PositionGeo = DbGeography.FromText(string.Format("POINT({0} {1})", buildingAddress.Lon, buildingAddress.Lat, 4326));

                if (nhas != null && nhas.Count() > 0)
                {

                    buildingAddress.MetroAreaId = nhas.FirstOrDefault().MetroAreaId;

                    foreach (NeighborhoodArea nh in nhas)
                    {
                        if (nh.LType == 1)
                        {
                            buildingAddress.NeighborhoodAreaFirstLevelId = nh.Id;
                        }
                        else if (nh.LType == 2)
                        {
                            buildingAddress.NeighborhoodAreaSecondLevelId = nh.Id;
                        }
                        else if (nh.LType == 3)
                        {
                            buildingAddress.NeighborhoodAreaThirdLevelId = nh.Id;
                        }
                    }

                    currentNh = NeighborhoodAreaUtils.GetHigherLevelNeighborhood(nhas);

                }

                building.Amenities = new List<Amenitie>();

                if (model.PropertyBuilding != null)
                {
                    this.MegreAmenities(model.PropertyBuilding.Amenities, building);
                }

                //Insert building address and map
                uow.Repository<BuildingAddress>().Insert(buildingAddress);
                building.BuildingAddressId = buildingAddress.Id;
                building.BuildingAddress = buildingAddress;

                //Insert building and map
                uow.Repository<Building>().Insert(building);

            }
            else
            {

                building.Map(model);

                if (model.PropertyBuilding != null)
                {
                    this.MegreAmenities(model.PropertyBuilding.Amenities, building);
                }

                uow.Repository<Building>().Update(building);

            }


            //SEO for building

            if (currentNh != null)
            {
                building.SeoTitle = BuildingUtils.GetSeoTitle(transformedAddress.StreetAddress, currentNh.MetroArea.ShortName);
                building.SeoCaption = BuildingUtils.GetSeoCaption(transformedAddress.StreetAddress, currentNh.MetroArea.ShortName);
                building.SeoDescription = BuildingUtils.GetSeoDescription(transformedAddress.StreetAddress, transformedAddress.City, currentNh.ShortName, building.Type, building.ConstructedDate, building.FireplacePresent, building.ManagementCompany, building.Created);

                building.SeoKeywords = BuildingUtils.GetSeoKeywords(transformedAddress.StreetAddress, currentNh);
                building.SeoSlug = BuildingUtils.GetSeoSlug(transformedAddress.StreetAddress, currentNh.MetroArea.ShortName);
                building.SeoMetaDescription = BuildingUtils.GetSeoMetaDescription(transformedAddress.StreetAddress, transformedAddress.City, currentNh.ShortName, building.Created);
                building.SeoURI = BuildingUtils.GetUri(currentNh, building.BuildingAddress);
                building.BuildingUri = BuildingUtils.GetUri(currentNh, building.BuildingAddress);
            }

            dbModel.BuildingId = building.Id;
            dbModel.Building = building;

        }

        private void MergeUnitPhotos(Property model, Unit dbModel, AddressResultPoco transformedAddress, NeighborhoodArea nh, UnitOfWork uow)
        {

            this.DeleteUnitPhotos(model, dbModel, uow);
            this.AddUnitPhotos(model, dbModel, transformedAddress, nh, uow);

        }

        private void DeleteUnitPhotos(Property model, Unit dbModel, UnitOfWork uow)
        {

            if (dbModel.UnitPhotos != null)
            {
                var toDelete = dbModel.UnitPhotos.ToList();
                toDelete.ForEach(z =>
                {
                    uow.Repository<UnitPhoto>().Delete(z);
                    dbModel.UnitPhotos.Remove(z);
                });
            }
        }

        private void AddUnitPhotos(Property model, Unit dbModel, AddressResultPoco transformedAddress, NeighborhoodArea nh, UnitOfWork uow)
        {

            if (model.PropertyPhoto != null)
            {

                var toAdd = model.PropertyPhoto.ToList();

                toAdd.ForEach(x =>
                {

                    UnitPhoto unitPhoto = new UnitPhoto();

                    unitPhoto.Map(x);

                    unitPhoto.DdfPropertyId = x.DdfPropertyId;
                    unitPhoto.PhotoType = ConfigurationManager.AppSettings["ddfPhotoType"];

                    //Seo for unit photo
                    unitPhoto.SeoTitle = PhotoUtils.GetSeoTitle(transformedAddress.StreetAddress, nh.MetroArea.ShortName);
                    unitPhoto.SeoCaption = PhotoUtils.GetSeoCaption(transformedAddress.StreetAddress, nh.MetroArea.ShortName, dbModel.ListingId);
                    unitPhoto.SeoDescription = PhotoUtils.GetSeoDescription();
                    unitPhoto.SeoKeywords = PhotoUtils.GetSeoKeywords(transformedAddress.StreetAddress, nh, dbModel.ListingId);
                    unitPhoto.SeoSlug = PhotoUtils.GetSeoSlug(transformedAddress.StreetAddress, nh.MetroArea.ShortName, dbModel.ListingId);
                    unitPhoto.SeoMetaDescription = PhotoUtils.GetSeoMetaDescription();

                    unitPhoto.LargeUri = PhotoUtils.GetLargeUri(dbModel.UnitUri, transformedAddress.StreetAddress, dbModel.ListingId, x.DdfSequenceId);
                    unitPhoto.ThumbnailUri = PhotoUtils.GetThumbnailUri(dbModel.UnitUri, transformedAddress.StreetAddress, dbModel.ListingId, x.DdfSequenceId);
                    unitPhoto.SmallUri = PhotoUtils.GetSmallUri(dbModel.UnitUri, transformedAddress.StreetAddress, dbModel.ListingId, x.DdfSequenceId);

                    unitPhoto.AltText = PhotoUtils.GetAlternateText();
                    unitPhoto.LastExternalUpdate = x.LastDdfUpdate;
                    unitPhoto.LastUpdate = DateTime.Now;
                    unitPhoto.LastUpdateBy = "ETL";
                    unitPhoto.CreatedBy = "ETL";

                    uow.Repository<UnitPhoto>().Insert(unitPhoto);
                    dbModel.UnitPhotos.Add(unitPhoto);

                });
            }
        }

        private void MergeUnitAgents(Property model, Unit dbModel, UnitOfWork uow)
        {

            var ids = model.PropertyAgent.Select(x => x.PropertyAgentId).ToList();

            var newAgents = uow.Repository<UnitAgent>()
            .Query(x => ids.Any(y => y == x.Id))
            .Select()
            .ToList();

            var agentsToRemove = dbModel.UnitAgents.Where(x => !newAgents.Any(y => y.Id == x.Id)).ToList();

            agentsToRemove.ForEach(x => dbModel.UnitAgents.Remove(x));

            newAgents.ForEach(x =>
            {
                if (dbModel.UnitAgents.All(z => z.Id != x.Id))
                {
                    dbModel.UnitAgents.Add(x);
                }
            });
        }

        private void MergeUnitRooms(Property model, Unit dbModel, UnitOfWork uow)
        {

            this.DeleteUnitRooms(model, dbModel, uow);

            this.AddUnitRooms(model, dbModel, uow);

        }

        private void DeleteUnitRooms(Property model, Unit dbModel, UnitOfWork uow)
        {
            if (dbModel.UnitRooms != null)
            {
                var toDelete = dbModel.UnitRooms.ToList();
                toDelete.ForEach(z =>
                {
                    uow.Repository<UnitRoom>().Delete(z);
                    dbModel.UnitRooms.Remove(z);
                });
            }
        }

        private void AddUnitRooms(Property model, Unit dbModel, UnitOfWork uow)
        {
            if (model.PropertyBuilding != null && model.PropertyBuilding.PropertyBuildingRoom != null)
            {

                List<RoomLevel> roomLevels = DdfMetadataManager.Instance.GetRoomLevels();
                List<RoomType> roomTypes = DdfMetadataManager.Instance.GetRoomTypes();

                var toAdd = model.PropertyBuilding.PropertyBuildingRoom.ToList();

                toAdd.ForEach(x =>
                {

                    UnitRoom unitRoom = new UnitRoom();

                    RoomLevel roomLevel = (from RoomLevel in roomLevels where RoomLevel.ShortName == x.Level select RoomLevel).FirstOrDefault();
                    RoomType roomType = (from RoomType in roomTypes where RoomType.ShortName == x.Type select RoomType).FirstOrDefault();

                    unitRoom.LevelId = roomLevel.Id;
                    unitRoom.TypeId = roomType.Id;

                    unitRoom.Map(x);

                    uow.Repository<UnitRoom>().Insert(unitRoom);
                    dbModel.UnitRooms.Add(unitRoom);

                });

            }
        }

        private void MegreFeatures(String model, Unit dbModel)
        {
            if (model != null)
            {
                //Transform string into features
                List<string> stringFeatures = model.Split(',').ToList();

                //Get all features from db
                List<Feature> dbFeatures = DdfMetadataManager.Instance.GetFeatures();

                //Keep only the one that match received list
                List<Feature> features = dbFeatures.Where(x => stringFeatures.Any(y => y == x.Name)).ToList();

                this.DeleteFeatures(features, dbModel);

                this.AddFeatures(features, dbModel);
            }
        }

        private void AddFeatures(List<Feature> model, Unit dbModel)
        {
            if (dbModel.Features != null)
            {
                var toAdd = model.Where(x => !dbModel.Features.Any(y => y.Name == x.Name)).ToList();
                toAdd.ForEach(z =>
                {
                    dbModel.Features.Add(new Feature() { Id = z.Id });
                });
            }
            else
            {
                model.ForEach(x =>
                {
                    dbModel.Features.Add(new Feature() { Id = x.Id });
                });
            }
        }

        private void DeleteFeatures(List<Feature> model, Unit dbModel)
        {
            if (dbModel.Features != null)
            {
                var toDelete = dbModel.Features.Where(x => !model.Any(y => y.Name == x.Name)).ToList();
                toDelete.ForEach(z =>
                {
                    dbModel.Features.Remove(z);
                });
            }
        }

        private void MegreAmenities(String model, Building dbModel)
        {

            if (model != null)
            {
                //Transform string into amenities
                List<string> stringFeatures = model.Split(',').ToList();

                //Get all amenities from db
                List<Amenitie> dbAmenities = DdfMetadataManager.Instance.GetAmenities();

                //Keep only the one that match received list
                List<Amenitie> amenities = dbAmenities.Where(x => stringFeatures.Any(y => y == x.ShortName)).ToList();

                this.DeleteAmenities(amenities, dbModel);

                this.AddAmenities(amenities, dbModel);
            }
        }

        private void AddAmenities(List<Amenitie> model, Building dbModel)
        {
            if (dbModel.Amenities != null)
            {
                var toAdd = model.Where(x => !dbModel.Amenities.Any(y => y.ShortName == x.ShortName)).ToList();
                toAdd.ForEach(z =>
                {
                    dbModel.Amenities.Add(new Amenitie() { Id = z.Id });
                });
            }
            else
            {
                model.ForEach(x =>
                {
                    dbModel.Amenities.Add(new Amenitie() { Id = x.Id });
                });
                dbModel.Amenities = model;
            }
        }

        private void DeleteAmenities(List<Amenitie> model, Building dbModel)
        {
            if (dbModel.Amenities != null)
            {
                var toDelete = dbModel.Amenities.Where(x => !model.Any(y => y.ShortName == x.ShortName)).ToList();
                toDelete.ForEach(z =>
                {
                    dbModel.Amenities.Remove(z);
                });
            }
        }

        private bool InsertSingleUnitPhotoIntoStorage(List<UnitPhoto> unitPhotos)
        {

            try
            {
                foreach (var unitPhoto in unitPhotos)
                {
                    if (unitPhoto != null)
                    {

                        try
                        {
                            MemoryStream ms = ddfCoreManager.GetObject("Property", unitPhoto.DdfPropertyId + ":" + unitPhoto.DdfSequenceId, PhotoUtils.SmallPhotoAlias);
                            blobManager.UploadFromStream(ms, unitPhoto.SmallUri);
                            ms = ddfCoreManager.GetObject("Property", unitPhoto.DdfPropertyId + ":" + unitPhoto.DdfSequenceId, PhotoUtils.ThumbNailPhotoAlias);
                            blobManager.UploadFromStream(ms, unitPhoto.ThumbnailUri);
                            ms = ddfCoreManager.GetObject("Property", unitPhoto.DdfPropertyId + ":" + unitPhoto.DdfSequenceId, PhotoUtils.LargePhotoAlias);
                            blobManager.UploadFromStream(ms, unitPhoto.LargeUri);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(">>> Error uploading image on azure storage", e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error connecting to the azure storage: " + e.Message);
                return false;
            }

            return true;

        }
        private bool InsertMultipleUnitPhotoIntoStorage(List<UnitPhoto> unitPhotos)
        {

            try
            {

                if (unitPhotos != null && unitPhotos.Count > 0)
                {

                    //Get the propertyId
                    string ddfPropertyId = unitPhotos.First().DdfPropertyId;

                    try
                    {

                        List<MultiPartSection> sections = ddfCoreManager.GetObjectMultipart("Property", ddfPropertyId, PhotoUtils.SmallPhotoAlias);
                        unitPhotos.ForEach(x => {
                            var section = sections.Find(y => y.ObjectID == x.DdfSequenceId);
                            if (section != null) {
                                blobManager.UploadFromStream(section.MultiPartMemoryStream, x.SmallUri);
                            }
                        });

                        sections = ddfCoreManager.GetObjectMultipart("Property", ddfPropertyId, PhotoUtils.ThumbNailPhotoAlias);
                        unitPhotos.ForEach(x => {
                            var section = sections.Find(y => y.ObjectID == x.DdfSequenceId);
                            if (section != null)
                            {
                                blobManager.UploadFromStream(section.MultiPartMemoryStream, x.ThumbnailUri);
                            }
                        });

                        sections = ddfCoreManager.GetObjectMultipart("Property", ddfPropertyId, PhotoUtils.LargePhotoAlias);
                        unitPhotos.ForEach(x => {
                            var section = sections.Find(y => y.ObjectID == x.DdfSequenceId);
                            if (section != null)
                            {
                                blobManager.UploadFromStream(section.MultiPartMemoryStream, x.LargeUri);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(">>> Error uploading image on azure storage", e.Message);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error connecting to the azure storage: " + e.Message);
                return false;
            }

            return true;

        }

        private bool RemoveUnitPhotoFromStorage(List<UnitPhoto> unitPhotos)
        {
            try
            {
                foreach (var unitPhoto in unitPhotos)
                {
                    if (unitPhoto != null)
                    {
                        try
                        {
                            blobManager.DeleteBlob(unitPhoto.SmallUri);
                            blobManager.DeleteBlob(unitPhoto.ThumbnailUri);
                            blobManager.DeleteBlob(unitPhoto.LargeUri);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(">>> Error deleting image on azure storage", e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error connecting to the azure storage: " + e.Message);
                return false;
            }

            return true;

        }

        public int? RemoveDeletedUnits(Dictionary<string, string> masterList)
        {

            int? countRemovedUnits;

            try
            {

                List<string> ddfUnitsIds = new List<string>(masterList.Keys);

                //Database propertyIds
                using (var context = new CDKDbContext())
                using (var uow = new UnitOfWork(context))
                {

                    List<Unit> unitsToRemove = uow.Repository<Unit>().Query(x => x.RemovedDate == null).Select().ToList();
                    unitsToRemove.RemoveAll(x => ddfUnitsIds.Any(k => x.DdfUnitId == k));

                    countRemovedUnits = 0;
                    unitsToRemove.ForEach(x =>
                    {
                        x.RemovedDate = DateTime.Now;
                        uow.Repository<Unit>().Update(x);
                        countRemovedUnits++;
                    });

                    uow.SaveChanges();
                    return countRemovedUnits;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> Error removing deleted units: " + e.Message);
                return null;
            }
        }

        public List<string> GetOutterUnits(Dictionary<string, string> masterList)
        {

            try
            {

                List<string> ddfUnitsIds = new List<string>(masterList.Keys);

                //Database propertyIds
                using (var context = new CDKDbContext())
                using (var uow = new UnitOfWork(context))
                {

                    List<string> dbUnitIds = uow.Repository<Unit>().Query().Select(x => x.DdfUnitId).ToList();
                    ddfUnitsIds.RemoveAll(x => dbUnitIds.Any(k => x == k));

                    return ddfUnitsIds;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

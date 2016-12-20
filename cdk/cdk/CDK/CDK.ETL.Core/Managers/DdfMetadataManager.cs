using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using CDK.DataAccess.Models.ddf;
using CDK.DataAccess.Repositories;
using CDK.ETL.DDF.Property;
using Repository.Pattern.Ef6;
using CDK.ETL.Core.Extenstions;
using CDK.ETL.DDF;

namespace CDK.ETL.Core.Managers
{
    class DdfMetadataManager
    {

        List<RoomLevel> roomLevels = null;
        List<RoomType> roomTypes = null;
        List<Amenitie> amenities = null;
        List<Feature> features = null;
        List<LeaseType> leaseTypes = null;

        private DdfCoreManager ddfCoreManager = null;

        private static DdfMetadataManager instance;

        public static DdfMetadataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DdfMetadataManager();
                }
                return instance;
            }
        }

        public void SetDdfCoreManager(RestSession session)
        {
            this.ddfCoreManager = new DdfCoreManager(session);
        }

        public List<RoomLevel> GetRoomLevels()
        {
            if (roomLevels == null)
            {
                using (var context = new CDKDbContext())
                {
                    roomLevels = context.RoomLevels.ToList();
                    foreach (var item in roomLevels)
                        ((IObjectContextAdapter)context).ObjectContext.Detach(item);
                }
            }
            return roomLevels;
        }

        public List<RoomType> GetRoomTypes()
        {
            if (roomTypes == null)
            {
                using (var context = new CDKDbContext())
                {
                    roomTypes = context.RoomTypes.ToList();
                    foreach (var item in roomTypes)
                        ((IObjectContextAdapter)context).ObjectContext.Detach(item);
                }
            }
            return roomTypes;
        }

        public List<Amenitie> GetAmenities()
        {
            if (amenities == null)
            {
                using (var context = new CDKDbContext())
                {
                    amenities = context.Amenities.ToList();
                    foreach (var item in amenities)
                        ((IObjectContextAdapter)context).ObjectContext.Detach(item);
                }
            }
            return amenities;
        }

        public List<Feature> GetFeatures()
        {
            if (features == null)
            {
                using (var context = new CDKDbContext())
                {
                    features = context.Features.ToList();
                    foreach (var item in features)
                        ((IObjectContextAdapter)context).ObjectContext.Detach(item);
                }
            }
            return features;
        }

        public List<LeaseType> GetLeaseTypes()
        {
            if (leaseTypes == null)
            {
                using (var context = new CDKDbContext())
                {
                    leaseTypes = context.LeaseTypes.ToList();
                    foreach (var item in leaseTypes)
                        ((IObjectContextAdapter)context).ObjectContext.Detach(item);
                }
            }
            return leaseTypes;
        }

        public void CreateUpdateAllMetadata()
        {

            ddfCoreManager.GetMetadataLookupType("Property", "Amenities").TryToMergeAllFromLookupType<Amenitie>();
            ddfCoreManager.GetMetadataLookupType("Property", "AccessType").TryToMergeAllFromLookupType<AccessType>();
            ddfCoreManager.GetMetadataLookupType("Property", "AmenitiesNearby").TryToMergeAllFromLookupType<AmenitiesNearby>();
            ddfCoreManager.GetMetadataLookupType("Property", "Amperage").TryToMergeAllFromLookupType<Amperage>();
            ddfCoreManager.GetMetadataLookupType("Property", "Appliances").TryToMergeAllFromLookupType<Appliance>();
            ddfCoreManager.GetMetadataLookupType("Property", "ArchitecturalStyle").TryToMergeAllFromLookupType<ArchitecturalStyle>();
            ddfCoreManager.GetMetadataLookupType("Property", "BasementDevelopment").TryToMergeAllFromLookupType<BasementDevelopment>();
            ddfCoreManager.GetMetadataLookupType("Property", "BasementFeatures").TryToMergeAllFromLookupType<BasementFeature>();
            ddfCoreManager.GetMetadataLookupType("Property", "BasementType").TryToMergeAllFromLookupType<BasementType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Boards").TryToMergeAllFromLookupType<Board>();
            ddfCoreManager.GetMetadataLookupType("Property", "BuildingType").TryToMergeAllFromLookupType<BuildingType>();
            ddfCoreManager.GetMetadataLookupType("Property", "BusinessSubType").TryToMergeAllFromLookupType<BusinessSubType>();
            ddfCoreManager.GetMetadataLookupType("Property", "BusinessType").TryToMergeAllFromLookupType<BusinessType>();
            ddfCoreManager.GetMetadataLookupType("Property", "CeilingType").TryToMergeAllFromLookupType<CeilingType>();
            //ddfCoreManager.GetMetadataLookupType("Property", "ClearCeilingHeight").TryToMergeAllFromLookupType<ClearCeilingHeight>();
            ddfCoreManager.GetMetadataLookupType("Property", "CommunicationType").TryToMergeAllFromLookupType<CommunicationType>();
            ddfCoreManager.GetMetadataLookupType("Property", "CommunityFeatures").TryToMergeAllFromLookupType<CommunityFeature>();
            ddfCoreManager.GetMetadataLookupType("Property", "ConstructionMaterial").TryToMergeAllFromLookupType<ConstructionMaterial>();
            ddfCoreManager.GetMetadataLookupType("Property", "ConstructionStatus").TryToMergeAllFromLookupType<ConstructionStatus>();
            ddfCoreManager.GetMetadataLookupType("Property", "ConstructionStyleAttachment").TryToMergeAllFromLookupType<ConstructionStyleAttachment>();
            ddfCoreManager.GetMetadataLookupType("Property", "ConstructionStyleOther").TryToMergeAllFromLookupType<ConstructionStyleOther>();
            ddfCoreManager.GetMetadataLookupType("Property", "ConstructionStyleSplitLevel").TryToMergeAllFromLookupType<ConstructionStyleSplitLevel>();
            ddfCoreManager.GetMetadataLookupType("Property", "CoolingType").TryToMergeAllFromLookupType<CoolingType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Crop").TryToMergeAllFromLookupType<Crop>();
            ddfCoreManager.GetMetadataLookupType("Property", "CurrentUse").TryToMergeAllFromLookupType<CurrentUse>();
            ddfCoreManager.GetMetadataLookupType("Property", "DocumentType").TryToMergeAllFromLookupType<DocumentType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Easement").TryToMergeAllFromLookupType<Easement>();
            ddfCoreManager.GetMetadataLookupType("Property", "EquipmentType").TryToMergeAllFromLookupType<EquipmentType>();
            ddfCoreManager.GetMetadataLookupType("Property", "ExteriorFinish").TryToMergeAllFromLookupType<ExteriorFinish>();
            ddfCoreManager.GetMetadataLookupType("Property", "FarmType").TryToMergeAllFromLookupType<FarmType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Features").TryToMergeAllFromLookupType<Feature>();
            ddfCoreManager.GetMetadataLookupType("Property", "FenceType").TryToMergeAllFromLookupType<FenceType>();
            ddfCoreManager.GetMetadataLookupType("Property", "FireProtection").TryToMergeAllFromLookupType<FireProtection>();
            ddfCoreManager.GetMetadataLookupType("Property", "FireplaceFuel").TryToMergeAllFromLookupType<FireplaceFuel>();
            ddfCoreManager.GetMetadataLookupType("Property", "FireplaceType").TryToMergeAllFromLookupType<FireplaceType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Fixture").TryToMergeAllFromLookupType<Fixture>();
            ddfCoreManager.GetMetadataLookupType("Property", "FlooringType").TryToMergeAllFromLookupType<FlooringType>();
            ddfCoreManager.GetMetadataLookupType("Property", "FoundationType").TryToMergeAllFromLookupType<FoundationType>();
            ddfCoreManager.GetMetadataLookupType("Property", "FrontsOn").TryToMergeAllFromLookupType<FrontsOn>();
            ddfCoreManager.GetMetadataLookupType("Property", "HeatingType").TryToMergeAllFromLookupType<HeatingType>();
            ddfCoreManager.GetMetadataLookupType("Property", "HeatingFuel").TryToMergeAllFromLookupType<HeatingFuel>();
            ddfCoreManager.GetMetadataLookupType("Property", "IrrigationType").TryToMergeAllFromLookupType<IrrigationType>();
            ddfCoreManager.GetMetadataLookupType("Property", "LandDispositionType").TryToMergeAllFromLookupType<LandDispositionType>();
            ddfCoreManager.GetMetadataLookupType("Property", "LandscapeFeatures").TryToMergeAllFromLookupType<LandscapeFeature>();
            ddfCoreManager.GetMetadataLookupType("Property", "LeaseType").TryToMergeAllFromLookupType<LeaseType>();
            ddfCoreManager.GetMetadataLookupType("Property", "LiveStockType").TryToMergeAllFromLookupType<LiveStockType>();
            ddfCoreManager.GetMetadataLookupType("Property", "LoadingType").TryToMergeAllFromLookupType<LoadingType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Machinery").TryToMergeAllFromLookupType<Machinery>();
            ddfCoreManager.GetMetadataLookupType("Property", "MaintenanceFeeType").TryToMergeAllFromLookupType<MaintenanceFeeType>();
            ddfCoreManager.GetMetadataLookupType("Property", "MeasureUnit").TryToMergeAllFromLookupType<MeasureUnit>();
            ddfCoreManager.GetMetadataLookupType("Property", "OwnershipType").TryToMergeAllFromLookupType<OwnershipType>();
            ddfCoreManager.GetMetadataLookupType("Property", "ParkingType").TryToMergeAllFromLookupType<ParkingType>();
            ddfCoreManager.GetMetadataLookupType("Property", "PaymentUnit").TryToMergeAllFromLookupType<PaymentUnit>();
            ddfCoreManager.GetMetadataLookupType("Property", "PoolFeatures").TryToMergeAllFromLookupType<PoolFeature>();
            ddfCoreManager.GetMetadataLookupType("Property", "PoolType").TryToMergeAllFromLookupType<PoolType>();
            ddfCoreManager.GetMetadataLookupType("Property", "PropertyType").TryToMergeAllFromLookupType<PropertyType>();
            ddfCoreManager.GetMetadataLookupType("Property", "RentalEquipmentType").TryToMergeAllFromLookupType<RentalEquipmentType>();
            ddfCoreManager.GetMetadataLookupType("Property", "RightType").TryToMergeAllFromLookupType<RightType>();
            ddfCoreManager.GetMetadataLookupType("Property", "RoadType").TryToMergeAllFromLookupType<RoadType>();
            ddfCoreManager.GetMetadataLookupType("Property", "RoofMaterial").TryToMergeAllFromLookupType<RoofMaterial>();
            ddfCoreManager.GetMetadataLookupType("Property", "RoofStyle").TryToMergeAllFromLookupType<RoofStyle>();
            ddfCoreManager.GetMetadataLookupType("Property", "RoomLevel").TryToMergeAllFromLookupType<RoomLevel>();
            ddfCoreManager.GetMetadataLookupType("Property", "RoomType").TryToMergeAllFromLookupType<RoomType>();
            ddfCoreManager.GetMetadataLookupType("Property", "Sewer").TryToMergeAllFromLookupType<Sewer>();
            ddfCoreManager.GetMetadataLookupType("Property", "SignType").TryToMergeAllFromLookupType<SignType>();
            ddfCoreManager.GetMetadataLookupType("Property", "SoilEvaluationType").TryToMergeAllFromLookupType<SoilEvaluationType>();
            ddfCoreManager.GetMetadataLookupType("Property", "SoilType").TryToMergeAllFromLookupType<SoilType>();
            ddfCoreManager.GetMetadataLookupType("Property", "StorageType").TryToMergeAllFromLookupType<StorageType>();
            ddfCoreManager.GetMetadataLookupType("Property", "StoreFront").TryToMergeAllFromLookupType<StoreFront>();
            ddfCoreManager.GetMetadataLookupType("Property", "StructureType").TryToMergeAllFromLookupType<StructureType>();
            ddfCoreManager.GetMetadataLookupType("Property", "SurfaceWater").TryToMergeAllFromLookupType<SurfaceWater>();
            ddfCoreManager.GetMetadataLookupType("Property", "TopographyType").TryToMergeAllFromLookupType<TopographyType>();
            ddfCoreManager.GetMetadataLookupType("Property", "TransactionType").TryToMergeAllFromLookupType<TransactionType>();
            ddfCoreManager.GetMetadataLookupType("Property", "UffiCodes").TryToMergeAllFromLookupType<UffiCode>();
            ddfCoreManager.GetMetadataLookupType("Property", "UtilityPower").TryToMergeAllFromLookupType<UtilityPower>();
            ddfCoreManager.GetMetadataLookupType("Property", "UtilityType").TryToMergeAllFromLookupType<UtilityType>();
            ddfCoreManager.GetMetadataLookupType("Property", "UtilityWater").TryToMergeAllFromLookupType<UtilityWater>();
            ddfCoreManager.GetMetadataLookupType("Property", "ViewType").TryToMergeAllFromLookupType<ViewType>();
            ddfCoreManager.GetMetadataLookupType("Property", "WaterFrontType").TryToMergeAllFromLookupType<WaterFrontType>();
            ddfCoreManager.GetMetadataLookupType("Property", "ZoningType").TryToMergeAllFromLookupType<ZoningType>();
            ddfCoreManager.GetMetadataLookupType("Agent", "Boards").TryToMergeAllFromLookupType<ABoard>();
            ddfCoreManager.GetMetadataLookupType("Agent", "IndividualDesignations").TryToMergeAllFromLookupType<IndividualDesignation>();
            ddfCoreManager.GetMetadataLookupType("Agent", "Languages").TryToMergeAllFromLookupType<ALanguage>();
            ddfCoreManager.GetMetadataLookupType("Agent", "Specialties").TryToMergeAllFromLookupType<Specialtie>();
            ddfCoreManager.GetMetadataLookupType("Office", "Franchisor").TryToMergeAllFromLookupType<Franchisor>();
            ddfCoreManager.GetMetadataLookupType("Office", "OrganizationDesignations").TryToMergeAllFromLookupType<OrganizationType>();
            ddfCoreManager.GetMetadataLookupType("Office", "OrganizationType").TryToMergeAllFromLookupType<OrganizationDesignation>();

        }
    }
}

using System;
using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class Building : Entity, ISeoModel, IExternalModel, IBaseModel
    {
        public long Id
        {
            get; set;
        }

        public long? BuildingAddressId
        {
            get; set;
        }

        public string BuildingUri
        {
            get; set;
        }

        public string Age
        {
            get; set;
        }

        public string Board
        {
            get; set;
        }

        public string Anchor
        {
            get; set;
        }

        public string BomaRating
        {
            get; set;
        }

        public string ConstructedDate
        {
            get; set;
        }

        public string EnerguideRating
        {
            get; set;
        }

        public string FireplacePresent
        {
            get; set;
        }

        public string FireplaceTotal
        {
            get; set;
        }

        public string LeedsCategory
        {
            get; set;
        }

        public string LeedsRating
        {
            get; set;
        }

        public string RenovatedDate
        {
            get; set;
        }

        public string StoriesTotal
        {
            get; set;
        }

        public string SizeExterior
        {
            get; set;
        }

        public string ManagementCompany
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public string Structure
        {
            get; set;
        }

        public string MunicipalId
        {
            get; set;
        }

        public string Uffi
        {
            get; set;
        }

        public string UnitType
        {
            get; set;
        }

        public string VacancyRate
        {
            get; set;
        }

        public string ZoningType
        {
            get; set;
        }

        public string ZoningDescription
        {
            get; set;
        }

        public string TotalBuildings
        {
            get; set;
        }

        public string WaterFrontName
        {
            get; set;
        }

        public string LocationDescription
        {
            get; set;
        }

        public System.DateTime LastExternalUpdate
        {
            get; set;
        }

        public System.DateTime LastUpdate
        {
            get; set;
        }

        public DateTime Created
        {
            get; set;
        }

        public string CreatedBy
        {
            get; set;
        }

        public string LastUpdateBy
        {
            get; set;
        }

        public string SeoCaption
        {
            get; set;
        }

        public string SeoDescription
        {
            get; set;
        }

        public string SeoKeywords
        {
            get; set;
        }

        public string SeoSlug
        {
            get; set;
        }

        public string SeoTitle
        {
            get; set;
        }

        public string SeoMetaDescription
        {
            get; set;
        }

        public string SeoURI
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Amenitie> Amenities
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Amperage> Amperages
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ArchitecturalStyle> ArchitecturalStyles
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BasementDevelopment> BasementDevelopments
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BasementFeature> BasementFeatures
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BasementType> BasementTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Board> Boards
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BuildingLand> BuildingLands
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BuildingType> BuildingTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<CeilingType> CeilingTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ClearCeilingHeight> ClearCeilingHeights
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<CommunicationType> CommunicationTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<CommunityFeature> CommunityFeatures
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ConstructionMaterial> ConstructionMaterials
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Crop> Crops
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<DocumentType> DocumentTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Easement> Easements
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<EquipmentType> EquipmentTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ExteriorFinish> ExteriorFinishes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FarmType> FarmTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FireplaceFuel> FireplaceFuels
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FireplaceType> FireplaceTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FireProtection> FireProtections
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Fixture> Fixtures
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FoundationType> FoundationTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<HeatingFuel> HeatingFuels
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<HeatingType> HeatingTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<IrrigationType> IrrigationTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Machinery> Machineries
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<MeasureUnit> MeasureUnits
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<PoolFeature> PoolFeatures
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<PoolType> PoolTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<RoadType> RoadTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<RoofMaterial> RoofMaterials
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<RoofStyle> RoofStyles
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<SignType> SignTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<StoreFront> StoreFronts
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<StructureType> StructureTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UffiCode> UffiCodes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Unit> Units
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UtilityPower> UtilityPowers
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UtilityWater> UtilityWaters
        {
            get; set;
        }

        public virtual BuildingAddress BuildingAddress
        {
            get; set;
        }
        
        public Building()
        {
            BuildingLands = new System.Collections.Generic.HashSet<BuildingLand>();
            Units = new System.Collections.Generic.HashSet<Unit>();
            Machineries = new System.Collections.Generic.HashSet<Machinery>();
            MeasureUnits = new System.Collections.Generic.HashSet<MeasureUnit>();
            PoolFeatures = new System.Collections.Generic.HashSet<PoolFeature>();
            PoolTypes = new System.Collections.Generic.HashSet<PoolType>();
            RoadTypes = new System.Collections.Generic.HashSet<RoadType>();
            RoofMaterials = new System.Collections.Generic.HashSet<RoofMaterial>();
            RoofStyles = new System.Collections.Generic.HashSet<RoofStyle>();
            SignTypes = new System.Collections.Generic.HashSet<SignType>();
            StoreFronts = new System.Collections.Generic.HashSet<StoreFront>();
            StructureTypes = new System.Collections.Generic.HashSet<StructureType>();
            UffiCodes = new System.Collections.Generic.HashSet<UffiCode>();
            UtilityPowers = new System.Collections.Generic.HashSet<UtilityPower>();
            UtilityWaters = new System.Collections.Generic.HashSet<UtilityWater>();
            Amenities = new System.Collections.Generic.HashSet<Amenitie>();
            Amperages = new System.Collections.Generic.HashSet<Amperage>();
            ArchitecturalStyles = new System.Collections.Generic.HashSet<ArchitecturalStyle>();
            BasementDevelopments = new System.Collections.Generic.HashSet<BasementDevelopment>();
            BasementFeatures = new System.Collections.Generic.HashSet<BasementFeature>();
            BasementTypes = new System.Collections.Generic.HashSet<BasementType>();
            Boards = new System.Collections.Generic.HashSet<Board>();
            BuildingTypes = new System.Collections.Generic.HashSet<BuildingType>();
            CeilingTypes = new System.Collections.Generic.HashSet<CeilingType>();
            ClearCeilingHeights = new System.Collections.Generic.HashSet<ClearCeilingHeight>();
            CommunicationTypes = new System.Collections.Generic.HashSet<CommunicationType>();
            CommunityFeatures = new System.Collections.Generic.HashSet<CommunityFeature>();
            ConstructionMaterials = new System.Collections.Generic.HashSet<ConstructionMaterial>();
            Crops = new System.Collections.Generic.HashSet<Crop>();
            DocumentTypes = new System.Collections.Generic.HashSet<DocumentType>();
            Easements = new System.Collections.Generic.HashSet<Easement>();
            EquipmentTypes = new System.Collections.Generic.HashSet<EquipmentType>();
            ExteriorFinishes = new System.Collections.Generic.HashSet<ExteriorFinish>();
            FarmTypes = new System.Collections.Generic.HashSet<FarmType>();
            FireplaceFuels = new System.Collections.Generic.HashSet<FireplaceFuel>();
            FireplaceTypes = new System.Collections.Generic.HashSet<FireplaceType>();
            FireProtections = new System.Collections.Generic.HashSet<FireProtection>();
            Fixtures = new System.Collections.Generic.HashSet<Fixture>();
            FoundationTypes = new System.Collections.Generic.HashSet<FoundationType>();
            HeatingFuels = new System.Collections.Generic.HashSet<HeatingFuel>();
            HeatingTypes = new System.Collections.Generic.HashSet<HeatingType>();
            IrrigationTypes = new System.Collections.Generic.HashSet<IrrigationType>();
        }
    }
}
using System;
using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class Unit : Entity, ISeoModel, IExternalModel, IBaseModel
    {
        public long Id
        {
            get; set;
        }

        public long BuildingId
        {
            get; set;
        }

        public string DdfUnitId
        {
            get; set;
        }

        public int? HalfBathTotal
        {
            get; set;
        }

        public int? BathroomTotal
        {
            get; set;
        }

        public int? BedroomsAboveGround
        {
            get; set;
        }

        public int? BedroomsBelowGround
        {
            get; set;
        }

        public int? BedroomsTotal
        {
            get; set;
        }

        public string CeilingHeight
        {
            get; set;
        }

        public string SizeInterior
        {
            get; set;
        }

        public string SizeInteriorFinished
        {
            get; set;
        }

        public string TotalFinishedArea
        {
            get; set;
        }

        public decimal? Lease
        {
            get; set;
        }

        public string LeasePerTime
        {
            get; set;
        }

        public string LeasePerUnit
        {
            get; set;
        }

        public string LeaseTermRemaining
        {
            get; set;
        }

        public int? LeaseTermRemainingFreq
        {
            get; set;
        }

        public decimal? MaintenanceFee
        {
            get; set;
        }

        public string MaintenanceFeePaymentUnit
        {
            get; set;
        }

        public int? ParkingSpaceTotal
        {
            get; set;
        }

        public string Plan
        {
            get; set;
        }

        public decimal? Price
        {
            get; set;
        }

        public string PricePerTime
        {
            get; set;
        }

        public string PricePerUnit
        {
            get; set;
        }

        public string PropertyType
        {
            get; set;
        }

        public string OwnershipType
        {
            get; set;
        }

        public string TransactionType
        {
            get; set;
        }

        public string PublicRemarks
        {
            get; set;
        }

        public string AdditionalInformationIndicator
        {
            get; set;
        }

        public string MoreInformationLink
        {
            get; set;
        }

        public string ListingId
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

        public string UnitUri
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

        public DateTime? RemovedDate
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<AmenitiesNearby> AmenitiesNearbies
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Appliance> Appliances
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Business> Businesses
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BusinessSubType> BusinessSubTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BusinessType> BusinessTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<CoolingType> CoolingTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Feature> Features
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FlooringType> FlooringTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<LiveStockType> LiveStockTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<LoadingType> LoadingTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<MaintenanceFeeType> MaintenanceFeeTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<PaymentUnit> PaymentUnits
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<RentalEquipmentType> RentalEquipmentTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<RightType> RightTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<StorageType> StorageTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<TransactionType> TransactionTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgent> UnitAgents
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitOpenHouse> UnitOpenHouses
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitParkingSpace> UnitParkingSpaces
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitPhoto> UnitPhotos
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitRoom> UnitRooms
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitUtilitiesAvailable> UnitUtilitiesAvailables
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ViewType> ViewTypes
        {
            get; set;
        }

        public virtual Building Building
        {
            get; set;
        }

        public Unit()
        {
            Businesses = new System.Collections.Generic.HashSet<Business>();
            UnitOpenHouses = new System.Collections.Generic.HashSet<UnitOpenHouse>();
            UnitParkingSpaces = new System.Collections.Generic.HashSet<UnitParkingSpace>();
            UnitPhotos = new System.Collections.Generic.HashSet<UnitPhoto>();
            UnitRooms = new System.Collections.Generic.HashSet<UnitRoom>();
            UnitUtilitiesAvailables = new System.Collections.Generic.HashSet<UnitUtilitiesAvailable>();
            BusinessSubTypes = new System.Collections.Generic.HashSet<BusinessSubType>();
            BusinessTypes = new System.Collections.Generic.HashSet<BusinessType>();
            AmenitiesNearbies = new System.Collections.Generic.HashSet<AmenitiesNearby>();
            Appliances = new System.Collections.Generic.HashSet<Appliance>();
            CoolingTypes = new System.Collections.Generic.HashSet<CoolingType>();
            Features = new System.Collections.Generic.HashSet<Feature>();
            FlooringTypes = new System.Collections.Generic.HashSet<FlooringType>();
            LiveStockTypes = new System.Collections.Generic.HashSet<LiveStockType>();
            LoadingTypes = new System.Collections.Generic.HashSet<LoadingType>();
            MaintenanceFeeTypes = new System.Collections.Generic.HashSet<MaintenanceFeeType>();
            PaymentUnits = new System.Collections.Generic.HashSet<PaymentUnit>();
            RentalEquipmentTypes = new System.Collections.Generic.HashSet<RentalEquipmentType>();
            RightTypes = new System.Collections.Generic.HashSet<RightType>();
            StorageTypes = new System.Collections.Generic.HashSet<StorageType>();
            TransactionTypes = new System.Collections.Generic.HashSet<TransactionType>();
            UnitAgents = new System.Collections.Generic.HashSet<UnitAgent>();
            ViewTypes = new System.Collections.Generic.HashSet<ViewType>();
        }
    }
}
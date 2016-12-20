namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            this.PropertyOpenHouse = new HashSet<PropertyOpenHouse>();
            this.PropertyParkingSpace = new HashSet<PropertyParkingSpace>();
            this.PropertyPhoto = new HashSet<PropertyPhoto>();
            this.PropertyUtilitiesAvailable = new HashSet<PropertyUtilitiesAvailable>();
            this.PropertyAgent = new HashSet<PropertyAgent>();
        }
    
        public long PropertyId { get; set; }
        public string DdfPropertyId { get; set; }
        public long PropertyAgentId { get; set; }
        public string StreetAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string CountryState { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AmmenitiesNearBy { get; set; }
        public string CommunicationType { get; set; }
        public string CommunityFeatures { get; set; }
        public string Crop { get; set; }
        public string DocumentType { get; set; }
        public string EquipmentType { get; set; }
        public string Easement { get; set; }
        public string FarmType { get; set; }
        public string Features { get; set; }
        public string IrrigationType { get; set; }
        public string Lease { get; set; }
        public string LeasePerTime { get; set; }
        public string LeasePerUnit { get; set; }
        public string LeaseTermRemaining { get; set; }
        public string LeaseTermRemainingFreq { get; set; }
        public string LeaseType { get; set; }
        public string LiveStockType { get; set; }
        public string LoadingType { get; set; }
        public string LocationDescription { get; set; }
        public string Machinery { get; set; }
        public string MaintenanceFee { get; set; }
        public string MaintenanceFeePaymentUnit { get; set; }
        public string MaintenanceFeeType { get; set; }
        public string ManagementCompany { get; set; }
        public string MunicipalId { get; set; }
        public string OwnershipType { get; set; }
        public string ParkingSpaceTotal { get; set; }
        public string Plan { get; set; }
        public string PoolType { get; set; }
        public string PoolFeatures { get; set; }
        public string Price { get; set; }
        public string PricePerTime { get; set; }
        public string PricePerUnit { get; set; }
        public string PropertyType { get; set; }
        public string PublicRemarks { get; set; }
        public string RentalEquipmentType { get; set; }
        public string RightType { get; set; }
        public string RoadType { get; set; }
        public string StorageType { get; set; }
        public string Structure { get; set; }
        public string SignType { get; set; }
        public string TransactionType { get; set; }
        public string TotalBuildings { get; set; }
        public string ViewType { get; set; }
        public string WaterFrontType { get; set; }
        public string WaterFrontName { get; set; }
        public string AdditionalInformationIndicator { get; set; }
        public string ZoningDescription { get; set; }
        public string ZoningType { get; set; }
        public string MoreInformationLink { get; set; }
        public string AnalyticsClick { get; set; }
        public string AnalyticsView { get; set; }
        public string Board { get; set; }
        public string ListingId { get; set; }

        public System.DateTime LastDdfUpdate { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        public virtual PropertyAlternateUrl PropertyAlternateUrl { get; set; }
        public virtual PropertyBuilding PropertyBuilding { get; set; }
        public virtual PropertyBusiness PropertyBusiness { get; set; }
        public virtual PropertyLand PropertyLand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyOpenHouse> PropertyOpenHouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyParkingSpace> PropertyParkingSpace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyPhoto> PropertyPhoto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyUtilitiesAvailable> PropertyUtilitiesAvailable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgent> PropertyAgent { get; set; }
    }
}

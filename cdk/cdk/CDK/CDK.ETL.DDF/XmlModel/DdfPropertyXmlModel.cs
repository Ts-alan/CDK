using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CDK.ETL.DDF.Property
{

    /// ------------------------------------------------------------------------------
    /// ---------------------------- ROOT --------------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    public partial class RETS
    {

        [XmlElementAttribute("COUNT")]
        public RETSCount COUNT { get; set; }

        [XmlElementAttribute("METADATA")]
        public RETSMetadata METADATA { get; set; }

        /// Namespace is needed here. If regenerate manually put the Namespace
        [XmlElementAttribute("RETS-RESPONSE", Namespace = "urn:CREA.Search.Property")]
        public RETSResponse RETSResponse { get; set; }

        [XmlAttributeAttribute()]
        public string ReplyCode { get; set; }

        [XmlAttributeAttribute()]

        public string ReplyText { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSCount
    {

        [XmlAttributeAttribute()]
        public int Records { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }

    }


    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponse
    {

        public RETSResponsePagination Pagination { get; set; }

        [XmlElementAttribute("PropertyDetails")]
        public RETSResponsePropertyDetails[] PropertyDetails { get; set; }

        [XmlElementAttribute("Property")]
        public RETSResponseProperty[] Property { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- RESPONSE-----------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePagination
    {


        public string TotalRecords { get; set; }

        public string Limit { get; set; }

        public string Offset { get; set; }

        public string TotalPages { get; set; }

        public string RecordsReturned { get; set; }
    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- PROPERTY DETAILS ---------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetails
    {

        public RETSResponsePropertyDetailsBusiness Business { get; set; }

        public RETSResponsePropertyDetailsAddress Address { get; set; }

        [XmlElementAttribute("AgentDetails")]
        public RETSResponsePropertyDetailsAgentDetails[] AgentDetails { get; set; }

        public RETSResponsePropertyDetailsBuilding Building { get; set; }

        public RETSResponsePropertyDetailsLand Land { get; set; }

        public RETSResponsePropertyDetailsParkingSpaces ParkingSpaces { get; set; }
        public RETSRETSRESPONSEPropertyDetailsPhoto Photo { get; set; }

        public RETSResponsePropertyDetailsUtilitiesAvailable UtilitiesAvailable { get; set; }

        public RETSResponsePropertyDetailsAlternateURL AlternateURL { get; set; }

        public RETSResponsePropertyDetailsOpenHouse OpenHouse { get; set; }

        [XmlAttributeAttribute()]
        public string ID { get; set; }

        [XmlElementAttribute("ListingID")]
        public string ListingID { get; set; }

        [XmlAttributeAttribute()]
        public string LastUpdated { get; set; }
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
        public string MunicipalID { get; set; }
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
        public string MunicipalId { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- ADDRESS -----------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsBusiness
    {

        public string BusinessType { get; set; }

        public string BusinessSubType { get; set; }

        public string EstablishedDate { get; set; }

        public string Franchise { get; set; }

        public string Name { get; set; }

        public string OperatingSince { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- ALTERNATE URL -----------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAlternateURL
    {

        public string BrochureLink { get; set; }

        public string MapLink { get; set; }

        public string PhotoLink { get; set; }

        public string SoundLink { get; set; }

        public string VideoLink { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- OPEN HOUSE---------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsOpenHouse
    {

        public RETSResponsePropertyDetailsOpenHouseEvent[] Event { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- EVENT---------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsOpenHouseEvent
    {

        public string StartDateTime { get; set; }

        public string EndDateTime { get; set; }

        public string Comments { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- UTILITY AVAIALABLE-------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsUtilitiesAvailable
    {
        public RETSResponsePropertyDetailsUtilitiesAvailableUtility[] Utility { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- EVENT---------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsUtilitiesAvailableUtility
    {

        public string Type { get; set; }

        public string Description { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponseProperty
    {

        [XmlAttributeAttribute()]
        public string ID { get; set; }


        [XmlAttributeAttribute()]
        public string LastUpdated { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- ADDRESS -----------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAddress
    {

        public string StreetAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string Addressline2 { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string StreetSuffix { get; set; }

        public string UnitNumber { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Neighbourhood { get; set; }

        public string CommunityName { get; set; }

    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- AGENT DETAIL-------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetails
    {

        [XmlAttributeAttribute()]
        public string ID { get; set; }

        public string Name { get; set; }

        public int LastUpdated { get; set; }
        public string Position { get; set; }

        public string EducationCredentials { get; set; }
        public string PhotoLastUpdated { get; set; }

        public RETSResponsePropertyDetailsAddress Address { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsSpecialtiy Specialties { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsDesignation Designations { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsLanguage Languages { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsTradingArea TradingAreas { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsPhone Phones { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsWebsites Websites { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsOffice Office { get; set; }

    }
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsSpecialtiy
    {
        [XmlElementAttribute("Specialty")]
        public string[] Specialty { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsDesignation
    {
        [XmlElementAttribute("Designation")]
        public string[] Designation;
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsLanguage
    {
        [XmlElementAttribute("Language")]
        public string[] Language { get; set; }
    }
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsTradingArea
    {
        [XmlElementAttribute("TradingArea")]
        public string[] TradingArea { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsPhone
    {
        [XmlElementAttribute("Phone")]
        public RETSResponsePropertyDetailsAgentDetailsPhonePhone[] Phone { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsPhonePhone
    {

        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string PhoneType { get; set; }

        [XmlTextAttribute(DataType = "anyURI")]
        public string Value { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsWebsites
    {
        [XmlElementAttribute("Website")]
        public RETSResponsePropertyDetailsAgentDetailsWebsitesWebsite[] Website { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsWebsitesWebsite
    {


        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string WebsiteType { get; set; }

        [XmlTextAttribute(DataType = "anyURI")]
        public string Value { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsOffice
    {
        public string Name { get; set; }

        [XmlAttributeAttribute()]
        public string ID { get; set; }
        public string LastUpdated { get; set; }
        public string LogoLastUpdated { get; set; }
        public string OrganizationType { get; set; }
        public string Designation { get; set; }
        public string Franchisor { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsOfficeAddress Address { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsOfficePhone Phones { get; set; }

        public RETSResponsePropertyDetailsAgentDetailsOfficeWebsites Websites { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsOfficeAddress
    {
        public string StreetAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string Addressline2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsOfficePhone
    {
        [XmlElementAttribute("Phone")]
        public RETSResponsePropertyDetailsAgentDetailsOfficePhonePhone[] Phone { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsOfficePhonePhone
    {

        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string PhoneType { get; set; }

        [XmlTextAttribute(DataType = "anyURI")]
        public string Value { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsOfficeWebsites
    {
        [XmlElementAttribute("Website")]
        public RETSResponsePropertyDetailsAgentDetailsOfficeWebsitesWebsite[] Website { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsAgentDetailsOfficeWebsitesWebsite
    {

        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string WebsiteType { get; set; }

        [XmlTextAttribute(DataType = "anyURI")]
        public string Value { get; set; }
    }

    /// ------------------------------------------------------------------------------
    /// ---------------------------- BUILDING ----------------------------------------
    /// ------------------------------------------------------------------------------
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsBuilding
    {

        [XmlElementAttribute()]
        public string BathroomTotal { get; set; }
        [XmlElementAttribute()]
        public string BedroomsAboveGround { get; set; }
        [XmlElementAttribute()]
        public string BedroomsBelowGround { get; set; }
        [XmlElementAttribute()]
        public string BedroomsTotal { get; set; }
        [XmlElementAttribute()]
        public string Age { get; set; }
        [XmlElementAttribute()]
        public string Amenities { get; set; }
        [XmlElementAttribute()]
        public string Amperage { get; set; }
        [XmlElementAttribute()]
        public string Anchor { get; set; }
        [XmlElementAttribute()]
        public string Appliances { get; set; }
        [XmlElementAttribute()]
        public string ArchitecturalStyle { get; set; }
        [XmlElementAttribute()]
        public string BasementDevelopment { get; set; }
        [XmlElementAttribute()]
        public string BasementFeatures { get; set; }
        [XmlElementAttribute()]
        public string BasementType { get; set; }
        [XmlElementAttribute()]
        public string BomaRating { get; set; }
        [XmlElementAttribute()]
        public string CeilingHeight { get; set; }
        [XmlElementAttribute()]
        public string CeilingType { get; set; }
        [XmlElementAttribute()]
        public string ClearCeilingHeight { get; set; }
        [XmlElementAttribute()]
        public string ConstructedDate { get; set; }
        [XmlElementAttribute()]
        public string ConstructionMaterial { get; set; }
        [XmlElementAttribute()]
        public string ConstructionStatus { get; set; }
        [XmlElementAttribute()]
        public string ConstructionStyleAttachment { get; set; }
        [XmlElementAttribute()]
        public string ConstructionStyleOther { get; set; }
        [XmlElementAttribute()]
        public string ConstructionStyleSplitLevel { get; set; }
        [XmlElementAttribute()]
        public string CoolingType { get; set; }
        [XmlElementAttribute()]
        public string EnerguideRating { get; set; }
        [XmlElementAttribute()]
        public string ExteriorFinish { get; set; }
        [XmlElementAttribute()]
        public string FireProtection { get; set; }
        [XmlElementAttribute()]
        public string FireplaceFuel { get; set; }
        [XmlElementAttribute()]
        public string FireplacePresent { get; set; }
        [XmlElementAttribute()]
        public string FireplaceTotal { get; set; }
        [XmlElementAttribute()]
        public string FireplaceType { get; set; }
        [XmlElementAttribute()]
        public string Fixture { get; set; }
        [XmlElementAttribute()]
        public string FlooringType { get; set; }
        [XmlElementAttribute()]
        public string FoundationType { get; set; }
        [XmlElementAttribute()]
        public string HalfBathTotal { get; set; }
        [XmlElementAttribute()]
        public string HeatingFuel { get; set; }
        [XmlElementAttribute()]
        public string HeatingType { get; set; }
        [XmlElementAttribute()]
        public string LeedsCategory { get; set; }
        [XmlElementAttribute()]
        public string LeedsRating { get; set; }
        [XmlElementAttribute()]
        public string RenovatedDate { get; set; }
        [XmlElementAttribute()]
        public string RoofMaterial { get; set; }
        [XmlElementAttribute()]
        public string RoofStyle { get; set; }
        [XmlElementAttribute()]
        public string StoriesTotal { get; set; }
        [XmlElementAttribute()]
        public string SizeExterior { get; set; }
        [XmlElementAttribute()]
        public string SizeInterior { get; set; }
        [XmlElementAttribute()]
        public string SizeInteriorFinished { get; set; }
        [XmlElementAttribute()]
        public string StoreFront { get; set; }
        [XmlElementAttribute()]
        public string TotalFinishedArea { get; set; }
        [XmlElementAttribute()]
        public string Type { get; set; }
        [XmlElementAttribute()]
        public string Uffi { get; set; }
        [XmlElementAttribute()]
        public string UnitType { get; set; }
        [XmlElementAttribute()]
        public string UtilityPower { get; set; }
        [XmlElementAttribute()]
        public string UtilityWater { get; set; }
        [XmlElementAttribute()]
        public string VacancyRate { get; set; }

        [XmlElementAttribute()]
        public RETSResponsePropertyDetailsBuildingRooms Rooms { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsBuildingRooms
    {

        [XmlElementAttribute("Room")]
        public RETSResponsePropertyDetailsBuildingRoomsRoom[] Room { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]

    public partial class RETSResponsePropertyDetailsBuildingRoomsRoom
    {
        public string Type { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Level { get; set; }
        public string Dimension { get; set; }
        public string Description { get; set; }
    }


    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsLand
    {

        public string SizeTotal { get; set; }
        public string SizeTotalText { get; set; }
        public string SizeFrontage { get; set; }
        public string AccessType { get; set; }
        public string Acreage { get; set; }
        public string Amenities { get; set; }
        public string ClearedTotal { get; set; }
        public string CurrentUse { get; set; }
        public string Divisible { get; set; }
        public string FenceTotal { get; set; }
        public string FenceType { get; set; }
        public string FrontsOn { get; set; }
        public string LandDisposition { get; set; }
        public string LandscapeFeatures { get; set; }
        public string PastureTotal { get; set; }
        public string Sewer { get; set; }
        public string SizeDepth { get; set; }
        public string SizeIrregular { get; set; }
        public string SoilEvaluation { get; set; }
        public string SoilType { get; set; }
        public string SurfaceWater { get; set; }
        public string TiledTotal { get; set; }
        public string TopographyType { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsParkingSpaces
    {
        [XmlElementAttribute("Parking")]
        public RETSResponsePropertyDetailsParkingSpacesParking[] Parking { get; set; }
    }
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsParkingSpacesParking
    {

        public string Name { get; set; }

        public string Spaces { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSRETSRESPONSEPropertyDetailsPhoto
    {

        [XmlElementAttribute("PropertyPhoto")]
        public RETSResponsePropertyDetailsPhotoPropertyPhoto[] PropertyPhoto { get; set; }
    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Property")]
    public partial class RETSResponsePropertyDetailsPhotoPropertyPhoto
    {

        public string SequenceId { get; set; }

        public string LastUpdated { get; set; }

    }

    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class RETSMetadata
    {
        /// 
        [XmlElementAttribute("METADATA-LOOKUP_TYPE")]
        public RETSMetaDataMetadataLookupType MetaDataLookupType { get; set; }

    }
    /// 
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class RETSMetaDataMetadataLookupType
    {

        /// 
        [XmlElementAttribute("LookupType")]
        public RETSMetadataLookupType[] LookupType { get; set; }
        /// 
        [XmlAttributeAttribute()]
        public string Resource { get; set; }
        /// 
        [XmlAttributeAttribute()]
        public string Lookup { get; set; }
        /// 
        [XmlAttributeAttribute()]
        public string Date { get; set; }
        /// 
        [XmlAttributeAttribute()]
        public string Version { get; set; }
    }
    /// 
    [GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class RETSMetadataLookupType
    {
        /// 
        public string MetadataEntryID { get; set; }
        /// 
        public string Value { get; set; }
        /// 
        public string LongValue { get; set; }
        /// 
        public string ShortValue { get; set; }

    }
}
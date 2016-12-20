namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ddf.ABoard",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UnitAgent",
                c => new
                {
                    UnitAgentId = c.Long(nullable: false),
                    UnitAgentOfficeId = c.Long(),
                    DdfAgentId = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    Position = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                    EducationCredentials = c.String(maxLength: 255, unicode: false),
                    PhotoLastUpdated = c.DateTime(),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    AddressLine1 = c.String(maxLength: 255, unicode: false),
                    Addressline2 = c.String(maxLength: 255, unicode: false),
                    StreetNumber = c.String(maxLength: 255, unicode: false),
                    StreetName = c.String(maxLength: 255, unicode: false),
                    StreetSuffix = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    Province = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                    LogoUri = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentId);

            CreateTable(
                "ddf.ALanguage",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.IndividualDesignation",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Specialtie",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UnitAgentContact",
                c => new
                {
                    UnitAgentContactId = c.Long(nullable: false, identity: true),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    AgentType = c.String(maxLength: 255, unicode: false),
                    TextValue = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                    UnitAgentId = c.Long(),
                })
                .PrimaryKey(t => t.UnitAgentContactId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.UnitAgentDesignation",
                c => new
                {
                    UnitAgentDesignationId = c.Long(nullable: false, identity: true),
                    UnitAgentId = c.Long(nullable: false),
                    Designation = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentDesignationId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.UnitAgentLanguage",
                c => new
                {
                    UnitAgentLanguageId = c.Long(nullable: false, identity: true),
                    UnitAgentId = c.Long(nullable: false),
                    Language = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentLanguageId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.UnitAgentOffice",
                c => new
                {
                    UnitAgentOfficeId = c.Long(nullable: false),
                    UnitAgentId = c.Long(),
                    DdfUnitAgentOfficeId = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    AddressLine1 = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                    Country = c.String(maxLength: 255, unicode: false),
                    Franchisor = c.String(maxLength: 255, unicode: false),
                    LogoLastUpdated = c.String(maxLength: 255, unicode: false),
                    LogoUri = c.String(maxLength: 255, unicode: false),
                    OrganizationType = c.String(maxLength: 255, unicode: false),
                    Designation = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.UnitAgentOfficeId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.Franchisor",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.OrganizationDesignation",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.OrganizationType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UnitAgentOfficePhone",
                c => new
                {
                    UnitAgentOfficePhoneId = c.Long(nullable: false, identity: true),
                    UnitAgentOfficeId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    PhoneType = c.String(maxLength: 255, unicode: false),
                    PhoneNumber = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentOfficePhoneId)
                .ForeignKey("ddf.UnitAgentOffice", t => t.UnitAgentOfficeId, cascadeDelete: true)
                .Index(t => t.UnitAgentOfficeId);

            CreateTable(
                "ddf.UnitAgentOfficeWebsite",
                c => new
                {
                    UnitAgentOfficeWebsiteId = c.Long(nullable: false, identity: true),
                    UnitAgentOfficeId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    WebsiteType = c.String(maxLength: 255, unicode: false),
                    WebsiteUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentOfficeWebsiteId)
                .ForeignKey("ddf.UnitAgentOffice", t => t.UnitAgentOfficeId, cascadeDelete: true)
                .Index(t => t.UnitAgentOfficeId);

            CreateTable(
                "ddf.UnitAgentPhone",
                c => new
                {
                    UnitAgentPhoneId = c.Long(nullable: false, identity: true),
                    UnitAgentId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    PhoneType = c.String(maxLength: 255, unicode: false),
                    PhoneNumber = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentPhoneId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.UnitAgentSpeciality",
                c => new
                {
                    UnitAgentSpecialityId = c.Long(nullable: false, identity: true),
                    UnitAgentId = c.Long(nullable: false),
                    Specialtie = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentSpecialityId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.UnitAgentTradingArea",
                c => new
                {
                    UnitAgentTradingAreaId = c.Long(nullable: false, identity: true),
                    UnitAgentId = c.Long(nullable: false),
                    TradingArea = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentTradingAreaId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.UnitAgentWebsite",
                c => new
                {
                    UnitAgentWebsiteId = c.Long(nullable: false, identity: true),
                    UnitAgentId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    WebsiteType = c.String(maxLength: 255, unicode: false),
                    WebsiteUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitAgentWebsiteId)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.Unit",
                c => new
                {
                    UnitId = c.Long(nullable: false, identity: true),
                    BuildingId = c.Long(nullable: false),
                    DdfUnitId = c.String(maxLength: 255, unicode: false),
                    HalfBathTotal = c.String(maxLength: 255, unicode: false),
                    BathroomTotal = c.String(maxLength: 255, unicode: false),
                    BedroomsAboveGround = c.String(maxLength: 255, unicode: false),
                    BedroomsBelowGround = c.String(maxLength: 255, unicode: false),
                    BedroomsTotal = c.String(maxLength: 255, unicode: false),
                    CeilingHeight = c.String(maxLength: 255, unicode: false),
                    SizeInterior = c.String(maxLength: 255, unicode: false),
                    SizeInteriorFinished = c.String(maxLength: 255, unicode: false),
                    TotalFinishedArea = c.String(maxLength: 255, unicode: false),
                    Lease = c.String(maxLength: 255, unicode: false),
                    LeasePerTime = c.String(maxLength: 255, unicode: false),
                    LeasePerUnit = c.String(maxLength: 255, unicode: false),
                    LeaseTermRemaining = c.String(maxLength: 255, unicode: false),
                    LeaseTermRemainingFreq = c.String(maxLength: 255, unicode: false),
                    MaintenanceFee = c.String(maxLength: 255, unicode: false),
                    MaintenanceFeePaymentUnit = c.String(maxLength: 255, unicode: false),
                    ParkingSpaceTotal = c.String(maxLength: 255, unicode: false),
                    Plan = c.String(maxLength: 255, unicode: false),
                    Price = c.String(maxLength: 255, unicode: false),
                    PricePerTime = c.String(maxLength: 255, unicode: false),
                    PricePerUnit = c.String(maxLength: 255, unicode: false),
                    PropertyType = c.String(maxLength: 255, unicode: false),
                    PublicRemarks = c.String(unicode: false),
                    AdditionalInformationIndicator = c.String(maxLength: 255, unicode: false),
                    MoreInformationLink = c.String(maxLength: 255, unicode: false),
                    LastDdfUpdate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                    UnitUri = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.AmenitiesNearby",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.BuildingLand",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    SizeTotal = c.String(maxLength: 255, unicode: false),
                    SizeTotalText = c.String(maxLength: 255, unicode: false),
                    SizeFrontage = c.String(maxLength: 255, unicode: false),
                    AccessType = c.String(maxLength: 255, unicode: false),
                    Acreage = c.String(maxLength: 255, unicode: false),
                    Amenities = c.String(maxLength: 255, unicode: false),
                    ClearedTotal = c.String(maxLength: 255, unicode: false),
                    CurrentUse = c.String(maxLength: 255, unicode: false),
                    Divisible = c.String(maxLength: 255, unicode: false),
                    FenceTotal = c.String(maxLength: 255, unicode: false),
                    FenceType = c.String(maxLength: 255, unicode: false),
                    FrontsOn = c.String(maxLength: 255, unicode: false),
                    LandDisposition = c.String(maxLength: 255, unicode: false),
                    LandscapeFeatures = c.String(maxLength: 255, unicode: false),
                    PastureTotal = c.String(maxLength: 255, unicode: false),
                    Sewer = c.String(maxLength: 255, unicode: false),
                    SizeDepth = c.String(maxLength: 255, unicode: false),
                    SizeIrregular = c.String(maxLength: 255, unicode: false),
                    SoilEvaluation = c.String(maxLength: 255, unicode: false),
                    SoilType = c.String(maxLength: 255, unicode: false),
                    SurfaceWater = c.String(maxLength: 255, unicode: false),
                    TiledTotal = c.String(maxLength: 255, unicode: false),
                    TopographyType = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(),
                })
                .PrimaryKey(t => t.BuildingId)
                .ForeignKey("ddf.Building", t => t.BuildingId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.AccessType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Building",
                c => new
                {
                    BuildingId = c.Long(nullable: false, identity: true),
                    BuildingAddressId = c.Long(),
                    BuildingUri = c.String(maxLength: 255, unicode: false),
                    Age = c.String(maxLength: 255, unicode: false),
                    Board = c.String(maxLength: 255, unicode: false),
                    Anchor = c.String(maxLength: 255, unicode: false),
                    BomaRating = c.String(maxLength: 255, unicode: false),
                    ConstructedDate = c.String(maxLength: 255, unicode: false),
                    EnerguideRating = c.String(maxLength: 255, unicode: false),
                    FireplacePresent = c.String(maxLength: 255, unicode: false),
                    FireplaceTotal = c.String(maxLength: 255, unicode: false),
                    LeedsCategory = c.String(maxLength: 255, unicode: false),
                    LeedsRating = c.String(maxLength: 255, unicode: false),
                    RenovatedDate = c.String(maxLength: 255, unicode: false),
                    StoriesTotal = c.String(maxLength: 255, unicode: false),
                    SizeExterior = c.String(maxLength: 255, unicode: false),
                    ManagementCompany = c.String(maxLength: 255, unicode: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Structure = c.String(maxLength: 255, unicode: false),
                    MunicipalId = c.String(maxLength: 255, unicode: false),
                    Uffi = c.String(maxLength: 255, unicode: false),
                    UnitType = c.String(maxLength: 255, unicode: false),
                    VacancyRate = c.String(maxLength: 255, unicode: false),
                    ZoningType = c.String(maxLength: 255, unicode: false),
                    ZoningDescription = c.String(maxLength: 255, unicode: false),
                    TotalBuildings = c.String(maxLength: 255, unicode: false),
                    WaterFrontName = c.String(maxLength: 255, unicode: false),
                    LocationDescription = c.String(maxLength: 255, unicode: false),
                    LastDdfUpdate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.BuildingId)
                .ForeignKey("ddf.BuildingAddress", t => t.BuildingAddressId)
                .Index(t => t.BuildingAddressId);

            CreateTable(
                "ddf.Amenitie",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Amperage",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ArchitecturalStyle",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.BasementDevelopment",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.BasementFeature",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.BasementType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Board",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.BuildingAddress",
                c => new
                {
                    BuildingAddressId = c.Long(nullable: false, identity: true),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    CountryState = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                    Country = c.String(maxLength: 255, unicode: false),
                    Lon = c.String(maxLength: 255, unicode: false),
                    Lat = c.String(maxLength: 255, unicode: false),
                    AddressType = c.String(maxLength: 255, unicode: false),
                    AdditionalStreetInfo = c.String(maxLength: 255, unicode: false),
                    DdfCommunityName = c.String(maxLength: 255, unicode: false),
                    Neighbourhood = c.String(maxLength: 255, unicode: false),
                    Subdivision = c.String(maxLength: 255, unicode: false),
                    PositionGeo = c.Geography(),
                    NeighborhoodAreaId = c.Long(),
                })
                .PrimaryKey(t => t.BuildingAddressId)
                .ForeignKey("cdk.NeighborhoodArea", t => t.NeighborhoodAreaId)
                .Index(t => t.NeighborhoodAreaId);

            CreateTable(
                "cdk.NeighborhoodArea",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MetroAreaId = c.Long(),
                    NeighborhoodAreaExtId = c.Long(),
                    NeighborhoodAreaExtVersion = c.String(maxLength: 255, unicode: false),
                    ParentId = c.Long(),
                    Name = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Description = c.String(unicode: false),
                    CenterPointGeo = c.Geography(),
                    CenterPointLat = c.String(maxLength: 255, unicode: false),
                    CenterPointLon = c.String(maxLength: 255, unicode: false),
                    CoordinatesGeo = c.Geography(),
                    CoordinatesAsText = c.String(unicode: false),
                    NeighborhoodAreaUri = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.MetroArea", t => t.MetroAreaId)
                .Index(t => t.MetroAreaId);

            CreateTable(
                "cdk.DevelopmentAddress",
                c => new
                {
                    Id = c.Long(nullable: false),
                    NeighborhoodAreaId = c.Long(),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    CountryState = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                    Country = c.String(maxLength: 255, unicode: false),
                    Lon = c.String(maxLength: 255, unicode: false),
                    Lat = c.String(maxLength: 255, unicode: false),
                    PositionGeo = c.Geography(),
                    StreetType = c.String(maxLength: 255, unicode: false),
                    AdditionalStreetInfo = c.String(maxLength: 255, unicode: false),
                    CommunityName = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.Development", t => t.Id, cascadeDelete: true)
                .ForeignKey("cdk.NeighborhoodArea", t => t.NeighborhoodAreaId)
                .Index(t => t.Id)
                .Index(t => t.NeighborhoodAreaId);

            CreateTable(
                "cdk.Development",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    DeveloperId = c.Long(nullable: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    PrimaryContactName = c.String(maxLength: 255, unicode: false),
                    PrimaryContactEmail = c.String(maxLength: 255, unicode: false),
                    PrimaryContactPhone = c.String(maxLength: 255, unicode: false),
                    SecondaryContactName = c.String(maxLength: 255, unicode: false),
                    SecondaryContactEmail = c.String(maxLength: 255, unicode: false),
                    SecondaryContactPhone = c.String(maxLength: 255, unicode: false),
                    ProjectWebsiteUrl = c.String(maxLength: 255, unicode: false),
                    ProjectFacebookUrl = c.String(maxLength: 255, unicode: false),
                    ProjectTwiterUrl = c.String(maxLength: 255, unicode: false),
                    ProjectGooglePlusUrl = c.String(maxLength: 255, unicode: false),
                    SalesCenterPhoneNumber = c.String(maxLength: 255, unicode: false),
                    SalesCenterAddress = c.String(maxLength: 255, unicode: false),
                    SalesCenterPhone = c.String(maxLength: 255, unicode: false),
                    SalesCenterOpenHours = c.String(unicode: false),
                    ConstructuedYear = c.String(maxLength: 4, unicode: false),
                    ForSale = c.Boolean(),
                    ForRent = c.Boolean(),
                    BuildingType = c.String(maxLength: 255, unicode: false),
                    Community = c.String(maxLength: 255, unicode: false),
                    PriceAveragePerSqrFeet = c.Decimal(precision: 10, scale: 2),
                    TotalNumberOfUnits = c.Int(),
                    TotalNumberOfStories = c.Int(),
                    SalesCompany = c.String(maxLength: 255, unicode: false),
                    MarketingCompany = c.String(maxLength: 255, unicode: false),
                    Architects = c.String(maxLength: 255, unicode: false),
                    InteriorDesigner = c.String(maxLength: 255, unicode: false),
                    ProjectSummary = c.String(unicode: false),
                    ShortProjectSummary = c.String(unicode: false),
                    ProjectAmenities = c.String(maxLength: 255, unicode: false),
                    CurrentIncentives = c.String(maxLength: 255, unicode: false),
                    LogoUri = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.Developer", t => t.DeveloperId, cascadeDelete: true)
                .Index(t => t.DeveloperId);

            CreateTable(
                "cdk.Developer",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(maxLength: 255, unicode: false),
                    PrimaryContactName = c.String(maxLength: 255, unicode: false),
                    PrimaryContactEmail = c.String(maxLength: 255, unicode: false),
                    SecondaryContactName = c.String(maxLength: 255, unicode: false),
                    SecondaryContactEmail = c.String(maxLength: 255, unicode: false),
                    DeveloperAddress = c.String(maxLength: 255, unicode: false),
                    Description = c.String(unicode: false),
                    ShortDescription = c.String(unicode: false),
                    LogoUri = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "cdk.DevelopmentFloorPlan",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    DevelopmentId = c.Long(nullable: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Beds = c.String(maxLength: 255, unicode: false),
                    Baths = c.String(maxLength: 255, unicode: false),
                    PropertyTaxe = c.String(maxLength: 255, unicode: false),
                    InteriorSize = c.String(maxLength: 255, unicode: false),
                    OwnershipType = c.String(maxLength: 255, unicode: false),
                    CondoMonthlyFees = c.Decimal(precision: 10, scale: 2),
                    BalconeySize = c.String(maxLength: 255, unicode: false),
                    PhotoName = c.String(maxLength: 255, unicode: false),
                    PhotoType = c.String(maxLength: 255, unicode: false),
                    PhotoUri = c.String(maxLength: 255, unicode: false),
                    SequenceNumber = c.String(maxLength: 255, unicode: false),
                    PropertyTaxePeriod = c.String(maxLength: 255, unicode: false),
                    CondoFeesPeriod = c.String(maxLength: 255, unicode: false),
                    InteriorSizeType = c.String(maxLength: 255, unicode: false),
                    BalconeySizeType = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.Development", t => t.DevelopmentId, cascadeDelete: true)
                .Index(t => t.DevelopmentId);

            CreateTable(
                "cdk.DevelopmentPhoto",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    DevelopmentId = c.Long(nullable: false),
                    PhotoName = c.String(maxLength: 255, unicode: false),
                    PhotoType = c.String(maxLength: 255, unicode: false),
                    PhotoUri = c.String(maxLength: 255, unicode: false),
                    SequenceNumber = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.Development", t => t.DevelopmentId, cascadeDelete: true)
                .Index(t => t.DevelopmentId);

            CreateTable(
                "cdk.DevelopmentVideo",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    DevelopmentId = c.Long(nullable: false),
                    VideoName = c.String(maxLength: 255, unicode: false),
                    VideoType = c.String(maxLength: 255, unicode: false),
                    VideoUri = c.String(maxLength: 255, unicode: false),
                    SequenceNumber = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.Development", t => t.DevelopmentId, cascadeDelete: true)
                .Index(t => t.DevelopmentId);

            CreateTable(
                "cdk.MetroArea",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    MetroAreaExtId = c.Long(),
                    MetroAreaExtVersion = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    State = c.String(maxLength: 255, unicode: false),
                    Country = c.String(maxLength: 255, unicode: false),
                    Description = c.String(unicode: false),
                    CenterPointGeo = c.Geography(),
                    CenterPointLat = c.String(maxLength: 255, unicode: false),
                    CenterPointLon = c.String(maxLength: 255, unicode: false),
                    CoordinatesGeo = c.Geography(),
                    CoordinatesAsText = c.String(unicode: false),
                    MetroAreaUri = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "cdk.NeighborhoodGuide",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    NeighborhoodAreaId = c.Long(),
                    TagLine = c.String(maxLength: 255, unicode: false),
                    WhatToExpect = c.String(unicode: false),
                    Demographics = c.String(unicode: false),
                    Lifestyle = c.String(unicode: false),
                    WhatYoullLove = c.String(unicode: false),
                    Source = c.String(unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.NeighborhoodArea", t => t.NeighborhoodAreaId)
                .Index(t => t.NeighborhoodAreaId);

            CreateTable(
                "cdk.NeighborhoodGuidePhoto",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    NeighborhoodGuideId = c.Long(nullable: false),
                    PhotoSmallUri = c.String(maxLength: 255, unicode: false),
                    PhotoLargeUri = c.String(maxLength: 255, unicode: false),
                    Description = c.String(unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.NeighborhoodGuide", t => t.NeighborhoodGuideId, cascadeDelete: true)
                .Index(t => t.NeighborhoodGuideId);

            CreateTable(
                "cdk.NeighborhoodGuideVideo",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    NeighborhoodGuideId = c.Long(nullable: false),
                    VideoUri = c.String(maxLength: 255, unicode: false),
                    Description = c.String(unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("cdk.NeighborhoodGuide", t => t.NeighborhoodGuideId, cascadeDelete: true)
                .Index(t => t.NeighborhoodGuideId);

            CreateTable(
                "ddf.BuildingType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.CeilingType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ClearCeilingHeight",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.CommunicationType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.CommunityFeature",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ConstructionMaterial",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Crop",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.DocumentType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Easement",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.EquipmentType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ExteriorFinish",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FarmType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FireplaceFuel",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FireplaceType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FireProtection",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Fixture",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FoundationType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.HeatingFuel",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.HeatingType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.IrrigationType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Machinery",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.MeasureUnit",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.PoolFeature",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.PoolType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.RoadType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.RoofMaterial",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.RoofStyle",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.SignType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.StoreFront",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.StructureType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UffiCode",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UtilityPower",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UtilityWater",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.CurrentUse",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FenceType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.LandDispositionType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.LandscapeFeature",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Sewer",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.SoilType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.SurfaceWater",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.TopographyType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Appliance",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Business",
                c => new
                {
                    UnitId = c.Long(nullable: false),
                    BusinessType = c.String(maxLength: 255, unicode: false),
                    BusinessSubType = c.String(maxLength: 255, unicode: false),
                    EstablishedDate = c.String(maxLength: 255, unicode: false),
                    Franchise = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    OperatingSince = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("ddf.Unit", t => t.UnitId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.BusinessSubType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.BusinessType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.CoolingType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.Feature",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FlooringType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.LiveStockType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.LoadingType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.MaintenanceFeeType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.PaymentUnit",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.RentalEquipmentType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.RightType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.StorageType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.TransactionType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UnitOpenHouse",
                c => new
                {
                    UnitOpenHouseId = c.Long(nullable: false, identity: true),
                    UnitId = c.Long(nullable: false),
                    StartDateTime = c.String(maxLength: 255, unicode: false),
                    EndDateTime = c.String(maxLength: 255, unicode: false),
                    Comments = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitOpenHouseId)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitParkingSpace",
                c => new
                {
                    UnitParkingSpaceId = c.Long(nullable: false, identity: true),
                    UnitId = c.Long(nullable: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    Spaces = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitParkingSpaceId)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitPhoto",
                c => new
                {
                    UnitPhotoId = c.Long(nullable: false, identity: true),
                    UnitId = c.Long(nullable: false),
                    DdfSequenceId = c.String(maxLength: 255, unicode: false),
                    DdfPropertyId = c.String(maxLength: 255, unicode: false),
                    FolderPath = c.String(maxLength: 255, unicode: false),
                    PhotoType = c.String(maxLength: 255, unicode: false),
                    PhotoThumbnailUri = c.String(maxLength: 255, unicode: false),
                    PhotoSmallUri = c.String(maxLength: 255, unicode: false),
                    PhotoLargeUri = c.String(maxLength: 255, unicode: false),
                    LastDdfUpdate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.UnitPhotoId)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitRoom",
                c => new
                {
                    UnitRoomId = c.Long(nullable: false, identity: true),
                    UnitId = c.Long(nullable: false),
                    TypeId = c.Long(),
                    Width = c.String(maxLength: 255, unicode: false),
                    Length = c.String(maxLength: 255, unicode: false),
                    LevelId = c.Long(),
                    Dimension = c.String(maxLength: 255, unicode: false),
                    Description = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.UnitRoomId)
                .ForeignKey("ddf.RoomLevel", t => t.LevelId)
                .ForeignKey("ddf.RoomType", t => t.TypeId)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId)
                .Index(t => t.TypeId)
                .Index(t => t.LevelId);

            CreateTable(
                "ddf.RoomLevel",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.RoomType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UnitUtilitiesAvailable",
                c => new
                {
                    UnitUtilitiesAvailableId = c.Long(nullable: false, identity: true),
                    UnitId = c.Long(nullable: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Description = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.UnitUtilitiesAvailableId)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.ViewType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddfraw.AuditDdfRequest",
                c => new
                {
                    RequestId = c.Long(nullable: false, identity: true),
                    Status = c.String(maxLength: 255, unicode: false),
                    Xml = c.String(unicode: false),
                    DdfLastUpdate = c.DateTime(),
                })
                .PrimaryKey(t => t.RequestId);

            CreateTable(
                "ddf.ConstructionStatu",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ConstructionStyleAttachment",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ConstructionStyleOther",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ConstructionStyleSplitLevel",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "cdk.DevelopmentAmenities",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(maxLength: 255, unicode: false),
                    Description = c.String(unicode: false),
                    IconUri = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.FrontsOn",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.LeaseType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.OwnershipType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ParkingType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddfraw.Property",
                c => new
                {
                    PropertyId = c.Long(nullable: false, identity: true),
                    DdfPropertyId = c.String(maxLength: 255, unicode: false),
                    PropertyAgentId = c.Long(nullable: false),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    AddressLine1 = c.String(maxLength: 255, unicode: false),
                    AddressLine2 = c.String(maxLength: 255, unicode: false),
                    StreetNumber = c.String(maxLength: 255, unicode: false),
                    StreetName = c.String(maxLength: 255, unicode: false),
                    StreetSuffix = c.String(maxLength: 255, unicode: false),
                    UnitNumber = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    CountryState = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                    Country = c.String(maxLength: 255, unicode: false),
                    AmmenitiesNearBy = c.String(maxLength: 255, unicode: false),
                    CommunicationType = c.String(maxLength: 255, unicode: false),
                    CommunityFeatures = c.String(maxLength: 255, unicode: false),
                    Crop = c.String(maxLength: 255, unicode: false),
                    DocumentType = c.String(maxLength: 255, unicode: false),
                    EquipmentType = c.String(maxLength: 255, unicode: false),
                    Easement = c.String(maxLength: 255, unicode: false),
                    FarmType = c.String(maxLength: 255, unicode: false),
                    Features = c.String(maxLength: 255, unicode: false),
                    IrrigationType = c.String(maxLength: 255, unicode: false),
                    Lease = c.String(maxLength: 255, unicode: false),
                    LeasePerTime = c.String(maxLength: 255, unicode: false),
                    LeasePerUnit = c.String(maxLength: 255, unicode: false),
                    LeaseTermRemaining = c.String(maxLength: 255, unicode: false),
                    LeaseTermRemainingFreq = c.String(maxLength: 255, unicode: false),
                    LeaseType = c.String(maxLength: 255, unicode: false),
                    LiveStockType = c.String(maxLength: 255, unicode: false),
                    LoadingType = c.String(maxLength: 255, unicode: false),
                    LocationDescription = c.String(maxLength: 255, unicode: false),
                    Machinery = c.String(maxLength: 255, unicode: false),
                    MaintenanceFee = c.String(maxLength: 255, unicode: false),
                    MaintenanceFeePaymentUnit = c.String(maxLength: 255, unicode: false),
                    MaintenanceFeeType = c.String(maxLength: 255, unicode: false),
                    ManagementCompany = c.String(maxLength: 255, unicode: false),
                    MunicipalId = c.String(maxLength: 255, unicode: false),
                    OwnershipType = c.String(maxLength: 255, unicode: false),
                    ParkingSpaceTotal = c.String(maxLength: 255, unicode: false),
                    Plan = c.String(maxLength: 255, unicode: false),
                    PoolType = c.String(maxLength: 255, unicode: false),
                    PoolFeatures = c.String(maxLength: 255, unicode: false),
                    Price = c.String(maxLength: 255, unicode: false),
                    PricePerTime = c.String(maxLength: 255, unicode: false),
                    PricePerUnit = c.String(maxLength: 255, unicode: false),
                    PropertyType = c.String(maxLength: 255, unicode: false),
                    PublicRemarks = c.String(unicode: false),
                    RentalEquipmentType = c.String(maxLength: 255, unicode: false),
                    RightType = c.String(maxLength: 255, unicode: false),
                    RoadType = c.String(maxLength: 255, unicode: false),
                    StorageType = c.String(maxLength: 255, unicode: false),
                    Structure = c.String(maxLength: 255, unicode: false),
                    SignType = c.String(maxLength: 255, unicode: false),
                    TransactionType = c.String(maxLength: 255, unicode: false),
                    TotalBuildings = c.String(maxLength: 255, unicode: false),
                    ViewType = c.String(maxLength: 255, unicode: false),
                    WaterFrontType = c.String(maxLength: 255, unicode: false),
                    WaterFrontName = c.String(maxLength: 255, unicode: false),
                    AdditionalInformationIndicator = c.String(maxLength: 255, unicode: false),
                    ZoningDescription = c.String(maxLength: 255, unicode: false),
                    ZoningType = c.String(maxLength: 255, unicode: false),
                    MoreInformationLink = c.String(maxLength: 255, unicode: false),
                    AnalyticsClick = c.String(unicode: false),
                    AnalyticsView = c.String(unicode: false),
                    Board = c.String(maxLength: 255, unicode: false),
                    LastDdfUpdate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyAgent",
                c => new
                {
                    PropertyAgentId = c.Long(nullable: false),
                    PropertyAgentOfficeId = c.Long(),
                    DdfAgentId = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    Position = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                    EducationCredentials = c.String(maxLength: 255, unicode: false),
                    PhotoLastUpdated = c.DateTime(),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    AddressLine1 = c.String(maxLength: 255, unicode: false),
                    Addressline2 = c.String(maxLength: 255, unicode: false),
                    StreetNumber = c.String(maxLength: 255, unicode: false),
                    StreetName = c.String(maxLength: 255, unicode: false),
                    StreetSuffix = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    Province = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentId)
                .ForeignKey("ddfraw.PropertyAgentOffice", t => t.PropertyAgentOfficeId)
                .Index(t => t.PropertyAgentOfficeId);

            CreateTable(
                "ddfraw.PropertyAgentContact",
                c => new
                {
                    PropertyAgentContactId = c.Long(nullable: false, identity: true),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    AgentType = c.String(maxLength: 255, unicode: false),
                    TextValue = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                    PropertyAgentId = c.Long(),
                })
                .PrimaryKey(t => t.PropertyAgentContactId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAgentDesignation",
                c => new
                {
                    PropertyAgentDesignationId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    Designation = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentDesignationId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAgentLanguage",
                c => new
                {
                    PropertyAgentLanguageId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    Language = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentLanguageId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAgentOffice",
                c => new
                {
                    PropertyAgentOfficeId = c.Long(nullable: false),
                    DdfPropertyAgentOfficeId = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    StreetAddress = c.String(maxLength: 255, unicode: false),
                    AddressLine1 = c.String(maxLength: 255, unicode: false),
                    City = c.String(maxLength: 255, unicode: false),
                    PostalCode = c.String(maxLength: 255, unicode: false),
                    Country = c.String(maxLength: 255, unicode: false),
                    Franchisor = c.String(maxLength: 255, unicode: false),
                    LogoLastUpdated = c.String(maxLength: 255, unicode: false),
                    OrganizationType = c.String(maxLength: 255, unicode: false),
                    Designation = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                    Addressline2 = c.String(maxLength: 255, unicode: false),
                    StreetNumber = c.String(maxLength: 255, unicode: false),
                    StreetName = c.String(maxLength: 255, unicode: false),
                    StreetSuffix = c.String(maxLength: 255, unicode: false),
                    Province = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentOfficeId);

            CreateTable(
                "ddfraw.PropertyAgentOfficePhone",
                c => new
                {
                    PropertyAgentOfficePhoneId = c.Long(nullable: false, identity: true),
                    PropertyAgentOfficeId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    PhoneType = c.String(maxLength: 255, unicode: false),
                    PhoneNumber = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentOfficePhoneId)
                .ForeignKey("ddfraw.PropertyAgentOffice", t => t.PropertyAgentOfficeId, cascadeDelete: true)
                .Index(t => t.PropertyAgentOfficeId);

            CreateTable(
                "ddfraw.PropertyAgentOfficeWebsite",
                c => new
                {
                    PropertyAgentOfficeWebsiteId = c.Long(nullable: false, identity: true),
                    PropertyAgentOfficeId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    WebsiteType = c.String(maxLength: 255, unicode: false),
                    WebsiteUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentOfficeWebsiteId)
                .ForeignKey("ddfraw.PropertyAgentOffice", t => t.PropertyAgentOfficeId, cascadeDelete: true)
                .Index(t => t.PropertyAgentOfficeId);

            CreateTable(
                "ddfraw.PropertyAgentPhone",
                c => new
                {
                    PropertyAgentPhoneId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    PhoneType = c.String(maxLength: 255, unicode: false),
                    PhoneNumber = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentPhoneId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAgentSpeciality",
                c => new
                {
                    PropertyAgentSpecialityId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    Specialtie = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentSpecialityId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAgentTradingArea",
                c => new
                {
                    PropertyAgentTradingAreaId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    TradingArea = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentTradingAreaId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAgentWebsite",
                c => new
                {
                    PropertyAgentWebsiteId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    ContactType = c.String(maxLength: 255, unicode: false),
                    WebsiteType = c.String(maxLength: 255, unicode: false),
                    WebsiteUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentWebsiteId)
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId);

            CreateTable(
                "ddfraw.PropertyAlternateUrl",
                c => new
                {
                    PropertyId = c.Long(nullable: false),
                    BrochureLink = c.String(maxLength: 255, unicode: false),
                    MapLink = c.String(maxLength: 255, unicode: false),
                    PhotoLink = c.String(maxLength: 255, unicode: false),
                    SoundLink = c.String(maxLength: 255, unicode: false),
                    VideoLink = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyBuilding",
                c => new
                {
                    PropertyId = c.Long(nullable: false),
                    BathroomTotal = c.String(maxLength: 255, unicode: false),
                    BedroomsAboveGround = c.String(maxLength: 255, unicode: false),
                    BedroomsBelowGround = c.String(maxLength: 255, unicode: false),
                    BedroomsTotal = c.String(maxLength: 255, unicode: false),
                    Age = c.String(maxLength: 255, unicode: false),
                    Amenities = c.String(maxLength: 255, unicode: false),
                    Amperage = c.String(maxLength: 255, unicode: false),
                    Anchor = c.String(maxLength: 255, unicode: false),
                    Appliances = c.String(maxLength: 255, unicode: false),
                    ArchitecturalStyle = c.String(maxLength: 255, unicode: false),
                    BasementDevelopment = c.String(maxLength: 255, unicode: false),
                    BasementFeatures = c.String(maxLength: 255, unicode: false),
                    BasementType = c.String(maxLength: 255, unicode: false),
                    BomaRating = c.String(maxLength: 255, unicode: false),
                    CeilingHeight = c.String(maxLength: 255, unicode: false),
                    CeilingType = c.String(maxLength: 255, unicode: false),
                    ClearCeilingHeight = c.String(maxLength: 255, unicode: false),
                    ConstructedDate = c.String(maxLength: 255, unicode: false),
                    ConstructionMaterial = c.String(maxLength: 255, unicode: false),
                    ConstructionStatus = c.String(maxLength: 255, unicode: false),
                    ConstructionStyleAttachment = c.String(maxLength: 255, unicode: false),
                    ConstructionStyleOther = c.String(maxLength: 255, unicode: false),
                    ConstructionStyleSplitLevel = c.String(maxLength: 255, unicode: false),
                    CoolingType = c.String(maxLength: 255, unicode: false),
                    EnerguideRating = c.String(maxLength: 255, unicode: false),
                    ExteriorFinish = c.String(maxLength: 255, unicode: false),
                    FireProtection = c.String(maxLength: 255, unicode: false),
                    FireplaceFuel = c.String(maxLength: 255, unicode: false),
                    FireplacePresent = c.String(maxLength: 255, unicode: false),
                    FireplaceTotal = c.String(maxLength: 255, unicode: false),
                    FireplaceType = c.String(maxLength: 255, unicode: false),
                    Fixture = c.String(maxLength: 255, unicode: false),
                    FlooringType = c.String(maxLength: 255, unicode: false),
                    FoundationType = c.String(maxLength: 255, unicode: false),
                    HalfBathTotal = c.String(maxLength: 255, unicode: false),
                    HeatingFuel = c.String(maxLength: 255, unicode: false),
                    HeatingType = c.String(maxLength: 255, unicode: false),
                    LeedsCategory = c.String(maxLength: 255, unicode: false),
                    LeedsRating = c.String(maxLength: 255, unicode: false),
                    RenovatedDate = c.String(maxLength: 255, unicode: false),
                    RoofMaterial = c.String(maxLength: 255, unicode: false),
                    RoofStyle = c.String(maxLength: 255, unicode: false),
                    StoriesTotal = c.String(maxLength: 255, unicode: false),
                    SizeExterior = c.String(maxLength: 255, unicode: false),
                    SizeInterior = c.String(maxLength: 255, unicode: false),
                    SizeInteriorFinished = c.String(maxLength: 255, unicode: false),
                    StoreFront = c.String(maxLength: 255, unicode: false),
                    TotalFinishedArea = c.String(maxLength: 255, unicode: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Uffi = c.String(maxLength: 255, unicode: false),
                    UnitType = c.String(maxLength: 255, unicode: false),
                    UtilityPower = c.String(maxLength: 255, unicode: false),
                    UtilityWater = c.String(maxLength: 255, unicode: false),
                    VacancyRate = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyBuildingRoom",
                c => new
                {
                    PropertyBuildingRoomId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Width = c.String(maxLength: 255, unicode: false),
                    Length = c.String(maxLength: 255, unicode: false),
                    Level = c.String(maxLength: 255, unicode: false),
                    Dimension = c.String(maxLength: 255, unicode: false),
                    Description = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PropertyBuildingRoomId)
                .ForeignKey("ddfraw.PropertyBuilding", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyBusiness",
                c => new
                {
                    PropertyId = c.Long(nullable: false),
                    BusinessType = c.String(maxLength: 255, unicode: false),
                    BusinessSubType = c.String(maxLength: 255, unicode: false),
                    EstablishedDate = c.String(maxLength: 255, unicode: false),
                    Franchise = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    OperatingSince = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyLand",
                c => new
                {
                    PropertyId = c.Long(nullable: false),
                    SizeTotal = c.String(maxLength: 255, unicode: false),
                    SizeTotalText = c.String(maxLength: 255, unicode: false),
                    SizeFrontage = c.String(maxLength: 255, unicode: false),
                    AccessType = c.String(maxLength: 255, unicode: false),
                    Acreage = c.String(maxLength: 255, unicode: false),
                    Amenities = c.String(maxLength: 255, unicode: false),
                    ClearedTotal = c.String(maxLength: 255, unicode: false),
                    CurrentUse = c.String(maxLength: 255, unicode: false),
                    Divisible = c.String(maxLength: 255, unicode: false),
                    FenceTotal = c.String(maxLength: 255, unicode: false),
                    FenceType = c.String(maxLength: 255, unicode: false),
                    FrontsOn = c.String(maxLength: 255, unicode: false),
                    LandDisposition = c.String(maxLength: 255, unicode: false),
                    LandscapeFeatures = c.String(maxLength: 255, unicode: false),
                    PastureTotal = c.String(maxLength: 255, unicode: false),
                    Sewer = c.String(maxLength: 255, unicode: false),
                    SizeDepth = c.String(maxLength: 255, unicode: false),
                    SizeIrregular = c.String(maxLength: 255, unicode: false),
                    SoilEvaluation = c.String(maxLength: 255, unicode: false),
                    SoilType = c.String(maxLength: 255, unicode: false),
                    SurfaceWater = c.String(maxLength: 255, unicode: false),
                    TiledTotal = c.String(maxLength: 255, unicode: false),
                    TopographyType = c.String(maxLength: 255, unicode: false),
                    LastUpdate = c.DateTime(),
                })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyOpenHouse",
                c => new
                {
                    PropertyOpenHouseId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    StartDateTime = c.String(maxLength: 255, unicode: false),
                    EndDateTime = c.String(maxLength: 255, unicode: false),
                    Comments = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyOpenHouseId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyParkingSpace",
                c => new
                {
                    PropertyParkingSpaceId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    Spaces = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyParkingSpaceId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyPhoto",
                c => new
                {
                    PropertyPhotoId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    DdfPropertyId = c.String(maxLength: 255, unicode: false),
                    DdfSequenceId = c.String(maxLength: 255, unicode: false),
                    FolderPath = c.String(maxLength: 255, unicode: false),
                    PhotoType = c.String(maxLength: 255, unicode: false),
                    PhotoName = c.String(maxLength: 255, unicode: false),
                    PhotoOriginalSize = c.String(maxLength: 255, unicode: false),
                    LastDdfUpdate = c.DateTime(nullable: false),
                    LastUpdate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PropertyPhotoId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddfraw.PropertyUtilitiesAvailable",
                c => new
                {
                    PropertyUtilitiesAvailableId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Description = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyUtilitiesAvailableId)
                .ForeignKey("ddfraw.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);

            CreateTable(
                "ddf.PropertyType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.SoilEvaluationType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.UtilityType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.WaterFrontType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.ZoningType",
                c => new
                {
                    Id = c.Long(nullable: false),
                    Value = c.String(maxLength: 255, unicode: false),
                    ShortName = c.String(maxLength: 255, unicode: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    AlternateName = c.String(maxLength: 255, unicode: false),
                    ImgUrl = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "ddf.AgentALanguage",
                c => new
                {
                    ALanguageId = c.Long(nullable: false),
                    UnitAgentId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.ALanguageId,
                    t.UnitAgentId
                })
                .ForeignKey("ddf.ALanguage", t => t.ALanguageId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.ALanguageId)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.AgentIndividualDesignation",
                c => new
                {
                    IndividualDesignationId = c.Long(nullable: false),
                    UnitAgentId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.IndividualDesignationId,
                    t.UnitAgentId
                })
                .ForeignKey("ddf.IndividualDesignation", t => t.IndividualDesignationId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.IndividualDesignationId)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.AgentSpecialty",
                c => new
                {
                    SpecialtyId = c.Long(nullable: false),
                    UnitAgentId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.SpecialtyId,
                    t.UnitAgentId
                })
                .ForeignKey("ddf.Specialtie", t => t.SpecialtyId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.SpecialtyId)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddf.OfficeFranchisor",
                c => new
                {
                    FranchisorId = c.Long(nullable: false),
                    UnitAgentOfficeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.FranchisorId,
                    t.UnitAgentOfficeId
                })
                .ForeignKey("ddf.Franchisor", t => t.FranchisorId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgentOffice", t => t.UnitAgentOfficeId, cascadeDelete: true)
                .Index(t => t.FranchisorId)
                .Index(t => t.UnitAgentOfficeId);

            CreateTable(
                "ddf.OfficeOrganizationDesignation",
                c => new
                {
                    OrganizationDesignationId = c.Long(nullable: false),
                    UnitAgentOfficeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.OrganizationDesignationId,
                    t.UnitAgentOfficeId
                })
                .ForeignKey("ddf.OrganizationDesignation", t => t.OrganizationDesignationId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgentOffice", t => t.UnitAgentOfficeId, cascadeDelete: true)
                .Index(t => t.OrganizationDesignationId)
                .Index(t => t.UnitAgentOfficeId);

            CreateTable(
                "ddf.OfficeOrganizationType",
                c => new
                {
                    OrganizationTypeId = c.Long(nullable: false),
                    UnitAgentOfficeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.OrganizationTypeId,
                    t.UnitAgentOfficeId
                })
                .ForeignKey("ddf.OrganizationType", t => t.OrganizationTypeId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgentOffice", t => t.UnitAgentOfficeId, cascadeDelete: true)
                .Index(t => t.OrganizationTypeId)
                .Index(t => t.UnitAgentOfficeId);

            CreateTable(
                "ddf.LandAccessType",
                c => new
                {
                    AccessTypeId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.AccessTypeId,
                    t.BuildingId
                })
                .ForeignKey("ddf.AccessType", t => t.AccessTypeId, cascadeDelete: true)
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.AccessTypeId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingAmenitie",
                c => new
                {
                    AmenitieId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.AmenitieId,
                    t.BuildingId
                })
                .ForeignKey("ddf.Amenitie", t => t.AmenitieId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.AmenitieId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingAmperage",
                c => new
                {
                    AmperageId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.AmperageId,
                    t.BuildingId
                })
                .ForeignKey("ddf.Amperage", t => t.AmperageId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.AmperageId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingArchitecturalStyle",
                c => new
                {
                    ArchitecturalStyleId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.ArchitecturalStyleId,
                    t.BuildingId
                })
                .ForeignKey("ddf.ArchitecturalStyle", t => t.ArchitecturalStyleId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.ArchitecturalStyleId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingBasementDevelopment",
                c => new
                {
                    BasementDevelopmentId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BasementDevelopmentId,
                    t.BuildingId
                })
                .ForeignKey("ddf.BasementDevelopment", t => t.BasementDevelopmentId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BasementDevelopmentId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingBasementFeature",
                c => new
                {
                    BasementFeatureId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BasementFeatureId,
                    t.BuildingId
                })
                .ForeignKey("ddf.BasementFeature", t => t.BasementFeatureId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BasementFeatureId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingBasementType",
                c => new
                {
                    BasementTypeId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BasementTypeId,
                    t.BuildingId
                })
                .ForeignKey("ddf.BasementType", t => t.BasementTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BasementTypeId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingBoard",
                c => new
                {
                    BoardId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BoardId,
                    t.BuildingId
                })
                .ForeignKey("ddf.Board", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BoardId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.BuildingBuildingType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    BuildingTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.BuildingTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.BuildingType", t => t.BuildingTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.BuildingTypeId);

            CreateTable(
                "ddf.BuildingCeilingType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    CeilingTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.CeilingTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.CeilingType", t => t.CeilingTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.CeilingTypeId);

            CreateTable(
                "ddf.BuildingClearCeilingHeight",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    ClearCeilingHeightId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.ClearCeilingHeightId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.ClearCeilingHeight", t => t.ClearCeilingHeightId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.ClearCeilingHeightId);

            CreateTable(
                "ddf.BuildingCommunicationType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    CommunicationTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.CommunicationTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.CommunicationType", t => t.CommunicationTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.CommunicationTypeId);

            CreateTable(
                "ddf.BuildingCommunityFeature",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    CommunityFeatureId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.CommunityFeatureId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.CommunityFeature", t => t.CommunityFeatureId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.CommunityFeatureId);

            CreateTable(
                "ddf.BuildingConstructionMaterial",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    ConstructionMaterialId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.ConstructionMaterialId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.ConstructionMaterial", t => t.ConstructionMaterialId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.ConstructionMaterialId);

            CreateTable(
                "ddf.BuildingCrop",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    CropId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.CropId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.Crop", t => t.CropId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.CropId);

            CreateTable(
                "ddf.BuildingDocumentType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    DocumentTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.DocumentTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.DocumentType", t => t.DocumentTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.DocumentTypeId);

            CreateTable(
                "ddf.BuildingEasement",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    EasementId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.EasementId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.Easement", t => t.EasementId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.EasementId);

            CreateTable(
                "ddf.BuildingEquipmentType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    EquipmentTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.EquipmentTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.EquipmentType", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.EquipmentTypeId);

            CreateTable(
                "ddf.BuildingExteriorFinish",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    ExteriorFinishId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.ExteriorFinishId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.ExteriorFinish", t => t.ExteriorFinishId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.ExteriorFinishId);

            CreateTable(
                "ddf.BuildingFarmType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FarmTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FarmTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.FarmType", t => t.FarmTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FarmTypeId);

            CreateTable(
                "ddf.BuildingFireplaceFuel",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FireplaceFuelId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FireplaceFuelId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.FireplaceFuel", t => t.FireplaceFuelId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FireplaceFuelId);

            CreateTable(
                "ddf.BuildingFireplaceType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FireplaceTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FireplaceTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.FireplaceType", t => t.FireplaceTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FireplaceTypeId);

            CreateTable(
                "ddf.BuildingFireProtection",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FireProtectionId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FireProtectionId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.FireProtection", t => t.FireProtectionId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FireProtectionId);

            CreateTable(
                "ddf.BuildingFixture",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FixtureId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FixtureId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.Fixture", t => t.FixtureId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FixtureId);

            CreateTable(
                "ddf.BuildingFoundationType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FoundationTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FoundationTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.FoundationType", t => t.FoundationTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FoundationTypeId);

            CreateTable(
                "ddf.BuildingHeatingFuel",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    HeatingFuelId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.HeatingFuelId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.HeatingFuel", t => t.HeatingFuelId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.HeatingFuelId);

            CreateTable(
                "ddf.BuildingHeatingType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    HeatingTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.HeatingTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.HeatingType", t => t.HeatingTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.HeatingTypeId);

            CreateTable(
                "ddf.BuildingIrrigationType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    IrrigationTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.IrrigationTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.IrrigationType", t => t.IrrigationTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.IrrigationTypeId);

            CreateTable(
                "ddf.BuildingMachinery",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    MachineryId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.MachineryId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.Machinery", t => t.MachineryId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.MachineryId);

            CreateTable(
                "ddf.BuildingMeasureUnit",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    MeasureUnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.MeasureUnitId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.MeasureUnit", t => t.MeasureUnitId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.MeasureUnitId);

            CreateTable(
                "ddf.BuildingPoolFeature",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    PoolFeatureId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.PoolFeatureId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.PoolFeature", t => t.PoolFeatureId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.PoolFeatureId);

            CreateTable(
                "ddf.BuildingPoolType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    PoolTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.PoolTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.PoolType", t => t.PoolTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.PoolTypeId);

            CreateTable(
                "ddf.BuildingRoadType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    RoadTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.RoadTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.RoadType", t => t.RoadTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.RoadTypeId);

            CreateTable(
                "ddf.BuildingRoofMaterial",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    RoofMaterialId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.RoofMaterialId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.RoofMaterial", t => t.RoofMaterialId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.RoofMaterialId);

            CreateTable(
                "ddf.BuildingRoofStyle",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    RoofStyleId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.RoofStyleId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.RoofStyle", t => t.RoofStyleId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.RoofStyleId);

            CreateTable(
                "ddf.BuildingSignType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    SignTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.SignTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.SignType", t => t.SignTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.SignTypeId);

            CreateTable(
                "ddf.BuildingStoreFront",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    StoreFrontId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.StoreFrontId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.StoreFront", t => t.StoreFrontId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.StoreFrontId);

            CreateTable(
                "ddf.BuildingStructureType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    StructureTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.StructureTypeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.StructureType", t => t.StructureTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.StructureTypeId);

            CreateTable(
                "ddf.BuildingUffiCode",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    UffiCodeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.UffiCodeId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.UffiCode", t => t.UffiCodeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.UffiCodeId);

            CreateTable(
                "ddf.BuildingUtilityPower",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    UtilityPowerId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.UtilityPowerId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.UtilityPower", t => t.UtilityPowerId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.UtilityPowerId);

            CreateTable(
                "ddf.BuildingUtilityWater",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    UtilityWaterId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.UtilityWaterId
                })
                .ForeignKey("ddf.Building", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.UtilityWater", t => t.UtilityWaterId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.UtilityWaterId);

            CreateTable(
                "ddf.LandCurrentUse",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    CurrentUseId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.CurrentUseId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.CurrentUse", t => t.CurrentUseId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.CurrentUseId);

            CreateTable(
                "ddf.LandFenceType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    FenceTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.FenceTypeId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.FenceType", t => t.FenceTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.FenceTypeId);

            CreateTable(
                "ddf.LandLandDispositionType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    LandDispositionTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.LandDispositionTypeId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.LandDispositionType", t => t.LandDispositionTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.LandDispositionTypeId);

            CreateTable(
                "ddf.LandLandscapeFeature",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    LandscapeFeatureId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.LandscapeFeatureId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.LandscapeFeature", t => t.LandscapeFeatureId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.LandscapeFeatureId);

            CreateTable(
                "ddf.LandSewer",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    SewerId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.SewerId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.Sewer", t => t.SewerId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.SewerId);

            CreateTable(
                "ddf.LandSoilType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    LandSoilTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.LandSoilTypeId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.SoilType", t => t.LandSoilTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.LandSoilTypeId);

            CreateTable(
                "ddf.LandSurfaceWater",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    SurfaceWaterId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.SurfaceWaterId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.SurfaceWater", t => t.SurfaceWaterId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.SurfaceWaterId);

            CreateTable(
                "ddf.LandTopographyType",
                c => new
                {
                    BuildingId = c.Long(nullable: false),
                    TopographyTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BuildingId,
                    t.TopographyTypeId
                })
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("ddf.TopographyType", t => t.TopographyTypeId, cascadeDelete: true)
                .Index(t => t.BuildingId)
                .Index(t => t.TopographyTypeId);

            CreateTable(
                "ddf.LandAmenitiesNearby",
                c => new
                {
                    AmenitiesNearbyId = c.Long(nullable: false),
                    BuildingId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.AmenitiesNearbyId,
                    t.BuildingId
                })
                .ForeignKey("ddf.AmenitiesNearby", t => t.AmenitiesNearbyId, cascadeDelete: true)
                .ForeignKey("ddf.BuildingLand", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.AmenitiesNearbyId)
                .Index(t => t.BuildingId);

            CreateTable(
                "ddf.UnitAmenitiesNearby",
                c => new
                {
                    AmenitiesNearbyId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.AmenitiesNearbyId,
                    t.UnitId
                })
                .ForeignKey("ddf.AmenitiesNearby", t => t.AmenitiesNearbyId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.AmenitiesNearbyId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitAppliance",
                c => new
                {
                    ApplianceId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.ApplianceId,
                    t.UnitId
                })
                .ForeignKey("ddf.Appliance", t => t.ApplianceId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.ApplianceId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.BusinessBusinessSubType",
                c => new
                {
                    BusinessSubTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BusinessSubTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.BusinessSubType", t => t.BusinessSubTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.BusinessSubTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.BusinessBusinessType",
                c => new
                {
                    BusinessTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.BusinessTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.BusinessType", t => t.BusinessTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.BusinessTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitCoolingType",
                c => new
                {
                    CoolingTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.CoolingTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.CoolingType", t => t.CoolingTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.CoolingTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitFeature",
                c => new
                {
                    FeatureId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.FeatureId,
                    t.UnitId
                })
                .ForeignKey("ddf.Feature", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitFlooringType",
                c => new
                {
                    FlooringTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.FlooringTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.FlooringType", t => t.FlooringTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.FlooringTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitLiveStockType",
                c => new
                {
                    LiveStockTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.LiveStockTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.LiveStockType", t => t.LiveStockTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.LiveStockTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitLoadingType",
                c => new
                {
                    LoadingTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.LoadingTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.LoadingType", t => t.LoadingTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.LoadingTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitMaintenanceFeeType",
                c => new
                {
                    MaintenanceFeeTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.MaintenanceFeeTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.MaintenanceFeeType", t => t.MaintenanceFeeTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.MaintenanceFeeTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitPaymentUnit",
                c => new
                {
                    PaymentUnitId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.PaymentUnitId,
                    t.UnitId
                })
                .ForeignKey("ddf.PaymentUnit", t => t.PaymentUnitId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.PaymentUnitId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitRentalEquipmentType",
                c => new
                {
                    RentalEquipmentTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.RentalEquipmentTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.RentalEquipmentType", t => t.RentalEquipmentTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.RentalEquipmentTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitRightType",
                c => new
                {
                    RightTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.RightTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.RightType", t => t.RightTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.RightTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitStorageType",
                c => new
                {
                    StorageTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.StorageTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.StorageType", t => t.StorageTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.StorageTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitTransactionType",
                c => new
                {
                    TransactionTypeId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.TransactionTypeId,
                    t.UnitId
                })
                .ForeignKey("ddf.TransactionType", t => t.TransactionTypeId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.TransactionTypeId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.UnitViewType",
                c => new
                {
                    UnitId = c.Long(nullable: false),
                    ViewTypeId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.UnitId,
                    t.ViewTypeId
                })
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .ForeignKey("ddf.ViewType", t => t.ViewTypeId, cascadeDelete: true)
                .Index(t => t.UnitId)
                .Index(t => t.ViewTypeId);

            CreateTable(
                "ddf.UnitUnitAgent",
                c => new
                {
                    UnitAgentId = c.Long(nullable: false),
                    UnitId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.UnitAgentId,
                    t.UnitId
                })
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .ForeignKey("ddf.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitAgentId)
                .Index(t => t.UnitId);

            CreateTable(
                "ddf.AgentABoard",
                c => new
                {
                    ABoardId = c.Long(nullable: false),
                    UnitAgentId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.ABoardId,
                    t.UnitAgentId
                })
                .ForeignKey("ddf.ABoard", t => t.ABoardId, cascadeDelete: true)
                .ForeignKey("ddf.UnitAgent", t => t.UnitAgentId, cascadeDelete: true)
                .Index(t => t.ABoardId)
                .Index(t => t.UnitAgentId);

            CreateTable(
                "ddfraw.PropertyPropertyAgent",
                c => new
                {
                    PropertyAgentId = c.Long(nullable: false),
                    PropertyId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.PropertyAgentId,
                    t.PropertyId
                })
                .ForeignKey("ddfraw.PropertyAgent", t => t.PropertyAgentId, cascadeDelete: true)
                .ForeignKey("ddfraw.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyAgentId)
                .Index(t => t.PropertyId);
        }

        public override void Down()
        {
            DropForeignKey("ddfraw.PropertyUtilitiesAvailable", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyPhoto", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyParkingSpace", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyOpenHouse", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyLand", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyBusiness", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyBuildingRoom", "PropertyId", "ddfraw.PropertyBuilding");
            DropForeignKey("ddfraw.PropertyBuilding", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyAlternateUrl", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyAgentWebsite", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentTradingArea", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentSpeciality", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentPhone", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgent", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice");
            DropForeignKey("ddfraw.PropertyAgentOfficeWebsite", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice");
            DropForeignKey("ddfraw.PropertyAgentOfficePhone", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice");
            DropForeignKey("ddfraw.PropertyAgentLanguage", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentDesignation", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentContact", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyPropertyAgent", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyPropertyAgent", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddf.AgentABoard", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.AgentABoard", "ABoardId", "ddf.ABoard");
            DropForeignKey("ddf.UnitUnitAgent", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitUnitAgent", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitViewType", "ViewTypeId", "ddf.ViewType");
            DropForeignKey("ddf.UnitViewType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitUtilitiesAvailable", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitRoom", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitRoom", "TypeId", "ddf.RoomType");
            DropForeignKey("ddf.UnitRoom", "LevelId", "ddf.RoomLevel");
            DropForeignKey("ddf.UnitPhoto", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitParkingSpace", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitOpenHouse", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitTransactionType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitTransactionType", "TransactionTypeId", "ddf.TransactionType");
            DropForeignKey("ddf.UnitStorageType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitStorageType", "StorageTypeId", "ddf.StorageType");
            DropForeignKey("ddf.UnitRightType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitRightType", "RightTypeId", "ddf.RightType");
            DropForeignKey("ddf.UnitRentalEquipmentType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitRentalEquipmentType", "RentalEquipmentTypeId", "ddf.RentalEquipmentType");
            DropForeignKey("ddf.UnitPaymentUnit", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitPaymentUnit", "PaymentUnitId", "ddf.PaymentUnit");
            DropForeignKey("ddf.UnitMaintenanceFeeType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitMaintenanceFeeType", "MaintenanceFeeTypeId", "ddf.MaintenanceFeeType");
            DropForeignKey("ddf.UnitLoadingType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitLoadingType", "LoadingTypeId", "ddf.LoadingType");
            DropForeignKey("ddf.UnitLiveStockType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitLiveStockType", "LiveStockTypeId", "ddf.LiveStockType");
            DropForeignKey("ddf.UnitFlooringType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitFlooringType", "FlooringTypeId", "ddf.FlooringType");
            DropForeignKey("ddf.UnitFeature", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitFeature", "FeatureId", "ddf.Feature");
            DropForeignKey("ddf.UnitCoolingType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitCoolingType", "CoolingTypeId", "ddf.CoolingType");
            DropForeignKey("ddf.BusinessBusinessType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.BusinessBusinessType", "BusinessTypeId", "ddf.BusinessType");
            DropForeignKey("ddf.BusinessBusinessSubType", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.BusinessBusinessSubType", "BusinessSubTypeId", "ddf.BusinessSubType");
            DropForeignKey("ddf.Business", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.Unit", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.UnitAppliance", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitAppliance", "ApplianceId", "ddf.Appliance");
            DropForeignKey("ddf.UnitAmenitiesNearby", "UnitId", "ddf.Unit");
            DropForeignKey("ddf.UnitAmenitiesNearby", "AmenitiesNearbyId", "ddf.AmenitiesNearby");
            DropForeignKey("ddf.LandAmenitiesNearby", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandAmenitiesNearby", "AmenitiesNearbyId", "ddf.AmenitiesNearby");
            DropForeignKey("ddf.LandTopographyType", "TopographyTypeId", "ddf.TopographyType");
            DropForeignKey("ddf.LandTopographyType", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandSurfaceWater", "SurfaceWaterId", "ddf.SurfaceWater");
            DropForeignKey("ddf.LandSurfaceWater", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandSoilType", "LandSoilTypeId", "ddf.SoilType");
            DropForeignKey("ddf.LandSoilType", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandSewer", "SewerId", "ddf.Sewer");
            DropForeignKey("ddf.LandSewer", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandLandscapeFeature", "LandscapeFeatureId", "ddf.LandscapeFeature");
            DropForeignKey("ddf.LandLandscapeFeature", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandLandDispositionType", "LandDispositionTypeId", "ddf.LandDispositionType");
            DropForeignKey("ddf.LandLandDispositionType", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandFenceType", "FenceTypeId", "ddf.FenceType");
            DropForeignKey("ddf.LandFenceType", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandCurrentUse", "CurrentUseId", "ddf.CurrentUse");
            DropForeignKey("ddf.LandCurrentUse", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.BuildingLand", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingUtilityWater", "UtilityWaterId", "ddf.UtilityWater");
            DropForeignKey("ddf.BuildingUtilityWater", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingUtilityPower", "UtilityPowerId", "ddf.UtilityPower");
            DropForeignKey("ddf.BuildingUtilityPower", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingUffiCode", "UffiCodeId", "ddf.UffiCode");
            DropForeignKey("ddf.BuildingUffiCode", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingStructureType", "StructureTypeId", "ddf.StructureType");
            DropForeignKey("ddf.BuildingStructureType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingStoreFront", "StoreFrontId", "ddf.StoreFront");
            DropForeignKey("ddf.BuildingStoreFront", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingSignType", "SignTypeId", "ddf.SignType");
            DropForeignKey("ddf.BuildingSignType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingRoofStyle", "RoofStyleId", "ddf.RoofStyle");
            DropForeignKey("ddf.BuildingRoofStyle", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingRoofMaterial", "RoofMaterialId", "ddf.RoofMaterial");
            DropForeignKey("ddf.BuildingRoofMaterial", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingRoadType", "RoadTypeId", "ddf.RoadType");
            DropForeignKey("ddf.BuildingRoadType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingPoolType", "PoolTypeId", "ddf.PoolType");
            DropForeignKey("ddf.BuildingPoolType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingPoolFeature", "PoolFeatureId", "ddf.PoolFeature");
            DropForeignKey("ddf.BuildingPoolFeature", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingMeasureUnit", "MeasureUnitId", "ddf.MeasureUnit");
            DropForeignKey("ddf.BuildingMeasureUnit", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingMachinery", "MachineryId", "ddf.Machinery");
            DropForeignKey("ddf.BuildingMachinery", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingIrrigationType", "IrrigationTypeId", "ddf.IrrigationType");
            DropForeignKey("ddf.BuildingIrrigationType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingHeatingType", "HeatingTypeId", "ddf.HeatingType");
            DropForeignKey("ddf.BuildingHeatingType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingHeatingFuel", "HeatingFuelId", "ddf.HeatingFuel");
            DropForeignKey("ddf.BuildingHeatingFuel", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingFoundationType", "FoundationTypeId", "ddf.FoundationType");
            DropForeignKey("ddf.BuildingFoundationType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingFixture", "FixtureId", "ddf.Fixture");
            DropForeignKey("ddf.BuildingFixture", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingFireProtection", "FireProtectionId", "ddf.FireProtection");
            DropForeignKey("ddf.BuildingFireProtection", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingFireplaceType", "FireplaceTypeId", "ddf.FireplaceType");
            DropForeignKey("ddf.BuildingFireplaceType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingFireplaceFuel", "FireplaceFuelId", "ddf.FireplaceFuel");
            DropForeignKey("ddf.BuildingFireplaceFuel", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingFarmType", "FarmTypeId", "ddf.FarmType");
            DropForeignKey("ddf.BuildingFarmType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingExteriorFinish", "ExteriorFinishId", "ddf.ExteriorFinish");
            DropForeignKey("ddf.BuildingExteriorFinish", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingEquipmentType", "EquipmentTypeId", "ddf.EquipmentType");
            DropForeignKey("ddf.BuildingEquipmentType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingEasement", "EasementId", "ddf.Easement");
            DropForeignKey("ddf.BuildingEasement", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingDocumentType", "DocumentTypeId", "ddf.DocumentType");
            DropForeignKey("ddf.BuildingDocumentType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingCrop", "CropId", "ddf.Crop");
            DropForeignKey("ddf.BuildingCrop", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingConstructionMaterial", "ConstructionMaterialId", "ddf.ConstructionMaterial");
            DropForeignKey("ddf.BuildingConstructionMaterial", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingCommunityFeature", "CommunityFeatureId", "ddf.CommunityFeature");
            DropForeignKey("ddf.BuildingCommunityFeature", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingCommunicationType", "CommunicationTypeId", "ddf.CommunicationType");
            DropForeignKey("ddf.BuildingCommunicationType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingClearCeilingHeight", "ClearCeilingHeightId", "ddf.ClearCeilingHeight");
            DropForeignKey("ddf.BuildingClearCeilingHeight", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingCeilingType", "CeilingTypeId", "ddf.CeilingType");
            DropForeignKey("ddf.BuildingCeilingType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingBuildingType", "BuildingTypeId", "ddf.BuildingType");
            DropForeignKey("ddf.BuildingBuildingType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.Building", "BuildingAddressId", "ddf.BuildingAddress");
            DropForeignKey("ddf.BuildingAddress", "NeighborhoodAreaId", "cdk.NeighborhoodArea");
            DropForeignKey("cdk.NeighborhoodGuideVideo", "NeighborhoodGuideId", "cdk.NeighborhoodGuide");
            DropForeignKey("cdk.NeighborhoodGuidePhoto", "NeighborhoodGuideId", "cdk.NeighborhoodGuide");
            DropForeignKey("cdk.NeighborhoodGuide", "NeighborhoodAreaId", "cdk.NeighborhoodArea");
            DropForeignKey("cdk.NeighborhoodArea", "MetroAreaId", "cdk.MetroArea");
            DropForeignKey("cdk.DevelopmentAddress", "NeighborhoodAreaId", "cdk.NeighborhoodArea");
            DropForeignKey("cdk.DevelopmentVideo", "DevelopmentId", "cdk.Development");
            DropForeignKey("cdk.DevelopmentPhoto", "DevelopmentId", "cdk.Development");
            DropForeignKey("cdk.DevelopmentFloorPlan", "DevelopmentId", "cdk.Development");
            DropForeignKey("cdk.DevelopmentAddress", "Id", "cdk.Development");
            DropForeignKey("cdk.Development", "DeveloperId", "cdk.Developer");
            DropForeignKey("ddf.BuildingBoard", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingBoard", "BoardId", "ddf.Board");
            DropForeignKey("ddf.BuildingBasementType", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingBasementType", "BasementTypeId", "ddf.BasementType");
            DropForeignKey("ddf.BuildingBasementFeature", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingBasementFeature", "BasementFeatureId", "ddf.BasementFeature");
            DropForeignKey("ddf.BuildingBasementDevelopment", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingBasementDevelopment", "BasementDevelopmentId", "ddf.BasementDevelopment");
            DropForeignKey("ddf.BuildingArchitecturalStyle", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingArchitecturalStyle", "ArchitecturalStyleId", "ddf.ArchitecturalStyle");
            DropForeignKey("ddf.BuildingAmperage", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingAmperage", "AmperageId", "ddf.Amperage");
            DropForeignKey("ddf.BuildingAmenitie", "BuildingId", "ddf.Building");
            DropForeignKey("ddf.BuildingAmenitie", "AmenitieId", "ddf.Amenitie");
            DropForeignKey("ddf.LandAccessType", "BuildingId", "ddf.BuildingLand");
            DropForeignKey("ddf.LandAccessType", "AccessTypeId", "ddf.AccessType");
            DropForeignKey("ddf.UnitAgentWebsite", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitAgentTradingArea", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitAgentSpeciality", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitAgentPhone", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitAgentOfficeWebsite", "UnitAgentOfficeId", "ddf.UnitAgentOffice");
            DropForeignKey("ddf.UnitAgentOfficePhone", "UnitAgentOfficeId", "ddf.UnitAgentOffice");
            DropForeignKey("ddf.UnitAgentOffice", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.OfficeOrganizationType", "UnitAgentOfficeId", "ddf.UnitAgentOffice");
            DropForeignKey("ddf.OfficeOrganizationType", "OrganizationTypeId", "ddf.OrganizationType");
            DropForeignKey("ddf.OfficeOrganizationDesignation", "UnitAgentOfficeId", "ddf.UnitAgentOffice");
            DropForeignKey("ddf.OfficeOrganizationDesignation", "OrganizationDesignationId", "ddf.OrganizationDesignation");
            DropForeignKey("ddf.OfficeFranchisor", "UnitAgentOfficeId", "ddf.UnitAgentOffice");
            DropForeignKey("ddf.OfficeFranchisor", "FranchisorId", "ddf.Franchisor");
            DropForeignKey("ddf.UnitAgentLanguage", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitAgentDesignation", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.UnitAgentContact", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.AgentSpecialty", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.AgentSpecialty", "SpecialtyId", "ddf.Specialtie");
            DropForeignKey("ddf.AgentIndividualDesignation", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.AgentIndividualDesignation", "IndividualDesignationId", "ddf.IndividualDesignation");
            DropForeignKey("ddf.AgentALanguage", "UnitAgentId", "ddf.UnitAgent");
            DropForeignKey("ddf.AgentALanguage", "ALanguageId", "ddf.ALanguage");
            DropIndex("ddfraw.PropertyPropertyAgent", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyPropertyAgent", new[] { "PropertyAgentId" });
            DropIndex("ddf.AgentABoard", new[] { "UnitAgentId" });
            DropIndex("ddf.AgentABoard", new[] { "ABoardId" });
            DropIndex("ddf.UnitUnitAgent", new[] { "UnitId" });
            DropIndex("ddf.UnitUnitAgent", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitViewType", new[] { "ViewTypeId" });
            DropIndex("ddf.UnitViewType", new[] { "UnitId" });
            DropIndex("ddf.UnitTransactionType", new[] { "UnitId" });
            DropIndex("ddf.UnitTransactionType", new[] { "TransactionTypeId" });
            DropIndex("ddf.UnitStorageType", new[] { "UnitId" });
            DropIndex("ddf.UnitStorageType", new[] { "StorageTypeId" });
            DropIndex("ddf.UnitRightType", new[] { "UnitId" });
            DropIndex("ddf.UnitRightType", new[] { "RightTypeId" });
            DropIndex("ddf.UnitRentalEquipmentType", new[] { "UnitId" });
            DropIndex("ddf.UnitRentalEquipmentType", new[] { "RentalEquipmentTypeId" });
            DropIndex("ddf.UnitPaymentUnit", new[] { "UnitId" });
            DropIndex("ddf.UnitPaymentUnit", new[] { "PaymentUnitId" });
            DropIndex("ddf.UnitMaintenanceFeeType", new[] { "UnitId" });
            DropIndex("ddf.UnitMaintenanceFeeType", new[] { "MaintenanceFeeTypeId" });
            DropIndex("ddf.UnitLoadingType", new[] { "UnitId" });
            DropIndex("ddf.UnitLoadingType", new[] { "LoadingTypeId" });
            DropIndex("ddf.UnitLiveStockType", new[] { "UnitId" });
            DropIndex("ddf.UnitLiveStockType", new[] { "LiveStockTypeId" });
            DropIndex("ddf.UnitFlooringType", new[] { "UnitId" });
            DropIndex("ddf.UnitFlooringType", new[] { "FlooringTypeId" });
            DropIndex("ddf.UnitFeature", new[] { "UnitId" });
            DropIndex("ddf.UnitFeature", new[] { "FeatureId" });
            DropIndex("ddf.UnitCoolingType", new[] { "UnitId" });
            DropIndex("ddf.UnitCoolingType", new[] { "CoolingTypeId" });
            DropIndex("ddf.BusinessBusinessType", new[] { "UnitId" });
            DropIndex("ddf.BusinessBusinessType", new[] { "BusinessTypeId" });
            DropIndex("ddf.BusinessBusinessSubType", new[] { "UnitId" });
            DropIndex("ddf.BusinessBusinessSubType", new[] { "BusinessSubTypeId" });
            DropIndex("ddf.UnitAppliance", new[] { "UnitId" });
            DropIndex("ddf.UnitAppliance", new[] { "ApplianceId" });
            DropIndex("ddf.UnitAmenitiesNearby", new[] { "UnitId" });
            DropIndex("ddf.UnitAmenitiesNearby", new[] { "AmenitiesNearbyId" });
            DropIndex("ddf.LandAmenitiesNearby", new[] { "BuildingId" });
            DropIndex("ddf.LandAmenitiesNearby", new[] { "AmenitiesNearbyId" });
            DropIndex("ddf.LandTopographyType", new[] { "TopographyTypeId" });
            DropIndex("ddf.LandTopographyType", new[] { "BuildingId" });
            DropIndex("ddf.LandSurfaceWater", new[] { "SurfaceWaterId" });
            DropIndex("ddf.LandSurfaceWater", new[] { "BuildingId" });
            DropIndex("ddf.LandSoilType", new[] { "LandSoilTypeId" });
            DropIndex("ddf.LandSoilType", new[] { "BuildingId" });
            DropIndex("ddf.LandSewer", new[] { "SewerId" });
            DropIndex("ddf.LandSewer", new[] { "BuildingId" });
            DropIndex("ddf.LandLandscapeFeature", new[] { "LandscapeFeatureId" });
            DropIndex("ddf.LandLandscapeFeature", new[] { "BuildingId" });
            DropIndex("ddf.LandLandDispositionType", new[] { "LandDispositionTypeId" });
            DropIndex("ddf.LandLandDispositionType", new[] { "BuildingId" });
            DropIndex("ddf.LandFenceType", new[] { "FenceTypeId" });
            DropIndex("ddf.LandFenceType", new[] { "BuildingId" });
            DropIndex("ddf.LandCurrentUse", new[] { "CurrentUseId" });
            DropIndex("ddf.LandCurrentUse", new[] { "BuildingId" });
            DropIndex("ddf.BuildingUtilityWater", new[] { "UtilityWaterId" });
            DropIndex("ddf.BuildingUtilityWater", new[] { "BuildingId" });
            DropIndex("ddf.BuildingUtilityPower", new[] { "UtilityPowerId" });
            DropIndex("ddf.BuildingUtilityPower", new[] { "BuildingId" });
            DropIndex("ddf.BuildingUffiCode", new[] { "UffiCodeId" });
            DropIndex("ddf.BuildingUffiCode", new[] { "BuildingId" });
            DropIndex("ddf.BuildingStructureType", new[] { "StructureTypeId" });
            DropIndex("ddf.BuildingStructureType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingStoreFront", new[] { "StoreFrontId" });
            DropIndex("ddf.BuildingStoreFront", new[] { "BuildingId" });
            DropIndex("ddf.BuildingSignType", new[] { "SignTypeId" });
            DropIndex("ddf.BuildingSignType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingRoofStyle", new[] { "RoofStyleId" });
            DropIndex("ddf.BuildingRoofStyle", new[] { "BuildingId" });
            DropIndex("ddf.BuildingRoofMaterial", new[] { "RoofMaterialId" });
            DropIndex("ddf.BuildingRoofMaterial", new[] { "BuildingId" });
            DropIndex("ddf.BuildingRoadType", new[] { "RoadTypeId" });
            DropIndex("ddf.BuildingRoadType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingPoolType", new[] { "PoolTypeId" });
            DropIndex("ddf.BuildingPoolType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingPoolFeature", new[] { "PoolFeatureId" });
            DropIndex("ddf.BuildingPoolFeature", new[] { "BuildingId" });
            DropIndex("ddf.BuildingMeasureUnit", new[] { "MeasureUnitId" });
            DropIndex("ddf.BuildingMeasureUnit", new[] { "BuildingId" });
            DropIndex("ddf.BuildingMachinery", new[] { "MachineryId" });
            DropIndex("ddf.BuildingMachinery", new[] { "BuildingId" });
            DropIndex("ddf.BuildingIrrigationType", new[] { "IrrigationTypeId" });
            DropIndex("ddf.BuildingIrrigationType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingHeatingType", new[] { "HeatingTypeId" });
            DropIndex("ddf.BuildingHeatingType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingHeatingFuel", new[] { "HeatingFuelId" });
            DropIndex("ddf.BuildingHeatingFuel", new[] { "BuildingId" });
            DropIndex("ddf.BuildingFoundationType", new[] { "FoundationTypeId" });
            DropIndex("ddf.BuildingFoundationType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingFixture", new[] { "FixtureId" });
            DropIndex("ddf.BuildingFixture", new[] { "BuildingId" });
            DropIndex("ddf.BuildingFireProtection", new[] { "FireProtectionId" });
            DropIndex("ddf.BuildingFireProtection", new[] { "BuildingId" });
            DropIndex("ddf.BuildingFireplaceType", new[] { "FireplaceTypeId" });
            DropIndex("ddf.BuildingFireplaceType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingFireplaceFuel", new[] { "FireplaceFuelId" });
            DropIndex("ddf.BuildingFireplaceFuel", new[] { "BuildingId" });
            DropIndex("ddf.BuildingFarmType", new[] { "FarmTypeId" });
            DropIndex("ddf.BuildingFarmType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingExteriorFinish", new[] { "ExteriorFinishId" });
            DropIndex("ddf.BuildingExteriorFinish", new[] { "BuildingId" });
            DropIndex("ddf.BuildingEquipmentType", new[] { "EquipmentTypeId" });
            DropIndex("ddf.BuildingEquipmentType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingEasement", new[] { "EasementId" });
            DropIndex("ddf.BuildingEasement", new[] { "BuildingId" });
            DropIndex("ddf.BuildingDocumentType", new[] { "DocumentTypeId" });
            DropIndex("ddf.BuildingDocumentType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingCrop", new[] { "CropId" });
            DropIndex("ddf.BuildingCrop", new[] { "BuildingId" });
            DropIndex("ddf.BuildingConstructionMaterial", new[] { "ConstructionMaterialId" });
            DropIndex("ddf.BuildingConstructionMaterial", new[] { "BuildingId" });
            DropIndex("ddf.BuildingCommunityFeature", new[] { "CommunityFeatureId" });
            DropIndex("ddf.BuildingCommunityFeature", new[] { "BuildingId" });
            DropIndex("ddf.BuildingCommunicationType", new[] { "CommunicationTypeId" });
            DropIndex("ddf.BuildingCommunicationType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingClearCeilingHeight", new[] { "ClearCeilingHeightId" });
            DropIndex("ddf.BuildingClearCeilingHeight", new[] { "BuildingId" });
            DropIndex("ddf.BuildingCeilingType", new[] { "CeilingTypeId" });
            DropIndex("ddf.BuildingCeilingType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingBuildingType", new[] { "BuildingTypeId" });
            DropIndex("ddf.BuildingBuildingType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingBoard", new[] { "BuildingId" });
            DropIndex("ddf.BuildingBoard", new[] { "BoardId" });
            DropIndex("ddf.BuildingBasementType", new[] { "BuildingId" });
            DropIndex("ddf.BuildingBasementType", new[] { "BasementTypeId" });
            DropIndex("ddf.BuildingBasementFeature", new[] { "BuildingId" });
            DropIndex("ddf.BuildingBasementFeature", new[] { "BasementFeatureId" });
            DropIndex("ddf.BuildingBasementDevelopment", new[] { "BuildingId" });
            DropIndex("ddf.BuildingBasementDevelopment", new[] { "BasementDevelopmentId" });
            DropIndex("ddf.BuildingArchitecturalStyle", new[] { "BuildingId" });
            DropIndex("ddf.BuildingArchitecturalStyle", new[] { "ArchitecturalStyleId" });
            DropIndex("ddf.BuildingAmperage", new[] { "BuildingId" });
            DropIndex("ddf.BuildingAmperage", new[] { "AmperageId" });
            DropIndex("ddf.BuildingAmenitie", new[] { "BuildingId" });
            DropIndex("ddf.BuildingAmenitie", new[] { "AmenitieId" });
            DropIndex("ddf.LandAccessType", new[] { "BuildingId" });
            DropIndex("ddf.LandAccessType", new[] { "AccessTypeId" });
            DropIndex("ddf.OfficeOrganizationType", new[] { "UnitAgentOfficeId" });
            DropIndex("ddf.OfficeOrganizationType", new[] { "OrganizationTypeId" });
            DropIndex("ddf.OfficeOrganizationDesignation", new[] { "UnitAgentOfficeId" });
            DropIndex("ddf.OfficeOrganizationDesignation", new[] { "OrganizationDesignationId" });
            DropIndex("ddf.OfficeFranchisor", new[] { "UnitAgentOfficeId" });
            DropIndex("ddf.OfficeFranchisor", new[] { "FranchisorId" });
            DropIndex("ddf.AgentSpecialty", new[] { "UnitAgentId" });
            DropIndex("ddf.AgentSpecialty", new[] { "SpecialtyId" });
            DropIndex("ddf.AgentIndividualDesignation", new[] { "UnitAgentId" });
            DropIndex("ddf.AgentIndividualDesignation", new[] { "IndividualDesignationId" });
            DropIndex("ddf.AgentALanguage", new[] { "UnitAgentId" });
            DropIndex("ddf.AgentALanguage", new[] { "ALanguageId" });
            DropIndex("ddfraw.PropertyUtilitiesAvailable", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyPhoto", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyParkingSpace", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyOpenHouse", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyLand", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyBusiness", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyBuildingRoom", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyBuilding", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyAlternateUrl", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyAgentWebsite", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentTradingArea", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentSpeciality", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentPhone", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentOfficeWebsite", new[] { "PropertyAgentOfficeId" });
            DropIndex("ddfraw.PropertyAgentOfficePhone", new[] { "PropertyAgentOfficeId" });
            DropIndex("ddfraw.PropertyAgentLanguage", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentDesignation", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentContact", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgent", new[] { "PropertyAgentOfficeId" });
            DropIndex("ddf.UnitUtilitiesAvailable", new[] { "UnitId" });
            DropIndex("ddf.UnitRoom", new[] { "LevelId" });
            DropIndex("ddf.UnitRoom", new[] { "TypeId" });
            DropIndex("ddf.UnitRoom", new[] { "UnitId" });
            DropIndex("ddf.UnitPhoto", new[] { "UnitId" });
            DropIndex("ddf.UnitParkingSpace", new[] { "UnitId" });
            DropIndex("ddf.UnitOpenHouse", new[] { "UnitId" });
            DropIndex("ddf.Business", new[] { "UnitId" });
            DropIndex("cdk.NeighborhoodGuideVideo", new[] { "NeighborhoodGuideId" });
            DropIndex("cdk.NeighborhoodGuidePhoto", new[] { "NeighborhoodGuideId" });
            DropIndex("cdk.NeighborhoodGuide", new[] { "NeighborhoodAreaId" });
            DropIndex("cdk.DevelopmentVideo", new[] { "DevelopmentId" });
            DropIndex("cdk.DevelopmentPhoto", new[] { "DevelopmentId" });
            DropIndex("cdk.DevelopmentFloorPlan", new[] { "DevelopmentId" });
            DropIndex("cdk.Development", new[] { "DeveloperId" });
            DropIndex("cdk.DevelopmentAddress", new[] { "NeighborhoodAreaId" });
            DropIndex("cdk.DevelopmentAddress", new[] { "Id" });
            DropIndex("cdk.NeighborhoodArea", new[] { "MetroAreaId" });
            DropIndex("ddf.BuildingAddress", new[] { "NeighborhoodAreaId" });
            DropIndex("ddf.Building", new[] { "BuildingAddressId" });
            DropIndex("ddf.BuildingLand", new[] { "BuildingId" });
            DropIndex("ddf.Unit", new[] { "BuildingId" });
            DropIndex("ddf.UnitAgentWebsite", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentTradingArea", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentSpeciality", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentPhone", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentOfficeWebsite", new[] { "UnitAgentOfficeId" });
            DropIndex("ddf.UnitAgentOfficePhone", new[] { "UnitAgentOfficeId" });
            DropIndex("ddf.UnitAgentOffice", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentLanguage", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentDesignation", new[] { "UnitAgentId" });
            DropIndex("ddf.UnitAgentContact", new[] { "UnitAgentId" });
            DropTable("ddfraw.PropertyPropertyAgent");
            DropTable("ddf.AgentABoard");
            DropTable("ddf.UnitUnitAgent");
            DropTable("ddf.UnitViewType");
            DropTable("ddf.UnitTransactionType");
            DropTable("ddf.UnitStorageType");
            DropTable("ddf.UnitRightType");
            DropTable("ddf.UnitRentalEquipmentType");
            DropTable("ddf.UnitPaymentUnit");
            DropTable("ddf.UnitMaintenanceFeeType");
            DropTable("ddf.UnitLoadingType");
            DropTable("ddf.UnitLiveStockType");
            DropTable("ddf.UnitFlooringType");
            DropTable("ddf.UnitFeature");
            DropTable("ddf.UnitCoolingType");
            DropTable("ddf.BusinessBusinessType");
            DropTable("ddf.BusinessBusinessSubType");
            DropTable("ddf.UnitAppliance");
            DropTable("ddf.UnitAmenitiesNearby");
            DropTable("ddf.LandAmenitiesNearby");
            DropTable("ddf.LandTopographyType");
            DropTable("ddf.LandSurfaceWater");
            DropTable("ddf.LandSoilType");
            DropTable("ddf.LandSewer");
            DropTable("ddf.LandLandscapeFeature");
            DropTable("ddf.LandLandDispositionType");
            DropTable("ddf.LandFenceType");
            DropTable("ddf.LandCurrentUse");
            DropTable("ddf.BuildingUtilityWater");
            DropTable("ddf.BuildingUtilityPower");
            DropTable("ddf.BuildingUffiCode");
            DropTable("ddf.BuildingStructureType");
            DropTable("ddf.BuildingStoreFront");
            DropTable("ddf.BuildingSignType");
            DropTable("ddf.BuildingRoofStyle");
            DropTable("ddf.BuildingRoofMaterial");
            DropTable("ddf.BuildingRoadType");
            DropTable("ddf.BuildingPoolType");
            DropTable("ddf.BuildingPoolFeature");
            DropTable("ddf.BuildingMeasureUnit");
            DropTable("ddf.BuildingMachinery");
            DropTable("ddf.BuildingIrrigationType");
            DropTable("ddf.BuildingHeatingType");
            DropTable("ddf.BuildingHeatingFuel");
            DropTable("ddf.BuildingFoundationType");
            DropTable("ddf.BuildingFixture");
            DropTable("ddf.BuildingFireProtection");
            DropTable("ddf.BuildingFireplaceType");
            DropTable("ddf.BuildingFireplaceFuel");
            DropTable("ddf.BuildingFarmType");
            DropTable("ddf.BuildingExteriorFinish");
            DropTable("ddf.BuildingEquipmentType");
            DropTable("ddf.BuildingEasement");
            DropTable("ddf.BuildingDocumentType");
            DropTable("ddf.BuildingCrop");
            DropTable("ddf.BuildingConstructionMaterial");
            DropTable("ddf.BuildingCommunityFeature");
            DropTable("ddf.BuildingCommunicationType");
            DropTable("ddf.BuildingClearCeilingHeight");
            DropTable("ddf.BuildingCeilingType");
            DropTable("ddf.BuildingBuildingType");
            DropTable("ddf.BuildingBoard");
            DropTable("ddf.BuildingBasementType");
            DropTable("ddf.BuildingBasementFeature");
            DropTable("ddf.BuildingBasementDevelopment");
            DropTable("ddf.BuildingArchitecturalStyle");
            DropTable("ddf.BuildingAmperage");
            DropTable("ddf.BuildingAmenitie");
            DropTable("ddf.LandAccessType");
            DropTable("ddf.OfficeOrganizationType");
            DropTable("ddf.OfficeOrganizationDesignation");
            DropTable("ddf.OfficeFranchisor");
            DropTable("ddf.AgentSpecialty");
            DropTable("ddf.AgentIndividualDesignation");
            DropTable("ddf.AgentALanguage");
            DropTable("ddf.ZoningType");
            DropTable("ddf.WaterFrontType");
            DropTable("ddf.UtilityType");
            DropTable("ddf.SoilEvaluationType");
            DropTable("ddf.PropertyType");
            DropTable("ddfraw.PropertyUtilitiesAvailable");
            DropTable("ddfraw.PropertyPhoto");
            DropTable("ddfraw.PropertyParkingSpace");
            DropTable("ddfraw.PropertyOpenHouse");
            DropTable("ddfraw.PropertyLand");
            DropTable("ddfraw.PropertyBusiness");
            DropTable("ddfraw.PropertyBuildingRoom");
            DropTable("ddfraw.PropertyBuilding");
            DropTable("ddfraw.PropertyAlternateUrl");
            DropTable("ddfraw.PropertyAgentWebsite");
            DropTable("ddfraw.PropertyAgentTradingArea");
            DropTable("ddfraw.PropertyAgentSpeciality");
            DropTable("ddfraw.PropertyAgentPhone");
            DropTable("ddfraw.PropertyAgentOfficeWebsite");
            DropTable("ddfraw.PropertyAgentOfficePhone");
            DropTable("ddfraw.PropertyAgentOffice");
            DropTable("ddfraw.PropertyAgentLanguage");
            DropTable("ddfraw.PropertyAgentDesignation");
            DropTable("ddfraw.PropertyAgentContact");
            DropTable("ddfraw.PropertyAgent");
            DropTable("ddfraw.Property");
            DropTable("ddf.ParkingType");
            DropTable("ddf.OwnershipType");
            DropTable("ddf.LeaseType");
            DropTable("ddf.FrontsOn");
            DropTable("cdk.DevelopmentAmenities");
            DropTable("ddf.ConstructionStyleSplitLevel");
            DropTable("ddf.ConstructionStyleOther");
            DropTable("ddf.ConstructionStyleAttachment");
            DropTable("ddf.ConstructionStatu");
            DropTable("ddfraw.AuditDdfRequest");
            DropTable("ddf.ViewType");
            DropTable("ddf.UnitUtilitiesAvailable");
            DropTable("ddf.RoomType");
            DropTable("ddf.RoomLevel");
            DropTable("ddf.UnitRoom");
            DropTable("ddf.UnitPhoto");
            DropTable("ddf.UnitParkingSpace");
            DropTable("ddf.UnitOpenHouse");
            DropTable("ddf.TransactionType");
            DropTable("ddf.StorageType");
            DropTable("ddf.RightType");
            DropTable("ddf.RentalEquipmentType");
            DropTable("ddf.PaymentUnit");
            DropTable("ddf.MaintenanceFeeType");
            DropTable("ddf.LoadingType");
            DropTable("ddf.LiveStockType");
            DropTable("ddf.FlooringType");
            DropTable("ddf.Feature");
            DropTable("ddf.CoolingType");
            DropTable("ddf.BusinessType");
            DropTable("ddf.BusinessSubType");
            DropTable("ddf.Business");
            DropTable("ddf.Appliance");
            DropTable("ddf.TopographyType");
            DropTable("ddf.SurfaceWater");
            DropTable("ddf.SoilType");
            DropTable("ddf.Sewer");
            DropTable("ddf.LandscapeFeature");
            DropTable("ddf.LandDispositionType");
            DropTable("ddf.FenceType");
            DropTable("ddf.CurrentUse");
            DropTable("ddf.UtilityWater");
            DropTable("ddf.UtilityPower");
            DropTable("ddf.UffiCode");
            DropTable("ddf.StructureType");
            DropTable("ddf.StoreFront");
            DropTable("ddf.SignType");
            DropTable("ddf.RoofStyle");
            DropTable("ddf.RoofMaterial");
            DropTable("ddf.RoadType");
            DropTable("ddf.PoolType");
            DropTable("ddf.PoolFeature");
            DropTable("ddf.MeasureUnit");
            DropTable("ddf.Machinery");
            DropTable("ddf.IrrigationType");
            DropTable("ddf.HeatingType");
            DropTable("ddf.HeatingFuel");
            DropTable("ddf.FoundationType");
            DropTable("ddf.Fixture");
            DropTable("ddf.FireProtection");
            DropTable("ddf.FireplaceType");
            DropTable("ddf.FireplaceFuel");
            DropTable("ddf.FarmType");
            DropTable("ddf.ExteriorFinish");
            DropTable("ddf.EquipmentType");
            DropTable("ddf.Easement");
            DropTable("ddf.DocumentType");
            DropTable("ddf.Crop");
            DropTable("ddf.ConstructionMaterial");
            DropTable("ddf.CommunityFeature");
            DropTable("ddf.CommunicationType");
            DropTable("ddf.ClearCeilingHeight");
            DropTable("ddf.CeilingType");
            DropTable("ddf.BuildingType");
            DropTable("cdk.NeighborhoodGuideVideo");
            DropTable("cdk.NeighborhoodGuidePhoto");
            DropTable("cdk.NeighborhoodGuide");
            DropTable("cdk.MetroArea");
            DropTable("cdk.DevelopmentVideo");
            DropTable("cdk.DevelopmentPhoto");
            DropTable("cdk.DevelopmentFloorPlan");
            DropTable("cdk.Developer");
            DropTable("cdk.Development");
            DropTable("cdk.DevelopmentAddress");
            DropTable("cdk.NeighborhoodArea");
            DropTable("ddf.BuildingAddress");
            DropTable("ddf.Board");
            DropTable("ddf.BasementType");
            DropTable("ddf.BasementFeature");
            DropTable("ddf.BasementDevelopment");
            DropTable("ddf.ArchitecturalStyle");
            DropTable("ddf.Amperage");
            DropTable("ddf.Amenitie");
            DropTable("ddf.Building");
            DropTable("ddf.AccessType");
            DropTable("ddf.BuildingLand");
            DropTable("ddf.AmenitiesNearby");
            DropTable("ddf.Unit");
            DropTable("ddf.UnitAgentWebsite");
            DropTable("ddf.UnitAgentTradingArea");
            DropTable("ddf.UnitAgentSpeciality");
            DropTable("ddf.UnitAgentPhone");
            DropTable("ddf.UnitAgentOfficeWebsite");
            DropTable("ddf.UnitAgentOfficePhone");
            DropTable("ddf.OrganizationType");
            DropTable("ddf.OrganizationDesignation");
            DropTable("ddf.Franchisor");
            DropTable("ddf.UnitAgentOffice");
            DropTable("ddf.UnitAgentLanguage");
            DropTable("ddf.UnitAgentDesignation");
            DropTable("ddf.UnitAgentContact");
            DropTable("ddf.Specialtie");
            DropTable("ddf.IndividualDesignation");
            DropTable("ddf.ALanguage");
            DropTable("ddf.UnitAgent");
            DropTable("ddf.ABoard");
        }
    }
}
namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DeleteDdfrawScheme : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "client.Roles", newSchema: "cdk");
            MoveTable(name: "client.Users", newSchema: "cdk");
            MoveTable(name: "client.UserClaims", newSchema: "cdk");
            MoveTable(name: "client.UserLogins", newSchema: "cdk");
            DropForeignKey("ddfraw.PropertyPropertyAgent", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyPropertyAgent", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyAgentContact", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentDesignation", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentLanguage", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentOfficePhone", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice");
            DropForeignKey("ddfraw.PropertyAgentOfficeWebsite", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice");
            DropForeignKey("ddfraw.PropertyAgent", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice");
            DropForeignKey("ddfraw.PropertyAgentPhone", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentSpeciality", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentTradingArea", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAgentWebsite", "PropertyAgentId", "ddfraw.PropertyAgent");
            DropForeignKey("ddfraw.PropertyAlternateUrl", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyBuilding", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyBuildingRoom", "PropertyId", "ddfraw.PropertyBuilding");
            DropForeignKey("ddfraw.PropertyBusiness", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyLand", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyOpenHouse", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyParkingSpace", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyPhoto", "PropertyId", "ddfraw.Property");
            DropForeignKey("ddfraw.PropertyUtilitiesAvailable", "PropertyId", "ddfraw.Property");
            DropIndex("ddfraw.PropertyAgent", new[] { "PropertyAgentOfficeId" });
            DropIndex("ddfraw.PropertyAgentContact", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentDesignation", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentLanguage", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentOfficePhone", new[] { "PropertyAgentOfficeId" });
            DropIndex("ddfraw.PropertyAgentOfficeWebsite", new[] { "PropertyAgentOfficeId" });
            DropIndex("ddfraw.PropertyAgentPhone", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentSpeciality", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentTradingArea", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAgentWebsite", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyAlternateUrl", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyBuilding", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyBuildingRoom", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyBusiness", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyLand", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyOpenHouse", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyParkingSpace", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyPhoto", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyUtilitiesAvailable", new[] { "PropertyId" });
            DropIndex("ddfraw.PropertyPropertyAgent", new[] { "PropertyAgentId" });
            DropIndex("ddfraw.PropertyPropertyAgent", new[] { "PropertyId" });
            DropTable("ddfraw.AuditDdfRequest");
            DropTable("ddfraw.Property");
            DropTable("ddfraw.PropertyAgent");
            DropTable("ddfraw.PropertyAgentContact");
            DropTable("ddfraw.PropertyAgentDesignation");
            DropTable("ddfraw.PropertyAgentLanguage");
            DropTable("ddfraw.PropertyAgentOffice");
            DropTable("ddfraw.PropertyAgentOfficePhone");
            DropTable("ddfraw.PropertyAgentOfficeWebsite");
            DropTable("ddfraw.PropertyAgentPhone");
            DropTable("ddfraw.PropertyAgentSpeciality");
            DropTable("ddfraw.PropertyAgentTradingArea");
            DropTable("ddfraw.PropertyAgentWebsite");
            DropTable("ddfraw.PropertyAlternateUrl");
            DropTable("ddfraw.PropertyBuilding");
            DropTable("ddfraw.PropertyBuildingRoom");
            DropTable("ddfraw.PropertyBusiness");
            DropTable("ddfraw.PropertyLand");
            DropTable("ddfraw.PropertyOpenHouse");
            DropTable("ddfraw.PropertyParkingSpace");
            DropTable("ddfraw.PropertyPhoto");
            DropTable("ddfraw.PropertyUtilitiesAvailable");
            DropTable("ddf.PropertyType");
            DropTable("ddfraw.PropertyPropertyAgent");
        }

        public override void Down()
        {
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
                });

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
                "ddfraw.PropertyUtilitiesAvailable",
                c => new
                {
                    PropertyUtilitiesAvailableId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    Type = c.String(maxLength: 255, unicode: false),
                    Description = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyUtilitiesAvailableId);

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
                .PrimaryKey(t => t.PropertyPhotoId);

            CreateTable(
                "ddfraw.PropertyParkingSpace",
                c => new
                {
                    PropertyParkingSpaceId = c.Long(nullable: false, identity: true),
                    PropertyId = c.Long(nullable: false),
                    Name = c.String(maxLength: 255, unicode: false),
                    Spaces = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyParkingSpaceId);

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
                .PrimaryKey(t => t.PropertyOpenHouseId);

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
                .PrimaryKey(t => t.PropertyId);

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
                .PrimaryKey(t => t.PropertyId);

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
                .PrimaryKey(t => t.PropertyBuildingRoomId);

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
                .PrimaryKey(t => t.PropertyId);

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
                .PrimaryKey(t => t.PropertyId);

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
                .PrimaryKey(t => t.PropertyAgentWebsiteId);

            CreateTable(
                "ddfraw.PropertyAgentTradingArea",
                c => new
                {
                    PropertyAgentTradingAreaId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    TradingArea = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentTradingAreaId);

            CreateTable(
                "ddfraw.PropertyAgentSpeciality",
                c => new
                {
                    PropertyAgentSpecialityId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    Specialtie = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentSpecialityId);

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
                .PrimaryKey(t => t.PropertyAgentPhoneId);

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
                .PrimaryKey(t => t.PropertyAgentOfficeWebsiteId);

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
                .PrimaryKey(t => t.PropertyAgentOfficePhoneId);

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
                "ddfraw.PropertyAgentLanguage",
                c => new
                {
                    PropertyAgentLanguageId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    Language = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentLanguageId);

            CreateTable(
                "ddfraw.PropertyAgentDesignation",
                c => new
                {
                    PropertyAgentDesignationId = c.Long(nullable: false, identity: true),
                    PropertyAgentId = c.Long(nullable: false),
                    Designation = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.PropertyAgentDesignationId);

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
                .PrimaryKey(t => t.PropertyAgentContactId);

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
                .PrimaryKey(t => t.PropertyAgentId);

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
                "ddfraw.AuditDdfRequest",
                c => new
                {
                    RequestId = c.Long(nullable: false, identity: true),
                    Status = c.String(maxLength: 255, unicode: false),
                    Xml = c.String(unicode: false),
                    DdfLastUpdate = c.DateTime(),
                })
                .PrimaryKey(t => t.RequestId);

            CreateIndex("ddfraw.PropertyPropertyAgent", "PropertyId");
            CreateIndex("ddfraw.PropertyPropertyAgent", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyUtilitiesAvailable", "PropertyId");
            CreateIndex("ddfraw.PropertyPhoto", "PropertyId");
            CreateIndex("ddfraw.PropertyParkingSpace", "PropertyId");
            CreateIndex("ddfraw.PropertyOpenHouse", "PropertyId");
            CreateIndex("ddfraw.PropertyLand", "PropertyId");
            CreateIndex("ddfraw.PropertyBusiness", "PropertyId");
            CreateIndex("ddfraw.PropertyBuildingRoom", "PropertyId");
            CreateIndex("ddfraw.PropertyBuilding", "PropertyId");
            CreateIndex("ddfraw.PropertyAlternateUrl", "PropertyId");
            CreateIndex("ddfraw.PropertyAgentWebsite", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgentTradingArea", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgentSpeciality", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgentPhone", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgentOfficeWebsite", "PropertyAgentOfficeId");
            CreateIndex("ddfraw.PropertyAgentOfficePhone", "PropertyAgentOfficeId");
            CreateIndex("ddfraw.PropertyAgentLanguage", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgentDesignation", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgentContact", "PropertyAgentId");
            CreateIndex("ddfraw.PropertyAgent", "PropertyAgentOfficeId");
            AddForeignKey("ddfraw.PropertyUtilitiesAvailable", "PropertyId", "ddfraw.Property", "PropertyId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyPhoto", "PropertyId", "ddfraw.Property", "PropertyId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyParkingSpace", "PropertyId", "ddfraw.Property", "PropertyId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyOpenHouse", "PropertyId", "ddfraw.Property", "PropertyId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyLand", "PropertyId", "ddfraw.Property", "PropertyId");
            AddForeignKey("ddfraw.PropertyBusiness", "PropertyId", "ddfraw.Property", "PropertyId");
            AddForeignKey("ddfraw.PropertyBuildingRoom", "PropertyId", "ddfraw.PropertyBuilding", "PropertyId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyBuilding", "PropertyId", "ddfraw.Property", "PropertyId");
            AddForeignKey("ddfraw.PropertyAlternateUrl", "PropertyId", "ddfraw.Property", "PropertyId");
            AddForeignKey("ddfraw.PropertyAgentWebsite", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentTradingArea", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentSpeciality", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentPhone", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgent", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice", "PropertyAgentOfficeId");
            AddForeignKey("ddfraw.PropertyAgentOfficeWebsite", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice", "PropertyAgentOfficeId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentOfficePhone", "PropertyAgentOfficeId", "ddfraw.PropertyAgentOffice", "PropertyAgentOfficeId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentLanguage", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentDesignation", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyAgentContact", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId");
            AddForeignKey("ddfraw.PropertyPropertyAgent", "PropertyId", "ddfraw.Property", "PropertyId", cascadeDelete: true);
            AddForeignKey("ddfraw.PropertyPropertyAgent", "PropertyAgentId", "ddfraw.PropertyAgent", "PropertyAgentId", cascadeDelete: true);
            MoveTable(name: "cdk.UserLogins", newSchema: "client");
            MoveTable(name: "cdk.UserClaims", newSchema: "client");
            MoveTable(name: "cdk.Users", newSchema: "client");
            MoveTable(name: "cdk.Roles", newSchema: "client");
        }
    }
}
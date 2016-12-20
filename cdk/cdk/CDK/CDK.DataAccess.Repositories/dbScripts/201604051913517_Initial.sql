IF schema_id('ddf') IS NULL
    EXECUTE('CREATE SCHEMA [ddf]')
CREATE TABLE [ddf].[ABoard] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ABoard] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UnitAgent] (
    [UnitAgentId] [bigint] NOT NULL,
    [UnitAgentOfficeId] [bigint],
    [DdfAgentId] [varchar](255),
    [Name] [varchar](255),
    [Position] [varchar](255),
    [LastUpdate] [datetime] NOT NULL,
    [EducationCredentials] [varchar](255),
    [PhotoLastUpdated] [datetime],
    [StreetAddress] [varchar](255),
    [AddressLine1] [varchar](255),
    [Addressline2] [varchar](255),
    [StreetNumber] [varchar](255),
    [StreetName] [varchar](255),
    [StreetSuffix] [varchar](255),
    [City] [varchar](255),
    [Province] [varchar](255),
    [PostalCode] [varchar](255),
    [LogoUri] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgent] PRIMARY KEY ([UnitAgentId])
)
CREATE TABLE [ddf].[ALanguage] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ALanguage] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[IndividualDesignation] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.IndividualDesignation] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Specialtie] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Specialtie] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UnitAgentContact] (
    [UnitAgentContactId] [bigint] NOT NULL IDENTITY,
    [ContactType] [varchar](255),
    [AgentType] [varchar](255),
    [TextValue] [varchar](255),
    [LastUpdate] [datetime] NOT NULL,
    [UnitAgentId] [bigint],
    CONSTRAINT [PK_ddf.UnitAgentContact] PRIMARY KEY ([UnitAgentContactId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentContact]([UnitAgentId])
CREATE TABLE [ddf].[UnitAgentDesignation] (
    [UnitAgentDesignationId] [bigint] NOT NULL IDENTITY,
    [UnitAgentId] [bigint] NOT NULL,
    [Designation] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentDesignation] PRIMARY KEY ([UnitAgentDesignationId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentDesignation]([UnitAgentId])
CREATE TABLE [ddf].[UnitAgentLanguage] (
    [UnitAgentLanguageId] [bigint] NOT NULL IDENTITY,
    [UnitAgentId] [bigint] NOT NULL,
    [Language] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentLanguage] PRIMARY KEY ([UnitAgentLanguageId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentLanguage]([UnitAgentId])
CREATE TABLE [ddf].[UnitAgentOffice] (
    [UnitAgentOfficeId] [bigint] NOT NULL,
    [UnitAgentId] [bigint],
    [DdfUnitAgentOfficeId] [varchar](255),
    [Name] [varchar](255),
    [StreetAddress] [varchar](255),
    [AddressLine1] [varchar](255),
    [City] [varchar](255),
    [PostalCode] [varchar](255),
    [Country] [varchar](255),
    [Franchisor] [varchar](255),
    [LogoLastUpdated] [varchar](255),
    [LogoUri] [varchar](255),
    [OrganizationType] [varchar](255),
    [Designation] [varchar](255),
    [LastUpdate] [datetime] NOT NULL,
    CONSTRAINT [PK_ddf.UnitAgentOffice] PRIMARY KEY ([UnitAgentOfficeId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentOffice]([UnitAgentId])
CREATE TABLE [ddf].[Franchisor] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Franchisor] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[OrganizationDesignation] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.OrganizationDesignation] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[OrganizationType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.OrganizationType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UnitAgentOfficePhone] (
    [UnitAgentOfficePhoneId] [bigint] NOT NULL IDENTITY,
    [UnitAgentOfficeId] [bigint] NOT NULL,
    [ContactType] [varchar](255),
    [PhoneType] [varchar](255),
    [PhoneNumber] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentOfficePhone] PRIMARY KEY ([UnitAgentOfficePhoneId])
)
CREATE INDEX [IX_UnitAgentOfficeId] ON [ddf].[UnitAgentOfficePhone]([UnitAgentOfficeId])
CREATE TABLE [ddf].[UnitAgentOfficeWebsite] (
    [UnitAgentOfficeWebsiteId] [bigint] NOT NULL IDENTITY,
    [UnitAgentOfficeId] [bigint] NOT NULL,
    [ContactType] [varchar](255),
    [WebsiteType] [varchar](255),
    [WebsiteUrl] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentOfficeWebsite] PRIMARY KEY ([UnitAgentOfficeWebsiteId])
)
CREATE INDEX [IX_UnitAgentOfficeId] ON [ddf].[UnitAgentOfficeWebsite]([UnitAgentOfficeId])
CREATE TABLE [ddf].[UnitAgentPhone] (
    [UnitAgentPhoneId] [bigint] NOT NULL IDENTITY,
    [UnitAgentId] [bigint] NOT NULL,
    [ContactType] [varchar](255),
    [PhoneType] [varchar](255),
    [PhoneNumber] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentPhone] PRIMARY KEY ([UnitAgentPhoneId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentPhone]([UnitAgentId])
CREATE TABLE [ddf].[UnitAgentSpeciality] (
    [UnitAgentSpecialityId] [bigint] NOT NULL IDENTITY,
    [UnitAgentId] [bigint] NOT NULL,
    [Specialtie] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentSpeciality] PRIMARY KEY ([UnitAgentSpecialityId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentSpeciality]([UnitAgentId])
CREATE TABLE [ddf].[UnitAgentTradingArea] (
    [UnitAgentTradingAreaId] [bigint] NOT NULL IDENTITY,
    [UnitAgentId] [bigint] NOT NULL,
    [TradingArea] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentTradingArea] PRIMARY KEY ([UnitAgentTradingAreaId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentTradingArea]([UnitAgentId])
CREATE TABLE [ddf].[UnitAgentWebsite] (
    [UnitAgentWebsiteId] [bigint] NOT NULL IDENTITY,
    [UnitAgentId] [bigint] NOT NULL,
    [ContactType] [varchar](255),
    [WebsiteType] [varchar](255),
    [WebsiteUrl] [varchar](255),
    CONSTRAINT [PK_ddf.UnitAgentWebsite] PRIMARY KEY ([UnitAgentWebsiteId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitAgentWebsite]([UnitAgentId])
CREATE TABLE [ddf].[Unit] (
    [UnitId] [bigint] NOT NULL IDENTITY,
    [BuildingId] [bigint] NOT NULL,
    [DdfUnitId] [varchar](255),
    [HalfBathTotal] [varchar](255),
    [BathroomTotal] [varchar](255),
    [BedroomsAboveGround] [varchar](255),
    [BedroomsBelowGround] [varchar](255),
    [BedroomsTotal] [varchar](255),
    [CeilingHeight] [varchar](255),
    [SizeInterior] [varchar](255),
    [SizeInteriorFinished] [varchar](255),
    [TotalFinishedArea] [varchar](255),
    [Lease] [varchar](255),
    [LeasePerTime] [varchar](255),
    [LeasePerUnit] [varchar](255),
    [LeaseTermRemaining] [varchar](255),
    [LeaseTermRemainingFreq] [varchar](255),
    [MaintenanceFee] [varchar](255),
    [MaintenanceFeePaymentUnit] [varchar](255),
    [ParkingSpaceTotal] [varchar](255),
    [Plan] [varchar](255),
    [Price] [varchar](255),
    [PricePerTime] [varchar](255),
    [PricePerUnit] [varchar](255),
    [PropertyType] [varchar](255),
    [PublicRemarks] [varchar](max),
    [AdditionalInformationIndicator] [varchar](255),
    [MoreInformationLink] [varchar](255),
    [LastDdfUpdate] [datetime] NOT NULL,
    [LastUpdate] [datetime] NOT NULL,
    [UnitUri] [varchar](255),
    CONSTRAINT [PK_ddf.Unit] PRIMARY KEY ([UnitId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[Unit]([BuildingId])
CREATE TABLE [ddf].[AmenitiesNearby] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.AmenitiesNearby] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[BuildingLand] (
    [BuildingId] [bigint] NOT NULL,
    [SizeTotal] [varchar](255),
    [SizeTotalText] [varchar](255),
    [SizeFrontage] [varchar](255),
    [AccessType] [varchar](255),
    [Acreage] [varchar](255),
    [Amenities] [varchar](255),
    [ClearedTotal] [varchar](255),
    [CurrentUse] [varchar](255),
    [Divisible] [varchar](255),
    [FenceTotal] [varchar](255),
    [FenceType] [varchar](255),
    [FrontsOn] [varchar](255),
    [LandDisposition] [varchar](255),
    [LandscapeFeatures] [varchar](255),
    [PastureTotal] [varchar](255),
    [Sewer] [varchar](255),
    [SizeDepth] [varchar](255),
    [SizeIrregular] [varchar](255),
    [SoilEvaluation] [varchar](255),
    [SoilType] [varchar](255),
    [SurfaceWater] [varchar](255),
    [TiledTotal] [varchar](255),
    [TopographyType] [varchar](255),
    [LastUpdate] [datetime],
    CONSTRAINT [PK_ddf.BuildingLand] PRIMARY KEY ([BuildingId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingLand]([BuildingId])
CREATE TABLE [ddf].[AccessType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.AccessType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Building] (
    [BuildingId] [bigint] NOT NULL IDENTITY,
    [BuildingAddressId] [bigint],
    [BuildingUri] [varchar](255),
    [Age] [varchar](255),
    [Board] [varchar](255),
    [Anchor] [varchar](255),
    [BomaRating] [varchar](255),
    [ConstructedDate] [varchar](255),
    [EnerguideRating] [varchar](255),
    [FireplacePresent] [varchar](255),
    [FireplaceTotal] [varchar](255),
    [LeedsCategory] [varchar](255),
    [LeedsRating] [varchar](255),
    [RenovatedDate] [varchar](255),
    [StoriesTotal] [varchar](255),
    [SizeExterior] [varchar](255),
    [ManagementCompany] [varchar](255),
    [Type] [varchar](255),
    [Structure] [varchar](255),
    [MunicipalId] [varchar](255),
    [Uffi] [varchar](255),
    [UnitType] [varchar](255),
    [VacancyRate] [varchar](255),
    [ZoningType] [varchar](255),
    [ZoningDescription] [varchar](255),
    [TotalBuildings] [varchar](255),
    [WaterFrontName] [varchar](255),
    [LocationDescription] [varchar](255),
    [LastDdfUpdate] [datetime] NOT NULL,
    [LastUpdate] [datetime] NOT NULL,
    CONSTRAINT [PK_ddf.Building] PRIMARY KEY ([BuildingId])
)
CREATE INDEX [IX_BuildingAddressId] ON [ddf].[Building]([BuildingAddressId])
CREATE TABLE [ddf].[Amenitie] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Amenitie] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Amperage] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Amperage] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ArchitecturalStyle] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ArchitecturalStyle] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[BasementDevelopment] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.BasementDevelopment] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[BasementFeature] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.BasementFeature] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[BasementType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.BasementType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Board] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Board] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[BuildingAddress] (
    [BuildingAddressId] [bigint] NOT NULL IDENTITY,
    [StreetAddress] [varchar](255),
    [City] [varchar](255),
    [CountryState] [varchar](255),
    [PostalCode] [varchar](255),
    [Country] [varchar](255),
    [Lon] [varchar](255),
    [Lat] [varchar](255),
    [AddressType] [varchar](255),
    [AdditionalStreetInfo] [varchar](255),
    [DdfCommunityName] [varchar](255),
    [Neighbourhood] [varchar](255),
    [Subdivision] [varchar](255),
    [PositionGeo] [geography],
    [NeighborhoodAreaId] [bigint],
    CONSTRAINT [PK_ddf.BuildingAddress] PRIMARY KEY ([BuildingAddressId])
)
CREATE INDEX [IX_NeighborhoodAreaId] ON [ddf].[BuildingAddress]([NeighborhoodAreaId])
IF schema_id('cdk') IS NULL
    EXECUTE('CREATE SCHEMA [cdk]')
CREATE TABLE [cdk].[NeighborhoodArea] (
    [Id] [bigint] NOT NULL IDENTITY,
    [MetroAreaId] [bigint],
    [NeighborhoodAreaExtId] [bigint],
    [NeighborhoodAreaExtVersion] [varchar](255),
    [ParentId] [bigint],
    [Name] [varchar](255),
    [ShortName] [varchar](255),
    [Description] [varchar](max),
    [CenterPointGeo] [geography],
    [CenterPointLat] [varchar](255),
    [CenterPointLon] [varchar](255),
    [CoordinatesGeo] [geography],
    [CoordinatesAsText] [varchar](max),
    [NeighborhoodAreaUri] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.NeighborhoodArea] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_MetroAreaId] ON [cdk].[NeighborhoodArea]([MetroAreaId])
CREATE TABLE [cdk].[DevelopmentAddress] (
    [Id] [bigint] NOT NULL,
    [NeighborhoodAreaId] [bigint],
    [StreetAddress] [varchar](255),
    [City] [varchar](255),
    [CountryState] [varchar](255),
    [PostalCode] [varchar](255),
    [Country] [varchar](255),
    [Lon] [varchar](255),
    [Lat] [varchar](255),
    [PositionGeo] [geography],
    [StreetType] [varchar](255),
    [AdditionalStreetInfo] [varchar](255),
    [CommunityName] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.DevelopmentAddress] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Id] ON [cdk].[DevelopmentAddress]([Id])
CREATE INDEX [IX_NeighborhoodAreaId] ON [cdk].[DevelopmentAddress]([NeighborhoodAreaId])
CREATE TABLE [cdk].[Development] (
    [Id] [bigint] NOT NULL IDENTITY,
    [DeveloperId] [bigint] NOT NULL,
    [Name] [varchar](255),
    [PrimaryContactName] [varchar](255),
    [PrimaryContactEmail] [varchar](255),
    [PrimaryContactPhone] [varchar](255),
    [SecondaryContactName] [varchar](255),
    [SecondaryContactEmail] [varchar](255),
    [SecondaryContactPhone] [varchar](255),
    [ProjectWebsiteUrl] [varchar](255),
    [ProjectFacebookUrl] [varchar](255),
    [ProjectTwiterUrl] [varchar](255),
    [ProjectGooglePlusUrl] [varchar](255),
    [SalesCenterPhoneNumber] [varchar](255),
    [SalesCenterAddress] [varchar](255),
    [SalesCenterPhone] [varchar](255),
    [SalesCenterOpenHours] [varchar](max),
    [ConstructuedYear] [varchar](4),
    [ForSale] [bit],
    [ForRent] [bit],
    [BuildingType] [varchar](255),
    [Community] [varchar](255),
    [PriceAveragePerSqrFeet] [decimal](10, 2),
    [TotalNumberOfUnits] [int],
    [TotalNumberOfStories] [int],
    [SalesCompany] [varchar](255),
    [MarketingCompany] [varchar](255),
    [Architects] [varchar](255),
    [InteriorDesigner] [varchar](255),
    [ProjectSummary] [varchar](max),
    [ShortProjectSummary] [varchar](max),
    [ProjectAmenities] [varchar](255),
    [CurrentIncentives] [varchar](255),
    [LogoUri] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.Development] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_DeveloperId] ON [cdk].[Development]([DeveloperId])
CREATE TABLE [cdk].[Developer] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Name] [varchar](255),
    [PrimaryContactName] [varchar](255),
    [PrimaryContactEmail] [varchar](255),
    [SecondaryContactName] [varchar](255),
    [SecondaryContactEmail] [varchar](255),
    [DeveloperAddress] [varchar](255),
    [Description] [varchar](max),
    [ShortDescription] [varchar](max),
    [LogoUri] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.Developer] PRIMARY KEY ([Id])
)
CREATE TABLE [cdk].[DevelopmentFloorPlan] (
    [Id] [bigint] NOT NULL IDENTITY,
    [DevelopmentId] [bigint] NOT NULL,
    [Name] [varchar](255),
    [Type] [varchar](255),
    [Beds] [varchar](255),
    [Baths] [varchar](255),
    [PropertyTaxe] [varchar](255),
    [InteriorSize] [varchar](255),
    [OwnershipType] [varchar](255),
    [CondoMonthlyFees] [decimal](10, 2),
    [BalconeySize] [varchar](255),
    [PhotoName] [varchar](255),
    [PhotoType] [varchar](255),
    [PhotoUri] [varchar](255),
    [SequenceNumber] [varchar](255),
    [PropertyTaxePeriod] [varchar](255),
    [CondoFeesPeriod] [varchar](255),
    [InteriorSizeType] [varchar](255),
    [BalconeySizeType] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.DevelopmentFloorPlan] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_DevelopmentId] ON [cdk].[DevelopmentFloorPlan]([DevelopmentId])
CREATE TABLE [cdk].[DevelopmentPhoto] (
    [Id] [bigint] NOT NULL IDENTITY,
    [DevelopmentId] [bigint] NOT NULL,
    [PhotoName] [varchar](255),
    [PhotoType] [varchar](255),
    [PhotoUri] [varchar](255),
    [SequenceNumber] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.DevelopmentPhoto] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_DevelopmentId] ON [cdk].[DevelopmentPhoto]([DevelopmentId])
CREATE TABLE [cdk].[DevelopmentVideo] (
    [Id] [bigint] NOT NULL IDENTITY,
    [DevelopmentId] [bigint] NOT NULL,
    [VideoName] [varchar](255),
    [VideoType] [varchar](255),
    [VideoUri] [varchar](255),
    [SequenceNumber] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.DevelopmentVideo] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_DevelopmentId] ON [cdk].[DevelopmentVideo]([DevelopmentId])
CREATE TABLE [cdk].[MetroArea] (
    [Id] [bigint] NOT NULL IDENTITY,
    [MetroAreaExtId] [bigint],
    [MetroAreaExtVersion] [varchar](255),
    [Name] [varchar](255),
    [ShortName] [varchar](255),
    [State] [varchar](255),
    [Country] [varchar](255),
    [Description] [varchar](max),
    [CenterPointGeo] [geography],
    [CenterPointLat] [varchar](255),
    [CenterPointLon] [varchar](255),
    [CoordinatesGeo] [geography],
    [CoordinatesAsText] [varchar](max),
    [MetroAreaUri] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.MetroArea] PRIMARY KEY ([Id])
)
CREATE TABLE [cdk].[NeighborhoodGuide] (
    [Id] [bigint] NOT NULL IDENTITY,
    [NeighborhoodAreaId] [bigint],
    [TagLine] [varchar](255),
    [WhatToExpect] [varchar](max),
    [Demographics] [varchar](max),
    [Lifestyle] [varchar](max),
    [WhatYoullLove] [varchar](max),
    [Source] [varchar](max),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.NeighborhoodGuide] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_NeighborhoodAreaId] ON [cdk].[NeighborhoodGuide]([NeighborhoodAreaId])
CREATE TABLE [cdk].[NeighborhoodGuidePhoto] (
    [Id] [bigint] NOT NULL IDENTITY,
    [NeighborhoodGuideId] [bigint] NOT NULL,
    [PhotoSmallUri] [varchar](255),
    [PhotoLargeUri] [varchar](255),
    [Description] [varchar](max),
    [LastUpdate] [datetime] NOT NULL,
    CONSTRAINT [PK_cdk.NeighborhoodGuidePhoto] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_NeighborhoodGuideId] ON [cdk].[NeighborhoodGuidePhoto]([NeighborhoodGuideId])
CREATE TABLE [cdk].[NeighborhoodGuideVideo] (
    [Id] [bigint] NOT NULL IDENTITY,
    [NeighborhoodGuideId] [bigint] NOT NULL,
    [VideoUri] [varchar](255),
    [Description] [varchar](max),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.NeighborhoodGuideVideo] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_NeighborhoodGuideId] ON [cdk].[NeighborhoodGuideVideo]([NeighborhoodGuideId])
CREATE TABLE [ddf].[BuildingType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.BuildingType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[CeilingType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.CeilingType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ClearCeilingHeight] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ClearCeilingHeight] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[CommunicationType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.CommunicationType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[CommunityFeature] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.CommunityFeature] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ConstructionMaterial] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ConstructionMaterial] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Crop] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Crop] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[DocumentType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.DocumentType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Easement] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Easement] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[EquipmentType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.EquipmentType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ExteriorFinish] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ExteriorFinish] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FarmType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FarmType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FireplaceFuel] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FireplaceFuel] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FireplaceType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FireplaceType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FireProtection] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FireProtection] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Fixture] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Fixture] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FoundationType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FoundationType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[HeatingFuel] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.HeatingFuel] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[HeatingType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.HeatingType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[IrrigationType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.IrrigationType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Machinery] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Machinery] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[MeasureUnit] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.MeasureUnit] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[PoolFeature] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.PoolFeature] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[PoolType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.PoolType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[RoadType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RoadType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[RoofMaterial] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RoofMaterial] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[RoofStyle] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RoofStyle] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[SignType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.SignType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[StoreFront] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.StoreFront] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[StructureType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.StructureType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UffiCode] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.UffiCode] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UtilityPower] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.UtilityPower] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UtilityWater] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.UtilityWater] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[CurrentUse] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.CurrentUse] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FenceType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FenceType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[LandDispositionType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.LandDispositionType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[LandscapeFeature] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.LandscapeFeature] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Sewer] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Sewer] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[SoilType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.SoilType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[SurfaceWater] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.SurfaceWater] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[TopographyType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.TopographyType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Appliance] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Appliance] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Business] (
    [UnitId] [bigint] NOT NULL,
    [BusinessType] [varchar](255),
    [BusinessSubType] [varchar](255),
    [EstablishedDate] [varchar](255),
    [Franchise] [varchar](255),
    [Name] [varchar](255),
    [OperatingSince] [varchar](255),
    CONSTRAINT [PK_ddf.Business] PRIMARY KEY ([UnitId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[Business]([UnitId])
CREATE TABLE [ddf].[BusinessSubType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.BusinessSubType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[BusinessType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.BusinessType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[CoolingType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.CoolingType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[Feature] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.Feature] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FlooringType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FlooringType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[LiveStockType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.LiveStockType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[LoadingType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.LoadingType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[MaintenanceFeeType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.MaintenanceFeeType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[PaymentUnit] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.PaymentUnit] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[RentalEquipmentType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RentalEquipmentType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[RightType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RightType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[StorageType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.StorageType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[TransactionType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.TransactionType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UnitOpenHouse] (
    [UnitOpenHouseId] [bigint] NOT NULL IDENTITY,
    [UnitId] [bigint] NOT NULL,
    [StartDateTime] [varchar](255),
    [EndDateTime] [varchar](255),
    [Comments] [varchar](255),
    CONSTRAINT [PK_ddf.UnitOpenHouse] PRIMARY KEY ([UnitOpenHouseId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[UnitOpenHouse]([UnitId])
CREATE TABLE [ddf].[UnitParkingSpace] (
    [UnitParkingSpaceId] [bigint] NOT NULL IDENTITY,
    [UnitId] [bigint] NOT NULL,
    [Name] [varchar](255),
    [Spaces] [varchar](255),
    CONSTRAINT [PK_ddf.UnitParkingSpace] PRIMARY KEY ([UnitParkingSpaceId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[UnitParkingSpace]([UnitId])
CREATE TABLE [ddf].[UnitPhoto] (
    [UnitPhotoId] [bigint] NOT NULL IDENTITY,
    [UnitId] [bigint] NOT NULL,
    [DdfSequenceId] [varchar](255),
    [DdfPropertyId] [varchar](255),
    [FolderPath] [varchar](255),
    [PhotoType] [varchar](255),
    [PhotoThumbnailUri] [varchar](255),
    [PhotoSmallUri] [varchar](255),
    [PhotoLargeUri] [varchar](255),
    [LastDdfUpdate] [datetime] NOT NULL,
    [LastUpdate] [datetime] NOT NULL,
    CONSTRAINT [PK_ddf.UnitPhoto] PRIMARY KEY ([UnitPhotoId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[UnitPhoto]([UnitId])
CREATE TABLE [ddf].[UnitRoom] (
    [UnitRoomId] [bigint] NOT NULL IDENTITY,
    [UnitId] [bigint] NOT NULL,
    [TypeId] [bigint],
    [Width] [varchar](255),
    [Length] [varchar](255),
    [LevelId] [bigint],
    [Dimension] [varchar](255),
    [Description] [varchar](255),
    [LastUpdate] [datetime] NOT NULL,
    CONSTRAINT [PK_ddf.UnitRoom] PRIMARY KEY ([UnitRoomId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[UnitRoom]([UnitId])
CREATE INDEX [IX_TypeId] ON [ddf].[UnitRoom]([TypeId])
CREATE INDEX [IX_LevelId] ON [ddf].[UnitRoom]([LevelId])
CREATE TABLE [ddf].[RoomLevel] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RoomLevel] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[RoomType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.RoomType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UnitUtilitiesAvailable] (
    [UnitUtilitiesAvailableId] [bigint] NOT NULL IDENTITY,
    [UnitId] [bigint] NOT NULL,
    [Type] [varchar](255),
    [Description] [varchar](255),
    CONSTRAINT [PK_ddf.UnitUtilitiesAvailable] PRIMARY KEY ([UnitUtilitiesAvailableId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[UnitUtilitiesAvailable]([UnitId])
CREATE TABLE [ddf].[ViewType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ViewType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ConstructionStatu] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ConstructionStatu] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ConstructionStyleAttachment] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ConstructionStyleAttachment] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ConstructionStyleOther] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ConstructionStyleOther] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ConstructionStyleSplitLevel] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ConstructionStyleSplitLevel] PRIMARY KEY ([Id])
)
CREATE TABLE [cdk].[DevelopmentAmenities] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Name] [varchar](255),
    [Description] [varchar](max),
    [IconUri] [varchar](255),
    [LastUpdate] [datetime2](7) NOT NULL,
    [Created] [datetime2](7) NOT NULL,
    [CreatedBy] [varchar](255),
    [LastUpdateBy] [varchar](255),
    CONSTRAINT [PK_cdk.DevelopmentAmenities] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[FrontsOn] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.FrontsOn] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[LeaseType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.LeaseType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[OwnershipType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.OwnershipType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ParkingType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ParkingType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[PropertyType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.PropertyType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[SoilEvaluationType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.SoilEvaluationType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[UtilityType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.UtilityType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[WaterFrontType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.WaterFrontType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[ZoningType] (
    [Id] [bigint] NOT NULL,
    [Value] [varchar](255),
    [ShortName] [varchar](255),
    [Name] [varchar](255),
    [AlternateName] [varchar](255),
    [ImgUrl] [varchar](255),
    CONSTRAINT [PK_ddf.ZoningType] PRIMARY KEY ([Id])
)
CREATE TABLE [ddf].[AgentALanguage] (
    [ALanguageId] [bigint] NOT NULL,
    [UnitAgentId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.AgentALanguage] PRIMARY KEY ([ALanguageId], [UnitAgentId])
)
CREATE INDEX [IX_ALanguageId] ON [ddf].[AgentALanguage]([ALanguageId])
CREATE INDEX [IX_UnitAgentId] ON [ddf].[AgentALanguage]([UnitAgentId])
CREATE TABLE [ddf].[AgentIndividualDesignation] (
    [IndividualDesignationId] [bigint] NOT NULL,
    [UnitAgentId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.AgentIndividualDesignation] PRIMARY KEY ([IndividualDesignationId], [UnitAgentId])
)
CREATE INDEX [IX_IndividualDesignationId] ON [ddf].[AgentIndividualDesignation]([IndividualDesignationId])
CREATE INDEX [IX_UnitAgentId] ON [ddf].[AgentIndividualDesignation]([UnitAgentId])
CREATE TABLE [ddf].[AgentSpecialty] (
    [SpecialtyId] [bigint] NOT NULL,
    [UnitAgentId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.AgentSpecialty] PRIMARY KEY ([SpecialtyId], [UnitAgentId])
)
CREATE INDEX [IX_SpecialtyId] ON [ddf].[AgentSpecialty]([SpecialtyId])
CREATE INDEX [IX_UnitAgentId] ON [ddf].[AgentSpecialty]([UnitAgentId])
CREATE TABLE [ddf].[OfficeFranchisor] (
    [FranchisorId] [bigint] NOT NULL,
    [UnitAgentOfficeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.OfficeFranchisor] PRIMARY KEY ([FranchisorId], [UnitAgentOfficeId])
)
CREATE INDEX [IX_FranchisorId] ON [ddf].[OfficeFranchisor]([FranchisorId])
CREATE INDEX [IX_UnitAgentOfficeId] ON [ddf].[OfficeFranchisor]([UnitAgentOfficeId])
CREATE TABLE [ddf].[OfficeOrganizationDesignation] (
    [OrganizationDesignationId] [bigint] NOT NULL,
    [UnitAgentOfficeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.OfficeOrganizationDesignation] PRIMARY KEY ([OrganizationDesignationId], [UnitAgentOfficeId])
)
CREATE INDEX [IX_OrganizationDesignationId] ON [ddf].[OfficeOrganizationDesignation]([OrganizationDesignationId])
CREATE INDEX [IX_UnitAgentOfficeId] ON [ddf].[OfficeOrganizationDesignation]([UnitAgentOfficeId])
CREATE TABLE [ddf].[OfficeOrganizationType] (
    [OrganizationTypeId] [bigint] NOT NULL,
    [UnitAgentOfficeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.OfficeOrganizationType] PRIMARY KEY ([OrganizationTypeId], [UnitAgentOfficeId])
)
CREATE INDEX [IX_OrganizationTypeId] ON [ddf].[OfficeOrganizationType]([OrganizationTypeId])
CREATE INDEX [IX_UnitAgentOfficeId] ON [ddf].[OfficeOrganizationType]([UnitAgentOfficeId])
CREATE TABLE [ddf].[LandAccessType] (
    [AccessTypeId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandAccessType] PRIMARY KEY ([AccessTypeId], [BuildingId])
)
CREATE INDEX [IX_AccessTypeId] ON [ddf].[LandAccessType]([AccessTypeId])
CREATE INDEX [IX_BuildingId] ON [ddf].[LandAccessType]([BuildingId])
CREATE TABLE [ddf].[BuildingAmenitie] (
    [AmenitieId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingAmenitie] PRIMARY KEY ([AmenitieId], [BuildingId])
)
CREATE INDEX [IX_AmenitieId] ON [ddf].[BuildingAmenitie]([AmenitieId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingAmenitie]([BuildingId])
CREATE TABLE [ddf].[BuildingAmperage] (
    [AmperageId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingAmperage] PRIMARY KEY ([AmperageId], [BuildingId])
)
CREATE INDEX [IX_AmperageId] ON [ddf].[BuildingAmperage]([AmperageId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingAmperage]([BuildingId])
CREATE TABLE [ddf].[BuildingArchitecturalStyle] (
    [ArchitecturalStyleId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingArchitecturalStyle] PRIMARY KEY ([ArchitecturalStyleId], [BuildingId])
)
CREATE INDEX [IX_ArchitecturalStyleId] ON [ddf].[BuildingArchitecturalStyle]([ArchitecturalStyleId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingArchitecturalStyle]([BuildingId])
CREATE TABLE [ddf].[BuildingBasementDevelopment] (
    [BasementDevelopmentId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingBasementDevelopment] PRIMARY KEY ([BasementDevelopmentId], [BuildingId])
)
CREATE INDEX [IX_BasementDevelopmentId] ON [ddf].[BuildingBasementDevelopment]([BasementDevelopmentId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingBasementDevelopment]([BuildingId])
CREATE TABLE [ddf].[BuildingBasementFeature] (
    [BasementFeatureId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingBasementFeature] PRIMARY KEY ([BasementFeatureId], [BuildingId])
)
CREATE INDEX [IX_BasementFeatureId] ON [ddf].[BuildingBasementFeature]([BasementFeatureId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingBasementFeature]([BuildingId])
CREATE TABLE [ddf].[BuildingBasementType] (
    [BasementTypeId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingBasementType] PRIMARY KEY ([BasementTypeId], [BuildingId])
)
CREATE INDEX [IX_BasementTypeId] ON [ddf].[BuildingBasementType]([BasementTypeId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingBasementType]([BuildingId])
CREATE TABLE [ddf].[BuildingBoard] (
    [BoardId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingBoard] PRIMARY KEY ([BoardId], [BuildingId])
)
CREATE INDEX [IX_BoardId] ON [ddf].[BuildingBoard]([BoardId])
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingBoard]([BuildingId])
CREATE TABLE [ddf].[BuildingBuildingType] (
    [BuildingId] [bigint] NOT NULL,
    [BuildingTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingBuildingType] PRIMARY KEY ([BuildingId], [BuildingTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingBuildingType]([BuildingId])
CREATE INDEX [IX_BuildingTypeId] ON [ddf].[BuildingBuildingType]([BuildingTypeId])
CREATE TABLE [ddf].[BuildingCeilingType] (
    [BuildingId] [bigint] NOT NULL,
    [CeilingTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingCeilingType] PRIMARY KEY ([BuildingId], [CeilingTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingCeilingType]([BuildingId])
CREATE INDEX [IX_CeilingTypeId] ON [ddf].[BuildingCeilingType]([CeilingTypeId])
CREATE TABLE [ddf].[BuildingClearCeilingHeight] (
    [BuildingId] [bigint] NOT NULL,
    [ClearCeilingHeightId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingClearCeilingHeight] PRIMARY KEY ([BuildingId], [ClearCeilingHeightId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingClearCeilingHeight]([BuildingId])
CREATE INDEX [IX_ClearCeilingHeightId] ON [ddf].[BuildingClearCeilingHeight]([ClearCeilingHeightId])
CREATE TABLE [ddf].[BuildingCommunicationType] (
    [BuildingId] [bigint] NOT NULL,
    [CommunicationTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingCommunicationType] PRIMARY KEY ([BuildingId], [CommunicationTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingCommunicationType]([BuildingId])
CREATE INDEX [IX_CommunicationTypeId] ON [ddf].[BuildingCommunicationType]([CommunicationTypeId])
CREATE TABLE [ddf].[BuildingCommunityFeature] (
    [BuildingId] [bigint] NOT NULL,
    [CommunityFeatureId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingCommunityFeature] PRIMARY KEY ([BuildingId], [CommunityFeatureId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingCommunityFeature]([BuildingId])
CREATE INDEX [IX_CommunityFeatureId] ON [ddf].[BuildingCommunityFeature]([CommunityFeatureId])
CREATE TABLE [ddf].[BuildingConstructionMaterial] (
    [BuildingId] [bigint] NOT NULL,
    [ConstructionMaterialId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingConstructionMaterial] PRIMARY KEY ([BuildingId], [ConstructionMaterialId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingConstructionMaterial]([BuildingId])
CREATE INDEX [IX_ConstructionMaterialId] ON [ddf].[BuildingConstructionMaterial]([ConstructionMaterialId])
CREATE TABLE [ddf].[BuildingCrop] (
    [BuildingId] [bigint] NOT NULL,
    [CropId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingCrop] PRIMARY KEY ([BuildingId], [CropId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingCrop]([BuildingId])
CREATE INDEX [IX_CropId] ON [ddf].[BuildingCrop]([CropId])
CREATE TABLE [ddf].[BuildingDocumentType] (
    [BuildingId] [bigint] NOT NULL,
    [DocumentTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingDocumentType] PRIMARY KEY ([BuildingId], [DocumentTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingDocumentType]([BuildingId])
CREATE INDEX [IX_DocumentTypeId] ON [ddf].[BuildingDocumentType]([DocumentTypeId])
CREATE TABLE [ddf].[BuildingEasement] (
    [BuildingId] [bigint] NOT NULL,
    [EasementId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingEasement] PRIMARY KEY ([BuildingId], [EasementId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingEasement]([BuildingId])
CREATE INDEX [IX_EasementId] ON [ddf].[BuildingEasement]([EasementId])
CREATE TABLE [ddf].[BuildingEquipmentType] (
    [BuildingId] [bigint] NOT NULL,
    [EquipmentTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingEquipmentType] PRIMARY KEY ([BuildingId], [EquipmentTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingEquipmentType]([BuildingId])
CREATE INDEX [IX_EquipmentTypeId] ON [ddf].[BuildingEquipmentType]([EquipmentTypeId])
CREATE TABLE [ddf].[BuildingExteriorFinish] (
    [BuildingId] [bigint] NOT NULL,
    [ExteriorFinishId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingExteriorFinish] PRIMARY KEY ([BuildingId], [ExteriorFinishId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingExteriorFinish]([BuildingId])
CREATE INDEX [IX_ExteriorFinishId] ON [ddf].[BuildingExteriorFinish]([ExteriorFinishId])
CREATE TABLE [ddf].[BuildingFarmType] (
    [BuildingId] [bigint] NOT NULL,
    [FarmTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingFarmType] PRIMARY KEY ([BuildingId], [FarmTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingFarmType]([BuildingId])
CREATE INDEX [IX_FarmTypeId] ON [ddf].[BuildingFarmType]([FarmTypeId])
CREATE TABLE [ddf].[BuildingFireplaceFuel] (
    [BuildingId] [bigint] NOT NULL,
    [FireplaceFuelId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingFireplaceFuel] PRIMARY KEY ([BuildingId], [FireplaceFuelId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingFireplaceFuel]([BuildingId])
CREATE INDEX [IX_FireplaceFuelId] ON [ddf].[BuildingFireplaceFuel]([FireplaceFuelId])
CREATE TABLE [ddf].[BuildingFireplaceType] (
    [BuildingId] [bigint] NOT NULL,
    [FireplaceTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingFireplaceType] PRIMARY KEY ([BuildingId], [FireplaceTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingFireplaceType]([BuildingId])
CREATE INDEX [IX_FireplaceTypeId] ON [ddf].[BuildingFireplaceType]([FireplaceTypeId])
CREATE TABLE [ddf].[BuildingFireProtection] (
    [BuildingId] [bigint] NOT NULL,
    [FireProtectionId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingFireProtection] PRIMARY KEY ([BuildingId], [FireProtectionId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingFireProtection]([BuildingId])
CREATE INDEX [IX_FireProtectionId] ON [ddf].[BuildingFireProtection]([FireProtectionId])
CREATE TABLE [ddf].[BuildingFixture] (
    [BuildingId] [bigint] NOT NULL,
    [FixtureId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingFixture] PRIMARY KEY ([BuildingId], [FixtureId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingFixture]([BuildingId])
CREATE INDEX [IX_FixtureId] ON [ddf].[BuildingFixture]([FixtureId])
CREATE TABLE [ddf].[BuildingFoundationType] (
    [BuildingId] [bigint] NOT NULL,
    [FoundationTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingFoundationType] PRIMARY KEY ([BuildingId], [FoundationTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingFoundationType]([BuildingId])
CREATE INDEX [IX_FoundationTypeId] ON [ddf].[BuildingFoundationType]([FoundationTypeId])
CREATE TABLE [ddf].[BuildingHeatingFuel] (
    [BuildingId] [bigint] NOT NULL,
    [HeatingFuelId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingHeatingFuel] PRIMARY KEY ([BuildingId], [HeatingFuelId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingHeatingFuel]([BuildingId])
CREATE INDEX [IX_HeatingFuelId] ON [ddf].[BuildingHeatingFuel]([HeatingFuelId])
CREATE TABLE [ddf].[BuildingHeatingType] (
    [BuildingId] [bigint] NOT NULL,
    [HeatingTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingHeatingType] PRIMARY KEY ([BuildingId], [HeatingTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingHeatingType]([BuildingId])
CREATE INDEX [IX_HeatingTypeId] ON [ddf].[BuildingHeatingType]([HeatingTypeId])
CREATE TABLE [ddf].[BuildingIrrigationType] (
    [BuildingId] [bigint] NOT NULL,
    [IrrigationTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingIrrigationType] PRIMARY KEY ([BuildingId], [IrrigationTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingIrrigationType]([BuildingId])
CREATE INDEX [IX_IrrigationTypeId] ON [ddf].[BuildingIrrigationType]([IrrigationTypeId])
CREATE TABLE [ddf].[BuildingMachinery] (
    [BuildingId] [bigint] NOT NULL,
    [MachineryId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingMachinery] PRIMARY KEY ([BuildingId], [MachineryId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingMachinery]([BuildingId])
CREATE INDEX [IX_MachineryId] ON [ddf].[BuildingMachinery]([MachineryId])
CREATE TABLE [ddf].[BuildingMeasureUnit] (
    [BuildingId] [bigint] NOT NULL,
    [MeasureUnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingMeasureUnit] PRIMARY KEY ([BuildingId], [MeasureUnitId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingMeasureUnit]([BuildingId])
CREATE INDEX [IX_MeasureUnitId] ON [ddf].[BuildingMeasureUnit]([MeasureUnitId])
CREATE TABLE [ddf].[BuildingPoolFeature] (
    [BuildingId] [bigint] NOT NULL,
    [PoolFeatureId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingPoolFeature] PRIMARY KEY ([BuildingId], [PoolFeatureId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingPoolFeature]([BuildingId])
CREATE INDEX [IX_PoolFeatureId] ON [ddf].[BuildingPoolFeature]([PoolFeatureId])
CREATE TABLE [ddf].[BuildingPoolType] (
    [BuildingId] [bigint] NOT NULL,
    [PoolTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingPoolType] PRIMARY KEY ([BuildingId], [PoolTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingPoolType]([BuildingId])
CREATE INDEX [IX_PoolTypeId] ON [ddf].[BuildingPoolType]([PoolTypeId])
CREATE TABLE [ddf].[BuildingRoadType] (
    [BuildingId] [bigint] NOT NULL,
    [RoadTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingRoadType] PRIMARY KEY ([BuildingId], [RoadTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingRoadType]([BuildingId])
CREATE INDEX [IX_RoadTypeId] ON [ddf].[BuildingRoadType]([RoadTypeId])
CREATE TABLE [ddf].[BuildingRoofMaterial] (
    [BuildingId] [bigint] NOT NULL,
    [RoofMaterialId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingRoofMaterial] PRIMARY KEY ([BuildingId], [RoofMaterialId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingRoofMaterial]([BuildingId])
CREATE INDEX [IX_RoofMaterialId] ON [ddf].[BuildingRoofMaterial]([RoofMaterialId])
CREATE TABLE [ddf].[BuildingRoofStyle] (
    [BuildingId] [bigint] NOT NULL,
    [RoofStyleId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingRoofStyle] PRIMARY KEY ([BuildingId], [RoofStyleId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingRoofStyle]([BuildingId])
CREATE INDEX [IX_RoofStyleId] ON [ddf].[BuildingRoofStyle]([RoofStyleId])
CREATE TABLE [ddf].[BuildingSignType] (
    [BuildingId] [bigint] NOT NULL,
    [SignTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingSignType] PRIMARY KEY ([BuildingId], [SignTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingSignType]([BuildingId])
CREATE INDEX [IX_SignTypeId] ON [ddf].[BuildingSignType]([SignTypeId])
CREATE TABLE [ddf].[BuildingStoreFront] (
    [BuildingId] [bigint] NOT NULL,
    [StoreFrontId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingStoreFront] PRIMARY KEY ([BuildingId], [StoreFrontId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingStoreFront]([BuildingId])
CREATE INDEX [IX_StoreFrontId] ON [ddf].[BuildingStoreFront]([StoreFrontId])
CREATE TABLE [ddf].[BuildingStructureType] (
    [BuildingId] [bigint] NOT NULL,
    [StructureTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingStructureType] PRIMARY KEY ([BuildingId], [StructureTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingStructureType]([BuildingId])
CREATE INDEX [IX_StructureTypeId] ON [ddf].[BuildingStructureType]([StructureTypeId])
CREATE TABLE [ddf].[BuildingUffiCode] (
    [BuildingId] [bigint] NOT NULL,
    [UffiCodeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingUffiCode] PRIMARY KEY ([BuildingId], [UffiCodeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingUffiCode]([BuildingId])
CREATE INDEX [IX_UffiCodeId] ON [ddf].[BuildingUffiCode]([UffiCodeId])
CREATE TABLE [ddf].[BuildingUtilityPower] (
    [BuildingId] [bigint] NOT NULL,
    [UtilityPowerId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingUtilityPower] PRIMARY KEY ([BuildingId], [UtilityPowerId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingUtilityPower]([BuildingId])
CREATE INDEX [IX_UtilityPowerId] ON [ddf].[BuildingUtilityPower]([UtilityPowerId])
CREATE TABLE [ddf].[BuildingUtilityWater] (
    [BuildingId] [bigint] NOT NULL,
    [UtilityWaterId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BuildingUtilityWater] PRIMARY KEY ([BuildingId], [UtilityWaterId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[BuildingUtilityWater]([BuildingId])
CREATE INDEX [IX_UtilityWaterId] ON [ddf].[BuildingUtilityWater]([UtilityWaterId])
CREATE TABLE [ddf].[LandCurrentUse] (
    [BuildingId] [bigint] NOT NULL,
    [CurrentUseId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandCurrentUse] PRIMARY KEY ([BuildingId], [CurrentUseId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandCurrentUse]([BuildingId])
CREATE INDEX [IX_CurrentUseId] ON [ddf].[LandCurrentUse]([CurrentUseId])
CREATE TABLE [ddf].[LandFenceType] (
    [BuildingId] [bigint] NOT NULL,
    [FenceTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandFenceType] PRIMARY KEY ([BuildingId], [FenceTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandFenceType]([BuildingId])
CREATE INDEX [IX_FenceTypeId] ON [ddf].[LandFenceType]([FenceTypeId])
CREATE TABLE [ddf].[LandLandDispositionType] (
    [BuildingId] [bigint] NOT NULL,
    [LandDispositionTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandLandDispositionType] PRIMARY KEY ([BuildingId], [LandDispositionTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandLandDispositionType]([BuildingId])
CREATE INDEX [IX_LandDispositionTypeId] ON [ddf].[LandLandDispositionType]([LandDispositionTypeId])
CREATE TABLE [ddf].[LandLandscapeFeature] (
    [BuildingId] [bigint] NOT NULL,
    [LandscapeFeatureId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandLandscapeFeature] PRIMARY KEY ([BuildingId], [LandscapeFeatureId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandLandscapeFeature]([BuildingId])
CREATE INDEX [IX_LandscapeFeatureId] ON [ddf].[LandLandscapeFeature]([LandscapeFeatureId])
CREATE TABLE [ddf].[LandSewer] (
    [BuildingId] [bigint] NOT NULL,
    [SewerId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandSewer] PRIMARY KEY ([BuildingId], [SewerId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandSewer]([BuildingId])
CREATE INDEX [IX_SewerId] ON [ddf].[LandSewer]([SewerId])
CREATE TABLE [ddf].[LandSoilType] (
    [BuildingId] [bigint] NOT NULL,
    [LandSoilTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandSoilType] PRIMARY KEY ([BuildingId], [LandSoilTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandSoilType]([BuildingId])
CREATE INDEX [IX_LandSoilTypeId] ON [ddf].[LandSoilType]([LandSoilTypeId])
CREATE TABLE [ddf].[LandSurfaceWater] (
    [BuildingId] [bigint] NOT NULL,
    [SurfaceWaterId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandSurfaceWater] PRIMARY KEY ([BuildingId], [SurfaceWaterId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandSurfaceWater]([BuildingId])
CREATE INDEX [IX_SurfaceWaterId] ON [ddf].[LandSurfaceWater]([SurfaceWaterId])
CREATE TABLE [ddf].[LandTopographyType] (
    [BuildingId] [bigint] NOT NULL,
    [TopographyTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandTopographyType] PRIMARY KEY ([BuildingId], [TopographyTypeId])
)
CREATE INDEX [IX_BuildingId] ON [ddf].[LandTopographyType]([BuildingId])
CREATE INDEX [IX_TopographyTypeId] ON [ddf].[LandTopographyType]([TopographyTypeId])
CREATE TABLE [ddf].[LandAmenitiesNearby] (
    [AmenitiesNearbyId] [bigint] NOT NULL,
    [BuildingId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.LandAmenitiesNearby] PRIMARY KEY ([AmenitiesNearbyId], [BuildingId])
)
CREATE INDEX [IX_AmenitiesNearbyId] ON [ddf].[LandAmenitiesNearby]([AmenitiesNearbyId])
CREATE INDEX [IX_BuildingId] ON [ddf].[LandAmenitiesNearby]([BuildingId])
CREATE TABLE [ddf].[UnitAmenitiesNearby] (
    [AmenitiesNearbyId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitAmenitiesNearby] PRIMARY KEY ([AmenitiesNearbyId], [UnitId])
)
CREATE INDEX [IX_AmenitiesNearbyId] ON [ddf].[UnitAmenitiesNearby]([AmenitiesNearbyId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitAmenitiesNearby]([UnitId])
CREATE TABLE [ddf].[UnitAppliance] (
    [ApplianceId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitAppliance] PRIMARY KEY ([ApplianceId], [UnitId])
)
CREATE INDEX [IX_ApplianceId] ON [ddf].[UnitAppliance]([ApplianceId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitAppliance]([UnitId])
CREATE TABLE [ddf].[BusinessBusinessSubType] (
    [BusinessSubTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BusinessBusinessSubType] PRIMARY KEY ([BusinessSubTypeId], [UnitId])
)
CREATE INDEX [IX_BusinessSubTypeId] ON [ddf].[BusinessBusinessSubType]([BusinessSubTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[BusinessBusinessSubType]([UnitId])
CREATE TABLE [ddf].[BusinessBusinessType] (
    [BusinessTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.BusinessBusinessType] PRIMARY KEY ([BusinessTypeId], [UnitId])
)
CREATE INDEX [IX_BusinessTypeId] ON [ddf].[BusinessBusinessType]([BusinessTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[BusinessBusinessType]([UnitId])
CREATE TABLE [ddf].[UnitCoolingType] (
    [CoolingTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitCoolingType] PRIMARY KEY ([CoolingTypeId], [UnitId])
)
CREATE INDEX [IX_CoolingTypeId] ON [ddf].[UnitCoolingType]([CoolingTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitCoolingType]([UnitId])
CREATE TABLE [ddf].[UnitFeature] (
    [FeatureId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitFeature] PRIMARY KEY ([FeatureId], [UnitId])
)
CREATE INDEX [IX_FeatureId] ON [ddf].[UnitFeature]([FeatureId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitFeature]([UnitId])
CREATE TABLE [ddf].[UnitFlooringType] (
    [FlooringTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitFlooringType] PRIMARY KEY ([FlooringTypeId], [UnitId])
)
CREATE INDEX [IX_FlooringTypeId] ON [ddf].[UnitFlooringType]([FlooringTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitFlooringType]([UnitId])
CREATE TABLE [ddf].[UnitLiveStockType] (
    [LiveStockTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitLiveStockType] PRIMARY KEY ([LiveStockTypeId], [UnitId])
)
CREATE INDEX [IX_LiveStockTypeId] ON [ddf].[UnitLiveStockType]([LiveStockTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitLiveStockType]([UnitId])
CREATE TABLE [ddf].[UnitLoadingType] (
    [LoadingTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitLoadingType] PRIMARY KEY ([LoadingTypeId], [UnitId])
)
CREATE INDEX [IX_LoadingTypeId] ON [ddf].[UnitLoadingType]([LoadingTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitLoadingType]([UnitId])
CREATE TABLE [ddf].[UnitMaintenanceFeeType] (
    [MaintenanceFeeTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitMaintenanceFeeType] PRIMARY KEY ([MaintenanceFeeTypeId], [UnitId])
)
CREATE INDEX [IX_MaintenanceFeeTypeId] ON [ddf].[UnitMaintenanceFeeType]([MaintenanceFeeTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitMaintenanceFeeType]([UnitId])
CREATE TABLE [ddf].[UnitPaymentUnit] (
    [PaymentUnitId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitPaymentUnit] PRIMARY KEY ([PaymentUnitId], [UnitId])
)
CREATE INDEX [IX_PaymentUnitId] ON [ddf].[UnitPaymentUnit]([PaymentUnitId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitPaymentUnit]([UnitId])
CREATE TABLE [ddf].[UnitRentalEquipmentType] (
    [RentalEquipmentTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitRentalEquipmentType] PRIMARY KEY ([RentalEquipmentTypeId], [UnitId])
)
CREATE INDEX [IX_RentalEquipmentTypeId] ON [ddf].[UnitRentalEquipmentType]([RentalEquipmentTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitRentalEquipmentType]([UnitId])
CREATE TABLE [ddf].[UnitRightType] (
    [RightTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitRightType] PRIMARY KEY ([RightTypeId], [UnitId])
)
CREATE INDEX [IX_RightTypeId] ON [ddf].[UnitRightType]([RightTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitRightType]([UnitId])
CREATE TABLE [ddf].[UnitStorageType] (
    [StorageTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitStorageType] PRIMARY KEY ([StorageTypeId], [UnitId])
)
CREATE INDEX [IX_StorageTypeId] ON [ddf].[UnitStorageType]([StorageTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitStorageType]([UnitId])
CREATE TABLE [ddf].[UnitTransactionType] (
    [TransactionTypeId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitTransactionType] PRIMARY KEY ([TransactionTypeId], [UnitId])
)
CREATE INDEX [IX_TransactionTypeId] ON [ddf].[UnitTransactionType]([TransactionTypeId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitTransactionType]([UnitId])
CREATE TABLE [ddf].[UnitViewType] (
    [UnitId] [bigint] NOT NULL,
    [ViewTypeId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitViewType] PRIMARY KEY ([UnitId], [ViewTypeId])
)
CREATE INDEX [IX_UnitId] ON [ddf].[UnitViewType]([UnitId])
CREATE INDEX [IX_ViewTypeId] ON [ddf].[UnitViewType]([ViewTypeId])
CREATE TABLE [ddf].[UnitUnitAgent] (
    [UnitAgentId] [bigint] NOT NULL,
    [UnitId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.UnitUnitAgent] PRIMARY KEY ([UnitAgentId], [UnitId])
)
CREATE INDEX [IX_UnitAgentId] ON [ddf].[UnitUnitAgent]([UnitAgentId])
CREATE INDEX [IX_UnitId] ON [ddf].[UnitUnitAgent]([UnitId])
CREATE TABLE [ddf].[AgentABoard] (
    [ABoardId] [bigint] NOT NULL,
    [UnitAgentId] [bigint] NOT NULL,
    CONSTRAINT [PK_ddf.AgentABoard] PRIMARY KEY ([ABoardId], [UnitAgentId])
)
CREATE INDEX [IX_ABoardId] ON [ddf].[AgentABoard]([ABoardId])
CREATE INDEX [IX_UnitAgentId] ON [ddf].[AgentABoard]([UnitAgentId])
ALTER TABLE [ddf].[UnitAgentContact] ADD CONSTRAINT [FK_ddf.UnitAgentContact_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId])
ALTER TABLE [ddf].[UnitAgentDesignation] ADD CONSTRAINT [FK_ddf.UnitAgentDesignation_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentLanguage] ADD CONSTRAINT [FK_ddf.UnitAgentLanguage_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentOffice] ADD CONSTRAINT [FK_ddf.UnitAgentOffice_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId])
ALTER TABLE [ddf].[UnitAgentOfficePhone] ADD CONSTRAINT [FK_ddf.UnitAgentOfficePhone_ddf.UnitAgentOffice_UnitAgentOfficeId] FOREIGN KEY ([UnitAgentOfficeId]) REFERENCES [ddf].[UnitAgentOffice] ([UnitAgentOfficeId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentOfficeWebsite] ADD CONSTRAINT [FK_ddf.UnitAgentOfficeWebsite_ddf.UnitAgentOffice_UnitAgentOfficeId] FOREIGN KEY ([UnitAgentOfficeId]) REFERENCES [ddf].[UnitAgentOffice] ([UnitAgentOfficeId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentPhone] ADD CONSTRAINT [FK_ddf.UnitAgentPhone_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentSpeciality] ADD CONSTRAINT [FK_ddf.UnitAgentSpeciality_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentTradingArea] ADD CONSTRAINT [FK_ddf.UnitAgentTradingArea_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAgentWebsite] ADD CONSTRAINT [FK_ddf.UnitAgentWebsite_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[Unit] ADD CONSTRAINT [FK_ddf.Unit_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingLand] ADD CONSTRAINT [FK_ddf.BuildingLand_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId])
ALTER TABLE [ddf].[Building] ADD CONSTRAINT [FK_ddf.Building_ddf.BuildingAddress_BuildingAddressId] FOREIGN KEY ([BuildingAddressId]) REFERENCES [ddf].[BuildingAddress] ([BuildingAddressId])
ALTER TABLE [ddf].[BuildingAddress] ADD CONSTRAINT [FK_ddf.BuildingAddress_cdk.NeighborhoodArea_NeighborhoodAreaId] FOREIGN KEY ([NeighborhoodAreaId]) REFERENCES [cdk].[NeighborhoodArea] ([Id])
ALTER TABLE [cdk].[NeighborhoodArea] ADD CONSTRAINT [FK_cdk.NeighborhoodArea_cdk.MetroArea_MetroAreaId] FOREIGN KEY ([MetroAreaId]) REFERENCES [cdk].[MetroArea] ([Id])
ALTER TABLE [cdk].[DevelopmentAddress] ADD CONSTRAINT [FK_cdk.DevelopmentAddress_cdk.Development_Id] FOREIGN KEY ([Id]) REFERENCES [cdk].[Development] ([Id]) ON DELETE CASCADE
ALTER TABLE [cdk].[DevelopmentAddress] ADD CONSTRAINT [FK_cdk.DevelopmentAddress_cdk.NeighborhoodArea_NeighborhoodAreaId] FOREIGN KEY ([NeighborhoodAreaId]) REFERENCES [cdk].[NeighborhoodArea] ([Id])
ALTER TABLE [cdk].[Development] ADD CONSTRAINT [FK_cdk.Development_cdk.Developer_DeveloperId] FOREIGN KEY ([DeveloperId]) REFERENCES [cdk].[Developer] ([Id]) ON DELETE CASCADE
ALTER TABLE [cdk].[DevelopmentFloorPlan] ADD CONSTRAINT [FK_cdk.DevelopmentFloorPlan_cdk.Development_DevelopmentId] FOREIGN KEY ([DevelopmentId]) REFERENCES [cdk].[Development] ([Id]) ON DELETE CASCADE
ALTER TABLE [cdk].[DevelopmentPhoto] ADD CONSTRAINT [FK_cdk.DevelopmentPhoto_cdk.Development_DevelopmentId] FOREIGN KEY ([DevelopmentId]) REFERENCES [cdk].[Development] ([Id]) ON DELETE CASCADE
ALTER TABLE [cdk].[DevelopmentVideo] ADD CONSTRAINT [FK_cdk.DevelopmentVideo_cdk.Development_DevelopmentId] FOREIGN KEY ([DevelopmentId]) REFERENCES [cdk].[Development] ([Id]) ON DELETE CASCADE
ALTER TABLE [cdk].[NeighborhoodGuide] ADD CONSTRAINT [FK_cdk.NeighborhoodGuide_cdk.NeighborhoodArea_NeighborhoodAreaId] FOREIGN KEY ([NeighborhoodAreaId]) REFERENCES [cdk].[NeighborhoodArea] ([Id])
ALTER TABLE [cdk].[NeighborhoodGuidePhoto] ADD CONSTRAINT [FK_cdk.NeighborhoodGuidePhoto_cdk.NeighborhoodGuide_NeighborhoodGuideId] FOREIGN KEY ([NeighborhoodGuideId]) REFERENCES [cdk].[NeighborhoodGuide] ([Id]) ON DELETE CASCADE
ALTER TABLE [cdk].[NeighborhoodGuideVideo] ADD CONSTRAINT [FK_cdk.NeighborhoodGuideVideo_cdk.NeighborhoodGuide_NeighborhoodGuideId] FOREIGN KEY ([NeighborhoodGuideId]) REFERENCES [cdk].[NeighborhoodGuide] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[Business] ADD CONSTRAINT [FK_ddf.Business_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId])
ALTER TABLE [ddf].[UnitOpenHouse] ADD CONSTRAINT [FK_ddf.UnitOpenHouse_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitParkingSpace] ADD CONSTRAINT [FK_ddf.UnitParkingSpace_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitPhoto] ADD CONSTRAINT [FK_ddf.UnitPhoto_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitRoom] ADD CONSTRAINT [FK_ddf.UnitRoom_ddf.RoomLevel_LevelId] FOREIGN KEY ([LevelId]) REFERENCES [ddf].[RoomLevel] ([Id])
ALTER TABLE [ddf].[UnitRoom] ADD CONSTRAINT [FK_ddf.UnitRoom_ddf.RoomType_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [ddf].[RoomType] ([Id])
ALTER TABLE [ddf].[UnitRoom] ADD CONSTRAINT [FK_ddf.UnitRoom_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitUtilitiesAvailable] ADD CONSTRAINT [FK_ddf.UnitUtilitiesAvailable_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentALanguage] ADD CONSTRAINT [FK_ddf.AgentALanguage_ddf.ALanguage_ALanguageId] FOREIGN KEY ([ALanguageId]) REFERENCES [ddf].[ALanguage] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentALanguage] ADD CONSTRAINT [FK_ddf.AgentALanguage_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentIndividualDesignation] ADD CONSTRAINT [FK_ddf.AgentIndividualDesignation_ddf.IndividualDesignation_IndividualDesignationId] FOREIGN KEY ([IndividualDesignationId]) REFERENCES [ddf].[IndividualDesignation] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentIndividualDesignation] ADD CONSTRAINT [FK_ddf.AgentIndividualDesignation_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentSpecialty] ADD CONSTRAINT [FK_ddf.AgentSpecialty_ddf.Specialtie_SpecialtyId] FOREIGN KEY ([SpecialtyId]) REFERENCES [ddf].[Specialtie] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentSpecialty] ADD CONSTRAINT [FK_ddf.AgentSpecialty_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[OfficeFranchisor] ADD CONSTRAINT [FK_ddf.OfficeFranchisor_ddf.Franchisor_FranchisorId] FOREIGN KEY ([FranchisorId]) REFERENCES [ddf].[Franchisor] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[OfficeFranchisor] ADD CONSTRAINT [FK_ddf.OfficeFranchisor_ddf.UnitAgentOffice_UnitAgentOfficeId] FOREIGN KEY ([UnitAgentOfficeId]) REFERENCES [ddf].[UnitAgentOffice] ([UnitAgentOfficeId]) ON DELETE CASCADE
ALTER TABLE [ddf].[OfficeOrganizationDesignation] ADD CONSTRAINT [FK_ddf.OfficeOrganizationDesignation_ddf.OrganizationDesignation_OrganizationDesignationId] FOREIGN KEY ([OrganizationDesignationId]) REFERENCES [ddf].[OrganizationDesignation] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[OfficeOrganizationDesignation] ADD CONSTRAINT [FK_ddf.OfficeOrganizationDesignation_ddf.UnitAgentOffice_UnitAgentOfficeId] FOREIGN KEY ([UnitAgentOfficeId]) REFERENCES [ddf].[UnitAgentOffice] ([UnitAgentOfficeId]) ON DELETE CASCADE
ALTER TABLE [ddf].[OfficeOrganizationType] ADD CONSTRAINT [FK_ddf.OfficeOrganizationType_ddf.OrganizationType_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [ddf].[OrganizationType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[OfficeOrganizationType] ADD CONSTRAINT [FK_ddf.OfficeOrganizationType_ddf.UnitAgentOffice_UnitAgentOfficeId] FOREIGN KEY ([UnitAgentOfficeId]) REFERENCES [ddf].[UnitAgentOffice] ([UnitAgentOfficeId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandAccessType] ADD CONSTRAINT [FK_ddf.LandAccessType_ddf.AccessType_AccessTypeId] FOREIGN KEY ([AccessTypeId]) REFERENCES [ddf].[AccessType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandAccessType] ADD CONSTRAINT [FK_ddf.LandAccessType_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingAmenitie] ADD CONSTRAINT [FK_ddf.BuildingAmenitie_ddf.Amenitie_AmenitieId] FOREIGN KEY ([AmenitieId]) REFERENCES [ddf].[Amenitie] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingAmenitie] ADD CONSTRAINT [FK_ddf.BuildingAmenitie_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingAmperage] ADD CONSTRAINT [FK_ddf.BuildingAmperage_ddf.Amperage_AmperageId] FOREIGN KEY ([AmperageId]) REFERENCES [ddf].[Amperage] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingAmperage] ADD CONSTRAINT [FK_ddf.BuildingAmperage_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingArchitecturalStyle] ADD CONSTRAINT [FK_ddf.BuildingArchitecturalStyle_ddf.ArchitecturalStyle_ArchitecturalStyleId] FOREIGN KEY ([ArchitecturalStyleId]) REFERENCES [ddf].[ArchitecturalStyle] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingArchitecturalStyle] ADD CONSTRAINT [FK_ddf.BuildingArchitecturalStyle_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBasementDevelopment] ADD CONSTRAINT [FK_ddf.BuildingBasementDevelopment_ddf.BasementDevelopment_BasementDevelopmentId] FOREIGN KEY ([BasementDevelopmentId]) REFERENCES [ddf].[BasementDevelopment] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBasementDevelopment] ADD CONSTRAINT [FK_ddf.BuildingBasementDevelopment_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBasementFeature] ADD CONSTRAINT [FK_ddf.BuildingBasementFeature_ddf.BasementFeature_BasementFeatureId] FOREIGN KEY ([BasementFeatureId]) REFERENCES [ddf].[BasementFeature] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBasementFeature] ADD CONSTRAINT [FK_ddf.BuildingBasementFeature_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBasementType] ADD CONSTRAINT [FK_ddf.BuildingBasementType_ddf.BasementType_BasementTypeId] FOREIGN KEY ([BasementTypeId]) REFERENCES [ddf].[BasementType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBasementType] ADD CONSTRAINT [FK_ddf.BuildingBasementType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBoard] ADD CONSTRAINT [FK_ddf.BuildingBoard_ddf.Board_BoardId] FOREIGN KEY ([BoardId]) REFERENCES [ddf].[Board] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBoard] ADD CONSTRAINT [FK_ddf.BuildingBoard_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBuildingType] ADD CONSTRAINT [FK_ddf.BuildingBuildingType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingBuildingType] ADD CONSTRAINT [FK_ddf.BuildingBuildingType_ddf.BuildingType_BuildingTypeId] FOREIGN KEY ([BuildingTypeId]) REFERENCES [ddf].[BuildingType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCeilingType] ADD CONSTRAINT [FK_ddf.BuildingCeilingType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCeilingType] ADD CONSTRAINT [FK_ddf.BuildingCeilingType_ddf.CeilingType_CeilingTypeId] FOREIGN KEY ([CeilingTypeId]) REFERENCES [ddf].[CeilingType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingClearCeilingHeight] ADD CONSTRAINT [FK_ddf.BuildingClearCeilingHeight_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingClearCeilingHeight] ADD CONSTRAINT [FK_ddf.BuildingClearCeilingHeight_ddf.ClearCeilingHeight_ClearCeilingHeightId] FOREIGN KEY ([ClearCeilingHeightId]) REFERENCES [ddf].[ClearCeilingHeight] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCommunicationType] ADD CONSTRAINT [FK_ddf.BuildingCommunicationType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCommunicationType] ADD CONSTRAINT [FK_ddf.BuildingCommunicationType_ddf.CommunicationType_CommunicationTypeId] FOREIGN KEY ([CommunicationTypeId]) REFERENCES [ddf].[CommunicationType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCommunityFeature] ADD CONSTRAINT [FK_ddf.BuildingCommunityFeature_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCommunityFeature] ADD CONSTRAINT [FK_ddf.BuildingCommunityFeature_ddf.CommunityFeature_CommunityFeatureId] FOREIGN KEY ([CommunityFeatureId]) REFERENCES [ddf].[CommunityFeature] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingConstructionMaterial] ADD CONSTRAINT [FK_ddf.BuildingConstructionMaterial_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingConstructionMaterial] ADD CONSTRAINT [FK_ddf.BuildingConstructionMaterial_ddf.ConstructionMaterial_ConstructionMaterialId] FOREIGN KEY ([ConstructionMaterialId]) REFERENCES [ddf].[ConstructionMaterial] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCrop] ADD CONSTRAINT [FK_ddf.BuildingCrop_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingCrop] ADD CONSTRAINT [FK_ddf.BuildingCrop_ddf.Crop_CropId] FOREIGN KEY ([CropId]) REFERENCES [ddf].[Crop] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingDocumentType] ADD CONSTRAINT [FK_ddf.BuildingDocumentType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingDocumentType] ADD CONSTRAINT [FK_ddf.BuildingDocumentType_ddf.DocumentType_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [ddf].[DocumentType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingEasement] ADD CONSTRAINT [FK_ddf.BuildingEasement_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingEasement] ADD CONSTRAINT [FK_ddf.BuildingEasement_ddf.Easement_EasementId] FOREIGN KEY ([EasementId]) REFERENCES [ddf].[Easement] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingEquipmentType] ADD CONSTRAINT [FK_ddf.BuildingEquipmentType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingEquipmentType] ADD CONSTRAINT [FK_ddf.BuildingEquipmentType_ddf.EquipmentType_EquipmentTypeId] FOREIGN KEY ([EquipmentTypeId]) REFERENCES [ddf].[EquipmentType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingExteriorFinish] ADD CONSTRAINT [FK_ddf.BuildingExteriorFinish_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingExteriorFinish] ADD CONSTRAINT [FK_ddf.BuildingExteriorFinish_ddf.ExteriorFinish_ExteriorFinishId] FOREIGN KEY ([ExteriorFinishId]) REFERENCES [ddf].[ExteriorFinish] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFarmType] ADD CONSTRAINT [FK_ddf.BuildingFarmType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFarmType] ADD CONSTRAINT [FK_ddf.BuildingFarmType_ddf.FarmType_FarmTypeId] FOREIGN KEY ([FarmTypeId]) REFERENCES [ddf].[FarmType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFireplaceFuel] ADD CONSTRAINT [FK_ddf.BuildingFireplaceFuel_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFireplaceFuel] ADD CONSTRAINT [FK_ddf.BuildingFireplaceFuel_ddf.FireplaceFuel_FireplaceFuelId] FOREIGN KEY ([FireplaceFuelId]) REFERENCES [ddf].[FireplaceFuel] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFireplaceType] ADD CONSTRAINT [FK_ddf.BuildingFireplaceType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFireplaceType] ADD CONSTRAINT [FK_ddf.BuildingFireplaceType_ddf.FireplaceType_FireplaceTypeId] FOREIGN KEY ([FireplaceTypeId]) REFERENCES [ddf].[FireplaceType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFireProtection] ADD CONSTRAINT [FK_ddf.BuildingFireProtection_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFireProtection] ADD CONSTRAINT [FK_ddf.BuildingFireProtection_ddf.FireProtection_FireProtectionId] FOREIGN KEY ([FireProtectionId]) REFERENCES [ddf].[FireProtection] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFixture] ADD CONSTRAINT [FK_ddf.BuildingFixture_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFixture] ADD CONSTRAINT [FK_ddf.BuildingFixture_ddf.Fixture_FixtureId] FOREIGN KEY ([FixtureId]) REFERENCES [ddf].[Fixture] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFoundationType] ADD CONSTRAINT [FK_ddf.BuildingFoundationType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingFoundationType] ADD CONSTRAINT [FK_ddf.BuildingFoundationType_ddf.FoundationType_FoundationTypeId] FOREIGN KEY ([FoundationTypeId]) REFERENCES [ddf].[FoundationType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingHeatingFuel] ADD CONSTRAINT [FK_ddf.BuildingHeatingFuel_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingHeatingFuel] ADD CONSTRAINT [FK_ddf.BuildingHeatingFuel_ddf.HeatingFuel_HeatingFuelId] FOREIGN KEY ([HeatingFuelId]) REFERENCES [ddf].[HeatingFuel] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingHeatingType] ADD CONSTRAINT [FK_ddf.BuildingHeatingType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingHeatingType] ADD CONSTRAINT [FK_ddf.BuildingHeatingType_ddf.HeatingType_HeatingTypeId] FOREIGN KEY ([HeatingTypeId]) REFERENCES [ddf].[HeatingType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingIrrigationType] ADD CONSTRAINT [FK_ddf.BuildingIrrigationType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingIrrigationType] ADD CONSTRAINT [FK_ddf.BuildingIrrigationType_ddf.IrrigationType_IrrigationTypeId] FOREIGN KEY ([IrrigationTypeId]) REFERENCES [ddf].[IrrigationType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingMachinery] ADD CONSTRAINT [FK_ddf.BuildingMachinery_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingMachinery] ADD CONSTRAINT [FK_ddf.BuildingMachinery_ddf.Machinery_MachineryId] FOREIGN KEY ([MachineryId]) REFERENCES [ddf].[Machinery] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingMeasureUnit] ADD CONSTRAINT [FK_ddf.BuildingMeasureUnit_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingMeasureUnit] ADD CONSTRAINT [FK_ddf.BuildingMeasureUnit_ddf.MeasureUnit_MeasureUnitId] FOREIGN KEY ([MeasureUnitId]) REFERENCES [ddf].[MeasureUnit] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingPoolFeature] ADD CONSTRAINT [FK_ddf.BuildingPoolFeature_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingPoolFeature] ADD CONSTRAINT [FK_ddf.BuildingPoolFeature_ddf.PoolFeature_PoolFeatureId] FOREIGN KEY ([PoolFeatureId]) REFERENCES [ddf].[PoolFeature] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingPoolType] ADD CONSTRAINT [FK_ddf.BuildingPoolType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingPoolType] ADD CONSTRAINT [FK_ddf.BuildingPoolType_ddf.PoolType_PoolTypeId] FOREIGN KEY ([PoolTypeId]) REFERENCES [ddf].[PoolType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingRoadType] ADD CONSTRAINT [FK_ddf.BuildingRoadType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingRoadType] ADD CONSTRAINT [FK_ddf.BuildingRoadType_ddf.RoadType_RoadTypeId] FOREIGN KEY ([RoadTypeId]) REFERENCES [ddf].[RoadType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingRoofMaterial] ADD CONSTRAINT [FK_ddf.BuildingRoofMaterial_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingRoofMaterial] ADD CONSTRAINT [FK_ddf.BuildingRoofMaterial_ddf.RoofMaterial_RoofMaterialId] FOREIGN KEY ([RoofMaterialId]) REFERENCES [ddf].[RoofMaterial] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingRoofStyle] ADD CONSTRAINT [FK_ddf.BuildingRoofStyle_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingRoofStyle] ADD CONSTRAINT [FK_ddf.BuildingRoofStyle_ddf.RoofStyle_RoofStyleId] FOREIGN KEY ([RoofStyleId]) REFERENCES [ddf].[RoofStyle] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingSignType] ADD CONSTRAINT [FK_ddf.BuildingSignType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingSignType] ADD CONSTRAINT [FK_ddf.BuildingSignType_ddf.SignType_SignTypeId] FOREIGN KEY ([SignTypeId]) REFERENCES [ddf].[SignType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingStoreFront] ADD CONSTRAINT [FK_ddf.BuildingStoreFront_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingStoreFront] ADD CONSTRAINT [FK_ddf.BuildingStoreFront_ddf.StoreFront_StoreFrontId] FOREIGN KEY ([StoreFrontId]) REFERENCES [ddf].[StoreFront] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingStructureType] ADD CONSTRAINT [FK_ddf.BuildingStructureType_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingStructureType] ADD CONSTRAINT [FK_ddf.BuildingStructureType_ddf.StructureType_StructureTypeId] FOREIGN KEY ([StructureTypeId]) REFERENCES [ddf].[StructureType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingUffiCode] ADD CONSTRAINT [FK_ddf.BuildingUffiCode_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingUffiCode] ADD CONSTRAINT [FK_ddf.BuildingUffiCode_ddf.UffiCode_UffiCodeId] FOREIGN KEY ([UffiCodeId]) REFERENCES [ddf].[UffiCode] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingUtilityPower] ADD CONSTRAINT [FK_ddf.BuildingUtilityPower_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingUtilityPower] ADD CONSTRAINT [FK_ddf.BuildingUtilityPower_ddf.UtilityPower_UtilityPowerId] FOREIGN KEY ([UtilityPowerId]) REFERENCES [ddf].[UtilityPower] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingUtilityWater] ADD CONSTRAINT [FK_ddf.BuildingUtilityWater_ddf.Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[Building] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BuildingUtilityWater] ADD CONSTRAINT [FK_ddf.BuildingUtilityWater_ddf.UtilityWater_UtilityWaterId] FOREIGN KEY ([UtilityWaterId]) REFERENCES [ddf].[UtilityWater] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandCurrentUse] ADD CONSTRAINT [FK_ddf.LandCurrentUse_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandCurrentUse] ADD CONSTRAINT [FK_ddf.LandCurrentUse_ddf.CurrentUse_CurrentUseId] FOREIGN KEY ([CurrentUseId]) REFERENCES [ddf].[CurrentUse] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandFenceType] ADD CONSTRAINT [FK_ddf.LandFenceType_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandFenceType] ADD CONSTRAINT [FK_ddf.LandFenceType_ddf.FenceType_FenceTypeId] FOREIGN KEY ([FenceTypeId]) REFERENCES [ddf].[FenceType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandLandDispositionType] ADD CONSTRAINT [FK_ddf.LandLandDispositionType_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandLandDispositionType] ADD CONSTRAINT [FK_ddf.LandLandDispositionType_ddf.LandDispositionType_LandDispositionTypeId] FOREIGN KEY ([LandDispositionTypeId]) REFERENCES [ddf].[LandDispositionType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandLandscapeFeature] ADD CONSTRAINT [FK_ddf.LandLandscapeFeature_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandLandscapeFeature] ADD CONSTRAINT [FK_ddf.LandLandscapeFeature_ddf.LandscapeFeature_LandscapeFeatureId] FOREIGN KEY ([LandscapeFeatureId]) REFERENCES [ddf].[LandscapeFeature] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandSewer] ADD CONSTRAINT [FK_ddf.LandSewer_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandSewer] ADD CONSTRAINT [FK_ddf.LandSewer_ddf.Sewer_SewerId] FOREIGN KEY ([SewerId]) REFERENCES [ddf].[Sewer] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandSoilType] ADD CONSTRAINT [FK_ddf.LandSoilType_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandSoilType] ADD CONSTRAINT [FK_ddf.LandSoilType_ddf.SoilType_LandSoilTypeId] FOREIGN KEY ([LandSoilTypeId]) REFERENCES [ddf].[SoilType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandSurfaceWater] ADD CONSTRAINT [FK_ddf.LandSurfaceWater_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandSurfaceWater] ADD CONSTRAINT [FK_ddf.LandSurfaceWater_ddf.SurfaceWater_SurfaceWaterId] FOREIGN KEY ([SurfaceWaterId]) REFERENCES [ddf].[SurfaceWater] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandTopographyType] ADD CONSTRAINT [FK_ddf.LandTopographyType_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandTopographyType] ADD CONSTRAINT [FK_ddf.LandTopographyType_ddf.TopographyType_TopographyTypeId] FOREIGN KEY ([TopographyTypeId]) REFERENCES [ddf].[TopographyType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandAmenitiesNearby] ADD CONSTRAINT [FK_ddf.LandAmenitiesNearby_ddf.AmenitiesNearby_AmenitiesNearbyId] FOREIGN KEY ([AmenitiesNearbyId]) REFERENCES [ddf].[AmenitiesNearby] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[LandAmenitiesNearby] ADD CONSTRAINT [FK_ddf.LandAmenitiesNearby_ddf.BuildingLand_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [ddf].[BuildingLand] ([BuildingId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAmenitiesNearby] ADD CONSTRAINT [FK_ddf.UnitAmenitiesNearby_ddf.AmenitiesNearby_AmenitiesNearbyId] FOREIGN KEY ([AmenitiesNearbyId]) REFERENCES [ddf].[AmenitiesNearby] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAmenitiesNearby] ADD CONSTRAINT [FK_ddf.UnitAmenitiesNearby_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAppliance] ADD CONSTRAINT [FK_ddf.UnitAppliance_ddf.Appliance_ApplianceId] FOREIGN KEY ([ApplianceId]) REFERENCES [ddf].[Appliance] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitAppliance] ADD CONSTRAINT [FK_ddf.UnitAppliance_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BusinessBusinessSubType] ADD CONSTRAINT [FK_ddf.BusinessBusinessSubType_ddf.BusinessSubType_BusinessSubTypeId] FOREIGN KEY ([BusinessSubTypeId]) REFERENCES [ddf].[BusinessSubType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BusinessBusinessSubType] ADD CONSTRAINT [FK_ddf.BusinessBusinessSubType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[BusinessBusinessType] ADD CONSTRAINT [FK_ddf.BusinessBusinessType_ddf.BusinessType_BusinessTypeId] FOREIGN KEY ([BusinessTypeId]) REFERENCES [ddf].[BusinessType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[BusinessBusinessType] ADD CONSTRAINT [FK_ddf.BusinessBusinessType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitCoolingType] ADD CONSTRAINT [FK_ddf.UnitCoolingType_ddf.CoolingType_CoolingTypeId] FOREIGN KEY ([CoolingTypeId]) REFERENCES [ddf].[CoolingType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitCoolingType] ADD CONSTRAINT [FK_ddf.UnitCoolingType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitFeature] ADD CONSTRAINT [FK_ddf.UnitFeature_ddf.Feature_FeatureId] FOREIGN KEY ([FeatureId]) REFERENCES [ddf].[Feature] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitFeature] ADD CONSTRAINT [FK_ddf.UnitFeature_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitFlooringType] ADD CONSTRAINT [FK_ddf.UnitFlooringType_ddf.FlooringType_FlooringTypeId] FOREIGN KEY ([FlooringTypeId]) REFERENCES [ddf].[FlooringType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitFlooringType] ADD CONSTRAINT [FK_ddf.UnitFlooringType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitLiveStockType] ADD CONSTRAINT [FK_ddf.UnitLiveStockType_ddf.LiveStockType_LiveStockTypeId] FOREIGN KEY ([LiveStockTypeId]) REFERENCES [ddf].[LiveStockType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitLiveStockType] ADD CONSTRAINT [FK_ddf.UnitLiveStockType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitLoadingType] ADD CONSTRAINT [FK_ddf.UnitLoadingType_ddf.LoadingType_LoadingTypeId] FOREIGN KEY ([LoadingTypeId]) REFERENCES [ddf].[LoadingType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitLoadingType] ADD CONSTRAINT [FK_ddf.UnitLoadingType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitMaintenanceFeeType] ADD CONSTRAINT [FK_ddf.UnitMaintenanceFeeType_ddf.MaintenanceFeeType_MaintenanceFeeTypeId] FOREIGN KEY ([MaintenanceFeeTypeId]) REFERENCES [ddf].[MaintenanceFeeType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitMaintenanceFeeType] ADD CONSTRAINT [FK_ddf.UnitMaintenanceFeeType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitPaymentUnit] ADD CONSTRAINT [FK_ddf.UnitPaymentUnit_ddf.PaymentUnit_PaymentUnitId] FOREIGN KEY ([PaymentUnitId]) REFERENCES [ddf].[PaymentUnit] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitPaymentUnit] ADD CONSTRAINT [FK_ddf.UnitPaymentUnit_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitRentalEquipmentType] ADD CONSTRAINT [FK_ddf.UnitRentalEquipmentType_ddf.RentalEquipmentType_RentalEquipmentTypeId] FOREIGN KEY ([RentalEquipmentTypeId]) REFERENCES [ddf].[RentalEquipmentType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitRentalEquipmentType] ADD CONSTRAINT [FK_ddf.UnitRentalEquipmentType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitRightType] ADD CONSTRAINT [FK_ddf.UnitRightType_ddf.RightType_RightTypeId] FOREIGN KEY ([RightTypeId]) REFERENCES [ddf].[RightType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitRightType] ADD CONSTRAINT [FK_ddf.UnitRightType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitStorageType] ADD CONSTRAINT [FK_ddf.UnitStorageType_ddf.StorageType_StorageTypeId] FOREIGN KEY ([StorageTypeId]) REFERENCES [ddf].[StorageType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitStorageType] ADD CONSTRAINT [FK_ddf.UnitStorageType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitTransactionType] ADD CONSTRAINT [FK_ddf.UnitTransactionType_ddf.TransactionType_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [ddf].[TransactionType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitTransactionType] ADD CONSTRAINT [FK_ddf.UnitTransactionType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitViewType] ADD CONSTRAINT [FK_ddf.UnitViewType_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitViewType] ADD CONSTRAINT [FK_ddf.UnitViewType_ddf.ViewType_ViewTypeId] FOREIGN KEY ([ViewTypeId]) REFERENCES [ddf].[ViewType] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitUnitAgent] ADD CONSTRAINT [FK_ddf.UnitUnitAgent_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
ALTER TABLE [ddf].[UnitUnitAgent] ADD CONSTRAINT [FK_ddf.UnitUnitAgent_ddf.Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [ddf].[Unit] ([UnitId]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentABoard] ADD CONSTRAINT [FK_ddf.AgentABoard_ddf.ABoard_ABoardId] FOREIGN KEY ([ABoardId]) REFERENCES [ddf].[ABoard] ([Id]) ON DELETE CASCADE
ALTER TABLE [ddf].[AgentABoard] ADD CONSTRAINT [FK_ddf.AgentABoard_ddf.UnitAgent_UnitAgentId] FOREIGN KEY ([UnitAgentId]) REFERENCES [ddf].[UnitAgent] ([UnitAgentId]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201604051913517_Initial', N'CDK.DataAccess.Repositories.Migrations.Configuration',  0x1F8B0800000000000400ECBDDB721CB9B62DF6EE08FF83424FB6639FD6EADE671F7BAFE8F6098A145B8A45B51824D5BDF77A51805560551E656556E78522DBE12FF3833FC9BF6020AFB84C2001241255252256442FB130E7C0C4C4C04CDCF1FFFD3FFFEFCFFFFD6997BE7AC44599E4D92FAF7FFCE16FAF5FE16C95AF936CF3CBEBBA7AF82FFFC7EBFFFE7FFECFFFD3CFEFD6BBA757BFF772FF4AE5886656FEF27A5B55FBBFBF7953AEB67887CA1F76C9AAC8CBFCA1FA6195EFDEA075FEE6A7BFFDEDDFDFFCF8E31B4C205E13AC57AF7EBEA9B32AD9E1E60FF2E7799EADF0BEAA51FA315FE3B4EC7E2729B70DEAABDFD00E977BB4C2BFBC3EBFF8C70F17A84267AB152ECB1F6EF03E2F932A2F125CBE7E7596268898748BD387D7AF5096E515AA88C17FFF5CE2DBAAC8B3CDED9EFC80D2BBE73D26720F282D715790BF8FE2A665FADB4FB44C6F46C51E6A559755BEB304FCF15F3B27BD11D59D5CFD7A702271E33BE2EEEA9996BA71E52FAFCFDEE6A858BF7E2566F5F7F3B4A062929FDB8AF9A1D5FB975760EABF0C04213CA2FF2372755AD505FE25C37555A0F45F5E5DD7F769B2FA077EBECBBFE2EC97AC4E53D652622B49E37E203F5D17F91E17D5F30D7EE8ECFF406C7FC3EBBD1115073546A72DDB87ACFA6FFFF5F5ABDF48E6E83EC50311183FDC124AE15F71860B54E1F535AA2A5C907AFC2DCFB094B390CFEF28AD719F15A11D694AAF5F7D444F5738DB54DB5F5EFFF46FFFF6FAD565F284D7FD2F5DF69FB384B4BCD11C7D36B7DBBCA8E83F97CF2A4C2E6729F531717798EC3EEC369F8B74817C7E438FC9A661919023D1ABCE3638AB48A4BAC16923526E937D1BB0BAB6F58595BA2CF2DD4D9E0E0D9649FC729BD7C58AFA295749DCA162832BDEBE9FDF8CB1401B21061CFB2031A81E3E4E0CA6B8040C4E3944E41832FCF4F090ACB094AD5EFB62FD20587BEA11E19A7EDA9B0FE0D2395DA1B2FABC5F931AEBF322ACC577092DA554D97AA877EB7AD530E1BCC06B521DA4BB510670D536AFF2B1146BB918135F93AAC0B83A5BAF0BD24E03C4FA36A3AB24C33F06CB2D25B9FD14E0C3DCB8F2B77A778F8B60B905698F6D5EB735894E4FCBE7764E3E48011A4E913F26D92A4C34AB507A4E1402C4B37C937F2E9290BD9BB6FFE1A56BD3775CD45D9BBEF3636CDC15CA3635DA60857D7DB2CA44205DB61212B235F443B64E1E9335190A5FE032D964ADA5A0D1A0A8A20053B2526126156C0B76BBC72BF229AC1245158CE98A22800292DDB094ADB183EA799E5568A5E8B08B52638EACDD6A29C9788DA87309266904494E94049454970616772E91BE294B62136591C5D40501649D4BD176F127CAD00A4D94401452DB2F493A5B4FBA9BD994F18DCC84ED828CDA7451D0D9F22E4024CA40244B3E4F14021254970494762ECE5D81E85CED5981D1447118C989F28092EA02C1E2CE25FA03DF9351DF54E57452132591A4D4A590455D4A3061F5974E0630B54D926675C4F459733A430FC561E2B7573DFC9C4E9CFB8D73BFDFDDDCAFCB00449A01D68D529C0206380AB00F1E204C0C243190C440E23B90789D1410038CF12C8253B01987EEF61166D48D6125869518567C8715C7D9393180E8E7F0E6AD537773663396AB3B84C34710D1A2598BD70CC6DC08F3A159CFA4AB32132B376D9634BB004DB399830892D51D7EAA0245508F0BD2EA6D0CD6C161996970E59C877AC67C5EA898359881508E28643056CD0A1B024EA8D0A126AB25EBB93A3EC07774D9B5166593D12FCDCC6B36EEB38712C4113598DEA459AD850539B9A632D6EBD1B513F7453C650BD12CF8CD6B1EEDEADA8CC6D1021C51D318B7213A370CC54EC6A53750DA6F9D545A7CEA43D7EF7A675FA03D6201776E9DE7755615010A7559A06CB54DCA3CC02645BA1D0DD89C7A8AFBDF848C3E151B94257F35912BCC2074D98EADC761A8F2DB3F320F9E6C1AD3BF0851999B72D28849CBFC3A59DB757EB6CA2777572984B50533D5914A69AC38A7C8CDD9B9C9B25229E34282C2DAD2C11ACE7B4E96D885A5EC802AF76B39EE2133D98BC5488A6ED39406949FDA5E062BCDDC2767B6298893B528A74263AAA42A35A8ACC6C309F6B36C3B9218750F3F8888AB607115EC7457C174BB733D744FC46F834957C6299A287A04F6A1450114E34C8C3331CE2C1367161D3A8811C87ACC313B1CB5A3E5397188CAC5001403500C40CB07200FE3795DC8D1CF00F858976986A5B317671A94C3C71CC82A0FCB34034EF0254CD365A223DA77D4382B60568B5D28601A24C2CD304D4C9DE9A7A57C048B6E666776B8E8708E2E6074767908190C520C1AD39975EE0A9AD961BB1661676C2722C7D444EFBCD831B78B716C9D8BF9DD8AC375284E2A2ABCA0AE84FF2B03944D5E75B7C0BC463E1EDF9FD1D24790236AEEA351B3DA3C0F73720D9F3D857674ED63DE9514CA96A2BDC0625E73612E8798D15E1894236A308C55B35A8C8073724D86ABE3A36B3373EF3D51B61AFD3529F39ACDFC01E8F10D3D7D0C3A0F39DC3CA92EE54B1A682E735390B2DDAB2F15726EF36EEDFC38DAB66B7B0ED986DFD6494A63F5EC4365ED3981108703DEA3F4E12DAAB677C4054B342BD14324AB22CF77A1B2C36B9A5B79769F3FE25F8BBCCE02B8B4CFF42D4EF36FA1330DE4D8739CA404FA3D4E36DB2AC0CA6FF217264D0917498863046C6E97499694DB1067099A9AEBB35BA8932B6EBBC7A80CF0DD6EB2B9C645BB9F3F546EED072F486E77B8D8DDE01D22954773099FE76581FF5C3EDF8F24B30A67285BE14B1CA026F9FCAED1F38E7C86C354EB352ABE26CD3B3E2B1C28A45EA728C0499BEB2209720939CD265893EF730BC48DEECF4033E94D179AB6F4E2ABEE5C25F9A7A77395CD5B1828FD903DE4C5AEBD99215B272B5485F8F67E241D7026E7AB24FB1AE6F819ED73FBB908C5F39D2AA1EFD72741B6B9B5F8378C8A7BD5EDC5BCD4B37CE12C2820DF650F4A59DFBABFDFA709FD4A286CED93012BF924D93E21DDD6B27E40A89C3AF8324AF0B3054302384130A6DA1EEA7A5B9749D69CD0062CEA13BFB48174B4884B90BCC4A7DAFBA8D5BEADEFD567FE0421B9264101A5A5BC94ABC5D3E6EA6D3530748695E7794E87686A231901D9462951325196B0B5F012233A5DA438FED226CA967109F2095C2ED5DAA234CF0BADD35809C0362955365016B1B5F22A79C4B755BEFAAA36931391ED0492254321196B4BF366ED4263E72800582926CA364A12B616F2630CB5A1B29C6CAF4A46325B29686B3D332682CD6604647BA544C95059C2D6C21BA28ED2777FD6C99E22A91D0C08CA162B8524CBD592D625A0535C1ABBFB64C05A3E49B65148B77EEB86F4C8D146435A4640B64E4A941FB991246C2DBC2B5056A295FE3CBF20245B0A0A48D6C252CE07C2673FB1A03CD53DC3B24F7B9CBDCFEB5273427D10913A71722A68A320E262263B7BA2B69495028D9504407B65292793E9C3863A63693A6CE590029B3726BBD8754327F59556D154D0A82101B4694C7531E97395B4EFDA9C3DA2A419CDAA0D946541731562A0F12A59DBA2FC9EE06FEAA0D4403222C2E86C4881876763F2BC8754F8E1B1C3732A3CC0E15772E329C6788AF1E44E31F6932D5728533D3C29CC63091AEA69314E507E69452BED729F8FD7D9BC2973F97E905304644B6C1FFE58EDC3C73E7677886D0C34DF59E22716D225F040EB5E4356F4DAF330D9116293D1E12237D18AB1B1E15A9895A2B35581C314AA6FE701F699A42494E075A85D2D7551D0E98E109B222E92C7A44C48CB5D3EAB4B9C055BC56EF30AC2F7A615979F825C4F99AD2F92729F97497BAD51880CCB15DAE3718A7CF91D0F25CD2954D0C7DF82BC5A4F82FD05DE57DB409BC648F8D8D4290A51B23C49DF3D92110B0AC3489A5F98667D5B170F6885FF207D96007EBC4BD2609F97BB7C9F6F0AB4DF06DA3AA2DB8860BCB63E7460144387215D33E851C8C8CBED2A41EB1D014E9B181C476D539B1AE61545BB85808506B7128002D2C00D96B21D5F8EBD27D5A238930B27ACB09791D19BCC0ADA5A3D74580C8C666515368F227A9319395B8B85DE88A1EDB096A21490B0BE3CA0864BC9B86ECF17F1173AFE3529E9348AA6E453CAD39E9844B0F54CD35F32A8E55E4E51BA36596F7F27636D61D7413031721455D9D94B4C983A88595BCB74324C2CE6C55556B352139673A2B6D6F31D0903FB2505450904397D1944E1794B1DCC4489F52AC7A07BF849BEB8C0111738BEC7058E39DD7C699D606A3C306BA9C07D99E0F0D1E35896086C0FBC76AF31593E87D56B077941E72CC4CCF8DB1C15018E0A9E65AB6D88C3186F492BBA21440971A8ED9CC49BAAA857848617CC8CC57219BE23A4DFD4C91A872AE16552E07D4A7A7DD7A4AD34170404CB31D004D715C6EBF29CD4DE260FF1B458935DA8DABBC159FE8882B19306E604873ACE4D27AFDF3D853A5FFD11656883E9B6DCF37CB7475900AA049ABA6E0218E91804F0614DC4933D4A435C12F1F9E121C0179A6E1709534FBFA315CA56CF37415AF23FF3AC3BA2102AAF0B5CAE8A641F6661A889507D4F2EC03A653365D22CFD86198D5DE5ABFEB58A704E3D9E03A9D34B2CDAA5952F0C33E4F5943155B988C288D82F0291BFC8874665619BAAB2504C052C9444AC2D2C56DBA4C2F49381D2DBEA59B5935A965358AD9193EDD7095BAF52A1B2F9A05FE0479CE6CD911BC5B4A42C0897452B289F97D44ABB96467B405110D29742125296409674B55E3337CC48E8EDE62594460B62D616D361B3C2549AA4B0914F928D13D25D575E8737AD35B3EC5F246179865D9451CEAE4B82F687BCD95DB3FED68DE553CABAD5655B6BA7D732BE08A21A1FEBD72F0431EB95EEF6F62B03837949C05E56406D2E27656D2DDD43C95DD8356534A400D92ECB698A00085B9724DFEDE8B80799AD7B7F81E4A17248629A62C8B28EA5A89EF59F172147565C5D86516AB2088CA87D09BAB93A92F491F6C713D2779C2A05A802960490D4950612B72E11F973AA04AD0864314DD158D824DB5A7491AFEA89AF789F81200A58C849A82DE5C56C2D7ED7750626AC65C4004B8754B595A388B585D3C7D0C75C0459C8564E4463302F676DF5137715E194DD923464B920A4B15D94B4DE5F858A9D81BB1931C0DE21556DE828626D613F4B7E59E3A93026CA42B672221A83793967AB4D9C2BC8EAAC9E72332FE76235F9890E3BA9ADD36673C20ABB1919BDE1ACA0BDE54F061FEB510AB4F569E2D33C48585B476F9935ED1649C290ADBC8CC66441D0D6F2F7B859C031687BBC2460332BA036989372B4D6C0C9BCA4DADA09F77252B6D67E288A2EC1C0604918B05990519B2D0ADA5AFE11ADB649860BD5FCE29011270858CCA4ABAD6585AC2DC5A8244D567DB876CC8593846C650434C6B252B6D65EE7796A36ECE025016B5901B5B59C948BB506CC65C414764EB07514B1B5F026476B030B1931C0C221556DE128626F61FE6038461344414B19099DB5AC988BC59AC9702E975E4E616B9BAC37B493B1DE419C6C4CA22A2306D838A4AA4D1C45AC2DA47BBBDA43921336B282909563BAC64E46C8DED26EDDDCC4A1822C682F2BA2339993B3BE4FE1E12139CFD75306336280AD43AADACC51C4DF8D0F9FCDEE1E85EEDF719FE86D6FEE79BECE27CF327C114421C7B1121AE77162D60E6CB50D8E097C1144D5164F1C0F10C4BCDC1FE47E71D0E1B7C4C60DF57143FDC96EA8F7B4394275D10EB0F8E91827DAAD0C2E71A2D58C7122C6891827BCC709CB2D4A729C50EE62728B13D2962187882161C4D81163478C1DBE63878F2D83523C31D95FE876784FDEBFE7708E4F0689B125C696185B3CC7164F7B78A51910A31DBFB3C24BB712E11E5A3A8018566258896165A1B0E2B8A15E154ED45BEF678592F640976B1CA1323188C4201283C84241C4FA688B2A7C284EC0B8C58EF67A08EBA041D562B488D122460BDFD1C2FC7499141F14A7CFDC024307339C1E73BDC2A803387CB0100C9A73A191EA72A105EF3522CCC4B81A6A63E96671DE98B4782E799D55C5F36D15E4DA83EBBCAC504AF7AD042B5988CB00821CFE0F703550C7ED76141320B3EE51F1B661D107BE97CFF562FD301C750BF4CDA6E71AEFC987629BE701AE65B9ADEFD7CD2B12215879DDDDECFB2B1EAA8EFCB3BDFFD3D02F8D5BCE0A8CA6EE8973FD9AF75BA8A4CFA9C1616CD5D966E5A96D539BC5C26B4DEF339195E422A864955BCB940AB3FA2EB2A9B69D1711E1F0BD97430D754CFB271F7155E4262D69828BEF9EAAF9085DAD04084188DEF26E6B7090C81F706068761111F9A7979E1571382EAEF324AB5C023FA31EA457C3E6178291E7795E90C84ADA70E9E49E51FDAC9C78FECC53858AED37C8DDAB732EA0920EEA631A317DE1BC0D3168184ABF486EA6F7D74C9C53F0D2F35075A226BB2AC6B7228C6BC3BA6B7964316DB90CC4A5A299E8D8966EF8AC838592E019F1B12C6A29A95FA811B53D28C142FD4A2FD585EB4512D356CBB4B4542B062A50A518777621FED97677658CEFB5C3EB775418E7E8E21CDD8B9AA39B33E5D2B68EEF797A2FF0DC5EECC31EA20FCBED07D677F4BE40DF66B08F0748EABA7790F82293800BF45AC52E9F4D4F776E076956CFE87BED12F99B03EC9C858BD9FDB020F1F3BA4876A8783EA72FAFAF024D95F179BEDBA124C05B0A7CA6D7DB66F7CAE2F38F789567EBD0FE15730DE46131DB403E267FFE0FBCAAFEC0F7A45B8697D9C70267798956F83ECFBF86CCF3EE1B29641132C75FF37C93E2EBB42E83E47A8B525C7613C69440BFD5BBFB206F928FF9061BBC8A650D9AE3A73DCEDE937E88AE9CBE962BFACB606BBCFE4FAC7D87FDBFFAC8EF322F6841FB6CDEE6A493853203AD1BE6FD2743AD7E2E35CC986E185D05F960AEF0D9637352F91A17B77F1697180FDEB9C02BF23D25F1E0BA20FF6ABA7EAF7FFCDBEB57B72B447B383F4DA137EF93B46DFBD3437721CED05BFA573BF5EE51262B80B621847AE7E8232ABE627A6160B01C8733A101C2D887ACBD8CF60297C9260B11ACBB4FD36DBDA37DBAE50358B38E1C3AD32EBFB3F14597C5A34BFB60FB876C45C73A8F21B2BCCA37795CECFCDE278A684C309B26A292DAD9215CE8664F1829EB9BDDADD730E74D6D1994029A097328CE659AE7C5758A14173B43925FB80923B04CA0AC6EC20E5698B1D44CFACC55AE58D214C50C0A24C9E90A230BCF28C8EFC91AE793E568A40CCA21C9E9CA210BFB5888A5ADD871961117718E314E0D1E74E2EABB9EA51B9A59B0598EA03B239B9E7AD01C630FF625F460D52FE83876620D563699AEEEDC45BFA1EF356BF56F40899F68C330BB8376C61FE5426098F9CBB7781DE08BF31655DB00D9F47FDEA1A700AEEB67D9E8A3F0CBE7F6E91B613E8D72A1E6B5B375FE917484B6E9F3251E279EE64E33BF4529E965E1E7304E6B0685813ACA34AB3075D36415A487738BFFAC71B60AB6E6C736E06BDAB8029C0E6D984E291E2A43366E040AF24CA30B9363EC1A1FF92EC0F9138B9AE952FD4CE4DCAE7313FE66759B1B84D8650ED8658E1FE2D3FA10C7F87DE4F1DB7D0D4513B7D50B2E736376B3AA312B6637083166078CD98DC7C3C4EC26AB3031BBC92AC6EC18B3C3C76CF7F5624DCC562F2E3BC56CE6ACB46DB01E5463949EDC7ED8BBCAFE62195635D88D32811660C35D0E13E8E070B0C3BCF1B21BB3FCE26537DA981297CDBFDB7E8A787C75FAE211A7BB5374178D28AE5971EAA7481798CCBB4EAF8188FD96C97EC0BCAB48EED0E62A0971AAEA8F2DAAEEF2774F7BBC0A103E2FF0AE8DEDC92AC0D9ADABE40197ED9B824B6745DDF89F39A1D355FE1820BB6194B3B407E307E8083E40612EBED2DDE5357157964BC11A48DD367858F80BF039D31453A1337DCB974A71CE351D0D8266C33C2C6B596285CE7489558A7E3B1F8E4B92304EEC86D874431ABF79599EBCDDA1340D32026AB2BBA2D40D925DD8DDD7333EAEE6F1267C6C9DFC904C05653F91C671210DC689912678A409B7FC7432AD3E76A97D74A92DC2A2CF0ED864589CEAB9398545FE8E0FD747A0A8CCCB0D81F1B9B8052FFB78E1CFC5896FC250C3F4CFCB3412D38FCBB462B3066FE738499D4307A31C23478C1C31722C1539988606070E56401D3738A9796123C5A8E8E0DED3DE8CC3BDAD32460C223188C420B2581091DA9B2296C8729A900208CF8B2CED1582ABA6188EDD121122C6951857625C592CAE88CD4D115624314D5491657D0495EAF91223DABE9D63CA8010434A0C2931A42C1C5286D6A68D28A3D46440614467C693EEC66862FF47440FB0D34B20EC638A8C12E34A8C2B31AE2C1757E416A78A2D80A42EBE40E2F3620C29A1434C215A3186C4181263C8623184682962064DD1C4882679DE9579F9AAA6A71ADDE64558ED1823628C883162A918C1B63438567012EA98C18BCD8A1DEF5089DD1ED8EB3563CC883123C68CA56246DFCAE07831A4AA63C528322F4EFC59277BF74E06A71E23468C1831622C1631D8A6A6081B9C882676F072F302C8537BA3E7659225E5D6218270FA3184C4101243C86221846B6BAA20220869C28828392B905CA262E7D609E93563F088C123068FA58247DFCAE0A831A4AAC3C528322F4E2405DEA768852F6BECB00CCBA9C7881123468C188B450CB6A929C20627A2891DBC9C9F00E2D8DB60D563008901240690C50388A6DFC1891804104F3D105220FAA07973C0DC25828CFA3184C4101243C89221646C6BEA18C2C8E883082B38338A3CB96D4EEF1463DC887123C68DE5E2C6937A2B7A9FA88B144F1E369E5FE675B69E71348ED78F0123068C1830160B185C5B53C40D5E46133E04C15951E43D2648D9C66DBA94518EF123C68F183F968A1F4C438383072BA08E1C9C948FB0E1D6F3609463D8886123868D85C386BACFC10A4C860D0FBD8D0F45D115C82D72F0FA3178C4E01183C752C1836F6B70FC1064D42144149C15453EA2D536214DE2D9E129BE5E35C68E183B62EC582A76F4CD2C51C40D265D1D3358A179F102A392B460526687136F8C728C193166C498B158CC181B9A226830029AA8C14ACD0A1BD7799E3A5F12C628C7B011C3460C1B4B850DA6A1C161831550870D4E6A76D8709BDDE83563C0880123068C2503867A466348D5870A0FB31837395ABBC5895E33C6891827629C582A4EF4AD0C8E1343AA3A4E8C2233E344FEE07EB128AB1DE3458C17315E2C172FC696A68A198C842E6EB062B363C76DFB24BA4BE0685463D4885123468D25A346D3CCD421A34DD6C78B4E6656B0B84D368EDB327ACD182A62A888A162A950D1B73238520CA9EA40318ACC8B13B409100B5CEE0F1D7563AC88B122C68AC562C5D0CE14D1624CD7C40B466866C4A0EF219036ECD8BD60D563DC887123C68DE5E206D3D454A18315D1450F4E6E5600F9FCF0909C9362DBC78E5E33868D183662D8582A6CF4AD0C8E1843AA3A588C22F3E24495A4E497EBFC1B2E1C6205A31DE3458C17315E2C162F9896A68819AC84266E70623E62C71F74E5C5397634DA3176C4D81163C7C2B1A36969DAD8D14A4CC68E4E6CDE038D7551E0ACFA5C3A8C5046DD183762DC8871C3396E5CA16CAD8F1D54E2CBD8DEC0E821CA28E3872438EF362F9C39DF39DCABC6F811E3478C1F4BC78FA1B9A9C3C728A28F1E8CDCACE041C12E92729F9789FBDD1A00480C2831A0C480B27440011A9E3AB440C2FA20036ACC0E37E50AEDB1F3E9581121069A186862A0091168D856574ABF50466B02CF94F274209A4498B7CF043BADFB346A3104C5101443D0D221A8696AEADE4D9BAC0F239DCCBC4091278E67F47BCD182E62B888E162F170D1B5364DC4E8252682C620362F6ED4C5035A61C73562563BC68F183F62FC583C7E302D4E134358A98938C289CE8A2577F93EDF1468BF7D76EB89F0FA319EC47812E3C9D2F1846F73EA8822C8E9638A283C2BAA9CEDF76982B29543401954632C89B124C612EB58D2DD5C0AC490A1657D916E37159286C6DF470A31BD8F244EC1E16D5D261969D0F6B1A1D73C7C68A06E70090FBD5E8810D17BABEDD82DCDF43EB7DBFA3E4C86EFCA8A382D29B7784D981020C3CB82B4806D527E37B1F0D39EB28A80DF26CDA73A6C9052F4735A167D6925D88E0D9320C5273ED54B741A78EC1AA43A80C3C7AAD88D89DD98EFA81B23B42FB933030A2843062FE52574CC8B1B3168C4A01183C64241431F310CC285AF58719EE769E2FA7425A31C23458C143152788C144CDB9203859428C5095962569870DEDB1AB7B4C6F010C383FFF0D0B52B393470095258E053E7858434CF0BE7AE03AB1D83430C0E3138F80C0E4CE3022284942A8709596456ACB84A1E316902ABAF6EC182538FD122468B182D3C460BAE75C9E1024896E20524332F60E468EDDCB7609463B088C122060B9FC1626C5B40A81013E5402149CC0A131F51925538A33B422EB1E3852132460C1A3168C4A0E13168C84D4C8E1D2A19298428056745926BF4BCA3571735DB3DAC9FAA1D9563EC88B123C60E8FB183695B72D09012A568214BCC0A1337040BA5EFFEAC933D8575EB710020316CC4B011C386C7B001B431397C2885A430A2969C174E92CDD63588F4AA3174C4D0114387CFD0D1B72C2060F049729810D2670507CA7AB4717E256A508E0122068818203C0608A66DC921424A9482842C312B4CDC15282BD1CAFDAA530120868B182E62B8F0182E84F625870C50400A1BB0D4ACD041213EED71F63EAF4B87C0C1A91F3E6C70E6B81E8AE500E606940F6BDCB87C8AAD9F8D4EE34E448C0A15153D807A97846860EFB275B8CCCEF31D1D7597477134946389743E544E951A322032BB155FA3E22B3D40BB472E775D8808C7D196598B5C9BB388714A2D3ACC97B271CDF1B42CB6C2C0C6250980ED4B969ADFC4B679953BB62DAA7A248D8A9AE2DC9A7AE5536A4617EB875BFC674D1F9718A1966B4F24BBFE9710D95DE6E91A17C4B1DBE5F36AAABF1D6386C96A5BEFEE3394A49F8B245096B73B9406CCEE8A06A520D95DA1B222D4FCBC5F3377948C3D38CB3645D15CA11CBF0BD45DF007614881BF0463F2EC4FC04D9EEFDCBE0054F3383E00D412D7F8DFEB9E52F8A7BA12865EE58F641D229CB6CA21F279C4A9A50B2E4853CE2829037C3071B92A927D1524B34502176D168D9395D18B4A7C61C4F808C6A782514C108122D99485ED877BCAC0564A615F33EFA435AF91B0B54E1BF81B6828EE0F096A8BE6477DA6CEAC17E87BD5C3C7FD38A11E27D44F72429DB6217852DD3AAA8A97CE6A02AF73A470DCC9D369C63811E3448C134BC689E9CE8D364A70DD1FE74164FBD07A82CBB34794342DC56D4829E31C3E80C076B90E3761A4531B7C9EFA08CAADDB2ED71DD8895788815D7A95ECAC0EFEEF09FEE6F6D9EE350FDFEAE2673B7EB64FF2B3ADFE647FE95B5729468C3105FC5833C9F35E8EA8D7099D30BFA14B47A5C3994001E0F051A233C4255830AAA1BEBEB704A65E62595AC8E73F763AD6937F7A5A13D44D3C3A11F49CB499AAA89BFD608DB35CAEEF14200E4FD2F8298B9FB2A3FC9439B6CBE7149F55155A6DE9FEB5B92D94038B6D35B6D5D8563DB7D54FD5D6E529531827B6D0D842630BF5DC426FF7695239AEC86AC0625B8D6D35B6D5796DF58236A4BCB91FE18CFCA799AAB56FA410CACB6D9DA6D325610866B6D0E069D2E4C32ACF826D8DF5B42FF6BCC0B4FA7CE1BC7D0E597AFFB999DF255FE459557ECA1CEE91EF345F6E88881FF0F801F7D30AAF302A1DAF1B1954633B8CED30B6C379EDF0D337C22DBA20EAD61639F5D81E637B8CED715E7BEC0E13BBB5464639B6C5D816635B9CD9163B6B1C1A62A779F856C89E0FB76D8DF2D9F2E52797021F69EFFF3CDB10F3E65F8B53605C9DADD705A9EA008DB1CDE82AC9F08F4173FB2940E46C5CF95BBDBBA76BA481720B12D3DABC6EEB8787E469F9DCE836C5505E3C6F9AF7E2B9E4755615CF740F5980DABACECB0AA5E7442158C90234E55DBFD8F11B464588895F7AA9564D34D0787364A02CABE7EE19D20001F99CFC196061245FD5E37B004BE7263C3FB07876A8C4EDF6B5A573BA44C52E4C99C211F04351741BE0C394AC99890D94CD352EC25C00D8E7D61E210A92DB1D2E7637788792ACC9257C9E9705FE3354BE6198C93F02BB7876EC1392CB67D67E47835E66F211ADB6A4EB1FA27BC23FBA153A3FEE71AEB05987A1CF4794A14DF391255DA43DCA42D428EDFB257B948618D20B2B1A8B8F1098DB1FEF7232580890658A02B4F8EB3C4F03B990E414AE93745D24AB1085A2D904EBB4F4B985095BFD9F81E8D1CC84D2BE4AF155C70F4F7BC1C067D7962E23F338D3E25991BE4A989CB8476502CCABD52B1A420264956C020DB0A4F73616CF907EC1DED6494ABBB30182F17825C2D239FD812A5C343BF842E71768696EBD4E284F48272B7BC88B5D3344F890ADE9A45B1E60F6F79F391D48061D93B45906EA35E705661C7B95645F03D429A9CDE72A5995E7E403A8CBCFD3A76FC88F36CBE5B37B9BA322C080E004AE23E69621156FD3B2225FBABF12FECE0A958C747B855210BAC7C2C8F07E6340B35EAF339F11EC337E06CB0009AA0B024ABB96A6FF006A4BD20B694B2109294B204BBA5B5F2659B302ADB5BE159AB05E10D2582F4ABA5A7F85B2B5D6722AA0B59A13505ACC4BB95AFBA97F5B45EFED414C6BB82CA5B41E10752D023B81A12F05F7D085AE20A0A0B22CB0B47371E81DEC530569EE69D7968093509BCE8BB9DA2CDF36A6B71FB89D4C57188DB8B2643A9D59971D719F1EF79D558DFAF16CAF1AF60FB9EEB132DC80E467FB2397E9A787870478B068729B9660F1A96F6DBCCECBE4F8EF8517A0DEADEB762DE8BCC0CD063BA214C055ED73227D29802388719F5C1AF7C99DD23EB9307BD7C89F8F491664F561C97D6B53FD9964A2FBE23484156F699D1CEB3A8DBDCFF3AC422B93217827F985FB515912505A3F2C87559C07E854FB0297C9266B8B355D4246DAB0944A0D7D49D56AB34A4B46789B1A6D4CC8D88B1A961316D71752A133AB846DD7CDBCADF15A138D8E15366B7D9CC6AC66487A189949BD3572869506C8EA6B0C5298555DB77BBC223DB4C42C400ED2CF86055429E84BA9D49A55D4BBA2D91075566064505446DAB0AC4A0D7D61D56AB34AFB07BE278307934AED240D4B094AEB4B08ABF81BB1775FA59903F70EE5C8C6EF9D55B387F10C4EA863535D9661D6C2DAA614663D1A3F55810E6B7A1C96EB27759C424C980EA9F633AFEFC3CE0F2D4C3770667861908E2CC43096CD0E330256A85063396339318FC8D679F081AA69D3F23912D236B1E901D4FC66D60F4466B6B11EE6C81A586FD6ECD6C5029D64D31AEBF968DB959F61B7B6454D0CD5E737A77E343DAB31B52047D694C685A1590D49B1BEB4D0D216737F0098FBA92F537DD76B278166E1BFC733DD9705CA56DBA40CB1D5F32ADF40CB7F0B1EE92936284BFE0A78B275D97EE97223CFB8FA788AAB8FD7CBAD0BDA2C2498CEBA33D2562B0B137AFA89CD29650F0B29E6D3B89CBC830F349A265ED0A9CFF283C5BAADFB5A92D166E4C932CDE9AD372CF2D2656F908EB2DFDE58E6A9F33E601D64206C3A8038A219F2C66101B35AEC13EC771D7AA90F877606C0F4ABE32BB874C1D94B78E9B08E32C074B6790A310C5A0C3286270C5B9705CD2CF0C3BD33A2CC329D33834863D2B79B1F6B7C74618EB1F3E2A7DB72D80ECB49459117D655597E4F993644E836A1CD0F0AE35EAE999161043AB2F0301A363B46F050271928BA2254C9312FF2F9DBC7A86D5993BB1FE7372F66F7E0CCF6C5201D5903632C9BDDC204AC936C625C9D1F6D1BF3B98156DBCAA6F7DDCE6F667E06D0C73974F635683EF470F9A4BAB82F6DA01C661BBA364EE877AECF8B11DC5523CE318241399E1871E8573A4C76D8BC2DF2D5963821CC15481FD13E4C46EDA1E62059919693ADC364F57BB2C64B956A32182D79119032FA68AF0D9A1578C65B815C834E8F10038E55C041D5B6C8F35DA0DB75DFE235CDAD3CBBCF1FF1AF056DABE1327D8BD3FC5BE84C0339F66C91BDC86226E36BF0CB6745FE5A6683B59853B6DA86D8D877B6DFA709BD8C3C84F78AD596F410E995AD28BDAD9ED3007E7CDBBD2E72811F493BDB877968A4CF34DC0DD77D8E61063C6FC997F08604F9102F579CE32425D0EF31BD2E39587661FC789E6254842E20E99A35F726E3F54590F7B4860C499FE023BD213709F1E56173A50F87D5211E83E2F224E1EDACAAD06A1B26E648997FAAB6419E8013F3BD251F94EA8A86DB1099E7E15AEB3BD293DDD46474152AF4BD7BA2AD252F2E932C29B7010E142405263FD12F74904DF034BF7D8A56F8B20E419621BB6BF2490ED226871C0375B7C7FC8234088210E6F6FDCB34CF8B60EDFC920EC5021E3C798FD2073AE00D4492F7B8095F61DA5C975918475E61BC2ECF4917639387387FD56417EA5B7083B3FC1105EBB4DDE4F943B8CE1ACD2DD078904E4A2538D4FCC76DF217EEBFE26172FB901D22B7B68712E25C6033A9D8BCB111E0261A4A92BE680B6D0710B30C12283F3F3C240172C99240F311EDCDD5CFD7F9B710239E2EB7E6B59700CB396885B2D5F34D90B0BFE84B174B3CADA05A13523FC2606B758F7443A7CD8D8A4025BF883FEA8A032A4CBE1A016B793937C766317FE98BA21CCFF2176BD59CA5301127F49E9CD9BBDCC26C8D49D65580998B5639443E41A6B52E48C0CDCA207330415FEF5AF4F362F5828FA7183DF5F9D147F69931BA7FF2C73D3EB708C7139B4F626B42E7B5402B6D5D6EB7F57DA049EEB2224E6B463C61661AFA5B6C026445FF1BE0E61ABA45804E0ADD1EEA7E8F255E0153473AD57B61B3A25BFB24986B64A3DA31AAD944353A9913704EACC98A5EF41B26BB66BE28CCB69D866B6142F5D9AAC0610A156E8355B32302AF0351F1BC2E0A32EAFA1CE2E373913C2665721F628EFB1267E1961C9BBCC2ACCBD1565C7E0A324EC9D61749B90FF83E58B62E57688FC3ED18BB2663319253A8A08F834CCDD2607F81F721A6029AE50F123E36758A42942C4FD2778F28AD035D5048F30BD3AC6FEBE201AD70A0E9F4BB240DF679B9CBF7F9A640FBED73A0F56FCDF48AD73184E57BBCAAB103FC6AEFAC71C3A7FE915CF7C1C300713C2388C1A43943090EE4D466AB6F2B5454239B97DFEAB70E97D979BEDBB517311ED954C127D727AC550D1E10F5D2EAD9E7A4DD1B3E8B723C6D9FB56A4EF317714E2D028499BCEB9F443FB29638F31976557BD43FDA3EAF49D2B3B533DA22553FA24648CD99D5FA7A80536B76CCE30A215E5420D9DDE23F6B3AA91022BBCB3C5DE3823837C080B1A14098814093559880D964F5A948364986523A260E33CC213CF1747DFEE1B63C35AED347734E421DC679312FF1BBDDE496E0F2EC11258D13DC83B98C753C915DB66D4E9887D14E2DE6870952CBEE3C99D734E57AD4B6538DB8B2D1EA74BCB4E0B6165DDB2C95397C2B75698BA1964C03BD517ABBCD8B402FA084C965B8AE254C761F769B052EE6326E8DFCBCBD5B9B943162CB8C2D33B6CC792DB33BC6E1D62419E5D816635B8C6D715E5B6C167F9BFD1D6ECD91D78F2D32B6C8D822E7B5C87FE6D9706EDFB6358EBAB125C696185BA2554B3C2BCB7C9534DCEA8B3B3C684E4F54778F36F216BFCBD6AFDAE92548789C836A4B4067BACEC6B7E23F92A697EC496323D6FCF2FA7F93DC31013E9C531DC187D409F09FDF30A5D53BE143B64E1E93758D52E69D5E13874C2942CE01756C1C35996918A78D8F8598780A9486DCC3BE4162EE13183E8C2306C8EE12FAD102A537D42A904B44691BC76872B2F1CEDF7EF8E1472917F221C4748B7B425F3FA717B5A124ABE4AF6692AD923D4A8D0D1210C02FEFA0247F8269DD0D998A2917788F33BAE2615C111EAC193215BA0A53FE73E1201812A67908AA69B9E818BC2672B4E1E48F62DDFCFC29BBC029AEF0ABB3E69239D28544E50AADE58F30F93CAE7D72595B9883F0595BA127C669B963304D685947CB66970E8B2EAF13E5B1BA240721B1BA124F83C1FDF1E3BC184BD0BEDCA9EE28697420068FE236D4D565A2A36EFFDEA9AFAED3A76283B2E4AFE62730624D79CB1400729D42D7C68FC6D91FCAA9343F376F829A536E6CA774DCFC076718D27102B0CDE746D4D07E6C8CEC36CCE7C09D78953D07F95CA82AE1343E164231DA975D45CE1812045436E064F70AB43331E17CEDDBF01175890C0A66C5AFF161787F94D756B737EBC2B781FED537C756A050376807C39391CE2D4195F777D016268A76F0D63051ED27D91E84163EDD0204052DE7DDA3BE98CB890E7B15C538482746517127D687615ECFB6202DA4A5652EFB40BD037DC1FC4E94C3BAB21C84C8BACA3C3136B3AF545BD01954D3F2997B1DDC81D0708E27CA686D610E42696D859E18A7A55ED2349F25152D97E7F4A1E59C4E94C3CA821C84BFCA0A3C0DEE8EF7DF7DE9AFBB6DEEB652EF575128807B5698CBF52C36ADA87200F8CA0AF89BB43CEBEECF1BF2D7B84312051DD14959B94146D638C067E1F7CD93A946851745E1C2EFBB37586D0A2F218729BCF4E2A9891B344AA0438067552D5CA3CB2D889380275A0DBCA4D582DC04BE046BEE277D7E411DD55D1268E1244943E7A04ED8C539723E411DC305F969AFF0E23A97D87E7314398471468E8AB589177839B0F854C4AADC02669002B32DB2FB372E94C506A5A1C23BC609181F70C468EAD1F58DB56530E988CEEC0D6BEBC824FF41E9601D61A008F4DF67EB75411F6DB0600FA3664953AF4432B6514D75D60192A95E16BDCDDC771806033E7237242C839BF757AF5394B16531E130A838C1E241C731EAC279EA5979D421585BA0B05CD6D6A74560DE1D728E82B1A1BD39C992D492D204A1BBABF09CC82CE775C2445616262C8995F5778204FE3D59636B024B4A13046EE41D092CE775C2045616262C8195F5778204EE7B44BFE164B3BDCF8B6D9EB74FED1A704BA53B41674517D490D0CA4C015E4B855A6CB7A7858161B93A554726D688BA07E3AD54888FB82A722D5DD52A104BA708A3E3A82627809AA3E58B7172DAA000549CF6BF891183D25150EFD79A7C00CC23E6B4EA14151B2D572E2AB23C68B834B72F3045F5F573B2C1B22956DBEF9679654C220580117BAD0761C6B94F10196C3B87EFD5DA16EF10ED60A2BE6D5B43A37C3CCDA1EDC5CF680E0A00A3E6603DA433CEFD3B690E13C53B447398A8EFD36A0EFD32A0F5F86F4A115CC7E475AC5634A7B23B683FC6D4BA007435AD9793EAC30C4FB68B0C9AA28BA8A063A50B1D257CCD4ABB82F5FE59A832CAA4CA05554F64545583378B0EC1415AC5160C6CC417E35F8BAE619FC1D61917679CE32435F7052BEDDD151C38E009267D0947D01793BB2CDED3B8A9B9E14BA7E4DF2D401E907724B1259C94EF767596AC865B0C4C7C24E9F877919C05E421516A390755CFC303C4A6C68F2A4BB987C941ED9D416811E7D0085E3723918FF4A66112D58D1C04A82DE0242817D051B2E012CE221F5213E75031FFCE6850A1C29384050A7B91AFEA7E9FA741A13971EF85E7D1A1655646600167BCEB36BD1A386210F5EE84111970409FB844E1FFAC93BD05157879FF6EE0E1215FB0124B38E4898698BCB84CB2A4DC1AB944D0F0EF143103C82D9CCC027EB944C5CE902383A8774F8CC8800BFAC4250A9F14789FA215BEACB1C9279497F7EF061E1EF2052BB1A4434C29C1C92FE71035395889851C42C6E2F440124935F408A3B0884B587C854F4691459CF264D829EF251770C393B20BDEA52D51F0BCCED636833641C1BF1B047CC81B9CC8024E794F063AE4FF0D43282BEDDD1D1C38E00B267D3947185283955ECA114A5230E90B38E24351748F5D1AFA4250F0EE0E111FF0082FB280533EA2D536C94867CEC4218CB07767B0D8D04EAC2E79EA7E1C271F605492C84CEF0530710223EDDF0B2C38B8216D485FC011D7799E9A4F6DB1D2DE1DC181038E60D2177284619018441771813230F4890B14FE26476BC3C20FA2DE0B3F220385EF1317297CFE60317BC9892FE004161D74C428B090339ACB0E0C3DD1CA2EE2860E5AE10393FB1C5C1C709B6C4C3B0B83A8F7E28FC840E9FBC4250A4FDFEC6A9E0B3429FE28ECDF010C36E48221791127D0C500F29531A50127BF802B3878D01B8CC4020EF9FCF0909CE76B135F0CA2DEDD302243D76975894B14BE7DD0F63AFF860B1307B0E2FE9DC0A1438E6004967346F3AAA8B9335AF1A59CD1A1AB9DD108F87706BD0A6BD8ED31E90B4E5AE70AE8862D7047D2541E16578C78DEEE04DA2128BFD2ED2CF2B4C909F4F97C3B026E6D6A4A705E1714F67369108045055BA699343C290F685979485EA8E15DE2CC746D40905FCC254C16D0EC679FBA9043E87F2E92729F9789F97C9752733127819901EE02E416745CB9427B3CCC3D88BF9030605CB629A4451D3B99B9C2D1ACD4425EBEC546FD274676314F75F050471A2FD26D6A73CD13C3F9255E7C39370C39409EE8129772465D3CA01536EC47CA2ACB3985CB05720C23B09073EEF27DBE29D07EFB6CC1174169310789F9002EE245FCDF165BFE865171FF6C7A8FAE4E4B77876CA7E072952C9C57F06B757B33F4AB1CA0F4C28E512E76F85DE538DB13109475EF6A695CC0CB8185EF45AC8A2DE02E5E608A363D26E5A454F7A0DB949307B41A788AA3AB43DC767EC8B12A58172732462D938C1E1D6AD8A2FE783052F057A915B09EF360710D1B96B7790E206F933AA3F2B3E736007FCECB3B20576EEB7B5A4513E11894D671A713B4EBD440792C1EA0FB6C2DBC60E602D7F2872CFC799EF7E7BD26CA2E49424567846C4A2E632F5EF0FEF66F7DA13929F0BD64FBFBC779CCE50B4AAFC134AB6259142C322365556E197DF1C25F258FF8B6CA575F0D4A0FC842C5E7C46CCA0FE12FEF80BC7962C8A4F8A22458F851C8AAE812F6E205FF48BF8C38A33DFD4B8C0DCAAF5280DC20CBDA784399D3E24EB946CFF4144DD34FD17B439284DCC008D9945FC65EBCE037243F9472C788261CA0D4801C0108DB38449DD7F28EA187984DDCC1CB814EE845AC8A2EE02E5E60BA4D056D4C02822409159A11B229B68CBD78C1EF0A949568D5AFDC4C141E94861C2008DA3801CE23C884CC2732BC7A9FD725D68F946551D5D4CC20653B4723C01B8F9A8F619206B63DD0A85B5D37473FF4A6995FA3E22BE912DDEED1CA808492B48A87ACA02D15E54C4E8A8D4AF3031252594FA7C1C9E60EC369320E624A16DA5E6029C09E16EF24BB43124EAA8B9360DA4D9EEFE886F2DD15BD7D5BCB365E54C5382A604B380119DED4DE59B8D87D646A434C2AD2038360FF9A64DE281C078D9AAEA7515D373DCD2548D4002B3804F58C17A2106B466806B1BE35C99BCA1F9E3F93DFBB41CA3B6F4EEF6327991DF05B27D5C3497CEADA1DEF092ECF1E5192A2FBD4A0BBAFD051F14F16B765A32AC393E2E64421023275A2FE4E82B75F7E4FF037FD6E375ECCDBAE951111A05F9FE8773EA87DBD5E3F2526C8A98ADB88D89699C55D7E0B56FBF2ED90AF66139628096EC3B27E7957865594D9C49736CB1F5D2B6BBDDDFDA5BB7241A5002E86B0B256CB21AA4CA0F3E69DEC423E2171A342ABC188AE2C468683AA937EEAB49CDD05E7AA711C583BFEBAE2E6C6997C0338C5999F25F3CAF2645980CF1467C5052E934DD624BBF057A93EC96146D399C7EADC6DB97CF8AE985DC10EDA0E262BFD44DBC215CA3635DA60978600EB4EB6825ECDB90928F23D71FEEB4B7550F2EB2BFA4499FFE9E12159D1C79832A15C6D8259139800996C0B8CBE737398B261AA5D74E53DEED66158486B2EB6EA3E1B8B2125BC5A7A98B6F307BE2F936A76EBD1C018B69F0E61660BD2D9F11DB52183621E4D2B32A0C649B723F7A6E3D45A66CF357868130B8DA08F9CCEDF2D8381EF9C198101C549FECEEB2741399EF8984153A4830E1834957BA2A385DB3D26A9F4422A17B2ABB427193F2A3AD35E99F789737FAA5C076D0053157EA2ADE0AE684EE7340F5F3A3403A5FA643B60349D1B823AF7136F0993053B685398ACF4136D0BE0D8C4AC1D80AA936D60EE2817CEF5C4B9AF2DD44179AFADE413E47C5AE1224315FE5CA44399A6E90E696999CE28585E2AA1CFD36289DCF7F854678F0D117CB1535727F3ED09C8C9F1E67D533E4A1A3A2EAAEEBD31E4A19CD7E138A8B4E500FC53D6C14972AFD96A2A31C6941BA0B609276D37129B65AC21E8F15E026555B403F25D5BD727C6FDEE1A238BB82B68E839EE74A9943AAF43C65D852D07E1A1A20E4E8A7BCD3D96C6BCE3A4759C73B8B81DCEE3705C03ED3800CF409F9F14C73E0D87C58D8926ABE8D83648BB7CC281ACAC48772CDF6B75390E405A75FD9D1473B953E5C6E405B574FC75BD3B409FE149B2585B940310595B97A7C5E5E6C0BA398939712D7B6DEF1C5064719A7C05CB7008A282F575520C050EEF19D355A3ABE3EEBC039C26999F24AB0D0A74008A1BD4F111F2FD1DD1A99E9B833FF401DFFEFAD78B7F5CDCD31FF11321C7AA2EAB7C87B22CAF1AFDBF7F2EF1795A3467317F795D15B5BC8D8D82DEE28A3B594886F86D0270485022310FC09C499431981381133067FDDE76D094F1A8C204CC876C9D3C26EB1AA5CC41110812149C84EFB61334271065CC31D5DC6BDDB92EADF3862377A6A0136587E4CCC17515250999C3B69BE9B4A0FD46C609C8CB0265AB6D52E6058436A64E027D2A36284BFE6AFC33E15285A85516EDC96D3D767B8EDACEA7CD263003C776BBFAECC0BBD55503F861D9DC348369BB2D2D1E3603C1CD57967B36C766765768B1B90D34A6E0264EB671AF0A683A4A732F90C06E3C131F3899C0E41FA091F1F8D75DA60C5CADBAEBD841D3865463AB741699BB4BE3260310D2E9507D18BBB4699082C4BC0AD3F76D51DABD4C0DC04952D37E4225DE359F92479CE6CD65B8A0CB643163E8FE29360DEC70A7BB21A48A206CFA3498AAE764D671EA5974B65E93C295B03DBCCC24E66F38D96CEFF3629BE76B552812652641993AD3D92A8BD9204F209A4261F09B3F24DA58D45C7E7F9D22F07B0FC9D9803783EE293776F323E6A8BF276B9C4F80363293A01F7155E42A060D89567CFCB54ED6608925217B58B53B6151FB1C94AE85258D5BBF321231E99360E7384935584CF234544ABEDA9DC27B5A34B065CA52D3C0F96E5767C94ADBD595844C61AB67CD5742943100A5E3F4BA993AF948DF2824BD411858969B062FF23D08467E9F6EECF9AAD67DC0D8F449B077DDD70E02EAD3A641D83BF04124FE8EFD29B827EAC6BCB84CB2A4DCC2809CC8F47010153B956D7DDA344852E07D8A56F8B2C6201538017338A561AC8011DC7591D39E9B627CCA4B18003EA91A5397340D91D7D95ADBD8798949C0F7A4F19270A3AA0026D9144A6518933C3DE15414C9465B4C5E62FACB8B481F3C230407C1FAD4E961D547F2ED26F5A41AEE31C99350D7799E6AC22B936C04A572549F36097293A3B50AA44F3300C91F74B19D4D3702538EAA86C4E9E9C564A3A4519F360D52E505BE2C7238AE8FA90640F4D3466A5569122B303DF1F0F0909CE77017B04F9B066966F29FAFF36F704F9F4D3705EBDE4F568275AF144F7DD6EB82CEF27F86074763EA74E0EC9FB80763669F380903BE642F03822FC41B40738FA42B70F907D1A7D8861555DA3D273EA53E3C0C0E200CCF704F81700F6A0340DCB3D51360E203D4329CF8C4F3D41C4EFF0E2E387533BEAC3B39F268B71F2A861DFD964F4394EEE5471DD6F0AEA421E4149EE1B820D70E89D8570F271BA492E5A6E4661FD20371B807FAA69A1FFB2A1DD8F6F8F7EEA6E0C697DE4030F6FDB8C9BE8BF84C1ADC87919F629BEA368CEF8F813D07F655B3A94F35965EEE023FDAB2D83474FF32160838BEB565F001471BCD579779BF6A2A06F1EF358141487C0DCA60FD60D8A4A75A4860F6551AC0B15BA55488FC4E371350E59410F3DC89010E3D2DA042690F7F4CF70DDB871A147DC3FEB90A031875A737371BC6C2375DAB8A07ED7199C860BC815A861CEF819EFAD0D5EBA4BA583FDCE03F6B5C822D5E10B19AD1B9AD48D09E9ACE69842C614917FFACAAC8084D35A9A211B7CFEA53B5857B29B0A47D06B7A447512999AB11B75A51D02C91C16293ABFF74E4F3099E05E9D2A6BF896474AC0CC043E2F4EAFE3732542FB7C95E05C509187C059B18A81C3F8FC9D350ED5626D8EFE33633339467E5FE1F4EC00E4EB3310692B3039FD8CDA192B5CB44B7510614B483576F9801C45CA095FB2F54B22E9968B636A8A5ED32322B87430926F693C0B296AD6A625F894AD62E13D34AB0763F73C25D0BCE5D366008AEDBA121CA5883AA7A7D909C05B866E42D1FBA344455ED9BE14FD41982697BF6C0A92943D8A91E3E7C9EC5145CD9D3170E1A18E2997590751BC10D33527EC89974A389AF778F28ADB58B10B294E9ECA80A91499E846A26CC9ACE970A8D979804FC679E693A4263AA04C46CB566C61BC3BDDAEC666646B41F7440721C7E63EAF0660A203E1C29184AC46F7D7E6309D71F1260E0D83208A57FC317DFC035E036E909374DEAA8CB38A50AB94FB5E55BE3CAC96C9676EBB8537CC297B0A0BA64A03CE4356E27BBC65530E0D2FE11B7BE8F79434ED248AB0BA65682DC05ECD7D7384D831DCC7320B3B5DE83350C4A092A6ABD68DC5227F208E64D39F66A5D09881B9451D6D23AD1ECB3A1435FDA7DE3598B31D361D82ABB4F27AE2EA0460B721F773A44E3371DACCE6F43F9667B4F71A6C4C895C6BA6A079842404E569F9CD178DC38C3F0EEA77D496BBFC34A66E50775A73CDDF5870D5D0C6711C6B702A4615495840DA29EA8A38DA88A021A2207FB18B12F9B4887E326FD07EB1917185437F06A3F0B67EE5A38A78310B4BF43D4DEDB2A4D632F28000C3C3ECEEA99FB5C955B60AF0B55AFF5B3286B50564145EB4B1BDE8AB8C1220273CDB999D340058312427A5AF7F173E4264E04B308E649F6966C3357C21A06050515B5CEE417034C9C09E711CC9B5238D17A52963628A1A4A4F5A05D4C94B197F6DC7842F58B702E16988E54C96AE610152AE0B4247B9456372FA9C2047C259469BEBBBA6D015F98C520C051B294A6389230E81CD57E84292C8D53FC38A43D103CE510494A5708511876C8704A59EB10096B698748479A275CA393D7144CA306BA0B3A8FAD739C0E7F61170267B7F53ED42BA80BA9D583BC081F3ED7B8519F43203F769B86CD7C280B4F974ED2D1F96EDCDD6CE037193990CFB8CF8BD66182E4749978059DABA6BF850ACCA59D44EF1B98F08E20A229022F09FAA3BBF840E7080165610FB0ED9939EC2FFB011654970394877C621C826044C03FEC8D064B3888BBA8C1C853AC8655011945DFBE63A1D54E14EEAEF0E9CEE1FA07D6A20987C23A46E50655279CCADE6461E65D3817BD7F3DFBB5BD96D2DCA7B2BC514925B5095F0E9B8DCC1C29C307756273178585136579A3524A6A134EEC2FD330F3A18C1ED4877D7491EFCDD1BA52A966546695F684639531CE3A1FC0C5C0E542B3FD2CE5CBDC2D23BB5723AD2EAD5A0972E664214DB10107B297EA78F55C73EF8C11410DB4CC4A0B2B4F79B4BF03C8D0A58A4C0EC0CDF1EAA02FC07545067E56E95A38420161E47393CF96718613FE872BD94705B45F02B70A50E95AF84301615401069F3CE3FC42F95FB87DCE28C04CEA68C68C13AAE05054BE444F372A9DCA215064191E9D92EEF7533B54929D2EA6A8A273A099E32444CDB8DEE7784BCABF9B8A3170572B6951B446C1A3AB5A3C8DA3C069A5394EE2AF83D3F888133428122BEFC1431C1CE020BE1C1EFD03DD71A77313206F523C59CD87D30054C87750193DBA10B8CD4FE74159DCA4A892960FFFC9A090FB80F279F71E7B69E1B4F31869F3628E4AFE5CC760AA3DC796CDA7E3C08B19B5CE83348C0A0B287A7122840B3A122CAB4767B61751EA9CD74898148A0AFA704E830339A3B5D55FE1858B34354EE0250D0AC12978700A8F07CD7DF165F1E724E682508D83462983C20CC21E1C3362014E616CF7E810E1DA209D57785193E2701A3EFCC303424E12CAE3D153D23DAE3A5F89C2268513747CF84B84843C2695CB9FCF989B6A35CE1AA50C8A34087B70CF8805F885B1DDA343845B77755EE1454D8AC369F8F00F0F08394928CF029E32E00F2F6A53306F4CE201759E5A8453DC5DC913AE62650D8BC6A87872168BA8F01657269FEE7A9A1EA10C4246C579F2351E19A040973C791F7D48575AEB5C22C89A148757F1E1200111F29358267FEEE22FECD6F88A133428162BEFC14B1C1CE022BE1CDEFD33CD254ED0BC40BE58C4C1A9FDE39D3FD2D5EA1A1789B206C512543C384A44047C2595C99FBBB88BE335AE62E50C0AC5887B70118B06AD90B365F0E81AEE2E7C9D6F584193E230F23EBCC3C2811B08D872F8F30F7FC1BFC63F9CA0418158790FFEE1E000FFF0E5F0EB9FE918344A1916C557DC19B1143EF11E6B981718340E19A50C0A31087B70C888053884B1DDA743B8D724B44E61258D0AC32878710E8B073A882B8B5F27F5675D263CD4891916A795F6E49B0E4CE118F8ACCE1CAF308F7E689C324A19146310F6E092110BF00863BB4787B00F98E85CC2C899146414F7E116060D720C5B069FAEE19F64D17A8713352A12ABE1C5471C20E826BE3CFE3CC5BC36A371D22865509C41D8836B462CE844F168BB4787F02FE7E89CC2499A148655F0E11C0E0F72105F16EF4EEA1F8099765227695EA856C19F933A3CB593FAB27873123DBB3D6C6ED2F988179C2E1227AFF310787ADC0072E963786CA6DC7350133E62650DCBC4A878F4148B0A2DC2B365F2EB2EF6D1AB096F31A286C51A353CFA8A0185A65599F2F8F514FCAED784CF4025C38242BA1EFD08C2031E85CBEDDFB7DCC366D22F1FD646BE9E04B170CE1496E7BA98CC4E5137C283707E2BA67F1C6EC2F59D9861695B698FEEEB00A17E2EF6DC5369F31BDFBC9B72CC20695A945EC1A77B064CC84363593C3B897FD36FCA519CB469C158259F0EE37021A7F165F3EB38E9FDC209D789F2868514D43CBA4F44061C2895D1DB8D44E56F1815F7CF06B7386915D445D5EA69AF2C6A144CAF2E82E1035EEDD41BA05CBC8105CD4BA65CBC99E730E5228EAFD59BE1C54F8D6B04118DF5BC24E80EE6F9519D1F04A4053D4071B423515E406D3327A7BA3F4E5F6C1E62F19166FB464CE3623830B302BA78C9C8C1A1777CB2461B77599C05AB5C7853564D7D5870BA049CBCCE23E3C3B7067EE15103F8C7CC39569E31738BB94FC2388479E857ED0F59486DBE240B79837F7D58E30C196D415FF4B77729FDC00BA8ADE6E4C04BF64D2E15E351962C37F3BAB2A6F0B294C67649187403FFECB3CE1732DE820EE11E88567B041253170190867C22BE5EAD710A84B8A457C697AE353E918434F68BB2A03FB8E7B775DE90D016F485FC46B7DA254A597559542A9083C047C5357E52622FE82EE60172B59F642175212459C833FCABE81A97C8680BFA0278395DED13B5B0BA344A1DC847F073EF1A5FA9D197F459FF38BCC6538288A604BC24E815E6A57A9D2F04A4053DC0BC6AAFF6812CA4B65D92055F411B85F49E90D116F4C55D81B212ADFA650EB53F604175294079C82F82A0DE3730EAC2E3FEE10D52E5181890D20FDF7961D53400FB42EAC47C8000B8B047D8B753B54E9105F5C590E455AE115E799DF08E0CBBB4839AEBACB49E1925266C1F0495BE30B8704B405AB8F8F4A962BAC1717745AFFF53B94090D21BCF0BAB5CD1BDA53CE108010BDE7ED9267AF7080D5B930E69840CCBD0C4413FEE68A014DEF0B5683164A86B1CA38081E5BAA661E18010ED427EC059EB0695B8BE340A2D958BC027A8271CA6CA62E909F8DF13FC4DB94228484CCC9F0F8233E6E0470CA0E08CAD5E0ADF3E0AA3EC9F89227AD31949ED1B36D34E6091965C816A6F79670D03D6A02421CDDA91280BAE43195C3F2F032DFD704FFF667BEBFAEE2FC5513CA5AC6604AF5001A70558D9898901152C74908829935F77F5AF24733F4E3A0ED6322C2BA83CE94CA3C79F0DF2517B575169733DCC3EA76AE765B5A6A107940093DE367E38D630BFE05E1F5E5CB673B942CDB0FCB0F6A4B3CD1E9336C929B89BD9D7428184497F4FE91BBA630266B2068C9F49B5CA75AA36FC3DDE09C0F6EFE7B9D78A0EC1CA431A20C39A317A3AD032E703D58E5385CCA90327B73B745D8EC1B9405B9CF42DA46358744075D2B3B64106CA23789867DE85B573AE52D1B0F42AFD49371BBF7D6B965D708FB38FC7DAB95CAD69E80425C0A4D38DDFC835CC2FB8D7C1EFC5A4C7612DC3D283CA939EB6FF20C2F904F5705AE1828C0EF0E7221DCCD03A175430282FA4A77529A360E852308B5023F7F1F611032FCAC2D3C5937474DE333B3CAB860EEDB566765BFCD1C483B0A27991417D13CF4ECFDA9B65A569ED3EB7488F98DDCE64339A8AC226A51574F4CE34DA4EADC60EC5D3E6008D89CB78C1E92271F23A574D1FF681214379E8D3B0B86FE226407ABA60B292CE619FCC362668C043B98E5BF937F11EAC305D46504FE743F31D0CFA2C8279B2D93D60E4425ED2A0609C82D669065B1D14A8A1FC04AC8D9A384DA7365D568DB6CE9DB66BBF26D9F9F2F3CF6F5A846659835ED438A4FDFCE676B5C53BD4FDF0F31B22B2C2FBAA46E9C77C8DD3B24FF888F67BFA8D1F35BB5F5E356DE897D7E7FFE5F6F5ABA75D9A95BFBCDE56D5FEEF6FDE940D74F9C32E591579993F543FACF2DD1BB4CEDFFCF4B7BFFDFB9B1F7F7CB36B31DEACB845B49F056B879CDADD7C422A3D8DB1C69749515617A842F7A8241574BEDEC96217FFB8B8A77FE3276188F5F3E0E03E2B76A5145AE0A3E27445BA97A7FFEE4EAE5CFCE3076AC7D98AC4A2F2871BDC5C7D90D3BB31BB4555116EF4E525291EDDBDDA941433B5AE5224AAB72B94A2A2A74C6738BDEFE03C4FEB5D36FE2D7251ADFD3B4A6BCC03743F9963DC6EF3A2A2FFE471989FCDB164185B8461CC25430949E6981F761B328213FCDCFD26A3FCFC46A86391536F245209AD5BE4A81183B5EBF76E241E201D78ACD155B979501139CD259857DBA0D6CE232B51C76473EC8BF503682AFB7B48DA5F77B7AEF028E3AFE64857A8AC3EEFD7A499F058ECEFE668EFD675FB44D77981D7C42FED8D952C2E2C615172DA61198D13EA434EB5086C55817135BCFCC805373EC9223CB52A57E43BF5A3109DB8146BC494E8FD04227629B6E5FEADDEDDE3022A769F628D287F2398DF6DD16E6BD26C9F20BC3EC51CF13CA1DD4C16A9FDC5828545FE98642BA17CE3AF562DB94229EDE8486D79F8DDA235E79BFC7391084DB9FFF1683E5E67E3EE066F3DB01ED2A513A6D68DFD30338417DB0FFB90AD93C7644D8655DCF6285FB406E11D286E8813E96E86F062E9DE2D862B76C7BA717CC47420B64E39B2D90CE1C5B27918130E1B89BD8FA53BE439436A25C4E448B8D3540E8599748BDE73ABD49ED1E23AD16C8205FB9AFD1E121AF3B339D61D7EAA80F6C9FC7CA891B1EB6CC7A15BC622BD1A087D4E0B71EAD340DACACA116496AF77E54C1453547E2A8A4D383E1EF91FF149D07318643F0294549515CC0A1C8E3843098560D6FF7A7C94E9F7037B270CBC57DA862E2A8443CC4D7B8F30EB8709736189903DD6D398ABF530CFE87576F03CAFB3AA104DEA7F34C721ED235B6D933217E68BD9DFEDE62C9513FA52E27273A12A9C4FC50665C95FA8BF4F8507945397FF96FBEDB11E28CC8F64F117E11902DA07779D729C49304378B133096C185864C8A4C8C081E7C64891F4660891F489FA099BF96C87EEF9B1A4390C11F96D86F062F92D0C72BA539A0B0D471BF4F96352058CE1C0B4D19E189D0E32C7B135CBF77474533C198DF9D9120BDA59C3251C2BDF87F3840B31BEC39FCF792590211F3BFD095A3252DF27F3BB02CA785C82359E14E7D9DF8F8FFB4B45F9D9F1DD35B2EB63FA9C68EE69C2314670FF2CE6AE3AF0CEE5F14A843984D6A14C726F5456B29017391CBF992D2A7C779EF9FDF818C4DDDBE09D410CFA1C0A696126EB97D15656B520733816B145E53737B009C7C7A3E57A911EFA8FEE3DC7A93EE3BCDEE2917E595F7C0FD12F8B1D996BC756884A762CEAAF811091D8DFAD9797156BCA7658EF51FAF01655DBBBBC42028584248BD212A582DEE52D630A491698784DF5CAB3FBFC11FF5AE47526BA1212B0C77F8BD3FC9B0E9F13B0C7877CC22759C4269CD097D6DE63FAA689109DF8248B9E56F217FE9055B848C4A5693EC50DF132C992722BAE50C31216DF75EAB85E11F8BACBC9160BC2B83D33CDAE05B73F59625CE3E22E11277FF9147BC4F6567708B14DB144BCC3C5EE06EF10F115BDBA47C215D2E7A05F16F8CFA91C5A19F35CF867B2787431CD159579774A97012766315666AEDE002205906C819D22F1B06BF38BCD91BD443EAF97581ED6A30A605BE053EC11E52AE153AC8E26367F0213205C8A05627D9F262B4AECE2ABB0D94A48B2DA6CD51C5546E987EC212F76EDCEDA6C9DAC5025C6EE29598BD6403A530CC655927D15DA012460B701877664147B7098A4436E439736450D3F1E4D5FFB4C7AEADB57BF9B477699BF9A4488EBCA66082F765DB91F38B557AAF962368BEA406BBD7A98B121ED4B033D07E667072C7AF84781D726D9615E1674EE44DC47CFA758B481A62281D34FCCEF36686480209A36FC6881D387380169FCD9629C97923089D740B5F22916887551D0EEA938B4617FB7988F481E9332B94F0530E6678B8DD13803BBBEECEFB6681235989F6DB66C136E969F843EF4F8ABD53992F54552EEC11B68A4443BDC7285F6787CAB5C4416926D462625D50107256C8A4524C0DFA4DB52DA9FECA2C905DE575B3994743F5BCE5310FA6F6A92064C508C4916987992BE7B247D0C6087BA9866872A937AFCD502A92E1EC858F20FD24D108BCCA558CCC5242918A9D8DF6D6676F6F9A640FB2D301613D3BED34DFEE367CC630F7EFC343A74DE35CAB1DF6E86F0E2FBEDFEFBEC33FAEB87EAABF75ADDE1381528936C8F2DCD547009168C95FAC476FDE1F6924EDE92F6270B1BB2D5569AD9EA7EB3B164876EC837579CE1667FB75A1F2EABA25E55787D217D50A44473DC77192E3675B2C690A952A2452F3629F03E255FF66BC2299C09C33A39D50119EABD0B69362B07785D9E13E76D72F1D8A590648909F9954B30C7BBC159FE884006084916DFAB36BC4143792EC5AE7FFBEE49B5B237A6D8AC8C6464544C43EB79BEDBA34CA81F20D9A2E727F7F76CFBB64DCB232313D17DC3CF1625ADB36495EC512AC6682EC1620EF9E1419C406E7EB19B85967D34FE6AD3BB5AA16CF57C2371974B30C7FB674ED7EE64DBD8DF6DD12E70B92A92BD3C8802922DD78D99173AA44563CD132C6AD466C8D44C0BC89D3B31CD2266E5ABFEB821EC0950E014D75D0EBD5EE27D9D64C602491C61C51196358F89C97EEF85ED109D78AC528D3C364378B93C2E56DBA4C2B4AB86D2DBEA39F5C96809DB85DB062091E566082F96E56F51D98C902EF0234EF33DFDA7C7A93119DC6596CC042512DD0CE1C5137D587BF44DF20E7806C1950891DC66082F9EDC7E57E958D419B48E2B7591D32E9CF6FBBC9BEBEB6EF171B748DF390BCDDDE2A9CFB0CC23CF587756221C62C17889FB60E7DFDEDA5DAD7A5B016BAB6C8AC546B6A3BC0FF64A9ECEB79CBE17CF8121ABC5DBAE72815DB46C82CBE194963CF44488040C48586C3A5D3F9CE7BB5D9D1146C9C14D4EB588BAF4D0E47D5E17DB3C175A989064B3D1EE7EDD6C87957601B209562C6EBCF72BCE251A8F09D6656ECA055DE600A51F4DAC178DF317EB456487603F0DB14C5FE623AE8A1CAA4A2EC19D21EF9EA403E80A915979FC8E0BB9D1E8E46CB63417C03D11E3AF21FB693E7B8DCA2562C7A5E1734CCF665FE7495649E1464C7342953E5E629A1BAA587C31CDE62B9F17A463457A1AA5EC0121CD09F5AC948FD800C9EE2D49DA06080A2CBDB4AFF4043140BAB77EF8D11AE7ADD81F1B7F7629A108C7A71CCD5790999FF73FE891C11D3E852620CB7C0CFD746FE2D0290E9D96EF8AB79401CEF730BF1FD3404C330A731E82C5CFCB317F5E16F9ACCCFB9E84FA907459E242BA7C8B4D083972B82E921D2A9EBBEBE8643C28DD15FDDD0E25E2E94F48C015BFBD9F5783DF09580453BCCAB3B5CE3FB0847B0E808F1422EE79007E5288D8D444FE3FF0AA52DD2708245B635FA215BECFF3AF2A702EDD1AFDEE1B31AC506133A9D6C8BFE6F926C5D7695DAAD005098B9A45292EBB81A9EA9E64958C532E702F1548772F83DE7A47E44F7B9CBDCFEB426D392361D379E94E68D578FD9F583CF72DA79A235FE605358E071C7EB4C2B991CF69F53F9AE3F48B4372C7924F71E8F8293A7D96DF81153E7B6C360B5FE3E2F6CFE2927445A54F01286379E0A36D3E9F1EDACB48E5431F42BA237A774A4B833F48D8B607E8AC159F62314B8C8AAF989E77539CE012532D061EFDF658F10614E6778B35E7EE7AC8F6B52D3142CAA9D631FEB6DED17E0618DD8734CBF95C1D3428606DF5197CCB8C9C6AD1AADB2B603E642BF2DFE4518406926D86EA7EDE938CC3C3631D1E628F4F510E90EE43434877A119C6173E90FB3E065A036DC06EB29C7AB845B9E6FBA104955363908E419A9D30BB4CF3BCA017002F329937A0CF9BD5D3C02C3ABDB703F605084921BF0CF3EF42788BD7422C6B7FB14040D55684687FB2EAB4367FDEA127E9DBC6A6D80F0BE80D16F090A04D3147FCF48D8C1FCA6DB2979D2E24594D32ACF38FE493B44D9FC99055EC514BA936B592922F1E7E96CBCFA758D4D136AF72A0F331FE6C8905BE22D6FF6C89257D96C65F6DFA117FD6F4FE4770AA4D4873E3F635659EB8AD0848B764102507042D25BAB51FB9A2E454376602534E526AEC577C1FFD8AA6452EB3F1A4819ED7A150409C4E67228667B7F01C83C631078DDF9335CE1789190DF2BC98A180389D98D114408E19CCCF965872CC607EB6C49262C6F86B8C19316608316338BBE02F580C900E5142A3BB4C781832044E5F88696EA8E0790B50E0548F47001B62AD77C2FADABB1A8F6AC4A31A43E3923E857C4AFC709DF0878B3D60F02BBDB97999338A0DF4CC438A0A8C85964D173D987187365789B8216DF8D11CE78F2DAAEEF2774F7BBC125A3E9F6213F877EDE315C94A5A6464532C9A44F280CBE6163ABE3D8C3FDB95F73FF33A4DAFF2472C179849B2F8ECE67521BE1ED9FF1643DBF714DA7C4F01C219F8887241A703A5DC75B16E10B09C82BBDDA13485E7E1C6244BCC2B546C308C39261DAECF7B52B74C4B75EC79EA0BC6F7D156824E832DDD56FC4D3D1D079BE307AE4D5FA4CDB2FBE3FD5F23E57ABB9F567D995619AF4733F2F1295C8F768E93D43BA5195007466BB523A1CD105E2EA1E94BB81D85DED3CE81C753CA32B60BBD0D4022CBCD105E2ECBDBB375ED4B3F9E83B708EDC2F1698C48713384974EF1EAD9FB4DF122B23BC1351091DF66082F98DFDD997212223FD2E7E01294FAE4B88CEEC4731398C875338497CB7562B3476E1334172E836A91BB66082F96BB17F9AAF6FFA6078BEAB22D55AB1E396D86F06239FDAE7B12C61F9F7B44072EAB55238FCD105E2E8FFFAC93BDFFE0CCC1BA305AAF1F696D86F07269FDD49EB7BC4CB2A4DCFA243607ECC2EC0980486D3384174BED4B54ECFC06EB1ED181CD6AD5C863338497CBE3A4C0FB14ADF0658D3D4EDB71B02E8CD6EB475A9B21445A7B8ED12CEC1C5AC7681D69ED486B6237BD6D34C93DDE74C5E33A125B0710996D86F08299FDE47771BC0374E2B2423392D80CE1E59238AFB3F5025B99785C174A4F0044669B21BC5866BFC7885E9BEE7790C8803A705AAB1D096D86F0D209ED374E33A0EE848E113A12DA81D01F8A22D92CD0F7E0711D683D0510996D86F06299FD11ADB649869BB7657CB1BAC77C76B9244BAD1BB96C86F072B98C515917B87D8AC91B994750A73BDF34DA91D066082F96D0D7799E7A3FD8C2803A105AAB1D096D86F0A209EDB707DD233A5239F69A238F1D787C93A3B55F1EF7880E3C56AB461E9B21BC601EE70FFE8F15B2A84E7CD6A9474E9B21BC684EDFD23B2CFD12BA817464B3423752D90CE1C552F936D9789E70EE111D88AC568D3C364378B93CA654BA2C729F6709474C172E6B94239BCD105E309BE95D1775E179FB3307EBC469AD7EA4B519C28BA5F5E78787E43CF7F9D6408FE84066B56AE4B119C2CBE57195A4E4F7EBFC1B2E3C72994175E1B3563D72DA0CE1A573FA0F3A2BE69DD30DAA3BA715EA91D366082F96D3E7755190CC3E973E2F6D1C305DAEFED22847369B21BC58365FD257433D1F4CE9215DCEA4A8752395CD105E2C95AF50B6BE48CA8689DE773C03E00EF436428944374378D1442F57688FBDEFB113911D29AE8788FC364378B1FCBEC55EA7401A38978969582FD2D70CE1E5D2374F3C6F16ED115D48AC548D3C364378B93CAE8B07B4C29E27EF5854173E6BD523A7CD105E2CA7EFF27DFBEEF4B3DF08CDE33AF07A0A2032DB0CE1C532FB6CBF4F1394AD3C927A8074E0B3463752D90CE1C552F96D5D261961A3D777685B48A7376855AA2A27D353B32299FBDFCCABAACFB7F91E70587C8A3DE26D7DAF061D12CD71DF9515BA4FE965DEEB0BE9496729D11C975449B6DA26A580C8FC1CB2397E227F3477B1DC2634AC715862DAD135A5AE56FD37A89E2EEEED4A8910BF1366082FFE3BB10CB367D23A723A72DA6577499E2FF064F908EAF44CA2463B12DA0CE1C512DAFB1AA5FBD2645C918C247624719A13F2F90ECB2CAA0B9DB5EA91D366082F96D357C92326945A7DF5BC518A8575D93FA2D78FB4364378B9B4CED1DA7BA466405D28ADD38E84364378B184FE8892ACC2195D4BB9C49EB76ACBD84E579F4E8344969B21BC58965FA3679A99DF3B501950977BF674DA91D066082F96D0372427942EF4863300EE72C593094A24BA19C2CB257AB2D9FAA6770FE9426AB56EA4B219C28BA532E512DA78BF1F670075BCF149A91D096D86F062097D57A0AC442BFFC7210560970DAF530891DC66082F96DC7460F6698FB3F779ED73AB2007EB72BD885E5FE5724E0DDA3DC8259A57A59FCD88B7152A2ABA7FEF2E9168CF27596C1BCCD6302297608E779EEF6885943CD8F8EB5111F71A155FE97EC13DF2B9635B4476A4AF1E42C7345613629D981E9AC7F3C36D57637C13E87E3B2E866DF32AF7CD2D8AE94A2A5857CB26AA02D2A84F08CD9F8BF5C32DFEB3A6B794886042921566FF0B80C926596C9DCED3352EAE51B515F64E33BF9BA335EE96B78C333FDB626DEBDD7D8692F4739140985CB225F6ED0EA50ADC31C912F30A151B0C638E49E69857A8AC48D57EDEAFA5EDF242921DA60A508D76C0F87493E73BBFD189223A06275855174BA806144FFADF434726EA2611A5FFCD1CE58F642D868CEE270B26E26C2382F4BFD9A03CE2542CD0F0A3457425BDC8AC24A34C21B28E3F5B60E1725524FB4A466313BED3364B89DDF8DFEBFB142DA4DBFB142ADD38736086F062670E28773CAF5874888E448E336091C78EDDA8F6365BC2C1B347D26146F73EDF0F82F11DBB582640BA2E92AC0F759A60A94374C6E4AE5888AEC68198F87B82BFF98DA83DA203DBD4AA31A29A21BCD8887A56AF133AFEBEA13339A5C7AD6802B0CB8D1A53082AC7770A22C7999FADD601AA5A9CFDEC7E3347F98F9DC083E607AB1933D5D049483A1A629DE759D93C7443E276E7305FD492A09DCE784E62C4D86986F0626327CFA1E7149F55155A6DDBD5B765C8CE65329BF61368B1019821C406D0B3E953B5F57975228CEF83F60AA0C8783384C8F89E48B77B32FAF63C4BACC9C407F77568B1019821BCD8067041799337C727CEC87F9A99276FC437013760BC19CC32549F4F2DDF6B6E1F567926ADE40F3F2EBD76A7423B2F30D1105C3DFC688DF3F61944A23FBB945084E3538EA631B62F357FCA3CDED0D121BADCCEA1548D1F15338417FB51B9C2A8F47C08658074B9BE40AD1BA96C86F062A9FCE95B4646C0DB64EF97CE1CAC03A527F423ADCD105E2CADBB6DEC7E49CD803ADD56A0D18E84364378B9846E6DF6397AEDDDE0C265A5AACAC9AA0DF46EBBE797D891DFFF79B6212556993924DAACC816185767EB7541EFA8171666B9248B66D0AA5C2519FE5168055C8A13E24F4AC49FECCBFD5BBDBBC70554EC3EC51A518E45CCEFB668B7F5C343F204E1F529765B93A0F2B2BF5BCC1490C6264C1234BFD89CB7ABB3AA78A6CBC582C7F8148B369297154ACFF3B578D084F9DDDA3ED0342BEEEEFA59B3DF302AC4B91039D5EEC4629D252B349C82968E2E0AC9D6D8D5F370012F84CD26DBCC32E57B718289FE621161F3553DDC39C307582EC5E23429778D0D7F9E944FB2C02403DF662D98871B7EB5388F858A9D6CD8F8AB0512589D2EB5F8A128928D827A629ACDB90D243ED8D1FD6489718D0BF968309F628FD85CE60522B629968877B8D8DDE01D4A32D29D017085F439E89705FE732A8756C63617A9F2999F2DB0B87B5B793C3EC90293B938934764136CF0DA58AA5C530005CCF13FA2D596F463C46F0EF3B30D167BABA208C8A7B9A2B237DC6932E0C45CF3922B114AB741CFD0A689C3E453B64799E47329D9029B7E75933D92CE9F7109E678FC741387282459F4959893F47739E91E095D2639D9023B4542C3687FB1E9C9E529706078F8D50E09FEE6F1293623B1447CBFA9FBC91203FC42F129F6887263E453EC479C403D70291688F57D9AACE8E7A6F82A56069F648E095D4228EC5306042CF087FBE078D4F1670B2CF2D901A0865F6D4687E3B55EC2E09049B01A6DD6ABE6710B71A8D9FF6C81956C801EE1F8ABC53118E18E27FE448C9868814B03DADB3A4969274020A29866319DD91F1BE16734875FCD919AD7899B0560194F4C734195E728C434AB999984D601F9A6650F79B16BFA3F1FB2351D76E6C24CC394AC79AEFFCC697F55D90F03926DB165CFB3BF5BF405F20233A5BD4AB2AF429F0012B0F03FF1E67395ACCA73123F056831CD0195D25701DA269963BECD5121F487BA9FECF694BCE89B2FB8995EFF93ED0DEC8C1977857EE8496D4EF5D3C343225FB7A310B19AE407CD667F0FB9F6744D6B538A84E3AF87DA9AF66E5DB783E2F302AF895F12940A9F5C58C2A2E4ED3D3ABD7162454BA9DFE9E248AA5C1C49E3E2C814E2FCE50CF2E7A3FCB2EFF8EBD2CB18C7F0413A271D48D2255FE8BBD4A1CFFD3C29618CBE269DB6F673C2C8D82CB8344AD0320E9360111536E07098F9D962C0849F2A60B706F3F3A1BE2E737B10C7D06AC838850C8E9B2FE0422D87C9616EEBD14219D51283A0AD3041EEF05B25D8A28B4709C684E3E4D815CA3635DA2CB03F87839FCB2E358E5165F7EADA4A67850E4FAAA1C44230EC7F3D4E3AB503A685C8D482CFA5920AE5C06346836CD45221C793A731F6F1D06F3FCA4D4384E3D96A9B94E2142AFBBBCDC2F5463D4096122D16268B0DCA92BF149B40E4D4E5BFB5617A9D71C43D7FC46D3F5E3E9E0FDFF536CF96FDFA3539F8F9042AA02CBE830D82C1C770903BAE995ADF23EBA698C0AAF8F8B32516D4ECB984636E0B7FE07B42E4655B4397879FF6A004B3E0688761405546F2FB6E155D4181156B36C11A4F3AFBC2FE7E9CED62C9AF8397EFC29C2FC2F4B760EE57C0E3E03A46FE65187EBBC7AB04A57EAF2B81739873FE6B12C9888F23809699BCD8E1B9DFD943AA48E8AF33BF1F27BBEE8A6677F65981D142EC6272984B2F2D94519D3308DAEA17E40ECF30B6E8E2D6BC31E13839B66CAFD5537F755E4FD5A48F3ABF777AC45FEBD823A5F5D09F3B27E62DC076067D0EDBB530533CF47368FB6D91AFB67581E51D9A7C8ACD11933DB0DDB3FFD1767F9384C4FC6CD12BC8EB6C2D63313FDB6C785E63C02EE6E7A36B0DE3C66EDF2DA1479ED10AD410815A00AAB6057D4D463E0E24245960E235D52BCFEEF347FC6B416926204302F6F86F719A7FD3E17302F6F8904FF824AB9D39D29E1C2BFDE116461E65FCD9068BFC252D3F8FBFDA6C195F6DA50DFFDD6F1628FB7D9AD0237D62E198DF2DD08AD5967C99E911169436B7B50AA840BA4D7B690F723317648AAD0610B0C7878FAFC9A9F6C872D7884FB1D9DCBF4337A8928E31B3BF5BF40471921295F7989EB212FA827C923526D0BB64132CF0528C0A9DA140BA555FB8BD6618376F594BFD613ED10137C9B38FF4D04F22863558C22D07E8B90F28DD159DBF715F938D203823BFF6AA737D569DCC8C5C984BA5F559B18236F9E58AB6C02658ECF1CF70B1A949BF0F0A0152A205EE13E55F5E5C2659520A4F828A69167B2B9202939F68DC97B617886976A8FB14ADF0652DD69A90E480794D02BC447139D50119E8D888692EA8F25D257C920DE6937C3075F8D10227CD498F1D223D9F6281483B938ABD2F629A39EA7B943ED0EE365031429205266E9A9ECC4C2EC11A4F2E369760B13B07E375794E3E369B5CDC3B2524596242F1884B30C7BBC159FE88C0EFB190648199E70FF057984FB143043ABACCCF367B7E9A212E40443EC50231F90BF7715B40E452EC103F642AC431C50DB1FDB6881BE660093BBFE2E6B0B5ECD5FE778B59785A09BD19C05CBC9C6C812D9FBAB76CD99F1F1E84BBF2DB5F2C10C8A056B663FCD502A979DBF3F93AFF265D81C7A5582336A7E741C42EC5624E0DADC828F7F9468A315CC2D2FB1E8F64968E3E6DBCDC4C1D45F7305B07C34CCDD8B1DAAAD93B51C67E85C6CFBCE0FC28F047B2AE84EE7BF793CDF73CDB8820FD6F3628D298CA7AF47491106294F2CEE4F167AB7DCE5E9F2739D1F65E261969AF0B2CC7F6D0B31ABA0A22D0B47C973F3059C7A5D823DED6F76AD021D162B85E56E83E6D7A1A7227594AB43F0C218EB1C69F431E8CF944E7C6E9E8E156DEBE2EA61D5D53BB42D9DA7F2BA3A8335A18AC1EA675D1CE3C34C2197F76C0A207A315786D921D663326901669F8148B4591A6228193E1CCEF3668644C21AD1FF53F1E6651AB997AC76BA05AF9140BC4BA2808833F8B2188FDDDA603F19894C9BD3848677EB6888D388327F198DF6DD1E4D9ACF1679BA8DDBD602504EDFE579B4E4DB6BE48CA3D78C38D9468875BAED01EC32B6C40B245179C74B8880E78B5269B621109B0346EED7EB28B2617782FF6A3999F2D274A08FD373549036648C6249BED2949FAEE11A53570F24F4CB343056E241C7EB540AA8B07B4C2C0809F4FB1185C252918A9D8DF6D2683F6F9A640FB2D706BA798F69D0F2A48572C7B9FD74B0C2A06E8197D1E0DC654C7675055F580388143CD1ADC56A8A8684F5FBEE35648B259675CC3885C82CD3AE8AE7D5E5E5804ED7F3D3A52B3D732FBE7358B3E83DA7A9829F6B1DA2A268A3287E2F8FCC1645793C2090DA4D8E77468F6D11DA74BF08EE2CE211CAC3FC934AAA6A4589F78286E2DF1881451BCC57FD6B4370F60B24936ABE0E91A17D748EC53B2BF5BEE75064FD8F53F5B62C94D94F9D912EB53916C920CA5B47B0B60F2C976DDAB78A92DB1BD5D342391E1EC112529222361FFB146CE6346E031019B8A1632862A7EC092A7BB2AE4BAF67160965258FFBC6C9CE7CE44585DE5F9F86EA730F9F852DFEDE4E754FC325BC676E0B7094864B919C28B6579B719C72FBD1950075E6BB523A1CD105E2CA1F94760FC715A785CC69ED6530091D966082F96D9E3233BFE58CD3CDC63CF689D7264B319C2F7CFE6B3B2CC5749D34795287DD65FE6FC856E5AEE1EEE31A42EAC2B7274901A8480B6B3162B0580FE729BD70538F76FC4F333DDD5DAD485830D8EE6DDA16283A10720943BC7C13B4AB804733B7F7E0356B33913E853678FC9BA4629738BAD032BA6714486801A366C99CA72267340780F2C9A34FBC419355EE6E5402385B234041FC46C080382CF64498F09CE545A3203B6EFC4E930DE0E3E16AABFAADF90145A08911AA3B0206B40104D46336932227BE089CE4C47B6C017BA02C90199C3DED50E864A4B1A99E3899C5268DA13CCD484996C5364E3817AC605F84E794899E685800A201DF3A8CA3CCA81997AE41AC5F74C32D8E4EF885DE316F72FFDE1BAF64084E9704CA92F0DC9064956D06458A6C862EED06C80F5313653D96847955E57B495FD3D2439BAA3065F98D7BF0D6901684A84E8645497BC416E9660E792A003F44101D9B613AFFC7D73E3994BE5CB9A72E5B73256952FC2CEAEFC16D04BE54BB69D76E54BD7C039D0408B21114292B6A18626ABB92491A07DD04567EF491307B8E0CF9E391320227500710BEE68339B491E00DB037BF4167F17F4E9CE97B953070050D1A61375A08C948927BA74B81EA9225BFA5DD084EB705B7344D45611841DB358B08387F7440D4FE315858DA74D8A1C156B0736886A120DA8804DFDF380732B9EA2F9A871C1AAD3AEEA2EDBA13CEDF608D31A57684B15DF25B36226F50FC25BD2C0AFC36DECB42386CA3EFB38E58F14CCF5C5F69CE0955594606F48B6F0340B7EC484E0CC9CC70706EA607490AE9D76600584A124877CCFB58DF3E5AC8E992A80B5331923211E8C38F96E5767C98A390960CD1B0042491B51D68A355246C74C1AD9D8999C11010F4C99EA79BC20C58D312CC20461065107BE8CD91C3F5D185BBDB065C03B1C59E477055C0803A2A849033C666055194076474D1EC8DEB90492310F462202EF409A564B4912926C450A0A77CC2468EC9B59E924F950957C91AFEA7EBAC6BEB2056D55A5B3623695CFC11F3109783BE79181C53A1429DE757378F68460345564E8456C8830C01E3109461BE711A0C73958E5FF59277BF79020AA2B69C0CA597181CBE09809C11B3A93152CD8C1A8C13D03E4420E0940490FFEC5211BB70B791C33434453677284833B14492E51B1730B1D8CA68A16BD880D2106D82366C268E33C0AF43807AB7CF6F52D070608EA4A1A708F7CD9F899CBE09809C11B3A93152CD8C1A9E1181C04F5496A5887092E8353A0869780C1821D921AD7C343806EDCE0F475E418056DD9C16471E4F4602D9DCF8F11ED700479729BF31E15D59478B29DE1EE418F9A044F3EE6B33B9883553BF7B0A343ED8BFA4A12F02F48DA389ACFE2982921583A93191CDAA108C23CA969CF0E5E59450DF6D54E0B6FB3E0474C0ACECC798C60A00E4C07B760C12B4FD0C1364CB0E0C74F071F0182813A141D3E1445B299F1F990F455A4E0056D78216471C4D4102D9DC70E1EED5004F98856DB24C345E2400E4E57458C5EE8D986130CF211F381B5721E1706271D8C061895A4974B8F4B3BF0805356126194B2A202037ECC5C60CD9C498611EA5074B8CEF3D4799315AFACA2032365430716FC88E9C099398F0E0CD421E9E0D67F60347544B0ED330CB0474E011FFD841EE750957F93A3B55BE5339AAACAEF456C2A7F803DE2CA1F6D9C57F93DCEE12A3F7F70DF3D2968AB49308AD91181813F6A32B076CE25C48875485234E7EADD18D1ABEAE8D0C8D872A1053E72227446CE6781C37509FE28709B6C1C6714184D15017A119BFA1F608FB8FA471BE7D57E8F73B0CAA7F5D63EAC6B5FFDACAE92008390150546E863260163E54C1A0C48872302DDA74F1F17760B0582BA9A0E8C9C1D23D80C8E9A149CA17379C1801D8A1A9F1F1E92F37CEDC00A465345885EC4860B03EC11D360B4711E037A9C83557EFBDACC75FE0D170E04E0B5952460C4AC88C0C21F3319383B671282C13A30299A275B9C49D16B4F90A27D16DDDED92DFCF193A2B3D30B291AAC0391825EE3F9E5BC2E0A9C559F4BFB8F85ACAF2206951C052DA8216671BCE4902C9D79246F403A24392EE90BC14EDD4B495D478D41CE96196306474E0CC6D099DB9E7AA043D282FEE722299B6A77DDDCA001D25105D0B0250D94E991D30734791E9100C84353AA5CA13D1ED6EDC45FA8758E149B069EA21C2BEFC2B7290B4E807F934598CF47B1560E45C65BEC3274E25475846A646C59D4021F394F3A2367CEA0E0C38D93DA52E489DB82BBA8AD25412766CD831EFED8A930D8393F2EF4580725455D3CA015761B4043085A7230A2D60461B339769270B6CE0C1B0CD621897297EFF34D81F6DB67F7182261E8C8C20BDBD245C8EAC809235A3B8F323C5A60D29C758F6A94BF6154DC3F3BBE51A30751BD4BD289B3D206BCD166E6E9B5920EDB036FF4D69EF41DC162D1AC360E2B9427A862B87118043F7A6AB8EC1BEE37088BEF5D85A6C27E9F26285B614B12886A52F5F702A615CF03CEADF21ECD47650B969D6435BFADCB2423B5785BDFD30AB6AB6C85B2DCA7E0C48C8F0A00E0732F86E731BD7422202B4F9A0AEE3C3021810303BC57BFE7BA3FF58A3FCFF3FEBE71BB7A0714C56A67440C6B5D029D59E90C9E873A97AD3BC92AEFDFB6B1AA6E41497AC6B94D36AC660E6CEE53CDDEDEFEE1AD3ACDAA4D73525D2ECD19D2942A999131AD6909766E7533803EEA5CB6EF242BFE2A79C4A4BA565FED6B1E5415AB9E1332AC7B007866E573881E6A1FB2F034AB3F476BA7660F284A553F8A9856BC083AB7DA473C1F952E59779255FE11255985333A06BDC4D8BEE6D5FA22016449431EA8B298490719D6032B94B69E2439AED133BD5597E66CC70A4051A4032362C80309742601183C0F352F5B7792557E43CA8052EE4265BBAAD700881400440DA9A0CC642625005C0FD4505B7B9A14A18F433910435493E8D00B989280079C5BF53D9A8F0A172C3BC96AA6D583360E5D024051AC6A46C4B0B225D099D5CDE079A870D9BA93ACF2BB0265255AF57B2EEDAA5DA12C56BD206658FD20F84C0A08981E68005B79925468FA31BF27F89BD54611514BAC7C9ADE271BD43A0F6759DD7E1C6962D7BC8D1E3DCE012AF86C43DFB0B76AE5921A54C58D8061CB16001D2AB9D1866A7A48F050DDAC8927D9A0CFDA97A887B2982FC7CB8AD2827C233248982CC98BA07317E57DBDD72D1B665FDB3E09397F0CDFA1B604EEFEB2B8D351AD2F8DE859C9FE0F9371BD22074B4A7030D2585F4C9C3BDA57D96CC796FE4F95B9BEB94275697D9DE764444AAF9514457E7EC3FF32FC5DF63F745DDD8FF91AA7E5A877BBDAE21D6A8A55EED1AA59E65CE3CBA4282BCAAC7B54E256E4F52B62FB63B2C605E9363F9715DE35D4FBE1F6CFF43C4D68F418043EA22C79C06575977FC5D92FAF7FFADB8F3FBD7E759626A8A41BF1D387D7AF9E766956FE7D559755BE435996574DD17F79BDADAAFDDFDFBC299B1CCB1F76C9AAC8CBFCA1FA6195EFDEA075FE8660FDEB9B1F7F7C83D7BB37A27A076B84F2B77FEF51CA72CD5D51F573EB69DAC8B8D0C253E3E77F60896D7DDDDEE00726DABD11AA5A54FC19889034F35F5EDF279B84BAF5B73A4DD17D4A7E79406989254801E07794D6B8C77844C56A8B8AD7AF3EA2A72B9C6DAA2DA98F7FFB3716B42AEA49CCDB6D5E54F49F9E7117803C4B2B5C64A8C20B607FD86D3E17E92CD0BE2553082DEB145F6533E2693E5AD30CE49467517140FAF4F090ACB00ECFC4FD17EB07C1AEE3A5E1757706D233EC152AABCFFB35A1770F4CFF5D25D47ECBCA79B7AEDB07C0CF0BBC265E1DEF03F4E7846D5EE5A3C96B9DCD4661A82A30AECED6EB8274777CC78D16F58A7C5D7F5C063A25D03FF90ECC8D477EAB77F7B85806DA7FD368816F6B12139E3C439F9318EA9BC3B45393AD16880F154A9B2B8F3C47887C937F2E92301FA9B32B946D6AD2AD8CBDA3D83B0AD93BFA90AD1332D6A8517A81CB649321F9E9B348C248C2654978BBC764D09E56490C7F917987191C361342AB7963C40E63D65091C1E0F9D94C36FE8A335CD001C035AA68055022E3A64CD604EE326A16A23C7363D3BFDBEE17F70E3F554B343B8F4341CD885F9C64FB3BF9F2E2A75F5EFF5F8DEADF5F7DF88F2F8CF6BFBCFA54AC71F1F7577F7BF57FFBA6FACC0F3D84338BF202CEB2B45FBC868CAC60AB206C9C9B33CE904066553B0BF212EA7CF07CD80A6F670C6755F738E9E85CD9D3F396C7519386B3A7CA721D6F8FED44A7FC9698885A6AC6E83CAFB3AAF06DEE6581B2D5362973DFF39274820B98533EA2E93319F553B14159F2D7F89AA65F785FDF658F9D4CE388CFF0240EA2E3203AE0209A6D94711631D2F0086828EFAF8DFC8BFC0B3AE4BADEE6998F715783E361F035E0041A6CAB867C3603B51E63D6C07BB999CEC6A54BE17AD88BE04ADD3FF07D99543EC8DB2179A02F831409EC8B689D5397430E1F7CE787DDF9013774A83DE8BC660CAFE6E4EC16BA13F15880254347985934E5615E0257998D06612BFEAE682E4B392B309A55F30CCEACAA17705E42DDB35510B6F27D74A77C74A4C277A1BED30FD3F7D56D72E5A52B1797E71F7BF3B735FD46E5794BFCED2AA1F7A5C1F7287D788BAAED1D29C13C92007E23B8459EEF16C1C66B0A5D9EDDE78FF8D722AF33DF9EE973788BD3FCDBA2392CE19F739CD04B51DF637A758AEFC9C0E42FFC21238D2AF1BE88C8425F2659526EBDAF2436DEEEB1677FBE81A5398C4AEF7BCA28E6352EEE12EF539A3D7413BA1780BEC3C5EE06EF107178B6593C83CB02FFE93913FE0ABA45C1993BCF7C8F5151F195B8E7961E255E22DC5CA7C8F712F77591F83FDD43319769473DF41295D7FDB9C4DC457D9F262BDA7C8AAFE2369EFF65879EFE5787BD3BCDF94A947EC81EF262D7EEC3CCD6C90A55DEBF161F493F8FC9E62AC9BE2EB0CF8276BDFCECE7F5BC3538DC7132FE0D95B8121A574243AE84AA9FAE32E39EFAE5A6690E1EC3D88F768A97F8680FB8F428C402D897059D3299B94519A07573ABCE021FC3B315190DF837B70F9EBE47782909C678BDC8E0717890DEF786C8E431291322EE7B536BF352FA029E185FABF7BD0B97348DF293FF6DA1DC43DF0BA0732F437B1FA49414769150D73CC3EC3FC45DE07DB55D620E8434C04D9D22EF36E749FAEE91748B96D8943C3C73EC19967D20D7F35C50922E134185775A0FB1F97B4E7F7FFCC2C6AE7EECEA1FA0AB7F3CDDFCA51693BA434EB3C61503C69CF3673D98FFD33567DEFBD2ED8D7F9EADCC565BEF33536F490DDE90EAF33EE57D9E6725915B112E5E301F004FE8EF08CD3775B2C68BD87E9914789F924FF935616D7333E532F04B7CD0AF305E97E7C4E39BDCFB91BC067B118FDFE02C7F44CB70E5B6BDD076A98989774F8B2C307E441919E2EF9AAB31767B94F9AECB25FABF4D7B270323DFAEA8B36495EC51EA7D53C1E78707DFDF123ADFBD806F7F472B94AD9E6FFC378F7FE659F79CD922C017B85C15C97E81515CD3A0FB4E81EF217E33886B263F16E8A85EE5ABFED0E042BE3992E520EB859B388C8BC3B890C3B8B31DC9395E3F1979179A77043CA930ED2DA1F4B67A4E23032303C34E60A1B2195D5CE0479CE6CDFB849182918287A060B74A17E917E97708FAC5E5A3C8BDE0DC8B2F0245D21D6ACDB2BF0C71C6D225B328E8BA82A95C57F4BD90B9E40D900B5CD3D8DDA6785BF99FEA3DB11B20AF169816F5BD96D7D16A81E9F3F180424B607A7EC0F72EC7F5C379BEDBD51961F112A1989EE9BBCFEB629BE7BE576E6EEBFB75B347D33B47FA87B77EC583BB37B8DB23E5E881C601F09D03069B286490056E491733395CDFC477F8FF88AB2277763EA33D67EF8AE8DE774FDAC7F11C217FC7C5120D0215E0950607EF972DD585542FCB399D343BC7F49CF0754E9CE623A63070FE3F672CB877229DE779417A7EA459975E1C31C29D95C0C910A7CA125B95FFCD66EAC5D49FE80BB878D57CD47E79FDBF5B47BA73622FF048A227D8B7DEBB77832366421B7FE498B9EE1963203F9F39836FCFCCD35807EF7CC4A1981A3A0EC5BC7FBBFEFFF6BEAC396E1C5BF3AF74D4D3CC3C7475DF988879A99E0859B2CA8EB04B0AA75D35F7BE28A04C28935314994566CA56FFFA4B30B900C4395848005CC417572971F6F3F11000B1B8ECB85F803ACF519DCF21DDFAF29AC2CB6B3983B3CA299AF57A3971DCC3DE94EE1F94FB2C7A26D96B75169B7705EF9F49E4FCA81441C3E57C59C70338BA4D939DD7307555F8085457878F50157FFE7FBA3D393A270F957F4BB6F4314DFFF4A6E0EBF7C2FCCC9BF85FD3741FD3FBF89CBB57B12131CDAB01B2A39374954AFC7493BB5EF8137F77A4C987F49C3939AEA7D94E74A6BBFFA4EAEDC6FFDB56F86D9A31BBDB3790F5EC5621E10BB751A88784FAB398873E67D32174FF82D8D2AB977201ED3DCD367F65B7458FB6E9C115BDB667B6E386EBBFFDF31F4517624B9882FFE8B5DCFFF2CCDD95474C36B8EA311B2908AB36080D107741BD977D3A9F49F627653BAEFC886F16A2BAAE33F5E188978B919CD7C9AADE6FCECFAC8FE2A2C294B3C9EEC55612AF7C1DAE723901E563B2653DF017E7F2FD5C67B70E23C71E46D2116FCB733D885C876F9086850CAE1ABCFAE90E3BFED657BE441CCB5C4BF0324B70B9F43D4ED3AC3C937631D598F36EC8A4DEF3F08B103C543C0FA3B37774E7BAA8B1F3EC9D9F7956FDF995FC701D817AA8C04E53702CFAEE7B81EBFC101DBD0CAB935DFAB978F31DE2D762E0DB04DCF5C0F71D898BD72C7DF5109EFB437A4A7DF46E985C0F212FE5BA7F176EE85F67767EA297193DFEC1B9673877BD14B2C42103A017E9FCC3E9A3FA71E0F6207EEDE54CA197533EB66B0FC77D0F67ADDFFEEBF75A42A650427E8F76742D211E4A4819580F25A494EBA1849472D712B29610B312D2ECDF584EED685C72B0898497E567F7888F69674FFB3E7CACF3F5B31C77DDA1F27677A8348FECFA4D6041EF297E9FC5AFEC60E3E5BCAF26B80FE52BD97F8A9CAF7DFBE3404E5FD3F73F8E74EBE449BFA1CF97C2136D9DACA1FB143DD1BC3C6BCE8130E6EC7FA605CBA7F4C589C04D7ACEA47B14FBF9B996B1C994B1854DFD49FE0D2E669594E1D3809B6712C7EEFB04A5EC4F24DB53F7B25D2F94F07E4CB194B8854D4B4D13DE9EA67C82A16F7DEB787EEB086BE7477B186D51BD1EAAB68443D5AE6914AFD05BA13706F4D8C5AA15FE3EB077EE7A82F38AC0B008BCEC2CBBDC66B296C015802301F0F4BA9E21BEE26F14FC55DB928BFAF7995D19159178C5E08AC1A0182C54AF985B3117127337E9F6BCDE9DB0626F0CECBDAFEEED5871B7E22E28EEFE3A47C7B5E8ADE01B057CD52DD3B75112E587157D2BFA42A2EF9664CF6BD55B71171C7751468F31D9D2DB335DE75556F08D03BEB5F2ADE01B037C857A76321F5B9FB4A26F455F50F4FD58BFA6ADB00B0EBBF49CECD6B5042BFA4641DF074AD839BBEB506385DE48D05BABDE0ABDD0D0FB9865D17E7DE7AEE81B057D9FC9F61025347B5D81B7022F28F028C98B112EBB476285DE0ABD90D0BB4FD3785DAEBC426F24E8ADDDBC1577A171F72525BB15772BEEC2E32E7D5AB765ACD81B0B7B9BF2B4A515782BF002026F13EDD7B9BC1577E171C70E23BACDD27567C68ABCD0C82B6F06CED6957A2BF88283EFDBD353749D8E7960EB8ABB3789BB531417BFDCA7DFC7BCCB75C5DE1BC6DE1F6C6A65C5DE8ABDA0C75D5C6E3CFF96AF6FDC1579619727B30B82D621C60ABCD0C0FB4492DD4D941FD33C5A17EAAD101C0B82F9961CE9BA7265C5DF18537C741DE6AEA00B0DBA345A974BADB80B8FBB73F644B6749D5E59B1171C7B5FD36375DBE15AF956F48546DFD5F1184724D9AEC05B81171478EFCE7994D03CEF833BB689A80FF66A3E117F06176C5D1807DDA955FB5B1679B769AB456FCE8F1EA4BFCF4F0571941FE8EEC6FD75CDB759517C0E513E8327EFEEC86E7D8B92FD264AA47B333D3F25756AD722BD16E9118AF48ABD157BC13F3BA7E97ACFDB0ABD71BE3BAF9F5C56D885875D9CA6D95AF256EC8DF1B9397AA19B53BAFD7305DF0ABEE0E04BC97A9BF40ABD31A0F79914C9A7099B01BFA5EB5AC31581C111784F5ED91D47EBC1582BF44243EF4B813B12AFD76CAD101C0F82D1FEB0026F055E70E0B1C313C87EEDF1ADD00B0EBDAF194972B25D7796ACF01B037E6CA47177A4C987F4DC6F4BA720A0EF3A1C418008CBF25C9B5F69C2965BD0DD3D39B1B833FCD2D2156BDC8EB9EC677322D989AD9BF91A3907CDFB64E749F275FACC0604793840DE93EC4FB6B4E648FA2D45ECCAE80BCBAE8CE522D343152BA316123487F494F6460B63EE0D939A79B9F8B8D93D6DE85F67B605BB35C111500AD9F52FCE65DFA671E17311FB8363C165CECB0E9B0FB987F3F36342A2F85B16F990BF7926B12FD99F48B6A7EE657F22F9A900CAB7E38E5B76CAFEFF54BEF02CE1CCA4F512655591BEA4E973DF82C478FBD6A39A77B9E588E9ECA5FBC288E93601E21FD1CE7931B9B03A17FA42E35E41AA388744E9A67894929CDD9DEAF85D41F36D161D4FEE25FB2F09ECB12C43BB8EF1D7317EE0B3B09FD7B9A5157763CC2D5DCEAA8B687EF552F46799C8BE3D225952DFFE112C69D9BDA589BE878DB1F47B44BFAF356CAD61A16BD8D57917B181E71736FB91F75A9453B1F64121C7EAB73C6D8AFA731E3659270BFD7FCFDD24FD8F67F2E37FF6981F32EB9C0FDA5F94E427768C7951D0CA58AC7566AD336137B8F1007C8DE9D5E944B607F6E16585E20AC551A178773AAC2721AD281C19859B6331685BE7CF56280687E20D035D5AAE8ABE2AFE29A70EC6C3A0EBAEBF87E4E0B303BD06001FB769E2E78B223CA6F88F9FFE769FD16DC4BE5FFCEBA7FF631DD1EB8CB2D47812FBEED55B20068A36DFDBCCAE29CBEF92B590AF853CE8D6524AF27591F70ABCE0C0BBFB5EBCAEF343745CC1B7822F34F8AA55AC2BF456E805875EA5BA0FEEF835A1B6F893D793FA1A3DF95CBC5AFF79B52F8C1BFC486D4E19A5A7ABDD2E6307AD3AC6EB45EAA728A1FFF427FA3F5C17843222BF9D9F1F69E647B4FBA7F72278737E7A8A7E3816CD561A7809C675F960B915999E9353F6CA3ED5B98EF07D9A9F485CDE29EBC566D7CFC7733D25F51B2599F3C901B6F9E79C445BD26C50F422FFF45A1DB3E7BA325D177FBA9EDD4AB7E7E68404C79BB884D3171CCB2EC6BEE5E744C73B2C48F6ECC15A4F70F89865D1DE1796CBE9051F32EF69E6615F5F2DBA3C6CC683E8AF347BFE429F499414A30FEF0A6E33FA9717251E70221CAFE75836777A9A6BC9979780BF25F89FC9F65074F39CBF22C563BDBC0AE7CF6FF2A9C7437E3F9384ECCB3744F14E3E92C479165837223A92D8F938499C5D73DC1BE4B6007F4D8B8EA16BF93171FD18DDA769EC231285584F6FE5FB2C1A78870222D3CF8BB316EDE129AFFFF491BFF3631C6DD9FB32FBB39BC05E9F65A103C3DC9ADC9E07E5586EF192F420963F45C8F9A8FFBC2D4F21772C37DAFBE80877CFB4712C9D95E177E728661D1DD7A5A8D967E0566C799960F9D9DBAB701F53D1BB5D79ED75F1DE4E9ED2ECB9EC037E4C766C4A20753D53F45F29EBCAFBEB615EE4FBE83CA519E5E2F3294AFE749D872203AFA7689B5F1755BC2BBC57FD6E2432CCBB10F82E2599EBBEDDDCF6FD0B73F6433E7B3493FE7DBF7DB8F96A2048BB7B7A8AA093700CB6B1817206ED30DF3D753C9CEEE7BCFB348FA6B4651D981CDC9D2FA3FBEB8C969FC20A26D741B89C0E529B2C2D8FEBF72564AEDFB3E2F57B96EFEF591E3E3B157FBE0CBEEFCFDB27A77E2FA9EBA2DF58F4D507BFAB2A39835F599C1CBF9FEE2B451E7A83A51F3E463EF4C7C9C7CA18872F124DEFC3B6A760D347E807FF62B0510C824B63063F029CACC18F414796DF472158D6CCD6D47029095F0F3F91647F26FB5E6BE5404183A1C00B7A4B386832111E049711CA6008B403A64100C0C65DFDD7AA8162A73B809A695FDF470F745EAB93EA1BBD9DCF147E4AF7D060D2D517C56C4F92E8DFBE168AB87AC179EDC9AD03D550035527A3CA21EFB9FB439AB87AD995B21CBDF11A59017B3DA1E638471EA296A1F525D7C1933D04CE7FD0C73C3AB9027425CD11A439692BA89D7F08BD04D79FE4E01B67CAA8BB29CF6E0AF3182579F481E85A86ED00BB39D26D44E268D8C6AF8EA8C1D01545BD25FC569E9FA231BA985FB37245F25546C9603470B206C3A123EB2DE1814F497840B8EA9EB9EA988DD3251B1D046B37CC02B7F57E6CA679006EDDEE65B600CC40ACBCCBD2EDE19C510FEBDA3E93A307A997C526EEE56ED273B2F320F7F7684787DB6B8DEB7A15ED9BC434391D32763382875D1DEFE88E89CEAF1ED317FA6BC640E349C33B1AA7DFBD6AF0119FAB811FF50089CDC17CAEE5167F0DFD0609884DB607E7DF44AE8EC738621BC49C07A19052BC76D90E0412978771BAC65AB537993B69D193064F3B986AF11EFA3CEF8A72F8A5A885CEF7D05ED3282EA47EA06C978D1FD91EC2711D53927935BD3E78969617AAFA925EBCDB3EB37D1B91F3E22A9D65EFFC4C05C559E59E355D8EA2F6AC843B69D8B5A6D4D353F1BE18A4EECF4527D24BA578FF830135CD6EA324CA5DDF53771B65B4F889BD5EDC7F0F67C28F31D9D2DBB3F36C36B2EF8BF7898783356AF13E3A60AD70F758BC8D7E78D8AA781BA769E6E7E1B965BD675F6B3D3E90F8890D357C64F1032D9F760FD8AE247B88C7274A77F975F1E6DBA7CE571B95B2BD54C02F34495F889F2EC197347DF2D41560A27DF4D7D9CC6831D6F281E94DF46F5ABF6F3C88FE9878177D794B3A5F9356CE4697BB7C5DEF2A6059AC8D1EFC4D0090EFBE887C7B7A727D1C3C3BCCC187A5E55D83AFF7E977E7FDD64A74B9FBDBF57424D99264FBFAC57DB10BB703B79EDBEC7B0B372467C85C67574E986F4D63CEB0FAF80034ABDBB75D2F1B5E2FD5563CED7994B0CD016FF14B46E5BB8FC9C74AF4E6FCE863D6223F15C465BFC343BFBADE7BE05A2EFBD7F57E03F691810D5B36E1D7817F22C9EE2D3E35ACCBEE6B0053CA65BB753DC82E87001EBE486DB77E4AC8D5B61852CCE67B5FF97981EE7C00E3FA9C65EC6C48E705E9267A89F2E8D1F928FF96269E661F4BC11E26F2EA7BA55CF76292DD4D941F7D9DE292ECF22D39525F872B167DB042AC975247DD8F6A5989BBA147E71DF27286A67800F7E79838B7398DE2F72F243EFBD8D2C7847B785636E7EC896CA98FD983AF51ECA7827E4D8FE93E23C7838FF331BDDF315EEB2B3A7BC987F49C0F5A01DB0819D2FD12842C7F3E627322D9890D343C9C09FB3ED97992CC6E4828823EECB5600D52FEDCE32138E5E50C816A57CEF2D1EA619859462F3490D84ADC410862020641A716B07CCCF8BC8DAA90BDA17F9D59D7DDB9ECDB342E7C2E72E0BAD757E6DE4367A194EBE1092DE5DE650C3824665D560F9D9C391EA77AF9D6550CF7AF5E4854CA1D5252646943EA0B2C6DF9C5C6C363E5EA4B8435BE4A5F7A206ABD1C337C2F662997638AB3062B025704864660B5826485DE0ABDD0D0EB5C88B1A26F455F40F471F780ACC85B9117107957F5A1B66CBD69EF4B42AEF0B38541FA46591FE85EE1E70F1B0C3639EE41A34DC1056B2B386E0B2B8CB3CAEE437A8976671273477B0ECA30283144B651C5D63147242D1705ED314B83525F8B015656B94FB7A0CC3AA01CF772D3DA9E61DC28EA7F3C782BCC36BBFDCF1217755A8797677793E501C7514A327C649C3FFE192AE8FDD38F480E87058501D6B94065BD3D94B09F1DC383891C0717B5E64180B808791B4868D7CED69B7CFA2EAA6E2519A6BE56D8AB632F28B3EFD973EC03F72FB43E585BD1327BC96CB5CC78C84159B58C1019E554D9E7B3615E6E368FE5614EC3B2799111249BADAA1ED9AC99179B4DE954AA417995A485C830A8D43ED78098A5661D382A6C48DA017101F28E68B50F352467E999AFF649B8C87A252A60C6398DBDB3DDC8587AA6F91EF5903407EA4F77D5F54EF0B2FBD4E535F183D2CA0484C867ADC73E8017CEC566B0925EFFB7EF87543C394A72F87136C867F088E236F4AF1182009FD9E5CFF0F49F5C4EDB5C73DB71C1DA0C81DF6B66E53354032458523ADB3C839ED8A71B10E335EBE9F3F33989B683969BDA26BDAB73B639871CB14FB92C2540C64FAFD588215CC21B9533CFB7E047DF747342FC661B385A3A44C665B5F3CD3AEC4B8FCC4382BC66BFF02444B68B5F669BDDCA76FB6C968C3EB377936ECFCDFD01FEB3C8AB9B6B36BB3E58DB210AF099DDF7D5BC4E80CCD6AAE69A55DE7E6B1B5A66AFD9FCEB1C1D033EAC82BED9E6B5EB847D7245095E332CDE771020C582C2D9E658F2C23EC91D113EB37C4BB2E7408F70AD6AAE99E5EDB75F3FDA307BCDA670D3478094F2FA669BD7AE13F6C9152504C970A88796D737FB0CF77F7C4509BE337CDF5E051426C5ADC239E758F4A2579279117EB3FC23D06464A569BE79FDD17BEAB1E1F59A49F1E2A400091514CE36AF9217F6E9ED88F09965FE9629FF29E6B4CD35BF1D17ACCD10F8036436D0C3CB699B79667B3FB602BFCFCC7ECCB2681FB2328B0AE79A5FD90B6B4BBA227C66F933D91EA28466AF0112DCE89A6B6E0507AC8DE0B8BD669492BCE8B6B15D6B2172DA6A9B6D564517ECF3CAF3FBCCEC7D9AC6E1966170DAE69AD98E0BD66608FCBE331BE82D5BAB9A734E7BBF595B669FD9FC92925DA06CD6AAE69A4DDE7E6B1B5A66BFD9E4EED60D91D156DD7CB32AFAD023B3BC00DFD9BD5C6F1C26B5C8B6D0F9E4B5FF16538EDB674637D13ED488B55635D77CF2F65BDBD0327BCD667B6575807C36CA669B51C103FB9C72EC7EB3CA16B6B22BC5023DA8BCBEF9E6B6E3448FF40A127C66985DAF7E9DEE4224B75635D7BCF2F65BDBD0327BCD267F057D808C72EA669BD58E0FF699150404C8EEE51EBF60D92DD5CD3CBB8D0F7DB35B09F0995D768E18776FACFFFCB6CAE69A5DD1036B2B7876DF996DEFC1F59FD846D75CF32A3860BF60A2E5F69DD5CE75C181F20B689D6BA61157ACCD01E584C83E7F9D73A0D4F32AE79CF7AE1FBD922E0AF19DF1CB2DD801C6C174C63DEAC678FB712FF5DE872EB3585FB31DE679ADD5CD359F5D1F7A3DA7AD00EFD9E56F3B0FF0A872EAE69AE1AE0FF60FAE20C077863B77C3FBCFB1A870AE5996BDB0B6A42BC2E739CCF96F94648FAF7CE2871CC95C8933CC380E10F39399398DD68196642CF57CB98EA37D57C3F5CB72DFD570D3CB70EF4571FE56C35D1D8F71448AA178EF9CD6027C6793D7639FC7967B69197C77CEA384E6F9E6FCC87EEDBF525510E3399B80B61E25AF2363A9997591D680391D9CD06566F33A4DEBC324FB269313E139971D4DF693F63CFFD232594D64F5CDA2DD19E77D333864CACECD79E653CC5C9CA6D9C0879097E13B871D55F68914042C2D9B9FA217BA39A5DB3F87A45310E2399F922EFB493A51C2E2329A92DDC0C79313E13B9BA226FB5CF2FC4BCBE46752D8401336E4BAA574484265499EF30A2BB48E2D24666959BE27AFEC0038A6A06F7A39119EF3DAD1641D46817F6999FC52784662E148BFBE19054479CE2CA2D13ABCA09CC5659A1D6C3F28BFB500DF59E5F5D8E7B2E55E5A06D9BE02B21FF452E54478CE624793FD474B9E7F6999FC9A912427DB7A3154DF6C76C478CE28A0CDFE136557C6D232CB24FF1ED1EF7DBF7D5BF4876A357D72192E72B26EDE6E6BFD2DB3AFEC959754F77D221B019E9F45414FAF2456DC4B7BFEAECA1BDF1A077B7DD9B4B9D64E9170836F9BFD2FB6BB7271B3DD1828321F6356B6962AEA3F7A8D3479418669AD7FE935DEECEAB31F718A12869DF4C179D2DB102719BECAF3741B95AA6AFC7F22C9FE5CF4F25A2CE50F9BF49C6DBBEFCEF7C9EE6F5FD298E7A9DDD9D0F8E9EFDCAF9FCFF1293AC6D1B630E15F3FFDF3A76EB2EF921B1AD313FDDB55D90DF9D74FD724DF929D1CC8C28D9DD68AB6D280E670CDA25DFF4B5257808FB20D2F11892F97D6B0792419A951B28D8E2496A2D1A104510D82FFE74666B7E5861E690189E4843B6DA2B56183D5375A3AD1D7C5E3979F3940F5C0D95792ED69F705D166184E2C9ACF85E3CC2EE3EA5E9077C069D407005C5149A397687726F10DCDA37D52B6591439905FC83C42110494A06E18A03A522F60856313A0406ABC35B20012315D1CCFA2884E1DAFE3145707601DBFD06E8EB4F8A1C8894D17B2651272CFFF1C0497AD42188C60BB170472AE072893905F266A6B3E7801F978709B45119C0ED8C629777D41377E8D6B2C28049DC8F6F48038D01F72FFF8FBDFFF29E516905619000B6D1A17041AC9B9992106ECB54DBC5041C6C30629463ECB409DEDF06542C893675CE6023B707E11685D22E0AC6613C747DB6D4692ED21CAD3AC85D9DDD353B4A5DA3140CB2AE499FF3908EC5A851D0F10B3242A2F30E4C210603C807B67A2BCE59E240E4D070740D635B97E5388EC838C0ECFA82835B2250054EFB23D49A27F973F81BD43C3FA89C8113082D204C131A25D056A53162F08C7A215A0001BFA6D6209226AFA789F5D9D9E1BBEC7AFE00E613EC572CE123DA88E976B1631BC5C1A8323BB5E1E6B026990D67BAD96577A229871885EC853DBEA8CAE189E066E675D8FA789DA6955E0BE189E4AE9EDD831DEACBCFD13B08CC9AA3E98990A5AEE0F692215BD19153BC81D955915C142CB1AE8EC8C6BD91FF4318F4E0BC267E590CAB086E46D60B476779628ED54CFB97C595254C920F5719CD7748F6A383EC2AAD522451AE607B3D676D81EBE7D8980E3FC9B19EABE66E5C930571925F3831D673C6C9040B044E0F10ECE0C79528F6F2EA853F6EC02F5E9C6415BAF1EDC785BB0B6DBEA84CF07FECC70FD76BF864FDCF8C4FD1C662356A35038F21CB64924F1B3F1AF0D4080B967C43513CD2DEBF4B0A799634633ADCAEF1BC19F350E94973A0441A2DA821038AC0E956F50A8AF7E158798E7E6C730C8ABD4D54683B6B48D7EAA5DED72885AD775C9A8CA554C53C2966175032BDB1BC296559E5D55B13E189B40FD2A2C626BBA2DEAD785A393D7FAC74018BBA84330D66DF454BF2A9783D4AF8E4B66F5EBC234256CCDA27E8D8FAD71EA570F8C8D5FBFB2EDA118316F4FE78CC49BD36B6C53C9245E31D7407318044A8A612C2AC8FC543C3920216A1FEEA6511594D8A789D53954C689E272946A390C95A3D7CD7724A7EC5CE41BFA42E3B43C22D9BC7002CC222EA1F620100534C34F8E8ACE0F48819804A89E2A478D802AF34F14B33328A01346E70825743034A75243AB2B96ECEB677D8B3D94FBA62D28322BAD4A544A345EEB651D8780B5B2EBA04D9D545D08362E2667541F2784C211EB622F184EA5260A5FE68C0BA2F44D586C080A42FE7B146A53A02218EA9B30E89A4DF91BF59B3082BD1915BE49606EC492678FBBD1EB1D3BB2DDA2D0317231B3975FC2C08CE982F125B6F80156E969882A2638630423F476803130348782352E92C62851F6A01ABB36F1F324D5FFD30C85554BC1A793FB3508B0B02945C554A22350211142923B104DB6B3808D71530213FBFFABDD2EA379AE43954D3EFD23AB361A31A86936D8BB3B046AA1E68075E9B2D21A166AE5A5D7F731491ED0984D1D6C8D0B98491C81CFC23602DA5ACF2C6ADCA89F18381BEE0FE9299D2FEC4AF33173AAC685C1EDE2D50CA1F67BB4A333865A693E664ED5B830A85DBC9A21D4AA0EC0C36F34DA1F1ED3EC90A63B79731B97678990CFB3DC6875DCC9E02E99231CA983E11D4C369DB2AEA9A361AA6BC8C3677ACA5225945A0A3ECBDCAF56E019044C47C0417CF683985E286D2C9C04507E3D1775731AB547320B155EB52EA6F2C8BECDB6F094E65F3AEA1AAFDC65DE537F0A764B6D9ACF6E7C3F94B886A679975E629D0E402FDDFBC50154EEF663240B06A8F940603A00AD3F4C4C6A2CD0310AFCB8B5BC5140D7B359BD896BE31F945EB8C9B1217A8CBE893AFE0A6993BB0E8F23F4B8533D066A58C6F40B27A6F0D1BB52C71B0EDA23122CE71338E4DE70FDE361CE70A1059AE790AB122788BD60AB1287E26EDC558935F6AE6914CFB1DC717683E608ED8B2B76BC77F3AA7502DE34A50ECBB122B78B479D6DE647021C473F01CCC5946495451FD838457F73F7A44A9D643E8C3D806C79854F767266F50FC0A2AE0CAAF3AFCFFB1BC3674F8C8C8B50996D02584D9F9FCF49B46D6E519957D9EC5A0FA352A65A5ED1947C9C59CD9471A82B99CADC6B73FEA690D90F1DA34253E29A0C464FAFD506D93996CAC678151E39A2A516CAD6C559D6490E83666512CEBB2EDF6F0893BD70312626BB4C53C02613742E81F1999C6856089F598D941D403009112EB056026ECEAD5E4298D4D64C0D0E4CF2FF06B1DA1B2F63E315629C00760B3BE7553F0B83610C960DCBAB8FCCAD99D5C31253BAFAD7CD2394BF0562C9389FA1F1C308C7C7CE4DBA3DD787A5CCAA2EF18683F688048BAB53827BF3AA5722E634750BCDB32ABF6F007BD6F91F0B773CC3F8D87B5F1D0E35AB5A571B0DDAD2362EAEC635AECDABBEB518D3D43630AF583E178C31AB3C8F81AD9A7802D8FAEB1C1D67D961132C875126522CAF9C09FECDACA689B8D3153634D7CA1CBF0904DAA36034F8091C13C0E00F368B9766B75112E58799553FC176187C1D92E5D53FD1C19915C02EF87425104FB83AD16F04883DC0301E0C4596F1C1784BB2E7D975006BA3415BDAC6C595BDC6B57915BC16639A4A07E615CBE782316695E731B055134F005B51468F31D9D2DB339DD77212C172186522C5F2CA99E0DFCC6A9A883B5D614373ADCCF19B40A03D0A46839FC031210CCEAF03C75BAE46DE52BB72827F33AD7D669D3A34D7CA1CBF0904DAA36034F8091CD3C0606124BBEAB6689D5DF16B4D47B1C7932CB2FC710ECEAFFEF1D833288048BED5797E2338EC8185F15028B24C018B3F66B7D9ACB21941DC8F856E2DAB3D9B5BADFB61B4910CCA2992CBC5A2CB26C32380AAA29D00A6D273B29BE79102A2E930C63A24CB2B64A28333AB671DECE9CA1A9E6F759EDF080E7B60613C148A2CE363F1032D7E2E3C99DB970BCE6ED01CA17D71E58FF76E5EB54FC09BA6F0613956E476F1A8B3CDFC4880E3E82783B9D975F438BB55685B68178FF76E9635CEA87387E55891DBC5A3CE36F323018EA31F1F731FB32CDACF733C2B9A0E5AD425595CB1EB3838AF7AD7C59EA6E429F2ADCEF31BC1610F2C8C874291657C2C7E26DB4394D02C9A570DACCD7E058DE15A1757F95ADFE655F478A0690A1E9C5C34A98B869A5DBA47C158433D019051929F33FA2D89E6B5C59FB31B4619DFBEBC92C67937B3A2C6E34D57D5901C2B72BB78D4D9667E24C071F4E363EE3E4DE3391E57CCD90D9A23B42FAEC6F1DECDABC60978D3D4382CC78ADC2E1E75B6991F09701CFD343037BB79B9DA6814670B9D8B6B5C9B5F5D339A7F03F38AE573C118B3CAF318D8AA89C7C7D69794EC6657BF6AA3415BDAC6C5D5AFC6B579D5AF16639AFA05E615CBE782316695E731B055134F015BE9D32CEF7BE00D4730C6132CB09671EECDAD9EF198D3D63424CFAAFCBE01EC59E77F2CDCF10CD3C0DEE6F41ACFADC356598DA2AD6A5D6499BBF836BF1A57E1CCA0C0C9B94573BA68A4D9657B148835D4E3636C13EDE7B7A6AD361AB4A56D5C5C216B5C9B571D6B31A62963605EB17C2E186356791E035B35F104B0754A337A9BA533BBA5A1351BC617D7BCBC2AD63A37B33AC6614D57C9E0FCE2795D38DE2C733E0ED25AF229608D5D4778CEE677F29B60398236816281058EF76F6E354EC09DB6CC61B956E6F84D20D01E05A3C14FE0181F83DF9E9EA2EB7437AFB2571B0DDAD2362EAED835AECDABCEB518D3943830AF583E178C31AB3C8F81AD9A7802D83A457111FAFBF43BCDE655C338C3618C0904CBAB65BC7B33AB6702E674350DCBB32ABF6F007BD6F91F0B773CC364B0F707FB403BC77A571AAEC25C45B0D47A77716F96F5AEC29C59BD93F3ACCAEF1BC09E75FEC7C21DCF303AF63E9164F7003FB6FDEB5C379FB220A6161476691005FEE3EF7F9765CEAE3E959ECDAA2E95D8B83E674CECB7DC7C06C32AB99E2B1353D9BA805AC593787D333A42412FF4714ECE1B879A3724926F3CC76F048396F91F0F792DF934B0774B13CB5B8BA656021B0F50A3388AC516C0D6C7F9D53F0E83BA43A0C15CA3F97D13E8B3CBFC68906BA8A78139F6CF4D941FD33CB23E2E706A1510F005350FA45D6C5584BC9D5F7D04B1AAA9943A4C18E0E0CD22B72F6A26005C806F3A182EB072A4CDA123DD5F3EEEE65C7F794F94101609175D790557E75976B5903528C3283474707883D0ED059BB1612BC3620AF0DD509B650D53ABA9A5F5A84155EB62ABE7C5BFF995CC0A73BAD5A8526EC17C2E1A65E6191E055625E54430954676A7864DAE94550EE0386B08965BD06A176758D31AFCE9CA1A94672CB76F007756391F0B6B3CC344F076CE9EC896DAADD29A5CCDE39CC0F127102DB7F6F16ECEB0FE0978D4D5402CEFAA5CBF213C5A63614C1CF20CD3C0E2D7F498EE33723CBCCEBA4728BA815AD6255B6C85EC383ABF1AD9C5A5A64A2AF2AFCEF91BC3660F5C8C8B4A9165346C5E3DD3243A4534FF8D92ECF1F581F74A5B343BCC0202A4B620F0EC6845ABBA92CE0B40BBF1088050959326EA3BFC13C5A8A6804EE9C53E5D748EF56A1F0AD1D1DFED5D6C1ADD3C35F9BA29DD0804B62FB44E1ADF0A34D5FA68741B9594E280F74F4D076DC6B9C6AF7EF20EB3516F9DBA3A162127C9961A56B69A5CCC67FB6B187CD5FA6464892D7E2A58E36D88DA25386454B56A8EC9606ACA956A542405AD4ED6401AB52E31E5CE776C7A8190117C67BCF37C4EB776E65142F3FC4136D9BEDCA876F75ED4744057FFE86B576FC862D17833F93A515BBA393FB26C98F5623A4C60229BB640D3AE8256E0C656A0DD538911FD0F32D32A3B67567004BE896170C2BD9EE9A06D8CA2660BB349D437FBE28656B611CA9A1265810A5AE86AD6AB944DA28ECDAB888D89AD31CAD77C6AD7759AC6C578C0BC74710CE29916FCEF41C0C56994B025B5F939C682F33940D5EA3A65A292E39910C6265CB2C64755C882D50752A3D6AB6ACF9659AD8276C985DDBC5769939024FCEEE99C89603BF278674CD48DBDEF4EC4D0846BD178E80959836CE1336EFD89D334B3EA30F11C621685863080E254CAA8921AFD1426DEED10D5A9EB965189E298A684B52917AB09602B68D9EA83AB516BD7A7E8856E4EE9F64FF3E225B088A721882D412026E8943006B4FA39F440F03C4005931D33512A704D0A73132E62D34058C832D60F5CE3D6B194ECACBA601C83984FFEF730F86A35CAE8EAB6F9A95E9CCF216A57C729A3CAD5F24C086353AE5AA3A32A68C5EA01A951EBD567C64A13B6B0EB9652F3B225F30999859A83C04D562CA10E23F1023E2010012A1BE2A2896699757AD89C70B99B1AFE4216BF01A81BB506DE93D7E74252B964D4A8F8710C426685DF83C08DD3A8B2C623C0789F0354B6AE53262A399E09616CC2456C7C54852C5B7D20352A96BE146248FCFEAF737464869B77DA004621B7607B10C4019A25E4A1345E1008C522407DC39C34510DF04E10A313AE7BD34361C83A38047AE3D6C3687FB0A98235B998D7F6D73058ABF5C908135BFC54B7C6DB10354D70C8A892D51C93C1D494ABD6A8480A5AA1AC81346A5DDA9CD28CEC2D26D53806F1C43BFEF72098E2344AA892DAFC1C6FC7F91CA046759D3251C9F14C086313AE54E3A32A64B5EA03A951EBD5D78C2439D9D6B7BD98D5AC0E9378025DB72D08CA3A5A25A481ED7E0E9DEBF81FA08E41CE99A8EDF04D0C8313AE69D3415BC8DAD61766A3D637A6FCAED0F2213DE7D4C9267F2F8812CC948CE05A668F22D19F59E0E79E647F46C97E7324DB894388B754B2436C5C04900497E681A5437A4A270E2266A28C9ECBAFCB804DE9CB2CF0F2254D9F1FD83F9FE80B8DF1F9CD8642980B6A7F353861464401E3954070F9D1CFEC24EC2392170720287D31D1555A350D10C8238A0E06E429EEE6C7592020D490C90A00A30E8E9AFC4FFA9D111A2BA1DF18C65819FD85F1ED14C5E589A2572F248AC9633CF12EAB6CAF640D44B20854018ECD02630FBF47F43B4B9276A6706C74D5864A36B40D8B4052E3CEDCF0A399E503F387E56E8138B2CA6B681CD5C4A362E96A5FC832FB6CD1904B59AC7E0D06A7521F581BB9166F85E9E2AD69A528A91D40ABF5CC81E611C035E1EF11E3432AE4BBCE1E48E39D6AFE2E25D9EEA1B15A7F567EC9201E2A5EFD14E66CF352195C28A5363F27E55FDC0DF0BEEBFA63A2F2C233213C1954A5F15F79E3A36A9CD75E1F848DFFE2AB6DBABCFCAABF22FD584FE013F78F882D61F6B3F03AEB3F70AB5A0A3F3BA6840898E040E018BADB05F4D4911563225253FD94697FD338B44AFEE8E89B06F00A6127B26DF0073DCBC3ABA1E6BB0C64102EBC21587A4DAB1D9D6949BBA179B44FCA66BFE80A51E3386770C304A2A5A3937776A608FD4492FD99ECE9FCE1597B825BD5522C1D988DA73345E5DDD353B4A5F78734E900F3D26006CF8A168543DD1E1EAA9C7B3AF32A22FF8085226B02980B9F4BF0F28E3B35671C14FF411FF3E8B4601C570EEA0C6CC8DE1E966BD7678DE6D000B6193099F744960DB779230C78DFCFB123AA79AF077BA38F3C1BD9EFFD3D0D246E8EB4688D8BD4CC1F8EAD2FB85D3CCDD281C9F93A53747ECDCA7349AF324AE60F4FCE19DC308168E900E59D9D2942C131CF1CD1A91DDB041CD58C8BCADE6398F111199F68969013FD96C50D225D7D5A3418A070EA611C0904BE6E0C871DD724D01580780F87EB0F889DFA1AFB117053AB0605B68D4BC44BE3DD2CB1526EEA52BBE22ADD9E5F81BC474ABB3C6E08F38089DE7834DE2C36214C5EEE091EA57E5D5423C0A91B9759BF2AEF6685954F24D98D8013A61614766958223E4ACF66858DBBE6A41DD700F1FA026BCC068DE15A17B726AFF56D5638134EE49915D4D0137A6082C501CEFAC49EE960AE3CB9675E60934EF2E9B42C0F5EC627FB4C0657C0810DB30299E6000715D9E2E0D7F34087C0587C5FF09C5ECB35D3C5F823AB8CB84E77F436CAF2D30D399147D2ED12545C1B7A12F6A2FDF4B7CBEFC086C5CDF6409FC9BF7EDAED9E0A44B060B44C52775F94CD6D0793C4736D9006AE59A3E4AA5DE829FBD0B6816EB4CD1A251F935DF412EDCE2416963C4B0A113A483942AA31A4FA9E598013D0CE37422AF976D3D4359B0FF00C3624CA443654A69AD59186C99416D8C4B96152A00BA051EA37465BC351AF95C255D7144AC5359146ED6D4692ED21CAD30CD0C83742CAF8768D9EBB6C4F92E8DF6522D4494629210B50620B732E678028EDB890E80CB850D9E5B95A2BA44B76456690F18AD2CE8AE61BA7CE8E86D0C09286D6D4166D2C4CA260E93FBF2E0657CC5329B5F384A626084B1F701B0432A51102A5A9150610304BBE4DDA116DB8067DCFE099266537EE374AB24728A91205D84BE81269D4D6DF0F2E339A924EB119522852E89CDC6E699E23758B6F045DE3DA0DBD5278A4F6C6385D8A3CA91364A0A1E89F233DC5A609D650B7EA3464C53BF044B7A77346E2CDE93506750144A056804E97A5A2C3FF5C76755E689C969781410983A8C0DC41848626DC5252180EF92F51A8543744866A9127416C5629347B1A90419362CC643664AA9F96ABDD2E2BBF98A14F5B43A17AE81A228DDADF68B43F3CA6D9214D77C8CB4726A9156F777F368A652A8D660E5AB8CF1011A41DA233D7AF56ACD568AA8A42DD6BAE4DA186EA3BD79C41B7719A66F731817AD63099C6438ED2DC8A6A8E52654145A2D15E51996BFE3DDA518DE68A44A3B9A2D268FE4C4F598A3C3C5C1BA48B6BB678507F3D473BA8D60134BA47B522B3558EE516233432C32CCF121B966D8CD0C816B3CCD7D5167BF708CDAA726DF4EEB9A6518C2B135A215D02814E555C74792B860F2C36508D848840C5009D4E7FFAFC7C4EA2AD6A6C0ED080DA653233E5A757BC272393285473545ACD6C1EF85CCEEA7F26279A15C348503B44065B0051EAACC8D223A4B5FC19D452B6E8EA73BA3D2BFA696233A445A4D0687B5F75EA004D6D13A4A56DD56910AFDC96D588EDA02E9144A7F007CB5F9ADD4649941F208D1D0250658746373348B267C4BFB6099C156C5A751AA28C1E63B2A5B7670A61BDD30EEA12494C15627E89ED4A85C61EDE67291BCFC1939D5D024C254FA3D5F903A95C4D0BACE587519DBA4DCFC94E559BBB04A0B20E8D46E787A286162F100426422BA44D20305385F826B42A541979F531CBA2BD2A925D02F08B528746D75F25DB03FB70084D8C716D9026AE59DB292679012564824F680515F1041A55F7691AE3AF6AA11552251018A84212D536614A8C92F325253B4443DB0469685BB51AD22745E7426C8635F11406DAB0F930AE0DD36336FBB589F6D8F3D336811F469B569D86539AD1DB2C057B147C23A8856BD7EA61BDB5028A983B623BAC4D20D1CDC03F3D456CE900340BDF348133F14DAB4E43B9A8E2F53EFD0E4E8088CDA02681C24CDB1F0C9FB8B6AA59A1ADA2D07595CF195BC2F12D0707095C23D86DE6DA752F5C9AE01D96B60D7CCDB6CD1A25ECB3C34D941FD33C52BC90402A483148686042BE25478AD7739904532E52E91E3C0AC3B3FA1D7CD0A80920376984BD32DA26507CD3AAD370CE9E8ACE280679B119D4245068B47D4D8FE93E23C7C32BE2559700D2D8A5D17D5D391EE38824E08A08AE0DFC96D2366B2773EACD2AC0444EDD044FE2D4AD861A36E74774C6A843A1D2D71019AAD5E8D42B349C3D4955B3547C2B3C63911ACF52E14542591B4C4B4239EB8DBB2236838A040A5DE98B5E68D151D8FE89D55DB11D2C7A22894E614A147397422BA88C27D08E38A2E44413F618DE52EC3D0611C16310994ED76D27AF6C9A05198C08AD60E79D27D0F5770B4212EB2687402AB00F0C11EA4C6053AC98E2B60D54D7361B7488C91EEFA672AD5897B821D0BD71C48BCBA1574E97027CE774890CD6A6707B87E4AEA4D88EAD56E1480C148ADB47409D2209A656A432D18C7CD2E1DA505D461F6EDA2B25411D97264CC5A5553FD6ACEFCB85C69A751B32D6AC9B0D94A003F4543125DAB61A040A5A6E0F860D22C48208D16A6C69EF4793B4B74D90BEB655D7B73BEFA2D3CDEEE90BFDEB4C73A83E4B149CBE8C7C6FBB7A5D3A8BAF2D9B53D127D07C6AA96874DF592A322BE5AF31BD3A9DC8F6807CB35052EB0DEA30D89A76773A80230B8CD0C8A08AD6D6964DD19D3F610FB992DAC82A9EC162014BBD5250B384A525D32D626929B56BB7D3E494DF81DF159A2678DD76DDAAEB27529263EF79AE0DEC23B6CDBAB5D8DF139AE587E88828EAB483ABB045126D97B07C3F6293B97C2BDC25E40874AA9A8D5DB29EA609A9692D81A1126CDB4DA75DA3CE6C078E408DEF1781C94C2C30DD3A2230A97716E0A42606D96C2F101815BB49103A13738C3796085CE8E61290CAC40EC37D26000FB6DC1F2735B7C76C1700C0882F8357119B1B66BA3A5E60358A94458C7A4447B94F02A53431C662CB84C0A7DE3681939AD864B383426034848F1570AC21239C36871B2290E90C11880D0D516C1F9049340618EF28800FAED21A200D415546188D48E5839014460073CCB00186D3CDE2093BA862693F0AA4D4684B0A70E20AAA159E3981549B4FA0C06770A026A01329901556F3299D631A700BA4791550B5D1F48A6AA33E6A8066F600B2A6C72442CD8A75B68566B0B72D50187C707BFF42E2B36A590D44847D84EBD2997D8146140BAD8AEFCF46AACA2F76E5400ED1D62580147669343AFF2B4DF07113DF08E9E2DB75F34275E75675980044047E05644D0377FDABECD031A0360D3D0C40651448855A5253EB7B60ED8E6FFD7E75052D38862FDB866F29D71B66CA885BE96ADBB99DAD20879991668F5DB33354B39D1523C45663586C39AD67BF147D479944B91BCE76A3A852739744ADB9F70652950D0A62A5354E3696AA7604ABA8559639D8706A6096446962529F8DA806B688642686183D3BE56E53957AB15DA9D76AE3AAE15E28F33D51567BA36A62F51E29904A6583CD9EA986C764EF948A586990FD5EAA86D5604F9582566995F51EAB0EA76AAF154E6A6092F9DEAB96D1680F969A5C6D598F3D590D33BC374B6C566A37D9AB55136BF66CC1642AED567BB86A26C55E2E9944A5DD786F57C3A059C683D0296DB05ACAD370E9F67E61844A53ECF682D56C8A3D6132894ABFF11EB18641B3570CA153DA60B5774CE2D2C541BF970C21B53044B9B70C23D49962B1D7AC65C3F69C49146AED667BD01A7ADD5E348C506984DDDEB49A4DBD470DA4525961B367ADC3A38985760F1B48686882764F1B46A832C4728F5BCDA6DAEB06D0A82C30DFFBD67028F7C081544A032CF6C4D53CEABD712095CA049BBD723C8F0608EABD733295A166C55E3A9944A5D9786F1DF77148B5C70E26535B60B1E78E67C2F6DE01343AFD8613061587624F9E4CA2526DBC47AF6150EDD5838894DACDF7EEB52CEA3D7C089DDA0A9B3D7D3597626F9F4CA2526FBCD7AF6150EFF983C99416D8EC01EC30611BA36032032BCC364AF1D3A2CA7D82182136936AB16F9017ADDA4388D0611698EF29E4059BED2FD4726046F5D96FD855A6D97BA826571966B517915783ED4B046830FD66FB140581F89E45980C556DBA875110ABDECF8893A256D8EC6FE4C56BF73AAA88316B6CF73E8AA790F21A15DF45406AF4D38CE541A71D7AA47F0B52615B13AC4DA8B77562CAC57654ADF5EED06AD325DAA707A8545B2A87ECE5D4D860678091766E7326A25CA2C022DF639F27A25268C5D4F5D9F389E9934850A5BDF77F22AA011A4C77EFBDA098EA2E05AA78D0BE50ECBC1884103362D81E51FD3E51B5F681FB4511F52825BA674E6630DF3B8A1921B6A3AAFBEC2345544A1498D2017B4A11D52015A6BECFFE52C5F63AB119536ABCCDAE5933A238729D6B47B710B62B89746FE8F2F3B172F15697025FB965F6295A5CDFAEDF75D3A1D32DC354EE8DE1EEEA01D6B03D345EE60F9BF49CB10E07C7D15DCD06900BDA4ADFEB8B9CA47B700AFD8A2B6E605E294FA2103CED3F8B8EF70DCA5792EDE9C938281539EE18EC0FEAC6E84101D7019AA1C69415775879C951E9B3D13245BD4C38A03A52FFC1C5D167CAEA0789530A62BB9AD40C964A7ADC65F99EABD23DFC062B841B8E12D8EE293438A894F47E90344E601A59D546CE074EB81C1605B59FA07415C222B04DA803C201D6126548600ECF61C1DE063081BBF0C86F7C656C0072CF81017B5C40EBE090B42BE15BE72E0BBB55A5D7800B7752BE0CAEF40E5F938F7023CBDA3BC2242AAF21C34BB20197012E0057350E4E2C78C89E061BF0D98AC0C3A1B92EB00C86E1260C13B9AA989BB2844B000E655B11FE713D9780B32982BE5057F29A85869F089282004DF22825994617A40D105633002B79C32277FCA076241A768F2462CF9D23FB900F0F457998451727065181F9FCE30A3243250C3EAC6370D8AA53257A040EE30C1EBACE611B9038ECEC8C01E1EBE04619B02EADE7C74F8125E7286A8F6D318C05C8E03920F2A935A214C5D9330342C39D1E63181B98C373708003744431AA5370068447AA1FCAD0C8D49EC3A2AC2AEEEA49BB27FA815FA9A3FC46A461517CD6902E0CBE7CCE40F76523DCD00AA48E2491C45F98145F8D342CB8A3A87B2AA7A613AA6A1D55E3B5124B28B1C2B9CE65CD177790FDF52067AD0C94D036FA0885022F28B11E29204A26168ACB290486A8C088550E89176C578EC0671F809C4828BA8D3E42A1420546EC07158143219D0661860F03368593E845E91737B5275468A4C1C15390F90DA3025B066C5E5036819001A77D1841CF884F1134E890113E7EFA434874F2E0BCA8E83C071307A0119F0F044E2B6CD5CA602BFCA13C7AA73B9B4B04479145CA2A39CAC049341E83A6C719CAE31363E38649187F98000B66D0BB298DEA546706A112945112097C85480F2398C127868287862D7635830D4CA970E9B28E96F7015A592BF3C0FE8B2DCE1D578001A6F4828260EEF32FE2EAFFD97E35D97B9810778113C699CFFDAA701FEB2BA90E6A73E27A790DC66E9795271D1BC580E770EA10C6DF98078B699A5D86A7DC53741F93E44130581920982748881AD598208EC06598CA33932D4224D307098F70407457087CEEF3A0B0FC1EEDA84D5864FA206129D56242AA469761A99ED487DFD8897A8F697648D3DDE58B87323A281BEEA4AC8173526E9C581DEA1AF8F0999EB2148B94821A778B93C879C3FDAA08C9A0E00E0CC7AFE70296460032E00A811FC90C5454D5EA3E5C97A20BA832081AC6EBCD61B52CB9906324EEC37829D2FDC288F18E1446B9F06324C3071B55C7DDA6F66B79423CB81D23C0118DBB925F4B7C9044E3E19168BD38D37F7CE7220C6CCCAF1C9A2B19BC0C542B225E21284524F0151AC5E05DC9A07710754C3FD9357688B8F3A48DC003D1FBC40E707CB62044751EB6ABB0180007A2C79DC39C523833A9E048477E9B410767F38A20F4F4733156FA73CC1D87CC0456389B025D6A87F58E4E388CDD63DDCD80877279C51D76BABD182FED41F56EC365023A944B8139A5B35A27271EC0E6CC7E1BB8C94C01D0265D5B00C50ABF82C069A8CCA126336991063BAA7370AAA193EF5F30449A82D12FDAF02B293A6133B85AC279E88C90A76054A14FE3B889C3130F69961ECDD0C7137A451B77C588180AE8EA90C1AE9BA0872754A0A56B3864F0B82EF3F79F18651D64F0997DE8CA17418AF20A1767A1314005C8A0F85E8239A672685A21AAEFAF31428E44EC1335DD2B7A0409E8B53B4E42618014891877087404736022A1E00F78348306C8E1151FD0454A626494C754BA0B8F095C400E056650E7944E4D2E50C2755086484278BC6209BC0B4B8C91FA662B974132C113C2A34014EEA2DAB5E905ECB6BAE4CB084E12B14F1CDD76EE311324DC62779339098501682462DC21D011CC81898482BF76CD0C1A2087577C40B7CD8991515E1EE72E3C267001391498419D533A35D9409997189023088EF0274C79F79FBBF0D8E0C8B4F6A0CE299D9A62A0DA2B0F8D8104B0F846927CDBA31421C5DD8D0E4364082680458D26C441B563530CD70FE34F185D5ABF18FA81CEBA63576FBA0883115C7E187E95809C408C9F441084DB44CD2001B37845067891AA181BF5B5A80E436402179845811ADC41B563D30B177733AC119C207A9F58022EC21584A86EB6751516030841F4B87398530A6726181CE31204D107C00CFA34A9AE2276151673CC18D61CCC298533530A8E78EBB2116C10169FC8812F9C16E468AE8F7618220308212CB8A30A07D58E4D2F5CF52DDA91199A00729F4892AE0B1744E037803B0A8801760072DC2DD81DD48DC984A4BDE8DC0C2400BD5794C8F7BA8B41515CD4EE2A2C265001E81558419C523833A5E07037D31B6106A2F789194E1F284468F7141603CC40F4B87398530A67A6161CE37E8D44EC1B2DE8CBB96DF4110A439018F65C40473007A6118A2F29D919A34222F6898A5A1928A16DF4110A035448C4B843A0239803530945FA64B55A1864F08B8E562112169EC057688C900230A8D08238A672687A212A0F5134868E48ED1B37F2419C40AB977018C245A4566345760675622A01D9447BF3191689D8273A6A65A084B6D147280CA02111E30E818E600E4C2414A734A3B7596AB8E21720F78A8C461D1C10AED94F484CF021932B10023B843B32A5B0B02D2AC5F0C8BC88801C7EF1C26944622350780B8F1170200E157630E7944E4D2D50DF9E9EA2EB7467062189D8277A6A65A084B6D147280CE02211E30E818E600E4C2414A7885D8F739F7EA79919322006AFE8E014C26111087C85C604291083022D98632A872619A23FD8B0CA063D224300F4940A55A1A9087C85C61C3D2283163DB2632A87261522762DCE439B4C3C3422A14FB4585D0C34D4F5EB7396D1E4F42D377A25632C8E9D4225B4AA51593C89BF50E91F258C057714710E77689A61BAA589F972798423149E1ACDA8288EC25B980CC12473E04EC28EA1CE4C3140EC9F9B283FA67964B33E48CB1B0A5B800DA850903640380D91A7E2C583A10B8081D3730A6EBE2547DA7CDAEEFEF27167835D535921B1CC5BA08CB5483842A02D506D2A4B8D723434BA704C3FE01B6A382607A843A1B3D48A8AA95ABD84C5106922B562924F7204347E52814823E3252E30433094548AF1F83404BE42640A972E83023190539823130CCD397B225B6A3C758333054311A71C0F9740E43364A688829814A8C29C543936DD907D4D8FE93E23C7C3AB55A542D842214D548FCAEB92F90D9D21DE1036DC7185B36A072717BEFA76E5FC374AB2C757F37BD74DF870D73BEC82BF529B22841D5A14D24A3ACF41D4DFB2ADE4F3F9004F337CBA8D0E4AFAE0989356F683ED9E82648E2DC36D0F9237DA8D0E2385E3788C23926CA91E2D30A5C2A19A4174A3FD55158C9A4A0E83D8E23C000A24C0944E3110CC6D2646F9014C24F0F1E1CB283CBD7A327994B06B742EF2A03E0B4FE0327FB5E44E30EA1F9DB9B6393FB27E8BF69955D2EBDDA8D8406F9A36837054B4C0DE2DA0DD5390545D5805BD0F748C130E2BC0F4410B0A15639C28A3E237247A7884C146A8105CA7697DA98C161428ADE2A376CB227ED5E67F578483A393A221B57908060E0794D6251AC2BA5F7D43D0E200A4537D8C96BF61987C10A96824C785DF1D3B8DE71BA47399EB40EEB2FB904D1F789C58E106C723FA2134A802C111CAD1901A7D8444010394D829160287E053F44237A774FBA7112C14D48A0FA53C93F895546C518445A094E202B47A090C0E0E05B54B748C108694EC4C8B064AAB70A865115DE17F5705A4A593C3D16DF3100C0522305AA77808EAFE671225279AB039885B4A8D20A163C15D93393B47CDC8CD8A40C9E4F271240889BFB0E1E0D1B1B8C4D098A1B927AFECC28172A64907259416778D63118F89E07F578486A353C9F0160C1C2028AD4B648475FF4B218EC4C225145A4C687970E70056716737D4AE0816402F050DA5F1183C1C435A1E97581A393CEC02533344C1940AC76A06D195F65755506A2A3914628BF300285001533AC54230B7D99E68B237EBAAA0B4B8231C8BB4B1BBF95D11088E4E0A85D4E62118380A505A973808EBFED78C2439298F6337C283921E77AAC326AE68E9B62982D3A1950204B67B0A128E1325BD4BAC8C130E26E6EE48930FE939A7E8D74480CAA5EB827889956B71E2EE3DC9FE2C868D9B23D9AA3D96095D3BCD6B90B8C54637AE1FD253AAF6B9A570EE2C132D7B79F9D5897B5FD2F4991D79F4FC89BEB003C061173B548AB7782B897F83B7BF6A1C669492BF971FDDBA7B29B51A6F4B22B5B37227AFF9710AAEAA70DB12B886AD6FD72EBBBF239A5FBD9028268FB1BA2861E4AEDD96F548322012378B767E8FE877DD826698D075186A051267DBE0DA65BC2F0213E20E80C663868FE6FAD5BE180A6B3BAB08A5DA859241B2BFFA55E37E490582866B711E0075F2014AD7800FE3F6D5BB9464BB8746AC725126468B3B7261111717563FA956269624306EA4360F21502CCBC468FDC03F6C20EEB3F448B3D3EB05DCD55FEA3B0E742C8A195F9E539CEF155B54B3C63C65FD072EABA5F0172AC53CBA8645EF26E8D91C02749D26A762C0FCD0C9AC2646305740445506E0A21A02B7E1BAA179B44F4A0ACB90E19C01C3C619818B1388DC86EF1349F667B2A796B143D80206AEB60097D552B80DD9DDD353B4A5F78734E9B87F69D0C64EC76F18805A1BE67EDD6E1A50CE2C9DD08AC84758FFA08F79741A1258958451435B19A613DB90F979EF5A45744A41342F1A4343053C9ADA48413C21FB73EAC7D6CB03BB39D282809D0168192B943160C05A1B70693C8DDBD07DCDCA356057192596B1C33903068F3302172710B90D1F58E2B5A183B902864DFB02F050FAE313CD8A9E23FD96C58DE3CA48810C5E875B9C4638340281B3D03447AC9A844526F6191270E7A6DCE83C14E5E708598F3E2C30A327479592A4EF1E3081C3D0553B56CD50D425F68B2260CBABDCE82C14E54123266110097D86403AE6416C70E6FA5DB3CAC0C47F80DA6710EEC0350A40ABB370084B104C220233F80C0ABA86012670179A72A582514C444AAFC190D638745A9CB90F7C073689858ACD6760349F935564C621FBE5E78BC4727E94DDACDBB4FDF2F3667BA0CFA4FAA1F8F3B2F8EE73BAA3715EFEFACBCF5FCE05F733BDFC7599286C44FC52C84C68B9F8AA155AD37C4C9ED2DA818E453549DD5C6F98A027B2232772959DA227B26533E0DBE21552BEA27F27F1B92079FFFC48771F93BBF3E9783E152ED3E7C75808F52F3FABF5FFF2B364F32F7747F657EEC285C2CCA87081DE25657FA0B1FB96C4DD0A888960776DFC4A8BDF2FB93C15FFA5FBD746D26FD2481B135485EF86161578C7064CF4F91817C2F2BB64435E681FDBBEE5F413DD93ED6BF1FB4BB46327B76142F48910C3FECB4D44F61979CE2B192D7FF16781E1DDF38FFFFBDFCFCE94F676380D00 , N'6.1.3-40302')


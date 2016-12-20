namespace CDK.DataAccess.Repositories
{
    using Mappings;
    using Mappings.cdk;
    using Models;
    using Models.cdk;
    using Models.ddf;
    using Repository.Pattern.Ef6;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading;

    public class CDKDbContext : DataContext
    {
        #region DbSets

        #region CDK

        public System.Data.Entity.DbSet<Role> Roles
        {
            get; set;
        }

        public System.Data.Entity.DbSet<User> Users
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UserClaim> UserClaims
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UserLogin> UserLogins
        {
            get; set;
        }

        public System.Data.Entity.IDbSet<Developer> Developers
        {
            get; set;
        } // Developer

        public System.Data.Entity.IDbSet<Development> Developments
        {
            get; set;
        } // Development

        public System.Data.Entity.IDbSet<DevelopmentAddress> DevelopmentAddresses
        {
            get; set;
        } // DevelopmentAddress

        public System.Data.Entity.IDbSet<DevelopmentAmenities> DevelopmentAmenities
        {
            get; set;
        } // DevelopmentAmenities

        public System.Data.Entity.IDbSet<DevelopmentFloorPlan> DevelopmentFloorPlans
        {
            get; set;
        } // DevelopmentFloorPlan

        public System.Data.Entity.IDbSet<DevelopmentPhoto> DevelopmentPhotos
        {
            get; set;
        } // DevelopmentPhoto

        public System.Data.Entity.IDbSet<DevelopmentVideo> DevelopmentVideos
        {
            get; set;
        } // DevelopmentVideo

        public System.Data.Entity.IDbSet<MetroArea> MetroAreas
        {
            get; set;
        } // MetroArea

        public System.Data.Entity.IDbSet<NeighborhoodArea> NeighborhoodAreas
        {
            get; set;
        } // NeighborhoodArea

        public System.Data.Entity.IDbSet<NeighborhoodGuide> NeighborhoodGuides
        {
            get; set;
        } // NeighborhoodGuide

        public System.Data.Entity.IDbSet<NeighborhoodGuidePhoto> NeighborhoodGuidePhotos
        {
            get; set;
        } // NeighborhoodGuidePhoto

        public System.Data.Entity.IDbSet<NeighborhoodGuideVideo> NeighborhoodGuideVideos
        {
            get; set;
        } // NeighborhoodGuideVideo

        #endregion CDK

        #region DDF

        public System.Data.Entity.DbSet<ABoard> ABoards
        {
            get; set;
        }

        public System.Data.Entity.DbSet<AccessType> AccessTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ALanguage> ALanguages
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Amenitie> Amenities
        {
            get; set;
        }

        public System.Data.Entity.DbSet<AmenitiesNearby> AmenitiesNearbies
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Amperage> Amperages
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Appliance> Appliances
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ArchitecturalStyle> ArchitecturalStyles
        {
            get; set;
        }

        public System.Data.Entity.DbSet<AuditDdfRequest> AuditDdfRequests
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BasementDevelopment> BasementDevelopments
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BasementFeature> BasementFeatures
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BasementType> BasementTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Board> Boards
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Building> Buildings
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BuildingAddress> BuildingAddresses
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BuildingLand> BuildingLands
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BuildingType> BuildingTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Business> Businesses
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BusinessSubType> BusinessSubTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<BusinessType> BusinessTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<CeilingType> CeilingTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ClearCeilingHeight> ClearCeilingHeights
        {
            get; set;
        }

        public System.Data.Entity.DbSet<CommunicationType> CommunicationTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<CommunityFeature> CommunityFeatures
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ConstructionMaterial> ConstructionMaterials
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ConstructionStatus> ConstructionStatus
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ConstructionStyleAttachment> ConstructionStyleAttachments
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ConstructionStyleOther> ConstructionStyleOthers
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ConstructionStyleSplitLevel> ConstructionStyleSplitLevels
        {
            get; set;
        }

        public System.Data.Entity.DbSet<CoolingType> CoolingTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Crop> Crops
        {
            get; set;
        }

        public System.Data.Entity.DbSet<CurrentUse> CurrentUses
        {
            get; set;
        }

        public System.Data.Entity.DbSet<DocumentType> DocumentTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Easement> Easements
        {
            get; set;
        }

        public System.Data.Entity.DbSet<EquipmentType> EquipmentTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ExteriorFinish> ExteriorFinishes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FarmType> FarmTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Feature> Features
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FenceType> FenceTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FireplaceFuel> FireplaceFuels
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FireplaceType> FireplaceTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FireProtection> FireProtections
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Fixture> Fixtures
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FlooringType> FlooringTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FoundationType> FoundationTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Franchisor> Franchisors
        {
            get; set;
        }

        public System.Data.Entity.DbSet<FrontsOn> FrontsOns
        {
            get; set;
        }

        public System.Data.Entity.DbSet<HeatingFuel> HeatingFuels
        {
            get; set;
        }

        public System.Data.Entity.DbSet<HeatingType> HeatingTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<IndividualDesignation> IndividualDesignations
        {
            get; set;
        }

        public System.Data.Entity.DbSet<IrrigationType> IrrigationTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<LandDispositionType> LandDispositionTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<LandscapeFeature> LandscapeFeatures
        {
            get; set;
        }

        public System.Data.Entity.DbSet<LeaseType> LeaseTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<LiveStockType> LiveStockTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<LoadingType> LoadingTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Machinery> Machineries
        {
            get; set;
        }

        public System.Data.Entity.DbSet<MaintenanceFeeType> MaintenanceFeeTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<MeasureUnit> MeasureUnits
        {
            get; set;
        }

        public System.Data.Entity.DbSet<OrganizationDesignation> OrganizationDesignations
        {
            get; set;
        }

        public System.Data.Entity.DbSet<OrganizationType> OrganizationTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<OwnershipType> OwnershipTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ParkingType> ParkingTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<PaymentUnit> PaymentUnits
        {
            get; set;
        }

        public System.Data.Entity.DbSet<PoolFeature> PoolFeatures
        {
            get; set;
        }

        public System.Data.Entity.DbSet<PoolType> PoolTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<PropertyType> PropertyTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RentalEquipmentType> RentalEquipmentTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RightType> RightTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RoadType> RoadTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RoofMaterial> RoofMaterials
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RoofStyle> RoofStyles
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RoomLevel> RoomLevels
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RoomType> RoomTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Sewer> Sewers
        {
            get; set;
        }

        public System.Data.Entity.DbSet<SignType> SignTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<SoilEvaluationType> SoilEvaluationTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<SoilType> SoilTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Specialtie> Specialties
        {
            get; set;
        }

        public System.Data.Entity.DbSet<StorageType> StorageTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<StoreFront> StoreFronts
        {
            get; set;
        }

        public System.Data.Entity.DbSet<StructureType> StructureTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<SurfaceWater> SurfaceWaters
        {
            get; set;
        }

        public System.Data.Entity.DbSet<TopographyType> TopographyTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<TransactionType> TransactionTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UffiCode> UffiCodes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<Unit> Units
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgent> UnitAgents
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentContact> UnitAgentContacts
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentDesignation> UnitAgentDesignations
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentLanguage> UnitAgentLanguages
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentOffice> UnitAgentOffices
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentOfficePhone> UnitAgentOfficePhones
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentOfficeWebsite> UnitAgentOfficeWebsites
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentPhone> UnitAgentPhones
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentSpeciality> UnitAgentSpecialities
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentTradingArea> UnitAgentTradingAreas
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitAgentWebsite> UnitAgentWebsites
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitOpenHouse> UnitOpenHouses
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitParkingSpace> UnitParkingSpaces
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitPhoto> UnitPhotos
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitRoom> UnitRooms
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UnitUtilitiesAvailable> UnitUtilitiesAvailables
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UtilityPower> UtilityPowers
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UtilityType> UtilityTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<UtilityWater> UtilityWaters
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ViewType> ViewTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<WaterFrontType> WaterFrontTypes
        {
            get; set;
        }

        public System.Data.Entity.DbSet<ZoningType> ZoningTypes
        {
            get; set;
        }

        #endregion DDF

        #endregion DbSets
   
        public CDKDbContext()
            : base("Name=CDKDbContext")
        {
            var objCtx = ((IObjectContextAdapter)this).ObjectContext;

            objCtx.SavingChanges += SavingChanges;
        }

        public CDKDbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        private static void SavingChanges(object sender, EventArgs e)
        {
            var objCtx = sender as ObjectContext;
            if (objCtx == null)
                return;

            var username = Thread.CurrentPrincipal != null ? Thread.CurrentPrincipal.Identity.Name : String.Empty;

            var auditableEntries =
                (from entry in objCtx.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                 where !entry.IsRelationship
                 let entity = entry.Entity as IBaseModel
                 where entity != null
                 select new
                 {
                     entity,
                     entry.State
                 }).ToList();

            foreach (var entry in auditableEntries.Where(x => x.State == EntityState.Added))
            {
                entry.entity.Created = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                entry.entity.CreatedBy = username;
            }

            foreach (var entry in auditableEntries.Where(x => x.State == EntityState.Modified))
            {
                /*var originalValues = objCtx.ObjectStateManager.GetObjectStateEntry(entry.entity).OriginalValues;

                entry.entity.Created = (DateTime)originalValues["Created"];
                entry.entity.CreatedBy = originalValues["CreatedBy"].GetType().Name.Equals("DBNull") ? string.Empty : (string)originalValues["CreatedBy"];
                          */
                entry.entity.LastUpdate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                entry.entity.LastUpdateBy = username;
            }
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());

            modelBuilder.Configurations.Add(new DeveloperMap());
            modelBuilder.Configurations.Add(new DevelopmentMap());
            modelBuilder.Configurations.Add(new DevelopmentAmenitiesMap());
            modelBuilder.Configurations.Add(new DevelopmentAddressMap());
            modelBuilder.Configurations.Add(new DevelopmentFloorPlanMap());
            modelBuilder.Configurations.Add(new DevelopmentPhotoMap());
            modelBuilder.Configurations.Add(new DevelopmentVideoMap());
            modelBuilder.Configurations.Add(new MetroAreaMap());
            modelBuilder.Configurations.Add(new NeighborhoodAreaMap());
            modelBuilder.Configurations.Add(new NeighborhoodGuideMap());
            modelBuilder.Configurations.Add(new NeighborhoodGuidePhotoMap());
            modelBuilder.Configurations.Add(new NeighborhoodGuideVideoMap());

            //DDF
            modelBuilder.Configurations.Add(new ABoardMap());
            modelBuilder.Configurations.Add(new AccessTypeMap());
            modelBuilder.Configurations.Add(new ALanguageMap());
            modelBuilder.Configurations.Add(new AmenitieMap());
            modelBuilder.Configurations.Add(new AmenitiesNearbyMap());
            modelBuilder.Configurations.Add(new AmperageMap());
            modelBuilder.Configurations.Add(new ApplianceMap());
            modelBuilder.Configurations.Add(new ArchitecturalStyleMap());
            modelBuilder.Configurations.Add(new AuditDdfRequestMap());
            modelBuilder.Configurations.Add(new BasementDevelopmentMap());
            modelBuilder.Configurations.Add(new BasementFeatureMap());
            modelBuilder.Configurations.Add(new BasementTypeMap());
            modelBuilder.Configurations.Add(new BoardMap());
            modelBuilder.Configurations.Add(new BuildingMap());
            modelBuilder.Configurations.Add(new BuildingAddressMap());
            modelBuilder.Configurations.Add(new BuildingLandMap());
            modelBuilder.Configurations.Add(new BuildingTypeMap());
            modelBuilder.Configurations.Add(new BusinessMap());
            modelBuilder.Configurations.Add(new BusinessSubTypeMap());
            modelBuilder.Configurations.Add(new BusinessTypeMap());
            modelBuilder.Configurations.Add(new CeilingTypeMap());
            modelBuilder.Configurations.Add(new ClearCeilingHeightMap());
            modelBuilder.Configurations.Add(new CommunicationTypeMap());
            modelBuilder.Configurations.Add(new CommunityFeatureMap());
            modelBuilder.Configurations.Add(new ConstructionMaterialMap());
            modelBuilder.Configurations.Add(new ConstructionStatuMap());
            modelBuilder.Configurations.Add(new ConstructionStyleAttachmentMap());
            modelBuilder.Configurations.Add(new ConstructionStyleOtherMap());
            modelBuilder.Configurations.Add(new ConstructionStyleSplitLevelMap());
            modelBuilder.Configurations.Add(new CoolingTypeMap());
            modelBuilder.Configurations.Add(new CropMap());
            modelBuilder.Configurations.Add(new CurrentUseMap());
            modelBuilder.Configurations.Add(new DocumentTypeMap());
            modelBuilder.Configurations.Add(new EasementMap());
            modelBuilder.Configurations.Add(new EquipmentTypeMap());
            modelBuilder.Configurations.Add(new ExteriorFinishMap());
            modelBuilder.Configurations.Add(new FarmTypeMap());
            modelBuilder.Configurations.Add(new FeatureMap());
            modelBuilder.Configurations.Add(new FenceTypeMap());
            modelBuilder.Configurations.Add(new FireplaceFuelMap());
            modelBuilder.Configurations.Add(new FireplaceTypeMap());
            modelBuilder.Configurations.Add(new FireProtectionMap());
            modelBuilder.Configurations.Add(new FixtureMap());
            modelBuilder.Configurations.Add(new FlooringTypeMap());
            modelBuilder.Configurations.Add(new FoundationTypeMap());
            modelBuilder.Configurations.Add(new FranchisorMap());
            modelBuilder.Configurations.Add(new FrontsOnMap());
            modelBuilder.Configurations.Add(new HeatingFuelMap());
            modelBuilder.Configurations.Add(new HeatingTypeMap());
            modelBuilder.Configurations.Add(new IndividualDesignationMap());
            modelBuilder.Configurations.Add(new IrrigationTypeMap());
            modelBuilder.Configurations.Add(new LandDispositionTypeMap());
            modelBuilder.Configurations.Add(new LandscapeFeatureMap());
            modelBuilder.Configurations.Add(new LeaseTypeMap());
            modelBuilder.Configurations.Add(new LiveStockTypeMap());
            modelBuilder.Configurations.Add(new LoadingTypeMap());
            modelBuilder.Configurations.Add(new MachineryMap());
            modelBuilder.Configurations.Add(new MaintenanceFeeTypeMap());
            modelBuilder.Configurations.Add(new MeasureUnitMap());
            modelBuilder.Configurations.Add(new OrganizationDesignationMap());
            modelBuilder.Configurations.Add(new OrganizationTypeMap());
            modelBuilder.Configurations.Add(new OwnershipTypeMap());
            modelBuilder.Configurations.Add(new ParkingTypeMap());
            modelBuilder.Configurations.Add(new PaymentUnitMap());
            modelBuilder.Configurations.Add(new PoolFeatureMap());
            modelBuilder.Configurations.Add(new PoolTypeMap());
            modelBuilder.Configurations.Add(new PropertyTypeMap());
            modelBuilder.Configurations.Add(new RentalEquipmentTypeMap());
            modelBuilder.Configurations.Add(new RightTypeMap());
            modelBuilder.Configurations.Add(new RoadTypeMap());
            modelBuilder.Configurations.Add(new RoofMaterialMap());
            modelBuilder.Configurations.Add(new RoofStyleMap());
            modelBuilder.Configurations.Add(new RoomLevelMap());
            modelBuilder.Configurations.Add(new RoomTypeMap());
            modelBuilder.Configurations.Add(new SewerMap());
            modelBuilder.Configurations.Add(new SignTypeMap());
            modelBuilder.Configurations.Add(new SoilEvaluationTypeMap());
            modelBuilder.Configurations.Add(new SoilTypeMap());
            modelBuilder.Configurations.Add(new SpecialtieMap());
            modelBuilder.Configurations.Add(new StorageTypeMap());
            modelBuilder.Configurations.Add(new StoreFrontMap());
            modelBuilder.Configurations.Add(new StructureTypeMap());
            modelBuilder.Configurations.Add(new SurfaceWaterMap());
            modelBuilder.Configurations.Add(new TopographyTypeMap());
            modelBuilder.Configurations.Add(new TransactionTypeMap());
            modelBuilder.Configurations.Add(new UffiCodeMap());
            modelBuilder.Configurations.Add(new UnitMap());
            modelBuilder.Configurations.Add(new UnitAgentMap());
            modelBuilder.Configurations.Add(new UnitAgentContactMap());
            modelBuilder.Configurations.Add(new UnitAgentDesignationMap());
            modelBuilder.Configurations.Add(new UnitAgentLanguageMap());
            modelBuilder.Configurations.Add(new UnitAgentOfficeMap());
            modelBuilder.Configurations.Add(new UnitAgentOfficePhoneMap());
            modelBuilder.Configurations.Add(new UnitAgentOfficeWebsiteMap());
            modelBuilder.Configurations.Add(new UnitAgentPhoneMap());
            modelBuilder.Configurations.Add(new UnitAgentSpecialityMap());
            modelBuilder.Configurations.Add(new UnitAgentTradingAreaMap());
            modelBuilder.Configurations.Add(new UnitAgentWebsiteMap());
            modelBuilder.Configurations.Add(new UnitOpenHouseMap());
            modelBuilder.Configurations.Add(new UnitParkingSpaceMap());
            modelBuilder.Configurations.Add(new UnitPhotoMap());
            modelBuilder.Configurations.Add(new UnitRoomMap());
            modelBuilder.Configurations.Add(new UnitUtilitiesAvailableMap());
            modelBuilder.Configurations.Add(new UtilityPowerMap());
            modelBuilder.Configurations.Add(new UtilityTypeMap());
            modelBuilder.Configurations.Add(new UtilityWaterMap());
            modelBuilder.Configurations.Add(new ViewTypeMap());
            modelBuilder.Configurations.Add(new WaterFrontTypeMap());
            modelBuilder.Configurations.Add(new ZoningTypeMap());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new RoleMap(schema));
            modelBuilder.Configurations.Add(new UserMap(schema));
            modelBuilder.Configurations.Add(new UserClaimMap(schema));
            modelBuilder.Configurations.Add(new UserLoginMap(schema));

            modelBuilder.Configurations.Add(new DeveloperMap(schema));
            modelBuilder.Configurations.Add(new DevelopmentMap(schema));
            modelBuilder.Configurations.Add(new DevelopmentAddressMap(schema));
            modelBuilder.Configurations.Add(new DevelopmentFloorPlanMap(schema));
            modelBuilder.Configurations.Add(new DevelopmentPhotoMap(schema));
            modelBuilder.Configurations.Add(new DevelopmentVideoMap(schema));
            modelBuilder.Configurations.Add(new DevelopmentAmenitiesMap());

            modelBuilder.Configurations.Add(new MetroAreaMap(schema));
            modelBuilder.Configurations.Add(new NeighborhoodAreaMap(schema));
            modelBuilder.Configurations.Add(new NeighborhoodGuideMap(schema));
            modelBuilder.Configurations.Add(new NeighborhoodGuidePhotoMap(schema));
            modelBuilder.Configurations.Add(new NeighborhoodGuideVideoMap(schema));

            //DDF
            modelBuilder.Configurations.Add(new ABoardMap(schema));
            modelBuilder.Configurations.Add(new AccessTypeMap(schema));
            modelBuilder.Configurations.Add(new ALanguageMap(schema));
            modelBuilder.Configurations.Add(new AmenitieMap(schema));
            modelBuilder.Configurations.Add(new AmenitiesNearbyMap(schema));
            modelBuilder.Configurations.Add(new AmperageMap(schema));
            modelBuilder.Configurations.Add(new ApplianceMap(schema));
            modelBuilder.Configurations.Add(new ArchitecturalStyleMap(schema));
            modelBuilder.Configurations.Add(new AuditDdfRequestMap(schema));
            modelBuilder.Configurations.Add(new BasementDevelopmentMap(schema));
            modelBuilder.Configurations.Add(new BasementFeatureMap(schema));
            modelBuilder.Configurations.Add(new BasementTypeMap(schema));
            modelBuilder.Configurations.Add(new BoardMap(schema));
            modelBuilder.Configurations.Add(new BuildingMap(schema));
            modelBuilder.Configurations.Add(new BuildingAddressMap(schema));
            modelBuilder.Configurations.Add(new BuildingLandMap(schema));
            modelBuilder.Configurations.Add(new BuildingTypeMap(schema));
            modelBuilder.Configurations.Add(new BusinessMap(schema));
            modelBuilder.Configurations.Add(new BusinessSubTypeMap(schema));
            modelBuilder.Configurations.Add(new BusinessTypeMap(schema));
            modelBuilder.Configurations.Add(new CeilingTypeMap(schema));
            modelBuilder.Configurations.Add(new ClearCeilingHeightMap(schema));
            modelBuilder.Configurations.Add(new CommunicationTypeMap(schema));
            modelBuilder.Configurations.Add(new CommunityFeatureMap(schema));
            modelBuilder.Configurations.Add(new ConstructionMaterialMap(schema));
            modelBuilder.Configurations.Add(new ConstructionStatuMap(schema));
            modelBuilder.Configurations.Add(new ConstructionStyleAttachmentMap(schema));
            modelBuilder.Configurations.Add(new ConstructionStyleOtherMap(schema));
            modelBuilder.Configurations.Add(new ConstructionStyleSplitLevelMap(schema));
            modelBuilder.Configurations.Add(new CoolingTypeMap(schema));
            modelBuilder.Configurations.Add(new CropMap(schema));
            modelBuilder.Configurations.Add(new CurrentUseMap(schema));
            modelBuilder.Configurations.Add(new DocumentTypeMap(schema));
            modelBuilder.Configurations.Add(new EasementMap(schema));
            modelBuilder.Configurations.Add(new EquipmentTypeMap(schema));
            modelBuilder.Configurations.Add(new ExteriorFinishMap(schema));
            modelBuilder.Configurations.Add(new FarmTypeMap(schema));
            modelBuilder.Configurations.Add(new FeatureMap(schema));
            modelBuilder.Configurations.Add(new FenceTypeMap(schema));
            modelBuilder.Configurations.Add(new FireplaceFuelMap(schema));
            modelBuilder.Configurations.Add(new FireplaceTypeMap(schema));
            modelBuilder.Configurations.Add(new FireProtectionMap(schema));
            modelBuilder.Configurations.Add(new FixtureMap(schema));
            modelBuilder.Configurations.Add(new FlooringTypeMap(schema));
            modelBuilder.Configurations.Add(new FoundationTypeMap(schema));
            modelBuilder.Configurations.Add(new FranchisorMap(schema));
            modelBuilder.Configurations.Add(new FrontsOnMap(schema));
            modelBuilder.Configurations.Add(new HeatingFuelMap(schema));
            modelBuilder.Configurations.Add(new HeatingTypeMap(schema));
            modelBuilder.Configurations.Add(new IndividualDesignationMap(schema));
            modelBuilder.Configurations.Add(new IrrigationTypeMap(schema));
            modelBuilder.Configurations.Add(new LandDispositionTypeMap(schema));
            modelBuilder.Configurations.Add(new LandscapeFeatureMap(schema));
            modelBuilder.Configurations.Add(new LeaseTypeMap(schema));
            modelBuilder.Configurations.Add(new LiveStockTypeMap(schema));
            modelBuilder.Configurations.Add(new LoadingTypeMap(schema));
            modelBuilder.Configurations.Add(new MachineryMap(schema));
            modelBuilder.Configurations.Add(new MaintenanceFeeTypeMap(schema));
            modelBuilder.Configurations.Add(new MeasureUnitMap(schema));
            modelBuilder.Configurations.Add(new OrganizationDesignationMap(schema));
            modelBuilder.Configurations.Add(new OrganizationTypeMap(schema));
            modelBuilder.Configurations.Add(new OwnershipTypeMap(schema));
            modelBuilder.Configurations.Add(new ParkingTypeMap(schema));
            modelBuilder.Configurations.Add(new PaymentUnitMap(schema));
            modelBuilder.Configurations.Add(new PoolFeatureMap(schema));
            modelBuilder.Configurations.Add(new PoolTypeMap(schema));
            modelBuilder.Configurations.Add(new PropertyTypeMap(schema));
            modelBuilder.Configurations.Add(new RentalEquipmentTypeMap(schema));
            modelBuilder.Configurations.Add(new RightTypeMap(schema));
            modelBuilder.Configurations.Add(new RoadTypeMap(schema));
            modelBuilder.Configurations.Add(new RoofMaterialMap(schema));
            modelBuilder.Configurations.Add(new RoofStyleMap(schema));
            modelBuilder.Configurations.Add(new RoomLevelMap(schema));
            modelBuilder.Configurations.Add(new RoomTypeMap(schema));
            modelBuilder.Configurations.Add(new SewerMap(schema));
            modelBuilder.Configurations.Add(new SignTypeMap(schema));
            modelBuilder.Configurations.Add(new SoilEvaluationTypeMap(schema));
            modelBuilder.Configurations.Add(new SoilTypeMap(schema));
            modelBuilder.Configurations.Add(new SpecialtieMap(schema));
            modelBuilder.Configurations.Add(new StorageTypeMap(schema));
            modelBuilder.Configurations.Add(new StoreFrontMap(schema));
            modelBuilder.Configurations.Add(new StructureTypeMap(schema));
            modelBuilder.Configurations.Add(new SurfaceWaterMap(schema));
            modelBuilder.Configurations.Add(new TopographyTypeMap(schema));
            modelBuilder.Configurations.Add(new TransactionTypeMap(schema));
            modelBuilder.Configurations.Add(new UffiCodeMap(schema));
            modelBuilder.Configurations.Add(new UnitMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentContactMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentDesignationMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentLanguageMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentOfficeMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentOfficePhoneMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentOfficeWebsiteMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentPhoneMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentSpecialityMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentTradingAreaMap(schema));
            modelBuilder.Configurations.Add(new UnitAgentWebsiteMap(schema));
            modelBuilder.Configurations.Add(new UnitOpenHouseMap(schema));
            modelBuilder.Configurations.Add(new UnitParkingSpaceMap(schema));
            modelBuilder.Configurations.Add(new UnitPhotoMap(schema));
            modelBuilder.Configurations.Add(new UnitRoomMap(schema));
            modelBuilder.Configurations.Add(new UnitUtilitiesAvailableMap(schema));
            modelBuilder.Configurations.Add(new UtilityPowerMap(schema));
            modelBuilder.Configurations.Add(new UtilityTypeMap(schema));
            modelBuilder.Configurations.Add(new UtilityWaterMap(schema));
            modelBuilder.Configurations.Add(new ViewTypeMap(schema));
            modelBuilder.Configurations.Add(new WaterFrontTypeMap(schema));
            modelBuilder.Configurations.Add(new ZoningTypeMap(schema));

            return modelBuilder;
        }
    }
}
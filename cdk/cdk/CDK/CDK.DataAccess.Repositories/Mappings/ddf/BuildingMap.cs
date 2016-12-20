namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;
    using CDK.DataAccess.Repositories.Extensions;

    public class BuildingMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Building>
    {
        public BuildingMap()
            : this("ddf")
        {
        }

        public BuildingMap(string schema)
        {
            ToTable(schema + ".Building");

            Property(x => x.BuildingAddressId).HasColumnName(@"BuildingAddressId").IsOptional().HasColumnType("bigint");
            Property(x => x.BuildingUri).HasColumnName(@"BuildingUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Age).HasColumnName(@"Age").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Board).HasColumnName(@"Board").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Anchor).HasColumnName(@"Anchor").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.BomaRating).HasColumnName(@"BomaRating").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ConstructedDate).HasColumnName(@"ConstructedDate").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EnerguideRating).HasColumnName(@"EnerguideRating").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FireplacePresent).HasColumnName(@"FireplacePresent").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FireplaceTotal).HasColumnName(@"FireplaceTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LeedsCategory).HasColumnName(@"LeedsCategory").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LeedsRating).HasColumnName(@"LeedsRating").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RenovatedDate).HasColumnName(@"RenovatedDate").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.StoriesTotal).HasColumnName(@"StoriesTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeExterior).HasColumnName(@"SizeExterior").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ManagementCompany).HasColumnName(@"ManagementCompany").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Type).HasColumnName(@"Type").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Structure).HasColumnName(@"Structure").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MunicipalId).HasColumnName(@"MunicipalId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Uffi).HasColumnName(@"Uffi").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UnitType).HasColumnName(@"UnitType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.VacancyRate).HasColumnName(@"VacancyRate").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ZoningType).HasColumnName(@"ZoningType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ZoningDescription).HasColumnName(@"ZoningDescription").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TotalBuildings).HasColumnName(@"TotalBuildings").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.WaterFrontName).HasColumnName(@"WaterFrontName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LocationDescription).HasColumnName(@"LocationDescription").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
           

            this.AddSeo();
            this.AddExternal();
            this.AddBase();

            HasOptional(a => a.BuildingAddress).WithMany(b => b.Buildings).HasForeignKey(c => c.BuildingAddressId);
            HasMany(t => t.Machineries).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingMachinery", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("MachineryId");
            });
            HasMany(t => t.MeasureUnits).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingMeasureUnit", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("MeasureUnitId");
            });
            HasMany(t => t.PoolFeatures).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingPoolFeature", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("PoolFeatureId");
            });
            HasMany(t => t.PoolTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingPoolType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("PoolTypeId");
            });
            HasMany(t => t.RoadTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingRoadType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("RoadTypeId");
            });
            HasMany(t => t.RoofMaterials).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingRoofMaterial", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("RoofMaterialId");
            });
            HasMany(t => t.RoofStyles).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingRoofStyle", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("RoofStyleId");
            });
            HasMany(t => t.SignTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingSignType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("SignTypeId");
            });
            HasMany(t => t.StoreFronts).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingStoreFront", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("StoreFrontId");
            });
            HasMany(t => t.StructureTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingStructureType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("StructureTypeId");
            });
            HasMany(t => t.UffiCodes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingUffiCode", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("UffiCodeId");
            });
            HasMany(t => t.UtilityPowers).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingUtilityPower", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("UtilityPowerId");
            });
            HasMany(t => t.UtilityWaters).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingUtilityWater", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("UtilityWaterId");
            });
            HasMany(t => t.BuildingTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingBuildingType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("BuildingTypeId");
            });
            HasMany(t => t.CeilingTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingCeilingType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("CeilingTypeId");
            });
            HasMany(t => t.ClearCeilingHeights).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingClearCeilingHeight", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("ClearCeilingHeightId");
            });
            HasMany(t => t.CommunicationTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingCommunicationType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("CommunicationTypeId");
            });
            HasMany(t => t.CommunityFeatures).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingCommunityFeature", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("CommunityFeatureId");
            });
            HasMany(t => t.ConstructionMaterials).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingConstructionMaterial", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("ConstructionMaterialId");
            });
            HasMany(t => t.Crops).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingCrop", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("CropId");
            });
            HasMany(t => t.DocumentTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingDocumentType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("DocumentTypeId");
            });
            HasMany(t => t.Easements).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingEasement", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("EasementId");
            });
            HasMany(t => t.EquipmentTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingEquipmentType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("EquipmentTypeId");
            });
            HasMany(t => t.ExteriorFinishes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingExteriorFinish", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("ExteriorFinishId");
            });
            HasMany(t => t.FarmTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingFarmType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FarmTypeId");
            });
            HasMany(t => t.FireplaceFuels).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingFireplaceFuel", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FireplaceFuelId");
            });
            HasMany(t => t.FireplaceTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingFireplaceType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FireplaceTypeId");
            });
            HasMany(t => t.FireProtections).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingFireProtection", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FireProtectionId");
            });
            HasMany(t => t.Fixtures).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingFixture", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FixtureId");
            });
            HasMany(t => t.FoundationTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingFoundationType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FoundationTypeId");
            });
            HasMany(t => t.HeatingFuels).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingHeatingFuel", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("HeatingFuelId");
            });
            HasMany(t => t.HeatingTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingHeatingType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("HeatingTypeId");
            });
            HasMany(t => t.IrrigationTypes).WithMany(t => t.Buildings).Map(m =>
            {
                m.ToTable("BuildingIrrigationType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("IrrigationTypeId");
            });
        }
    }
}
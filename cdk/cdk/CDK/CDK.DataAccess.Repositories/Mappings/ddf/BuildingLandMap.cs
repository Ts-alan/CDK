namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class BuildingLandMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BuildingLand>
    {
        public BuildingLandMap()
            : this("ddf")
        {
        }

        public BuildingLandMap(string schema)
        {
            ToTable(schema + ".BuildingLand");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.BuildingId).HasColumnName(@"BuildingId").IsOptional().HasColumnType("bigint");
            Property(x => x.SizeTotal).HasColumnName(@"SizeTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeTotalText).HasColumnName(@"SizeTotalText").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeFrontage).HasColumnName(@"SizeFrontage").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AccessType).HasColumnName(@"AccessType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Acreage).HasColumnName(@"Acreage").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Amenities).HasColumnName(@"Amenities").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ClearedTotal).HasColumnName(@"ClearedTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CurrentUse).HasColumnName(@"CurrentUse").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Divisible).HasColumnName(@"Divisible").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FenceTotal).HasColumnName(@"FenceTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FenceType).HasColumnName(@"FenceType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FrontsOn).HasColumnName(@"FrontsOn").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LandDisposition).HasColumnName(@"LandDisposition").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LandscapeFeatures).HasColumnName(@"LandscapeFeatures").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PastureTotal).HasColumnName(@"PastureTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Sewer).HasColumnName(@"Sewer").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeDepth).HasColumnName(@"SizeDepth").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeIrregular).HasColumnName(@"SizeIrregular").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SoilEvaluation).HasColumnName(@"SoilEvaluation").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SoilType).HasColumnName(@"SoilType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SurfaceWater).HasColumnName(@"SurfaceWater").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TiledTotal).HasColumnName(@"TiledTotal").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TopographyType).HasColumnName(@"TopographyType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LastUpdate).HasColumnName(@"LastUpdate").IsOptional().HasColumnType("datetime");

            HasOptional(a => a.Building).WithMany(b => b.BuildingLands).HasForeignKey(c => c.BuildingId);
            HasMany(t => t.CurrentUses).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandCurrentUse", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("CurrentUseId");
            });
            HasMany(t => t.FenceTypes).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandFenceType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("FenceTypeId");
            });
            HasMany(t => t.LandDispositionTypes).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandLandDispositionType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("LandDispositionTypeId");
            });
            HasMany(t => t.LandscapeFeatures_LandscapeFeatureId).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandLandscapeFeature", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("LandscapeFeatureId");
            });
            HasMany(t => t.Sewers).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandSewer", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("SewerId");
            });
            HasMany(t => t.SoilTypes).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandSoilType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("LandSoilTypeId");
            });
            HasMany(t => t.SurfaceWaters).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandSurfaceWater", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("SurfaceWaterId");
            });
            HasMany(t => t.TopographyTypes).WithMany(t => t.BuildingLands).Map(m =>
            {
                m.ToTable("LandTopographyType", "ddf");
                m.MapLeftKey("BuildingId");
                m.MapRightKey("TopographyTypeId");
            });
        }
    }
}
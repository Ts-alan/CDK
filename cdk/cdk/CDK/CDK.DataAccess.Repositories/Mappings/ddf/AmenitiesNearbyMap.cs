namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class AmenitiesNearbyMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AmenitiesNearby>
    {
        public AmenitiesNearbyMap()
            : this("ddf")
        {
        }

        public AmenitiesNearbyMap(string schema)
        {
            ToTable(schema + ".AmenitiesNearby");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.Units).WithMany(t => t.AmenitiesNearbies).Map(m =>
            {
                m.ToTable("UnitAmenitiesNearby", "ddf");
                m.MapLeftKey("AmenitiesNearbyId");
                m.MapRightKey("UnitId");
            });
            HasMany(t => t.BuildingLands).WithMany(t => t.AmenitiesNearbies).Map(m =>
            {
                m.ToTable("LandAmenitiesNearby", "ddf");
                m.MapLeftKey("AmenitiesNearbyId");
                m.MapRightKey("BuildingId");
            });
        }
    }
}
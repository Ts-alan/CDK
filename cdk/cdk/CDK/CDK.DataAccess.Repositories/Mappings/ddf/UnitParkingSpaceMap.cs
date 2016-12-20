namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitParkingSpaceMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitParkingSpace>
    {
        public UnitParkingSpaceMap()
            : this("ddf")
        {
        }

        public UnitParkingSpaceMap(string schema)
        {
            ToTable(schema + ".UnitParkingSpace");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitId).HasColumnName(@"UnitId").IsRequired().HasColumnType("bigint");
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Spaces).HasColumnName(@"Spaces").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.Unit).WithMany(b => b.UnitParkingSpaces).HasForeignKey(c => c.UnitId);
        }
    }
}
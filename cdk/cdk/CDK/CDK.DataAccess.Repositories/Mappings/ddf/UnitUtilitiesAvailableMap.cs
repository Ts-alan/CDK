namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitUtilitiesAvailableMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitUtilitiesAvailable>
    {
        public UnitUtilitiesAvailableMap()
            : this("ddf")
        {
        }

        public UnitUtilitiesAvailableMap(string schema)
        {
            ToTable(schema + ".UnitUtilitiesAvailable");
            HasKey(x => x.UnitUtilitiesAvailableId);

            Property(x => x.UnitUtilitiesAvailableId).HasColumnName(@"UnitUtilitiesAvailableId").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitId).HasColumnName(@"UnitId").IsRequired().HasColumnType("bigint");
            Property(x => x.Type).HasColumnName(@"Type").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Description).HasColumnName(@"Description").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.Unit).WithMany(b => b.UnitUtilitiesAvailables).HasForeignKey(c => c.UnitId);
        }
    }
}
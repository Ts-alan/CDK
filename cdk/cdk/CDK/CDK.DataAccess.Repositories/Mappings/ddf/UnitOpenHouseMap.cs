namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitOpenHouseMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitOpenHouse>
    {
        public UnitOpenHouseMap()
            : this("ddf")
        {
        }

        public UnitOpenHouseMap(string schema)
        {
            ToTable(schema + ".UnitOpenHouse");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitId).HasColumnName(@"UnitId").IsRequired().HasColumnType("bigint");
            Property(x => x.StartDateTime).HasColumnName(@"StartDateTime").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EndDateTime).HasColumnName(@"EndDateTime").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Comments).HasColumnName(@"Comments").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.Unit).WithMany(b => b.UnitOpenHouses).HasForeignKey(c => c.UnitId);
        }
    }
}
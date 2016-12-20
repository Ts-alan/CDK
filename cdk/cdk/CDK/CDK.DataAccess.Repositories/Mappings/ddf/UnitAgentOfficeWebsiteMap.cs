namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentOfficeWebsiteMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentOfficeWebsite>
    {
        public UnitAgentOfficeWebsiteMap()
            : this("ddf")
        {
        }

        public UnitAgentOfficeWebsiteMap(string schema)
        {
            ToTable(schema + ".UnitAgentOfficeWebsite");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentOfficeId).HasColumnName(@"UnitAgentOfficeId").IsRequired().HasColumnType("bigint");
            Property(x => x.ContactType).HasColumnName(@"ContactType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.WebsiteType).HasColumnName(@"WebsiteType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.WebsiteUrl).HasColumnName(@"WebsiteUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgentOffice).WithMany(b => b.UnitAgentOfficeWebsites).HasForeignKey(c => c.UnitAgentOfficeId);
        }
    }
}
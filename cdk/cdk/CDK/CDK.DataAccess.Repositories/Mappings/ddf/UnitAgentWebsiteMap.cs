namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentWebsiteMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentWebsite>
    {
        public UnitAgentWebsiteMap()
            : this("ddf")
        {
        }

        public UnitAgentWebsiteMap(string schema)
        {
            ToTable(schema + ".UnitAgentWebsite");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsRequired().HasColumnType("bigint");
            Property(x => x.ContactType).HasColumnName(@"ContactType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.WebsiteType).HasColumnName(@"WebsiteType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.WebsiteUrl).HasColumnName(@"WebsiteUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgent).WithMany(b => b.UnitAgentWebsites).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
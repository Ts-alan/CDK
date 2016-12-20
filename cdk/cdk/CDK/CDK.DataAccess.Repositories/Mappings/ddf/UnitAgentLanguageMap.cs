namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentLanguageMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentLanguage>
    {
        public UnitAgentLanguageMap()
            : this("ddf")
        {
        }

        public UnitAgentLanguageMap(string schema)
        {
            ToTable(schema + ".UnitAgentLanguage");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsRequired().HasColumnType("bigint");
            Property(x => x.Language).HasColumnName(@"Language").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgent).WithMany(b => b.UnitAgentLanguages).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
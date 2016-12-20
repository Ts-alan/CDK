namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class ALanguageMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ALanguage>
    {
        public ALanguageMap()
            : this("ddf")
        {
        }

        public ALanguageMap(string schema)
        {
            ToTable(schema + ".ALanguage");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.UnitAgents).WithMany(t => t.ALanguages).Map(m =>
            {
                m.ToTable("AgentALanguage", "ddf");
                m.MapLeftKey("ALanguageId");
                m.MapRightKey("UnitAgentId");
            });
        }
    }
}
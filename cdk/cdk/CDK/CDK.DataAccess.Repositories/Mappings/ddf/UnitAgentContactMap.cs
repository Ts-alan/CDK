namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentContactMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentContact>
    {
        public UnitAgentContactMap()
            : this("ddf")
        {
        }

        public UnitAgentContactMap(string schema)
        {
            ToTable(schema + ".UnitAgentContact");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ContactType).HasColumnName(@"ContactType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AgentType).HasColumnName(@"AgentType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TextValue).HasColumnName(@"TextValue").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LastUpdate).HasColumnName(@"LastUpdate").IsRequired().HasColumnType("datetime");
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsOptional().HasColumnType("bigint");

            HasOptional(a => a.UnitAgent).WithMany(b => b.UnitAgentContacts).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
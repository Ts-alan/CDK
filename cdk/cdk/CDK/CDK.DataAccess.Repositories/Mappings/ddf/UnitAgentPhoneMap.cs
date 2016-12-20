namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentPhoneMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentPhone>
    {
        public UnitAgentPhoneMap()
            : this("ddf")
        {
        }

        public UnitAgentPhoneMap(string schema)
        {
            ToTable(schema + ".UnitAgentPhone");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsRequired().HasColumnType("bigint");
            Property(x => x.ContactType).HasColumnName(@"ContactType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PhoneType).HasColumnName(@"PhoneType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgent).WithMany(b => b.UnitAgentPhones).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
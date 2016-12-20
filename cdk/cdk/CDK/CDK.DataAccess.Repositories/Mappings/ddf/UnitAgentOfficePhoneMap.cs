namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentOfficePhoneMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentOfficePhone>
    {
        public UnitAgentOfficePhoneMap()
            : this("ddf")
        {
        }

        public UnitAgentOfficePhoneMap(string schema)
        {
            ToTable(schema + ".UnitAgentOfficePhone");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentOfficeId).HasColumnName(@"UnitAgentOfficeId").IsRequired().HasColumnType("bigint");
            Property(x => x.ContactType).HasColumnName(@"ContactType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PhoneType).HasColumnName(@"PhoneType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgentOffice).WithMany(b => b.UnitAgentOfficePhones).HasForeignKey(c => c.UnitAgentOfficeId);
        }
    }
}
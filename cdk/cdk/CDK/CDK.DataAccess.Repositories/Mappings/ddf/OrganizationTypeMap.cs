namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class OrganizationTypeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OrganizationType>
    {
        public OrganizationTypeMap()
            : this("ddf")
        {
        }

        public OrganizationTypeMap(string schema)
        {
            ToTable(schema + ".OrganizationType");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.UnitAgentOffices).WithMany(t => t.OrganizationTypes).Map(m =>
            {
                m.ToTable("OfficeOrganizationType", "ddf");
                m.MapLeftKey("OrganizationTypeId");
                m.MapRightKey("UnitAgentOfficeId");
            });
        }
    }
}
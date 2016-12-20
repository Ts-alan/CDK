namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class OrganizationDesignationMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OrganizationDesignation>
    {
        public OrganizationDesignationMap()
            : this("ddf")
        {
        }

        public OrganizationDesignationMap(string schema)
        {
            ToTable(schema + ".OrganizationDesignation");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.UnitAgentOffices).WithMany(t => t.OrganizationDesignations).Map(m =>
            {
                m.ToTable("OfficeOrganizationDesignation", "ddf");
                m.MapLeftKey("OrganizationDesignationId");
                m.MapRightKey("UnitAgentOfficeId");
            });
        }
    }
}
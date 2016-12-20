namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentOfficeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentOffice>
    {
        public UnitAgentOfficeMap()
            : this("ddf")
        {
        }

        public UnitAgentOfficeMap(string schema)
        {
            ToTable(schema + ".UnitAgentOffice");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.DdfUnitAgentOfficeId).HasColumnName(@"DdfUnitAgentOfficeId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.StreetAddress).HasColumnName(@"StreetAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AddressLine1).HasColumnName(@"AddressLine1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.City).HasColumnName(@"City").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Country).HasColumnName(@"Country").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Franchisor).HasColumnName(@"Franchisor").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LogoLastUpdated).HasColumnName(@"LogoLastUpdated").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LogoUri).HasColumnName(@"LogoUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OrganizationType).HasColumnName(@"OrganizationType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Designation).HasColumnName(@"Designation").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LastUpdate).HasColumnName(@"LastUpdate").IsRequired().HasColumnType("datetime");
        }
    }
}
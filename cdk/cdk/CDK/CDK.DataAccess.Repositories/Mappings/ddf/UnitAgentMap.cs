namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgent>
    {
        public UnitAgentMap()
            : this("ddf")
        {
        }

        public UnitAgentMap(string schema)
        {
            ToTable(schema + ".UnitAgent");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UnitAgentOfficeId).HasColumnName(@"UnitAgentOfficeId").IsOptional().HasColumnType("bigint");
            Property(x => x.DdfAgentId).HasColumnName(@"DdfAgentId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Position).HasColumnName(@"Position").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LastUpdate).HasColumnName(@"LastUpdate").IsRequired().HasColumnType("datetime");
            Property(x => x.EducationCredentials).HasColumnName(@"EducationCredentials").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PhotoLastUpdated).HasColumnName(@"PhotoLastUpdated").IsOptional().HasColumnType("datetime");
            Property(x => x.StreetAddress).HasColumnName(@"StreetAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AddressLine1).HasColumnName(@"AddressLine1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Addressline2).HasColumnName(@"Addressline2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.StreetNumber).HasColumnName(@"StreetNumber").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.StreetName).HasColumnName(@"StreetName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.StreetSuffix).HasColumnName(@"StreetSuffix").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.City).HasColumnName(@"City").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Province).HasColumnName(@"Province").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ThumbnailPhotoUri).HasColumnName(@"ThumbnailPhotoUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LargePhotoUri).HasColumnName(@"LargePhotoUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasMany(t => t.Units).WithMany(t => t.UnitAgents).Map(m =>
            {
                m.ToTable("UnitUnitAgent", "ddf");
                m.MapLeftKey("UnitAgentId");
                m.MapRightKey("UnitId");
            });

            HasOptional(a => a.UnitAgentOffice).WithMany(b => b.UnitAgents).HasForeignKey(c => c.UnitAgentOfficeId);
        }
    }
}
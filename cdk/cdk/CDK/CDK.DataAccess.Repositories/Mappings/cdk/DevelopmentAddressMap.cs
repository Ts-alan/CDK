using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // DevelopmentAddress

    public class DevelopmentAddressMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DevelopmentAddress>
    {
        public DevelopmentAddressMap()
            : this("cdk")
        {
        }

        public DevelopmentAddressMap(string schema)
        {
            ToTable(schema + ".DevelopmentAddress");

            HasKey(x => x.Id);

            Property(x => x.StreetAddress).HasColumnName("StreetAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.City).HasColumnName("City").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CountryState).HasColumnName("CountryState").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Country).HasColumnName("Country").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Lon).HasColumnName("Lon").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Lat).HasColumnName("Lat").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PositionGeo).HasColumnName("PositionGeo").IsOptional().HasColumnType("geography");
            Property(x => x.StreetType).HasColumnName("StreetType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AdditionalStreetInfo).HasColumnName("AdditionalStreetInfo").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CommunityName).HasColumnName("CommunityName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            this.AddBaseWithoutId();

            // Foreign keys
            HasOptional(a => a.NeighborhoodArea).WithMany(b => b.DevelopmentAddress).HasForeignKey(c => c.NeighborhoodAreaId);
        }
    }
}
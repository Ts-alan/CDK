namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class BuildingAddressMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BuildingAddress>
    {
        public BuildingAddressMap()
            : this("ddf")
        {
        }

        public BuildingAddressMap(string schema)
        {
            ToTable(schema + ".BuildingAddress");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.StreetAddress).HasColumnName(@"StreetAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.City).HasColumnName(@"City").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CountryState).HasColumnName(@"CountryState").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Country).HasColumnName(@"Country").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Lon).HasColumnName(@"Lon").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Lat).HasColumnName(@"Lat").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AddressType).HasColumnName(@"AddressType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AdditionalStreetInfo).HasColumnName(@"AdditionalStreetInfo").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DdfCommunityName).HasColumnName(@"DdfCommunityName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Neighbourhood).HasColumnName(@"Neighbourhood").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Subdivision).HasColumnName(@"Subdivision").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PositionGeo).HasColumnName(@"PositionGeo").IsOptional().HasColumnType("geography");
            Property(x => x.MetroAreaId).HasColumnName(@"MetroAreaId").IsOptional().HasColumnType("bigint");
            Property(x => x.NeighborhoodAreaFirstLevelId).HasColumnName(@"NeighborhoodAreaFirstLevelId").IsOptional().HasColumnType("bigint");
            Property(x => x.NeighborhoodAreaSecondLevelId).HasColumnName(@"NeighborhoodAreaSecondLevelId").IsOptional().HasColumnType("bigint");
            Property(x => x.NeighborhoodAreaThirdLevelId).HasColumnName(@"NeighborhoodAreaThirdLevelId").IsOptional().HasColumnType("bigint");
            Property(x => x.FullAddress).HasColumnName(@"FullAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
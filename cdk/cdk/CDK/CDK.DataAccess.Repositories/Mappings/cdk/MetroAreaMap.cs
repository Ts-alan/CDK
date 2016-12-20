using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // MetroArea

    public class MetroAreaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MetroArea>
    {
        public MetroAreaMap() : this("cdk")
        {
        }

        public MetroAreaMap(string schema)
        {
            ToTable(schema + ".MetroArea");

            this.AddBase();
            this.AddSeo();

            Property(x => x.MetroAreaExtId).HasColumnName("MetroAreaExtId").IsOptional().HasColumnType("bigint");
            Property(x => x.MetroAreaExtVersion).HasColumnName("MetroAreaExtVersion").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName("ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.State).HasColumnName("State").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Country).HasColumnName("Country").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Description).HasColumnName("Description").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.CenterPointGeo).HasColumnName("CenterPointGeo").IsOptional().HasColumnType("geography");
            Property(x => x.CenterPointLat).HasColumnName("CenterPointLat").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CenterPointLon).HasColumnName("CenterPointLon").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CoordinatesGeo).HasColumnName("CoordinatesGeo").IsOptional().HasColumnType("geography");
            Property(x => x.MetroCoordinatesAsText).HasColumnName("MetroCoordinatesAsText").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.CoordinatesAsText).HasColumnName("CoordinatesAsText").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.MetroAreaUri).HasColumnName("MetroAreaUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MType).HasColumnName("MType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }
    }
}
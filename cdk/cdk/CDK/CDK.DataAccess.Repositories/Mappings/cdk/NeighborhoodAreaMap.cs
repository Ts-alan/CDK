using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // NeighborhoodArea

    public class NeighborhoodAreaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NeighborhoodArea>
    {
        public NeighborhoodAreaMap() : this("cdk")
        {
        }

        public NeighborhoodAreaMap(string schema)
        {
            ToTable(schema + ".NeighborhoodArea");

            this.AddBase();
            this.AddSeo();

            Property(x => x.MetroAreaId).HasColumnName("MetroAreaId").IsOptional().HasColumnType("bigint");
            Property(x => x.NeighborhoodAreaExtId).HasColumnName("NeighborhoodAreaExtId").IsOptional().HasColumnType("bigint");
            Property(x => x.NeighborhoodAreaExtVersion).HasColumnName("NeighborhoodAreaExtVersion").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ParentId).HasColumnName("ParentId").IsOptional().HasColumnType("bigint");
            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName("ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Description).HasColumnName("Description").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.CenterPointGeo).HasColumnName("CenterPointGeo").IsOptional().HasColumnType("geography");
            Property(x => x.CenterPointLat).HasColumnName("CenterPointLat").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CenterPointLon).HasColumnName("CenterPointLon").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CoordinatesGeo).HasColumnName("CoordinatesGeo").IsOptional().HasColumnType("geography");
            Property(x => x.CoordinatesAsText).HasColumnName("CoordinatesAsText").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.NeighborhoodAreaUri).HasColumnName("NeighborhoodAreaUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LType).HasColumnName("LType").IsOptional().HasColumnType("int");
            Property(x => x.HasChild).HasColumnName("HasChild").IsRequired().HasColumnType("bit");
            Property(x => x.NType).HasColumnName("NType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            // Foreign keys
            HasOptional(a => a.MetroArea).WithMany(b => b.NeighborhoodAreas).HasForeignKey(c => c.MetroAreaId); // NeighborhoodArea_MetroArea
        }
    }
}
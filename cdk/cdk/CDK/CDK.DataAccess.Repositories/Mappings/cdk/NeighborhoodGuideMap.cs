using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // NeighborhoodGuide

    public class NeighborhoodGuideMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NeighborhoodGuide>
    {
        public NeighborhoodGuideMap()
            : this("cdk")
        {
        }

        public NeighborhoodGuideMap(string schema)
        {
            ToTable(schema + ".NeighborhoodGuide");

            this.AddBase();
            this.AddSeo();

            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NeighborhoodAreaId).HasColumnName("NeighborhoodAreaId").IsOptional().HasColumnType("bigint");
            Property(x => x.TagLine).HasColumnName("TagLine").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.WhatToExpect).HasColumnName("WhatToExpect").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.Demographics).HasColumnName("Demographics").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.Lifestyle).HasColumnName("Lifestyle").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.WhatYoullLove).HasColumnName("WhatYoullLove").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.Source).HasColumnName("Source").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");

            // Foreign keys
            HasOptional(a => a.NeighborhoodArea).WithMany(b => b.NeighborhoodGuides).HasForeignKey(c => c.NeighborhoodAreaId); // FK__Neighborh__Neigh__30592A6F
        }
    }
}
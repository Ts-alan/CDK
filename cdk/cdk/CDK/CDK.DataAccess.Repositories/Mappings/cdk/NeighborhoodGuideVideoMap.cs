using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // NeighborhoodGuideVideo

    public class NeighborhoodGuideVideoMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NeighborhoodGuideVideo>
    {
        public NeighborhoodGuideVideoMap()
            : this("cdk")
        {
        }

        public NeighborhoodGuideVideoMap(string schema)
        {
            ToTable(schema + ".NeighborhoodGuideVideo");

            Property(x => x.NeighborhoodGuideId).HasColumnName("NeighborhoodGuideId").IsRequired().HasColumnType("bigint");

            this.AddBase();
            this.AddVideo();
            this.AddSequense();
            this.AddSeo();

            // Foreign keys
            HasRequired(a => a.NeighborhoodGuide).WithMany(b => b.NeighborhoodGuideVideos).HasForeignKey(c => c.NeighborhoodGuideId); // FK__Neighborh__Neigh__324172E1
        }
    }
}
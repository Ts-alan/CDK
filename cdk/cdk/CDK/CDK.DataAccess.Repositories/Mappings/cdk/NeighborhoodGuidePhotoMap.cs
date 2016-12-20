using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // NeighborhoodGuidePhoto

    public class NeighborhoodGuidePhotoMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NeighborhoodGuidePhoto>
    {
        public NeighborhoodGuidePhotoMap()
            : this("cdk")
        {
        }

        public NeighborhoodGuidePhotoMap(string schema)
        {
            ToTable(schema + ".NeighborhoodGuidePhoto");

            this.AddBase();
            this.AddPhoto();
            this.AddSequense();
            this.AddSeo();

            Property(x => x.NeighborhoodGuideId).HasColumnName("NeighborhoodGuideId").IsRequired().HasColumnType("bigint");

            // Foreign keys
            HasRequired(a => a.NeighborhoodGuide).WithMany(b => b.NeighborhoodGuidePhotos).HasForeignKey(c => c.NeighborhoodGuideId); // FK__Neighborh__Neigh__314D4EA8
        }
    }
}
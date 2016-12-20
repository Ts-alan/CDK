using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // DevelopmentPhoto

    public class DevelopmentPhotoMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DevelopmentPhoto>
    {
        public DevelopmentPhotoMap()
            : this("cdk")
        {
        }

        public DevelopmentPhotoMap(string schema)
        {
            ToTable(schema + ".DevelopmentPhoto");

            this.AddBase();
            this.AddPhoto();
            this.AddSequense();
            this.AddSeo();

            Property(x => x.DevelopmentId).HasColumnName("DevelopmentId").IsRequired().HasColumnType("bigint");

            // Foreign keys
            HasRequired(a => a.Development).WithMany(b => b.DevelopmentPhotos).HasForeignKey(c => c.DevelopmentId); // FK__Developme__Devel__2D7CBDC4
        }
    }
}
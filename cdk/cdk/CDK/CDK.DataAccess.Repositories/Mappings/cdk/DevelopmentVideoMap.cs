using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // DevelopmentVideo

    public class DevelopmentVideoMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DevelopmentVideo>
    {
        public DevelopmentVideoMap()
            : this("cdk")
        {
        }

        public DevelopmentVideoMap(string schema)
        {
            ToTable(schema + ".DevelopmentVideo");

            this.AddBase();
            this.AddVideo();
            this.AddSequense();
            this.AddSeo();

            Property(x => x.DevelopmentId).HasColumnName("DevelopmentId").IsRequired().HasColumnType("bigint");

            // Foreign keys
            HasRequired(a => a.Development).WithMany(b => b.DevelopmentVideos).HasForeignKey(c => c.DevelopmentId); // FK__Developme__Devel__2E70E1FD
        }
    }
}
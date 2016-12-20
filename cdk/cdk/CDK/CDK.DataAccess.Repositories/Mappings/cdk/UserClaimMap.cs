using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    public class UserClaimMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserClaim>
    {
        public UserClaimMap()
            : this("cdk")
        {
        }

        public UserClaimMap(string schema)
        {
            ToTable(schema + ".UserClaims");

            this.AddBase();

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("bigint");
            Property(x => x.ClaimType).HasColumnName("ClaimType").IsOptional().HasColumnType("nvarchar");
            Property(x => x.ClaimValue).HasColumnName("ClaimValue").IsOptional().HasColumnType("nvarchar");

            // Foreign keys
            HasRequired(a => a.User).WithMany(b => b.UserClaims).HasForeignKey(c => c.UserId);
        }
    }
}
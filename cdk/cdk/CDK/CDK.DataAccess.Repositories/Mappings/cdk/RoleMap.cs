using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    public class RoleMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Role>
    {
        public RoleMap()
            : this("cdk")
        {
        }

        public RoleMap(string schema)
        {
            ToTable(schema + ".Roles");

            this.AddBase();

            Property(x => x.Name).HasColumnName("Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            HasMany(t => t.Users).WithMany(t => t.Roles).Map(m =>
            {
                m.ToTable("UserRoles", "cdk");
                m.MapLeftKey("RoleId");
                m.MapRightKey("UserId");
            });
        }
    }
}
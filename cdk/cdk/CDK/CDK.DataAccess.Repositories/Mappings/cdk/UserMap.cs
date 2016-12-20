using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    public class UserMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserMap()
            : this("cdk")
        {
        }

        public UserMap(string schema)
        {
            ToTable(schema + ".Users");

            this.AddBase();

            Property(x => x.Email).HasColumnName("Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.EmailConfirmed).HasColumnName("EmailConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsOptional().HasColumnType("nvarchar");
            Property(x => x.SecurityStamp).HasColumnName("SecurityStamp").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsOptional().HasColumnType("nvarchar");
            Property(x => x.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").IsRequired().HasColumnType("bit");
            Property(x => x.TwoFactorEnabled).HasColumnName("TwoFactorEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc").IsOptional().HasColumnType("datetime");
            Property(x => x.LockoutEnabled).HasColumnName("LockoutEnabled").IsRequired().HasColumnType("bit");
            Property(x => x.AccessFailedCount).HasColumnName("AccessFailedCount").IsRequired().HasColumnType("int");
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);

            Property(x => x.FirstName).HasColumnName("FirstName").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);

            Property(x => x.LastName).HasColumnName("LastName").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
        }
    }
}
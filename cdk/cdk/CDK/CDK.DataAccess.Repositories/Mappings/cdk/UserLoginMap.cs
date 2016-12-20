using CDK.DataAccess.Models.cdk;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    public class UserLoginMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
            : this("cdk")
        {
        }

        public UserLoginMap(string schema)
        {
            ToTable(schema + ".UserLogins");

            HasKey(x => new
            {
                x.LoginProvider,
                x.ProviderKey,
                x.UserId
            });

            Property(x => x.LoginProvider).HasColumnName("LoginProvider").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProviderKey).HasColumnName("ProviderKey").IsRequired().HasColumnType("nvarchar").HasMaxLength(128).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.User).WithMany(b => b.UserLogins).HasForeignKey(c => c.UserId);
        }
    }
}
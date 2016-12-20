using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // Developer

    public class DeveloperMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Developer>
    {
        public DeveloperMap()
            : this("cdk")
        {
        }

        public DeveloperMap(string schema)
        {
            ToTable(schema + ".Developer");

            this.AddBase();
            this.AddSeo();

            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PrimaryContactName).HasColumnName("PrimaryContactName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PrimaryContactEmail).HasColumnName("PrimaryContactEmail").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SecondaryContactName).HasColumnName("SecondaryContactName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SecondaryContactEmail).HasColumnName("SecondaryContactEmail").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            Property(x => x.DeveloperAddress).HasColumnName("DeveloperAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            Property(x => x.Description).HasColumnName("Description").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.ShortDescription).HasColumnName("ShortDescription").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.LogoUri).HasColumnName("LogoUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
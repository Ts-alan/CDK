using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // Development

    public class DevelopmentMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Development>
    {
        public DevelopmentMap()
            : this("cdk")
        {
        }

        public DevelopmentMap(string schema)
        {
            ToTable(schema + ".Development");

            this.AddBase();
            this.AddSeo();

            Property(x => x.DeveloperId).HasColumnName("DeveloperId").IsRequired().HasColumnType("bigint");

            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PrimaryContactName).HasColumnName("PrimaryContactName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PrimaryContactEmail).HasColumnName("PrimaryContactEmail").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PrimaryContactPhone).HasColumnName("PrimaryContactPhone").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SecondaryContactName).HasColumnName("SecondaryContactName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SecondaryContactEmail).HasColumnName("SecondaryContactEmail").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SecondaryContactPhone).HasColumnName("SecondaryContactPhone").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ProjectWebsiteUrl).HasColumnName("ProjectWebsiteUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ProjectFacebookUrl).HasColumnName("ProjectFacebookUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ProjectTwiterUrl).HasColumnName("ProjectTwiterUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ProjectGooglePlusUrl).HasColumnName("ProjectGooglePlusUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SalesCenterPhoneNumber).HasColumnName("SalesCenterPhoneNumber").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SalesCenterAddress).HasColumnName("SalesCenterAddress").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SalesCenterPhone).HasColumnName("SalesCenterPhone").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SalesCenterOpenHours).HasColumnName("SalesCenterOpenHours").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.ConstructuedYear).HasColumnName("ConstructuedYear").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(4);
            Property(x => x.ForSale).HasColumnName("ForSale").IsOptional().HasColumnType("bit");
            Property(x => x.ForRent).HasColumnName("ForRent").IsOptional().HasColumnType("bit");
            Property(x => x.BuildingType).HasColumnName("BuildingType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Community).HasColumnName("Community").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PriceAveragePerSqrFeet).HasColumnName("PriceAveragePerSqrFeet").IsOptional().HasColumnType("decimal").HasPrecision(10, 2);
            Property(x => x.TotalNumberOfUnits).HasColumnName("TotalNumberOfUnits").IsOptional().HasColumnType("int");
            Property(x => x.TotalNumberOfStories).HasColumnName("TotalNumberOfStories").IsOptional().HasColumnType("int");
            Property(x => x.SalesCompany).HasColumnName("SalesCompany").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MarketingCompany).HasColumnName("MarketingCompany").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Architects).HasColumnName("Architects").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.InteriorDesigner).HasColumnName("InteriorDesigner").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ProjectSummary).HasColumnName("ProjectSummary").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.ShortProjectSummary).HasColumnName("ShortProjectSummary").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.ProjectAmenities).HasColumnName("ProjectAmenities").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CurrentIncentives).HasColumnName("CurrentIncentives").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LogoUri).HasColumnName("LogoUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            // Foreign keys
            HasRequired(a => a.Developer).WithMany(b => b.Developments).HasForeignKey(c => c.DeveloperId);
            HasRequired(a => a.DevelopmentAddress).WithRequiredPrincipal(x => x.Development).WillCascadeOnDelete(true);
        }
    }
}
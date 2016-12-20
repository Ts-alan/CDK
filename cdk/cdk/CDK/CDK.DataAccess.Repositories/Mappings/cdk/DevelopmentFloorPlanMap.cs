using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    // DevelopmentFloorPlan

    public class DevelopmentFloorPlanMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DevelopmentFloorPlan>
    {
        public DevelopmentFloorPlanMap()
            : this("cdk")
        {
        }

        public DevelopmentFloorPlanMap(string schema)
        {
            ToTable(schema + ".DevelopmentFloorPlan");

            this.AddBase();
            this.AddPhoto();
            this.AddSequense();
            this.AddSeo();

            Property(x => x.DevelopmentId).HasColumnName("DevelopmentId").IsRequired().HasColumnType("bigint");
            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Type).HasColumnName("Type").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Beds).HasColumnName("Beds").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Baths).HasColumnName("Baths").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PropertyTaxe).HasColumnName("PropertyTaxe").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.InteriorSize).HasColumnName("InteriorSize").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OwnershipType).HasColumnName("OwnershipType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CondoMonthlyFees).HasColumnName("CondoMonthlyFees").IsOptional().HasColumnType("decimal").HasPrecision(10, 2);
            Property(x => x.BalconeySize).HasColumnName("BalconeySize").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            Property(x => x.PropertyTaxePeriod).HasColumnName("PropertyTaxePeriod").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CondoFeesPeriod).HasColumnName("CondoFeesPeriod").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.InteriorSizeType).HasColumnName("InteriorSizeType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.BalconeySizeType).HasColumnName("BalconeySizeType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            // Foreign keys
            HasRequired(a => a.Development).WithMany(b => b.DevelopmentFloorPlans).HasForeignKey(c => c.DevelopmentId); // FK__Developme__Devel__2C88998B
        }
    }
}
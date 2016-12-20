using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Repositories.Extensions;

namespace CDK.DataAccess.Repositories.Mappings.cdk
{
    public class DevelopmentAmenitiesMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DevelopmentAmenities>
    {
        public DevelopmentAmenitiesMap()
            : this("cdk")
        {
        }

        public DevelopmentAmenitiesMap(string schema)
        {
            ToTable(schema + ".DevelopmentAmenities");

            this.AddBase();

            Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            Property(x => x.Description).HasColumnName("Description").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            Property(x => x.IconUri).HasColumnName("IconUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasMany(x => x.Developments).WithMany(y => y.DevelopmentAmenities).Map(x =>
            {
                x.MapLeftKey("DevelopmentAmenities_Id");
                x.MapRightKey("Development_Id");
                x.ToTable("DevelopmentAmenitiesDevelopments", "cdk");
            });
        }
    }
}
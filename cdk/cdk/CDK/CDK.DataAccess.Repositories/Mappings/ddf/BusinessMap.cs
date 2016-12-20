namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class BusinessMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Business>
    {
        public BusinessMap()
            : this("ddf")
        {
        }

        public BusinessMap(string schema)
        {
            ToTable(schema + ".Business");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UnitId).HasColumnName(@"UnitId").IsOptional().HasColumnType("bigint");
            Property(x => x.BusinessType).HasColumnName(@"BusinessType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.BusinessSubType).HasColumnName(@"BusinessSubType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstablishedDate).HasColumnName(@"EstablishedDate").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Franchise).HasColumnName(@"Franchise").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperatingSince).HasColumnName(@"OperatingSince").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasOptional(a => a.Unit).WithMany(b => b.Businesses).HasForeignKey(c => c.UnitId);
        }
    }
}
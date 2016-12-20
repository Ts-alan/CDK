namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class BusinessSubTypeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BusinessSubType>
    {
        public BusinessSubTypeMap()
            : this("ddf")
        {
        }

        public BusinessSubTypeMap(string schema)
        {
            ToTable(schema + ".BusinessSubType");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.Units).WithMany(t => t.BusinessSubTypes).Map(m =>
            {
                m.ToTable("BusinessBusinessSubType", "ddf");
                m.MapLeftKey("BusinessSubTypeId");
                m.MapRightKey("UnitId");
            });
        }
    }
}
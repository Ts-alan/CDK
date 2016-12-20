namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class StorageTypeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<StorageType>
    {
        public StorageTypeMap()
            : this("ddf")
        {
        }

        public StorageTypeMap(string schema)
        {
            ToTable(schema + ".StorageType");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.Units).WithMany(t => t.StorageTypes).Map(m =>
            {
                m.ToTable("UnitStorageType", "ddf");
                m.MapLeftKey("StorageTypeId");
                m.MapRightKey("UnitId");
            });
        }
    }
}
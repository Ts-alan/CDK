namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class RentalEquipmentTypeMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RentalEquipmentType>
    {
        public RentalEquipmentTypeMap()
            : this("ddf")
        {
        }

        public RentalEquipmentTypeMap(string schema)
        {
            ToTable(schema + ".RentalEquipmentType");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.Units).WithMany(t => t.RentalEquipmentTypes).Map(m =>
            {
                m.ToTable("UnitRentalEquipmentType", "ddf");
                m.MapLeftKey("RentalEquipmentTypeId");
                m.MapRightKey("UnitId");
            });
        }
    }
}
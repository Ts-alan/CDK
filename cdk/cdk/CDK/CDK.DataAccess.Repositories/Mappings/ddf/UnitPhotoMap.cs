namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;
    using CDK.DataAccess.Repositories.Extensions;

    public class UnitPhotoMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitPhoto>
    {
        public UnitPhotoMap()
            : this("ddf")
        {
        }

        public UnitPhotoMap(string schema)
        {
            ToTable(schema + ".UnitPhoto");

            Property(x => x.UnitId).HasColumnName(@"UnitId").IsRequired().HasColumnType("bigint");
            Property(x => x.DdfSequenceId).HasColumnName(@"DdfSequenceId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DdfPropertyId).HasColumnName(@"DdfPropertyId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            this.AddBase();
            this.AddSeo();
            this.AddPhoto();
            this.AddExternal();

            HasRequired(a => a.Unit).WithMany(b => b.UnitPhotos).HasForeignKey(c => c.UnitId);
        }
    }
}
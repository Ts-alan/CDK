namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitRoomMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitRoom>
    {
        public UnitRoomMap()
            : this("ddf")
        {
        }

        public UnitRoomMap(string schema)
        {
            ToTable(schema + ".UnitRoom");
            HasKey(x => x.UnitRoomId);

            Property(x => x.UnitRoomId).HasColumnName(@"UnitRoomId").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitId).HasColumnName(@"UnitId").IsRequired().HasColumnType("bigint");
            Property(x => x.TypeId).HasColumnName(@"TypeId").IsOptional().HasColumnType("bigint");
            Property(x => x.Width).HasColumnName(@"Width").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Length).HasColumnName(@"Length").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LevelId).HasColumnName(@"LevelId").IsOptional().HasColumnType("bigint");
            Property(x => x.Dimension).HasColumnName(@"Dimension").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Description).HasColumnName(@"Description").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LastUpdate).HasColumnName(@"LastUpdate").IsRequired().HasColumnType("datetime");

            HasOptional(a => a.RoomLevel).WithMany(b => b.UnitRooms).HasForeignKey(c => c.LevelId);
            HasOptional(a => a.RoomType).WithMany(b => b.UnitRooms).HasForeignKey(c => c.TypeId);
            HasRequired(a => a.Unit).WithMany(b => b.UnitRooms).HasForeignKey(c => c.UnitId);
        }
    }
}
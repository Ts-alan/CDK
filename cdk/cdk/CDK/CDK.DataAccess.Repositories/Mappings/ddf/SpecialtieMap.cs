namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class SpecialtieMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Specialtie>
    {
        public SpecialtieMap()
            : this("ddf")
        {
        }

        public SpecialtieMap(string schema)
        {
            ToTable(schema + ".Specialtie");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName(@"Value").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ShortName).HasColumnName(@"ShortName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AlternateName).HasColumnName(@"AlternateName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImgUrl).HasColumnName(@"ImgUrl").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            HasMany(t => t.UnitAgents).WithMany(t => t.Specialties).Map(m =>
            {
                m.ToTable("AgentSpecialty", "ddf");
                m.MapLeftKey("SpecialtyId");
                m.MapRightKey("UnitAgentId");
            });
        }
    }
}
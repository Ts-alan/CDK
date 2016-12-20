namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentSpecialityMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentSpeciality>
    {
        public UnitAgentSpecialityMap()
            : this("ddf")
        {
        }

        public UnitAgentSpecialityMap(string schema)
        {
            ToTable(schema + ".UnitAgentSpeciality");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsRequired().HasColumnType("bigint");
            Property(x => x.Specialtie).HasColumnName(@"Specialtie").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgent).WithMany(b => b.UnitAgentSpecialities).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
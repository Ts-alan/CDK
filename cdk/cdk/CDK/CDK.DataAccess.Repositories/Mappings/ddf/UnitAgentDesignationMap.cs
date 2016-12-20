namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentDesignationMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentDesignation>
    {
        public UnitAgentDesignationMap()
            : this("ddf")
        {
        }

        public UnitAgentDesignationMap(string schema)
        {
            ToTable(schema + ".UnitAgentDesignation");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsRequired().HasColumnType("bigint");
            Property(x => x.Designation).HasColumnName(@"Designation").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgent).WithMany(b => b.UnitAgentDesignations).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
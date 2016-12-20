namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class AuditDdfRequestMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AuditDdfRequest>
    {
        public AuditDdfRequestMap()
            : this("ddf")
        {
        }

        public AuditDdfRequestMap(string schema)
        {
            ToTable(schema + ".AuditDdfRequest");
            HasKey(x => x.RequestId);

            Property(x => x.RequestId).HasColumnName(@"RequestId").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName(@"Status").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Xml).HasColumnName(@"Xml").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.DdfLastUpdate).HasColumnName(@"DdfLastUpdate").IsOptional().HasColumnType("datetime");
        }
    }
}
namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;

    public class UnitAgentTradingAreaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UnitAgentTradingArea>
    {
        public UnitAgentTradingAreaMap()
            : this("ddf")
        {
        }

        public UnitAgentTradingAreaMap(string schema)
        {
            ToTable(schema + ".UnitAgentTradingArea");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UnitAgentId).HasColumnName(@"UnitAgentId").IsRequired().HasColumnType("bigint");
            Property(x => x.TradingArea).HasColumnName(@"TradingArea").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            HasRequired(a => a.UnitAgent).WithMany(b => b.UnitAgentTradingAreas).HasForeignKey(c => c.UnitAgentId);
        }
    }
}
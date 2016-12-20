namespace CDK.DataAccess.Repositories.Mappings
{
    using CDK.DataAccess.Models.ddf;
    using CDK.DataAccess.Repositories.Extensions;

    public class UnitMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Unit>
    {
        public UnitMap()
            : this("ddf")
        {
        }

        public UnitMap(string schema)
        {
            ToTable(schema + ".Unit");

            Property(x => x.BuildingId).HasColumnName(@"BuildingId").IsRequired().HasColumnType("bigint");
            Property(x => x.DdfUnitId).HasColumnName(@"DdfUnitId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.HalfBathTotal).HasColumnName(@"HalfBathTotal").IsOptional().HasColumnType("int");
            Property(x => x.BathroomTotal).HasColumnName(@"BathroomTotal").IsOptional().HasColumnType("int");
            Property(x => x.BedroomsAboveGround).HasColumnName(@"BedroomsAboveGround").IsOptional().HasColumnType("int");
            Property(x => x.BedroomsBelowGround).HasColumnName(@"BedroomsBelowGround").IsOptional().HasColumnType("int");
            Property(x => x.BedroomsTotal).HasColumnName(@"BedroomsTotal").IsOptional().HasColumnType("int");
            Property(x => x.CeilingHeight).HasColumnName(@"CeilingHeight").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeInterior).HasColumnName(@"SizeInterior").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SizeInteriorFinished).HasColumnName(@"SizeInteriorFinished").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TotalFinishedArea).HasColumnName(@"TotalFinishedArea").IsOptional().HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Lease).HasColumnName(@"Lease").IsOptional().HasColumnType("decimal");
            Property(x => x.LeasePerTime).HasColumnName(@"LeasePerTime").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LeasePerUnit).HasColumnName(@"LeasePerUnit").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LeaseTermRemaining).HasColumnName(@"LeaseTermRemaining").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LeaseTermRemainingFreq).HasColumnName(@"LeaseTermRemainingFreq").IsOptional().HasColumnType("int");
            Property(x => x.MaintenanceFee).HasColumnName(@"MaintenanceFee").IsOptional().HasColumnType("decimal");
            Property(x => x.MaintenanceFeePaymentUnit).HasColumnName(@"MaintenanceFeePaymentUnit").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ParkingSpaceTotal).HasColumnName(@"ParkingSpaceTotal").IsOptional().HasColumnType("int");
            Property(x => x.Plan).HasColumnName(@"Plan").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Price).HasColumnName(@"Price").IsOptional().HasColumnType("decimal");
            Property(x => x.PricePerTime).HasColumnName(@"PricePerTime").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PricePerUnit).HasColumnName(@"PricePerUnit").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PropertyType).HasColumnName(@"PropertyType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.PublicRemarks).HasColumnName(@"PublicRemarks").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.AdditionalInformationIndicator).HasColumnName(@"AdditionalInformationIndicator").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MoreInformationLink).HasColumnName(@"MoreInformationLink").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ListingId).HasColumnName(@"ListingId").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UnitUri).HasColumnName(@"UnitUri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OwnershipType).HasColumnName(@"OwnershipType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TransactionType).HasColumnName(@"TransactionType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RemovedDate).HasColumnName(@"RemovedDate").IsOptional().HasColumnType("datetime2");

            this.AddSeo();
            this.AddExternal();
            this.AddBase();

            HasRequired(a => a.Building).WithMany(b => b.Units).HasForeignKey(c => c.BuildingId);
            HasMany(t => t.ViewTypes).WithMany(t => t.Units).Map(m =>
            {
                m.ToTable("UnitViewType", "ddf");
                m.MapLeftKey("UnitId");
                m.MapRightKey("ViewTypeId");
            });
        }
    }
}
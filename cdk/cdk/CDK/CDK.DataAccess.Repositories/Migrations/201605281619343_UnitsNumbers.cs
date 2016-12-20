namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsNumbers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("ddf.Unit", "HalfBathTotal", c => c.Int());
            AlterColumn("ddf.Unit", "BathroomTotal", c => c.Int());
            AlterColumn("ddf.Unit", "BedroomsAboveGround", c => c.Int());
            AlterColumn("ddf.Unit", "BedroomsBelowGround", c => c.Int());
            AlterColumn("ddf.Unit", "BedroomsTotal", c => c.Int());
            AlterColumn("ddf.Unit", "TotalFinishedArea", c => c.Int());
            AlterColumn("ddf.Unit", "Lease", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("ddf.Unit", "LeaseTermRemainingFreq", c => c.Int());
            AlterColumn("ddf.Unit", "MaintenanceFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("ddf.Unit", "ParkingSpaceTotal", c => c.Int());
            AlterColumn("ddf.Unit", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("ddf.Unit", "Price", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "ParkingSpaceTotal", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "MaintenanceFee", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "LeaseTermRemainingFreq", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "Lease", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "TotalFinishedArea", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "BedroomsTotal", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "BedroomsBelowGround", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "BedroomsAboveGround", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "BathroomTotal", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("ddf.Unit", "HalfBathTotal", c => c.String(maxLength: 255, unicode: false));
        }
    }
}

namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitRemovedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("ddf.Unit", "RemovedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("ddf.Unit", "RemovedDate");
        }
    }
}

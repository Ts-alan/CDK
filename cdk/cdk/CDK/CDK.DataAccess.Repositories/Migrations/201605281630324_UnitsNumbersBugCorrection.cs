namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsNumbersBugCorrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("ddf.Unit", "TotalFinishedArea", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("ddf.Unit", "TotalFinishedArea", c => c.Int());
        }
    }
}

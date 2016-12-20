namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetroAreaCoordinate : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.MetroArea", "MetroCoordinatesAsText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("cdk.MetroArea", "MetroCoordinatesAsText");
        }
    }
}

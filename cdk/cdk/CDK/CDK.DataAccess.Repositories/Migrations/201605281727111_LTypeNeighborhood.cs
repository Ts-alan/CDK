namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LTypeNeighborhood : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.NeighborhoodArea", "LType", c => c.Int());
            AlterColumn("cdk.MetroArea", "MetroCoordinatesAsText", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("cdk.MetroArea", "MetroCoordinatesAsText", c => c.String());
            DropColumn("cdk.NeighborhoodArea", "LType");
        }
    }
}

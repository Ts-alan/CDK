namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetroNeighborhoodTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.NeighborhoodArea", "NType", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.MetroArea", "MType", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("cdk.MetroArea", "MType");
            DropColumn("cdk.NeighborhoodArea", "NType");
        }
    }
}

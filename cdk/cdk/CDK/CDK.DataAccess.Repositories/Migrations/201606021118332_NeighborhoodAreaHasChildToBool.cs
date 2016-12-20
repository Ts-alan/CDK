namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeighborhoodAreaHasChildToBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("cdk.NeighborhoodArea", "HasChild", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("cdk.NeighborhoodArea", "HasChild", c => c.Int());
        }
    }
}

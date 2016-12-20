namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HasChildNeighborhood : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.NeighborhoodArea", "HasChild", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("cdk.NeighborhoodArea", "HasChild");
        }
    }
}

namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeighborhoodAreaRemovingBuildingAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("ddf.BuildingAddress", "NeighborhoodArea_Id", "cdk.NeighborhoodArea");
            DropIndex("ddf.BuildingAddress", new[] { "NeighborhoodArea_Id" });
            DropColumn("ddf.BuildingAddress", "NeighborhoodArea_Id");
        }
        
        public override void Down()
        {
            AddColumn("ddf.BuildingAddress", "NeighborhoodArea_Id", c => c.Long());
            CreateIndex("ddf.BuildingAddress", "NeighborhoodArea_Id");
            AddForeignKey("ddf.BuildingAddress", "NeighborhoodArea_Id", "cdk.NeighborhoodArea", "Id");
        }
    }
}

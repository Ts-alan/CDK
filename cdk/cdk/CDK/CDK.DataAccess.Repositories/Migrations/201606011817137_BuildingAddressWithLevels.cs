namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildingAddressWithLevels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "ddf.BuildingAddress", name: "NeighborhoodAreaId", newName: "NeighborhoodArea_Id");
            RenameIndex(table: "ddf.BuildingAddress", name: "IX_NeighborhoodAreaId", newName: "IX_NeighborhoodArea_Id");
            AddColumn("ddf.BuildingAddress", "MetroAreaId", c => c.Long());
            AddColumn("ddf.BuildingAddress", "NeighborhoodAreaFirstLevelId", c => c.Long());
            AddColumn("ddf.BuildingAddress", "NeighborhoodAreaSecondLevelId", c => c.Long());
            AddColumn("ddf.BuildingAddress", "NeighborhoodAreaThirdLevelId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("ddf.BuildingAddress", "NeighborhoodAreaThirdLevelId");
            DropColumn("ddf.BuildingAddress", "NeighborhoodAreaSecondLevelId");
            DropColumn("ddf.BuildingAddress", "NeighborhoodAreaFirstLevelId");
            DropColumn("ddf.BuildingAddress", "MetroAreaId");
            RenameIndex(table: "ddf.BuildingAddress", name: "IX_NeighborhoodArea_Id", newName: "IX_NeighborhoodAreaId");
            RenameColumn(table: "ddf.BuildingAddress", name: "NeighborhoodArea_Id", newName: "NeighborhoodAreaId");
        }
    }
}

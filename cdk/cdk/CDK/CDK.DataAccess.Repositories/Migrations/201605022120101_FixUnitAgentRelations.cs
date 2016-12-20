namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUnitAgentRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("ddf.UnitAgentOffice", "UnitAgentId", "ddf.UnitAgent");
            DropIndex("ddf.UnitAgentOffice", new[] { "UnitAgentId" });
            CreateIndex("ddf.UnitAgent", "UnitAgentOfficeId");
            AddForeignKey("ddf.UnitAgent", "UnitAgentOfficeId", "ddf.UnitAgentOffice", "Id");
            DropColumn("ddf.UnitAgentOffice", "UnitAgentId");
        }
        
        public override void Down()
        {
            AddColumn("ddf.UnitAgentOffice", "UnitAgentId", c => c.Long());
            DropForeignKey("ddf.UnitAgent", "UnitAgentOfficeId", "ddf.UnitAgentOffice");
            DropIndex("ddf.UnitAgent", new[] { "UnitAgentOfficeId" });
            CreateIndex("ddf.UnitAgentOffice", "UnitAgentId");
            AddForeignKey("ddf.UnitAgentOffice", "UnitAgentId", "ddf.UnitAgent", "Id");
        }
    }
}

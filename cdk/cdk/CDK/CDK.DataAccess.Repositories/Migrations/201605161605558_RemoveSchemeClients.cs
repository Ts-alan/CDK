namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSchemeClients : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "client.UserRoles", newSchema: "cdk");
        }
        
        public override void Down()
        {
            MoveTable(name: "cdk.UserRoles", newSchema: "client");
        }
    }
}

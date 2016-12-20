namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.Users", "LastName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("cdk.Users", "FirstName", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("cdk.Users", "FirstName");
            DropColumn("cdk.Users", "LastName");
        }
    }
}

namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelFixFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("cdk.Users", "LastName", c => c.String(maxLength: 256));
            AlterColumn("cdk.Users", "FirstName", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("cdk.Users", "FirstName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("cdk.Users", "LastName", c => c.String(nullable: false, maxLength: 256));
        }
    }
}

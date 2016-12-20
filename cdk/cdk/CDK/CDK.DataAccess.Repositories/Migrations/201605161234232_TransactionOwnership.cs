namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionOwnership : DbMigration
    {
        public override void Up()
        {
            AddColumn("ddf.Unit", "OwnershipType", c => c.String(maxLength: 255, unicode: false));
            AddColumn("ddf.Unit", "TransactionType", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("ddf.Unit", "TransactionType");
            DropColumn("ddf.Unit", "OwnershipType");
        }
    }
}

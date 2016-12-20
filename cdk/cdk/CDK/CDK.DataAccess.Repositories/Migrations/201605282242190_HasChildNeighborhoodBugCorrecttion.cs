namespace CDK.DataAccess.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HasChildNeighborhoodBugCorrecttion : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "cdk.NeighborhoodArea", name: "HasChild", newName: "__mig_tmp__0");
            RenameColumn(table: "cdk.NeighborhoodArea", name: "LType", newName: "HasChild");
            RenameColumn(table: "cdk.NeighborhoodArea", name: "__mig_tmp__0", newName: "LType");
        }
        
        public override void Down()
        {
            RenameColumn(table: "cdk.NeighborhoodArea", name: "LType", newName: "__mig_tmp__0");
            RenameColumn(table: "cdk.NeighborhoodArea", name: "HasChild", newName: "LType");
            RenameColumn(table: "cdk.NeighborhoodArea", name: "__mig_tmp__0", newName: "HasChild");
        }
    }
}

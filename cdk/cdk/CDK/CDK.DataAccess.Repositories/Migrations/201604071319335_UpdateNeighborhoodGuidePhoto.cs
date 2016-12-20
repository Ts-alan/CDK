namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateNeighborhoodGuidePhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.NeighborhoodGuidePhoto", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("cdk.NeighborhoodGuidePhoto", "CreatedBy", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "LastUpdateBy", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.NeighborhoodGuidePhoto", "LastUpdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }

        public override void Down()
        {
            AlterColumn("cdk.NeighborhoodGuidePhoto", "LastUpdate", c => c.DateTime(nullable: false));
            DropColumn("cdk.NeighborhoodGuidePhoto", "LastUpdateBy");
            DropColumn("cdk.NeighborhoodGuidePhoto", "CreatedBy");
            DropColumn("cdk.NeighborhoodGuidePhoto", "Created");
        }
    }
}
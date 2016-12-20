namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateNeighborhoodGuideFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.NeighborhoodGuide", "Name", c => c.String(maxLength: 255, unicode: false));
        }

        public override void Down()
        {
            DropColumn("cdk.NeighborhoodGuide", "Name");
        }
    }
}
namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateDevAmenities : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.DevelopmentAmenitiesDevelopments", newSchema: "cdk");
        }

        public override void Down()
        {
            MoveTable(name: "cdk.DevelopmentAmenitiesDevelopments", newSchema: "dbo");
        }
    }
}
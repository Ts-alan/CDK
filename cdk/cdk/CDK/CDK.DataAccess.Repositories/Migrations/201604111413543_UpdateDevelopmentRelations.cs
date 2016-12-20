namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateDevelopmentRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevelopmentAmenitiesDevelopments",
                c => new
                {
                    DevelopmentAmenities_Id = c.Long(nullable: false),
                    Development_Id = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.DevelopmentAmenities_Id,
                    t.Development_Id
                })
                .ForeignKey("cdk.DevelopmentAmenities", t => t.DevelopmentAmenities_Id, cascadeDelete: true)
                .ForeignKey("cdk.Development", t => t.Development_Id, cascadeDelete: true)
                .Index(t => t.DevelopmentAmenities_Id)
                .Index(t => t.Development_Id);

            AddColumn("cdk.DevelopmentFloorPlan", "PhotoSmallUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "PhotoLargeUri", c => c.String(maxLength: 255, unicode: false));
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoUri");
        }

        public override void Down()
        {
            AddColumn("cdk.DevelopmentFloorPlan", "PhotoUri", c => c.String(maxLength: 255, unicode: false));
            DropForeignKey("dbo.DevelopmentAmenitiesDevelopments", "Development_Id", "cdk.Development");
            DropForeignKey("dbo.DevelopmentAmenitiesDevelopments", "DevelopmentAmenities_Id", "cdk.DevelopmentAmenities");
            DropIndex("dbo.DevelopmentAmenitiesDevelopments", new[] { "Development_Id" });
            DropIndex("dbo.DevelopmentAmenitiesDevelopments", new[] { "DevelopmentAmenities_Id" });
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoLargeUri");
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoSmallUri");
            DropTable("dbo.DevelopmentAmenitiesDevelopments");
        }
    }
}
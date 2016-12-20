namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AdjustPhotoModelFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.DevelopmentFloorPlan", "LargeUri", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "SmallUri", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "PhotoAlt", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "LargeUri", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "SmallUri", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "PhotoAlt", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "LargeUri", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "SmallUri", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "PhotoAlt", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.DevelopmentFloorPlan", "ThumbnailUri", c => c.String(unicode: false));
            AlterColumn("cdk.DevelopmentPhoto", "ThumbnailUri", c => c.String(unicode: false));
            AlterColumn("cdk.NeighborhoodGuidePhoto", "ThumbnailUri", c => c.String(unicode: false));
            DropColumn("cdk.DevelopmentFloorPlan", "OriginalUri");
            DropColumn("cdk.DevelopmentPhoto", "OriginalUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "OriginalUri");
        }

        public override void Down()
        {
            AddColumn("cdk.NeighborhoodGuidePhoto", "OriginalUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "OriginalUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "OriginalUri", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.NeighborhoodGuidePhoto", "ThumbnailUri", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.DevelopmentPhoto", "ThumbnailUri", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.DevelopmentFloorPlan", "ThumbnailUri", c => c.String(maxLength: 255, unicode: false));
            DropColumn("cdk.NeighborhoodGuidePhoto", "PhotoAlt");
            DropColumn("cdk.NeighborhoodGuidePhoto", "SmallUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "LargeUri");
            DropColumn("cdk.DevelopmentPhoto", "PhotoAlt");
            DropColumn("cdk.DevelopmentPhoto", "SmallUri");
            DropColumn("cdk.DevelopmentPhoto", "LargeUri");
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoAlt");
            DropColumn("cdk.DevelopmentFloorPlan", "SmallUri");
            DropColumn("cdk.DevelopmentFloorPlan", "LargeUri");
        }
    }
}
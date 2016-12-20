namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSeoDataFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.NeighborhoodArea", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodArea", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodArea", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodArea", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.Development", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.Development", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.Development", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.Development", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.Developer", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.Developer", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.Developer", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.Developer", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "ThumbnailUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "OriginalUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "PhotoDescription", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "ThumbnailUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "OriginalUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "PhotoDescription", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentVideo", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.DevelopmentVideo", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.MetroArea", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.MetroArea", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.MetroArea", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.MetroArea", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuide", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuide", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuide", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuide", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "PhotoDescription", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "ThumbnailUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "OriginalUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "PhotoName", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "PhotoType", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "SeoSlug", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "SeoCaption", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "SeoDescription", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "SeoKeywords", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "SeoSlug", c => c.String(unicode: false));
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoSmallUri");
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoLargeUri");
            DropColumn("cdk.DevelopmentPhoto", "PhotoUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "PhotoSmallUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "PhotoLargeUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "Description");
        }

        public override void Down()
        {
            AddColumn("cdk.NeighborhoodGuidePhoto", "Description", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "PhotoLargeUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "PhotoSmallUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentPhoto", "PhotoUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "PhotoLargeUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentFloorPlan", "PhotoSmallUri", c => c.String(maxLength: 255, unicode: false));
            DropColumn("cdk.NeighborhoodGuideVideo", "SeoSlug");
            DropColumn("cdk.NeighborhoodGuideVideo", "SeoKeywords");
            DropColumn("cdk.NeighborhoodGuideVideo", "SeoDescription");
            DropColumn("cdk.NeighborhoodGuideVideo", "SeoCaption");
            DropColumn("cdk.NeighborhoodGuidePhoto", "SeoSlug");
            DropColumn("cdk.NeighborhoodGuidePhoto", "SeoKeywords");
            DropColumn("cdk.NeighborhoodGuidePhoto", "SeoDescription");
            DropColumn("cdk.NeighborhoodGuidePhoto", "SeoCaption");
            DropColumn("cdk.NeighborhoodGuidePhoto", "PhotoType");
            DropColumn("cdk.NeighborhoodGuidePhoto", "PhotoName");
            DropColumn("cdk.NeighborhoodGuidePhoto", "OriginalUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "ThumbnailUri");
            DropColumn("cdk.NeighborhoodGuidePhoto", "PhotoDescription");
            DropColumn("cdk.NeighborhoodGuide", "SeoSlug");
            DropColumn("cdk.NeighborhoodGuide", "SeoKeywords");
            DropColumn("cdk.NeighborhoodGuide", "SeoDescription");
            DropColumn("cdk.NeighborhoodGuide", "SeoCaption");
            DropColumn("cdk.MetroArea", "SeoSlug");
            DropColumn("cdk.MetroArea", "SeoKeywords");
            DropColumn("cdk.MetroArea", "SeoDescription");
            DropColumn("cdk.MetroArea", "SeoCaption");
            DropColumn("cdk.DevelopmentVideo", "SeoSlug");
            DropColumn("cdk.DevelopmentVideo", "SeoKeywords");
            DropColumn("cdk.DevelopmentVideo", "SeoDescription");
            DropColumn("cdk.DevelopmentVideo", "SeoCaption");
            DropColumn("cdk.DevelopmentPhoto", "SeoSlug");
            DropColumn("cdk.DevelopmentPhoto", "SeoKeywords");
            DropColumn("cdk.DevelopmentPhoto", "SeoDescription");
            DropColumn("cdk.DevelopmentPhoto", "SeoCaption");
            DropColumn("cdk.DevelopmentPhoto", "PhotoDescription");
            DropColumn("cdk.DevelopmentPhoto", "OriginalUri");
            DropColumn("cdk.DevelopmentPhoto", "ThumbnailUri");
            DropColumn("cdk.DevelopmentFloorPlan", "SeoSlug");
            DropColumn("cdk.DevelopmentFloorPlan", "SeoKeywords");
            DropColumn("cdk.DevelopmentFloorPlan", "SeoDescription");
            DropColumn("cdk.DevelopmentFloorPlan", "SeoCaption");
            DropColumn("cdk.DevelopmentFloorPlan", "PhotoDescription");
            DropColumn("cdk.DevelopmentFloorPlan", "OriginalUri");
            DropColumn("cdk.DevelopmentFloorPlan", "ThumbnailUri");
            DropColumn("cdk.Developer", "SeoSlug");
            DropColumn("cdk.Developer", "SeoKeywords");
            DropColumn("cdk.Developer", "SeoDescription");
            DropColumn("cdk.Developer", "SeoCaption");
            DropColumn("cdk.Development", "SeoSlug");
            DropColumn("cdk.Development", "SeoKeywords");
            DropColumn("cdk.Development", "SeoDescription");
            DropColumn("cdk.Development", "SeoCaption");
            DropColumn("cdk.NeighborhoodArea", "SeoSlug");
            DropColumn("cdk.NeighborhoodArea", "SeoKeywords");
            DropColumn("cdk.NeighborhoodArea", "SeoDescription");
            DropColumn("cdk.NeighborhoodArea", "SeoCaption");
        }
    }
}
namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateVideoModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("cdk.DevelopmentVideo", "Name", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "Type", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "Uri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "Description", c => c.String(unicode: false));
            AddColumn("cdk.NeighborhoodGuidePhoto", "SequenceNumber", c => c.Int(nullable: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "Name", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "Type", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "Uri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.NeighborhoodGuideVideo", "SequenceNumber", c => c.Int(nullable: false));
            DropColumn("cdk.DevelopmentVideo", "VideoName");
            DropColumn("cdk.DevelopmentVideo", "VideoType");
            DropColumn("cdk.DevelopmentVideo", "VideoUri");
            DropColumn("cdk.NeighborhoodGuideVideo", "VideoUri");
        }

        public override void Down()
        {
            AddColumn("cdk.NeighborhoodGuideVideo", "VideoUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "VideoUri", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "VideoType", c => c.String(maxLength: 255, unicode: false));
            AddColumn("cdk.DevelopmentVideo", "VideoName", c => c.String(maxLength: 255, unicode: false));
            DropColumn("cdk.NeighborhoodGuideVideo", "SequenceNumber");
            DropColumn("cdk.NeighborhoodGuideVideo", "Uri");
            DropColumn("cdk.NeighborhoodGuideVideo", "Type");
            DropColumn("cdk.NeighborhoodGuideVideo", "Name");
            DropColumn("cdk.NeighborhoodGuidePhoto", "SequenceNumber");
            DropColumn("cdk.DevelopmentVideo", "Description");
            DropColumn("cdk.DevelopmentVideo", "Uri");
            DropColumn("cdk.DevelopmentVideo", "Type");
            DropColumn("cdk.DevelopmentVideo", "Name");
        }
    }
}
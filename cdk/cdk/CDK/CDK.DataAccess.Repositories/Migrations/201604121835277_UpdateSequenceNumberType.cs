namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateSequenceNumberType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("cdk.DevelopmentFloorPlan", "SequenceNumber", c => c.Int(nullable: false));
            AlterColumn("cdk.DevelopmentPhoto", "SequenceNumber", c => c.Int(nullable: false));
            AlterColumn("cdk.DevelopmentVideo", "SequenceNumber", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("cdk.DevelopmentVideo", "SequenceNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.DevelopmentPhoto", "SequenceNumber", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("cdk.DevelopmentFloorPlan", "SequenceNumber", c => c.String(maxLength: 255, unicode: false));
        }
    }
}
namespace CDK.DataAccess.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "client.Roles",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "client.Users",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(maxLength: 4000),
                    SecurityStamp = c.String(maxLength: 4000),
                    PhoneNumber = c.String(maxLength: 4000),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "client.UserClaims",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    UserId = c.Long(nullable: false),
                    ClaimType = c.String(maxLength: 4000),
                    ClaimValue = c.String(maxLength: 4000),
                    LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    CreatedBy = c.String(maxLength: 255, unicode: false),
                    LastUpdateBy = c.String(maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("client.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "client.UserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.LoginProvider,
                    t.ProviderKey,
                    t.UserId
                })
                .ForeignKey("client.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "client.UserRoles",
                c => new
                {
                    RoleId = c.Long(nullable: false),
                    UserId = c.Long(nullable: false),
                })
                .PrimaryKey(t => new
                {
                    t.RoleId,
                    t.UserId
                })
                .ForeignKey("client.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("client.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("client.UserRoles", "UserId", "client.Users");
            DropForeignKey("client.UserRoles", "RoleId", "client.Roles");
            DropForeignKey("client.UserLogins", "UserId", "client.Users");
            DropForeignKey("client.UserClaims", "UserId", "client.Users");
            DropIndex("client.UserRoles", new[] { "UserId" });
            DropIndex("client.UserRoles", new[] { "RoleId" });
            DropIndex("client.UserLogins", new[] { "UserId" });
            DropIndex("client.UserClaims", new[] { "UserId" });
            DropTable("client.UserRoles");
            DropTable("client.UserLogins");
            DropTable("client.UserClaims");
            DropTable("client.Users");
            DropTable("client.Roles");
        }
    }
}
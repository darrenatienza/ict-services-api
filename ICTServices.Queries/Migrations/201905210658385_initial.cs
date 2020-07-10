namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Auth.Permissions",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PermissionID);
            
            CreateTable(
                "Auth.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false),
                        PasswordSalt = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 250),
                        MiddleName = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "SG.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Desc = c.String(),
                        Personnel = c.String(),
                        Acts = c.String(),
                        Rmks = c.String(),
                    })
                .PrimaryKey(t => t.ReportID);
            
            CreateTable(
                "Auth.UserPermissions",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        PermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.PermissionID })
                .ForeignKey("Auth.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("Auth.Permissions", t => t.PermissionID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PermissionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Auth.UserPermissions", "PermissionID", "Auth.Permissions");
            DropForeignKey("Auth.UserPermissions", "UserID", "Auth.Users");
            DropIndex("Auth.UserPermissions", new[] { "PermissionID" });
            DropIndex("Auth.UserPermissions", new[] { "UserID" });
            DropTable("Auth.UserPermissions");
            DropTable("SG.Reports");
            DropTable("Auth.Users");
            DropTable("Auth.Permissions");
        }
    }
}

namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_roles_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Auth.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropTable("Auth.Roles");
        }
    }
}

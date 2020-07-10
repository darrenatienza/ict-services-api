namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_userGuid_property : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Auth.Users", "UserGUID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("Auth.Users", "UserGUID", c => c.Guid());
        }
    }
}

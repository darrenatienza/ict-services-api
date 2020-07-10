namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_identity_ID_to_guid_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Auth.Users", "UserGUID", c => c.Guid());
            DropColumn("Auth.Users", "IdentityID");
        }
        
        public override void Down()
        {
            AddColumn("Auth.Users", "IdentityID", c => c.Guid());
            DropColumn("Auth.Users", "UserGUID");
        }
    }
}

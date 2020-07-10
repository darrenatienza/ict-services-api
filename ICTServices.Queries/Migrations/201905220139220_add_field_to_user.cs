namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_field_to_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("Auth.Users", "CreateDate", c => c.DateTime(defaultValue: DateTime.Now));
            AddColumn("Auth.Users", "UserCreatedBy", c => c.String(defaultValue:""));
        }
        
        public override void Down()
        {
            DropColumn("Auth.Users", "UserCreatedBy");
            DropColumn("Auth.Users", "CreateDate");
        }
    }
}

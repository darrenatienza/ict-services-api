namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unexpected_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("Logs.UserActivityLogs", "UserGUID", c => c.Guid());
            AddColumn("Logs.UserActivityLogs", "RecordGUID", c => c.Guid());
            DropColumn("Logs.UserActivityLogs", "UserIdentityID");
            DropColumn("Logs.UserActivityLogs", "RecordIdentityID");
        }
        
        public override void Down()
        {
            AddColumn("Logs.UserActivityLogs", "RecordIdentityID", c => c.Guid());
            AddColumn("Logs.UserActivityLogs", "UserIdentityID", c => c.Guid());
            DropColumn("Logs.UserActivityLogs", "RecordGUID");
            DropColumn("Logs.UserActivityLogs", "UserGUID");
        }
    }
}

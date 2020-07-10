namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_082610 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Logs.SystemLogs",
                c => new
                    {
                        SystemLogID = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        Timestamp = c.String(),
                        FileName = c.String(),
                        LineNumber = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.SystemLogID);
            
            CreateTable(
                "Logs.UserActivityLogs",
                c => new
                    {
                        UserActivityLogID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        Action = c.String(),
                        Message = c.String(),
                        UserIdentityID = c.Guid(),
                        RecordIdentityID = c.Guid(),
                    })
                .PrimaryKey(t => t.UserActivityLogID);
            
            AddColumn("Auth.Users", "IdentityID", c => c.Guid());
            AddColumn("Inventory.InventoryDetails", "IdentityID", c => c.Guid());
            AddColumn("Inventory.InventoryRecords", "IdentityID", c => c.Guid());
            AddColumn("Inventory.QuantityInventory", "IdentityID", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("Inventory.QuantityInventory", "IdentityID");
            DropColumn("Inventory.InventoryRecords", "IdentityID");
            DropColumn("Inventory.InventoryDetails", "IdentityID");
            DropColumn("Auth.Users", "IdentityID");
            DropTable("Logs.UserActivityLogs");
            DropTable("Logs.SystemLogs");
        }
    }
}

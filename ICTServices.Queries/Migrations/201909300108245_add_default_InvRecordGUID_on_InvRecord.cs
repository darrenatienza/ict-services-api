namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_default_InvRecordGUID_on_InvRecord : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid(defaultValue: Guid.NewGuid()));
        }
        
        public override void Down()
        {
            AlterColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid());
        }
    }
}

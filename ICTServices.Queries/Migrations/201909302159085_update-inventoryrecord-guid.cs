namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinventoryrecordguid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid());
        }
    }
}

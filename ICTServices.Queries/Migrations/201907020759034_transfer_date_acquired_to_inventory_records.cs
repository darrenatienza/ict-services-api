namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transfer_date_acquired_to_inventory_records : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.InventoryRecords", "DateAcquired", c => c.DateTime(nullable: false));
            DropColumn("Inventory.InventoryDetails", "DateAcquired");
        }
        
        public override void Down()
        {
            AddColumn("Inventory.InventoryDetails", "DateAcquired", c => c.DateTime(nullable: false));
            DropColumn("Inventory.InventoryRecords", "DateAcquired");
        }
    }
}

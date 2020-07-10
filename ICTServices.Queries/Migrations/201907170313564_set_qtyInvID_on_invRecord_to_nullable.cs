namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_qtyInvID_on_invRecord_to_nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Inventory.InventoryRecords", "QtyInvID", "Inventory.QuantityInventory");
            DropIndex("Inventory.InventoryRecords", new[] { "QtyInvID" });
            AlterColumn("Inventory.InventoryRecords", "QtyInvID", c => c.Int());
            CreateIndex("Inventory.InventoryRecords", "QtyInvID");
            AddForeignKey("Inventory.InventoryRecords", "QtyInvID", "Inventory.QuantityInventory", "QtyInvID");
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.InventoryRecords", "QtyInvID", "Inventory.QuantityInventory");
            DropIndex("Inventory.InventoryRecords", new[] { "QtyInvID" });
            AlterColumn("Inventory.InventoryRecords", "QtyInvID", c => c.Int(nullable: false));
            CreateIndex("Inventory.InventoryRecords", "QtyInvID");
            AddForeignKey("Inventory.InventoryRecords", "QtyInvID", "Inventory.QuantityInventory", "QtyInvID", cascadeDelete: true);
        }
    }
}

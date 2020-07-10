namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_inv_stat_and_inv_stat_id_on_qty_inv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inventory.InventoryStatus",
                c => new
                    {
                        InvStatID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InvStatID);
            
            AddColumn("Inventory.InventoryRecords", "InvStatID", c => c.Int());
            AddColumn("Inventory.QuantityInventory", "InvStatID", c => c.Int());
            CreateIndex("Inventory.InventoryRecords", "InvStatID");
            CreateIndex("Inventory.QuantityInventory", "InvStatID");
            AddForeignKey("Inventory.InventoryRecords", "InvStatID", "Inventory.InventoryStatus", "InvStatID");
            AddForeignKey("Inventory.QuantityInventory", "InvStatID", "Inventory.InventoryStatus", "InvStatID");
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.QuantityInventory", "InvStatID", "Inventory.InventoryStatus");
            DropForeignKey("Inventory.InventoryRecords", "InvStatID", "Inventory.InventoryStatus");
            DropIndex("Inventory.QuantityInventory", new[] { "InvStatID" });
            DropIndex("Inventory.InventoryRecords", new[] { "InvStatID" });
            DropColumn("Inventory.QuantityInventory", "InvStatID");
            DropColumn("Inventory.InventoryRecords", "InvStatID");
            DropTable("Inventory.InventoryStatus");
        }
    }
}

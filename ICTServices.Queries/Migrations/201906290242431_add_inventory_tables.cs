namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_inventory_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inventory.InventoryDetails",
                c => new
                    {
                        InvDetailID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        InvTypeID = c.Int(nullable: false),
                        DateAcquired = c.DateTime(nullable: false),
                        Specs = c.String(),
                        OtherDetails = c.String(),
                    })
                .PrimaryKey(t => t.InvDetailID)
                .ForeignKey("Inventory.InventoryTypes", t => t.InvTypeID, cascadeDelete: false)
                .Index(t => t.InvTypeID);
            
            CreateTable(
                "Inventory.InventoryTypes",
                c => new
                    {
                        InvTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InvTypeID);
            
            CreateTable(
                "Inventory.InventoryLocations",
                c => new
                    {
                        InvLocationID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InvLocationID);
            
            CreateTable(
                "Inventory.InventoryRecords",
                c => new
                    {
                        InvRecordID = c.Int(nullable: false, identity: true),
                        PropertyNum = c.String(),
                        EquipNum = c.String(),
                        InvDetailID = c.Int(nullable: false),
                        InvLocationID = c.Int(nullable: false),
                        QtyInvID = c.Int(nullable: false),
                        Status = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.InvRecordID)
                .ForeignKey("Inventory.InventoryDetails", t => t.InvDetailID, cascadeDelete: true)
                .ForeignKey("Inventory.InventoryLocations", t => t.InvLocationID, cascadeDelete: false)
                .ForeignKey("Inventory.QuantityInventory", t => t.QtyInvID, cascadeDelete: true)
                .Index(t => t.InvDetailID)
                .Index(t => t.InvLocationID)
                .Index(t => t.QtyInvID);
            
            CreateTable(
                "Inventory.QuantityInventory",
                c => new
                    {
                        QtyInvID = c.Int(nullable: false, identity: true),
                        InvTypeID = c.Int(nullable: false),
                        InvLocationID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.QtyInvID)
                .ForeignKey("Inventory.InventoryLocations", t => t.InvLocationID, cascadeDelete: false)
                .ForeignKey("Inventory.InventoryTypes", t => t.InvTypeID, cascadeDelete: false)
                .Index(t => t.InvTypeID)
                .Index(t => t.InvLocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.InventoryRecords", "QtyInvID", "Inventory.QuantityInventory");
            DropForeignKey("Inventory.QuantityInventory", "InvTypeID", "Inventory.InventoryTypes");
            DropForeignKey("Inventory.QuantityInventory", "InvLocationID", "Inventory.InventoryLocations");
            DropForeignKey("Inventory.InventoryRecords", "InvLocationID", "Inventory.InventoryLocations");
            DropForeignKey("Inventory.InventoryRecords", "InvDetailID", "Inventory.InventoryDetails");
            DropForeignKey("Inventory.InventoryDetails", "InvTypeID", "Inventory.InventoryTypes");
            DropIndex("Inventory.QuantityInventory", new[] { "InvLocationID" });
            DropIndex("Inventory.QuantityInventory", new[] { "InvTypeID" });
            DropIndex("Inventory.InventoryRecords", new[] { "QtyInvID" });
            DropIndex("Inventory.InventoryRecords", new[] { "InvLocationID" });
            DropIndex("Inventory.InventoryRecords", new[] { "InvDetailID" });
            DropIndex("Inventory.InventoryDetails", new[] { "InvTypeID" });
            DropTable("Inventory.QuantityInventory");
            DropTable("Inventory.InventoryRecords");
            DropTable("Inventory.InventoryLocations");
            DropTable("Inventory.InventoryTypes");
            DropTable("Inventory.InventoryDetails");
        }
    }
}

namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_date_acquired_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Inventory.InventoryRecords", "DateAcquired", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Inventory.InventoryRecords", "DateAcquired", c => c.DateTime(nullable: false));
        }
    }
}

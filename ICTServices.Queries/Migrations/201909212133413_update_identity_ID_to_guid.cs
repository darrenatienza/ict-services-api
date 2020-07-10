namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_identity_ID_to_guid : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid());
            DropColumn("Inventory.InventoryRecords", "IdentityID");
        }
        
        public override void Down()
        {
            AddColumn("Inventory.InventoryRecords", "IdentityID", c => c.Guid());
            DropColumn("Inventory.InventoryRecords", "InvRecordGUID");
        }
    }
}

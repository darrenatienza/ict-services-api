namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_databaseGenerationOption_computed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Auth.Users", "UserGUID", c => c.Guid(defaultValue: Guid.NewGuid()));
            AlterColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid(defaultValue: Guid.NewGuid()));
        }
        
        public override void Down()
        {
            AlterColumn("Inventory.InventoryRecords", "InvRecordGUID", c => c.Guid());
            AlterColumn("Auth.Users", "UserGUID", c => c.Guid());
        }
    }
}

namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_code_column_to_inv_type : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.InventoryTypes", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Inventory.InventoryTypes", "Code");
        }
    }
}

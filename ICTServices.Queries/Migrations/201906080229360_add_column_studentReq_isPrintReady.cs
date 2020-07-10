namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_studentReq_isPrintReady : DbMigration
    {
        public override void Up()
        {
            AddColumn("StudentService.StudentReqs", "isPrintReady", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("StudentService.StudentReqs", "isPrintReady");
        }
    }
}

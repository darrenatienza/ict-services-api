namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("Schedule.ClassSchedules", "SchoolYearID", c => c.Int(nullable: false));
            AddColumn("Schedule.ClassSchedules", "Semester", c => c.String());
            CreateIndex("Schedule.ClassSchedules", "SchoolYearID");
            AddForeignKey("Schedule.ClassSchedules", "SchoolYearID", "Common.SchoolYears", "SchoolYearID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Schedule.ClassSchedules", "SchoolYearID", "Common.SchoolYears");
            DropIndex("Schedule.ClassSchedules", new[] { "SchoolYearID" });
            DropColumn("Schedule.ClassSchedules", "Semester");
            DropColumn("Schedule.ClassSchedules", "SchoolYearID");
        }
    }
}

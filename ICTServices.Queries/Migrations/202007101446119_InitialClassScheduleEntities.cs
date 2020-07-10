namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialClassScheduleEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Schedule.ClassSchedules",
                c => new
                    {
                        ClassScheduleID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        EmployeeID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassScheduleID)
                .ForeignKey("Person.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("Common.Rooms", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("Common.Sections", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("Common.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.RoomID)
                .Index(t => t.SectionID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "Common.EmployeeTypes",
                c => new
                    {
                        EmployeeTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeTypeID);
            
            CreateTable(
                "Common.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "Common.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SectionID);
            
            CreateTable(
                "Common.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            AddColumn("Person.Employees", "EmployeeTypeID", c => c.Int());
            CreateIndex("Person.Employees", "EmployeeTypeID");
            AddForeignKey("Person.Employees", "EmployeeTypeID", "Common.EmployeeTypes", "EmployeeTypeID");
        }
        
        public override void Down()
        {
            DropForeignKey("Schedule.ClassSchedules", "SubjectID", "Common.Subjects");
            DropForeignKey("Schedule.ClassSchedules", "SectionID", "Common.Sections");
            DropForeignKey("Schedule.ClassSchedules", "RoomID", "Common.Rooms");
            DropForeignKey("Schedule.ClassSchedules", "EmployeeID", "Person.Employees");
            DropForeignKey("Person.Employees", "EmployeeTypeID", "Common.EmployeeTypes");
            DropIndex("Person.Employees", new[] { "EmployeeTypeID" });
            DropIndex("Schedule.ClassSchedules", new[] { "SubjectID" });
            DropIndex("Schedule.ClassSchedules", new[] { "SectionID" });
            DropIndex("Schedule.ClassSchedules", new[] { "RoomID" });
            DropIndex("Schedule.ClassSchedules", new[] { "EmployeeID" });
            DropColumn("Person.Employees", "EmployeeTypeID");
            DropTable("Common.Subjects");
            DropTable("Common.Sections");
            DropTable("Common.Rooms");
            DropTable("Common.EmployeeTypes");
            DropTable("Schedule.ClassSchedules");
        }
    }
}

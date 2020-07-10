namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_columns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Common.Colleges",
                c => new
                    {
                        CollegeID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CollegeID);
            
            CreateTable(
                "Common.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        CollegeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("Common.Colleges", t => t.CollegeID, cascadeDelete: true)
                .Index(t => t.CollegeID);
            
            CreateTable(
                "Common.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StudentReqTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("Common.StudentReqTypes", t => t.StudentReqTypeID, cascadeDelete: true)
                .Index(t => t.StudentReqTypeID);
            
            CreateTable(
                "Common.StudentReqTypes",
                c => new
                    {
                        StudentReqTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StudentReqTypeID);
            
            CreateTable(
                "Common.Majors",
                c => new
                    {
                        MajorID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MajorID)
                .ForeignKey("Common.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "Common.SchoolYears",
                c => new
                    {
                        SchoolYearID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SchoolYearID);
            
            CreateTable(
                "Person.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        SrCode = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        CollegeID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        MajorID = c.Int(nullable: false),
                        YearLevel = c.String(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("Common.Colleges", t => t.CollegeID, cascadeDelete: false)
                .ForeignKey("Common.Courses", t => t.CourseID, cascadeDelete: false)
                .ForeignKey("Common.Majors", t => t.MajorID, cascadeDelete: false)
                .Index(t => t.CollegeID)
                .Index(t => t.CourseID)
                .Index(t => t.MajorID);
            
            CreateTable(
                "StudentService.StudentReqs",
                c => new
                    {
                        StudentReqID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        StudentReqTypeID = c.Int(nullable: false),
                        ReceiptNum = c.String(),
                        SchoolYearID = c.Int(nullable: false),
                        Semester = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        IsClaimed = c.Boolean(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ClaimedDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.StudentReqID)
                .ForeignKey("Common.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("Common.SchoolYears", t => t.SchoolYearID, cascadeDelete: true)
                .ForeignKey("Person.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("Common.StudentReqTypes", t => t.StudentReqTypeID, cascadeDelete: false)
                .Index(t => t.StudentID)
                .Index(t => t.StudentReqTypeID)
                .Index(t => t.SchoolYearID)
                .Index(t => t.LocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("StudentService.StudentReqs", "StudentReqTypeID", "Common.StudentReqTypes");
            DropForeignKey("StudentService.StudentReqs", "StudentID", "Person.Students");
            DropForeignKey("StudentService.StudentReqs", "SchoolYearID", "Common.SchoolYears");
            DropForeignKey("StudentService.StudentReqs", "LocationID", "Common.Locations");
            DropForeignKey("Person.Students", "MajorID", "Common.Majors");
            DropForeignKey("Person.Students", "CourseID", "Common.Courses");
            DropForeignKey("Person.Students", "CollegeID", "Common.Colleges");
            DropForeignKey("Common.Majors", "CourseID", "Common.Courses");
            DropForeignKey("Common.Locations", "StudentReqTypeID", "Common.StudentReqTypes");
            DropForeignKey("Common.Courses", "CollegeID", "Common.Colleges");
            DropIndex("StudentService.StudentReqs", new[] { "LocationID" });
            DropIndex("StudentService.StudentReqs", new[] { "SchoolYearID" });
            DropIndex("StudentService.StudentReqs", new[] { "StudentReqTypeID" });
            DropIndex("StudentService.StudentReqs", new[] { "StudentID" });
            DropIndex("Person.Students", new[] { "MajorID" });
            DropIndex("Person.Students", new[] { "CourseID" });
            DropIndex("Person.Students", new[] { "CollegeID" });
            DropIndex("Common.Majors", new[] { "CourseID" });
            DropIndex("Common.Locations", new[] { "StudentReqTypeID" });
            DropIndex("Common.Courses", new[] { "CollegeID" });
            DropTable("StudentService.StudentReqs");
            DropTable("Person.Students");
            DropTable("Common.SchoolYears");
            DropTable("Common.Majors");
            DropTable("Common.StudentReqTypes");
            DropTable("Common.Locations");
            DropTable("Common.Courses");
            DropTable("Common.Colleges");
        }
    }
}

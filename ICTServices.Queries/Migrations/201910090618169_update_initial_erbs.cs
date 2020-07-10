namespace API.Queries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_initial_erbs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Person.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        OfficeID = c.Int(),
                        CollegeID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("Common.Colleges", t => t.CollegeID)
                .ForeignKey("Common.Offices", t => t.OfficeID)
                .Index(t => t.OfficeID)
                .Index(t => t.CollegeID);
            
            CreateTable(
                "Common.Offices",
                c => new
                    {
                        OfficeID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OfficeID);
            
            CreateTable(
                "ERBS.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        ItemID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        DateTimeFrom = c.DateTime(nullable: false),
                        DateTimeTo = c.DateTime(nullable: false),
                        BorrowedDate = c.DateTime(),
                        ReturnedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("Person.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("ERBS.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "ERBS.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "ERBS.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.VenueID);
            
            CreateTable(
                "ERBS.VenueReservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReservationID, t.VenueID })
                .ForeignKey("ERBS.Reservations", t => t.ReservationID, cascadeDelete: true)
                .ForeignKey("ERBS.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.ReservationID)
                .Index(t => t.VenueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ERBS.VenueReservations", "VenueID", "ERBS.Venues");
            DropForeignKey("ERBS.VenueReservations", "ReservationID", "ERBS.Reservations");
            DropForeignKey("ERBS.Reservations", "ItemID", "ERBS.Items");
            DropForeignKey("ERBS.Reservations", "EmployeeID", "Person.Employees");
            DropForeignKey("Person.Employees", "OfficeID", "Common.Offices");
            DropForeignKey("Person.Employees", "CollegeID", "Common.Colleges");
            DropIndex("ERBS.VenueReservations", new[] { "VenueID" });
            DropIndex("ERBS.VenueReservations", new[] { "ReservationID" });
            DropIndex("ERBS.Reservations", new[] { "EmployeeID" });
            DropIndex("ERBS.Reservations", new[] { "ItemID" });
            DropIndex("Person.Employees", new[] { "CollegeID" });
            DropIndex("Person.Employees", new[] { "OfficeID" });
            DropTable("ERBS.VenueReservations");
            DropTable("ERBS.Venues");
            DropTable("ERBS.Items");
            DropTable("ERBS.Reservations");
            DropTable("Common.Offices");
            DropTable("Person.Employees");
        }
    }
}

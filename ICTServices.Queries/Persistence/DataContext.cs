using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Queries.Core.Domain;
using API.Queries.Migrations;
using API.Queries.EntityConfiguration;
using System.Data.Entity.Migrations;
using API.Queries.Core.Domain.Auth;
using API.Queries.Core.Domain.SG;
using Common =  API.Queries.Core.Domain.Common;

using Inventory = API.Queries.Core.Domain.Inventory;
using API.Queries.Core.Domain.Person;
using API.Queries.Core.Domain.StudentService;
using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.Inventory;
using API.Queries.Core.Domain.Logs;
using API.Queries.Persistence.EntityConfiguration;
using API.Queries.Core.Domain.ERBS;

namespace API.Queries.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
            //: base("name=ServerContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            
            
            
        }
        public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<User> AuthUsers { get; set; }
        public virtual DbSet<Permission> AuthPermissions { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Report> SGReports { get; set; }
        public virtual DbSet<Common.Location> Locations { get; set; }
        public virtual DbSet<Common.SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Common.College> Colleges { get; set; }
        public virtual DbSet<Common.Course> Courses { get; set; }
        public virtual DbSet<Common.Major> Majors { get; set; }

        public virtual DbSet<StudentReq> StudReqs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentReqType> StudReqTypes { get; set; }

        public virtual DbSet<InvDetail> InvDetails { get; set; }
        public virtual DbSet<InvLocation> InvLocations { get; set; }
        public virtual DbSet<InvRecord> InvRecords { get; set; }
        public virtual DbSet<InvType> InvTypes { get; set; }
        public virtual DbSet<QtyInv> QtyInvs { get; set; }

        public virtual DbSet<InvStat> InvStats { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Inventory Records
        /// </summary>
        //public virtual DbSet<Inventory.InvRec> InvRecs { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new InvRecordConfig());
            modelBuilder.Configurations.Add(new ReservationConfig());
            
        }
    }
}

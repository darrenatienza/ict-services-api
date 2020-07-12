using API.Queries.Core;
using API.Queries.Core.IRepositories;
using API.Queries.Core.IRepositories.Auth;
using API.Queries.Persistence.Repositories;
using API.Queries.Persistence.Repositories.Auth;
using Common = API.Queries.Persistence.Repositories.Common;
using API.Queries.Persistence.Repositories.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Queries.Core.IRepositories.Person;
using API.Queries.Core.IRepositories.StudentService;
using API.Queries.Core.IRepositories.Common;
using API.Queries.Persistence.Repositories.Person;
using API.Queries.Persistence.Repositories.StudentService;
using API.Queries.Persistence.Repositories.Common;
using API.Queries.Persistence.Repositories.Inventory;
using API.Queries.Core.IRepositories.Inventory;
using API.Queries.Persistence.Repositories.Logs;
using API.Queries.Core.IRepositories.Schedule;

namespace API.Queries.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Permissions = new PermissionRepository(_context);
            SGReports = new SGReportRepo(_context);
            Roles = new RoleRepo(_context);
            Colleges = new Common.CollegeRepo(_context);
            Courses = new Common.CourseRepo(_context);
            Locations = new Common.LocationRepo(_context);
            Majors = new Common.MajorRepo(_context);
            SchoolYears = new Common.SchoolYearRepo(_context);
       
            Students = new StudentRepo(_context);
            StudReqs = new StudReqRepo(_context);
            StudentReqTypes = new StudReqTypeRepo(_context);
            InvDetails = new InvDetailRepo(_context);
            InvLocations = new InvLocationRepo(_context);
            InvRecords = new InvRecordRepo(_context);
            QtyInvs = new QtyInvRepo(_context);
            InvTypes = new InvTypeRepo(_context);
            this.UserActivityLogs = new UserActivityLogRepo(_context);
            this.SystemLogs = new SystemLogRepo(_context);
            InvStats = new InvStatRepo(_context);

            Reservations = new ReservationRepo(_context);
            Items = new ItemRepo(_context);
            Offices = new OfficeRepo(_context);
            Employees = new EmployeeRepo(_context);
            Venues = new VenueRepo(_context);
            ClassSchedules = new ClassScheduleRepo(_context);

        }

        public IUserRepository Users { get; private set; }
        public IPermissionRepository Permissions { get; private set; }
        public IRoleRepo Roles { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public Core.IRepositories.SG.ISGReportRepo SGReports
        {
            get;
            private set;
        }


        public Core.IRepositories.Common.ICollegeRepo Colleges
        {
            get;
            private set;
        }

        public Core.IRepositories.Common.ICourseRepo Courses
        {
            get;
            private set;
        }

        public Core.IRepositories.Common.ILocationRepo Locations
        {
            get;
            private set;
        }

        public Core.IRepositories.Common.IMajorRepo Majors
        {
            get;
            private set;
        }

        public Core.IRepositories.Common.ISchoolYearRepo SchoolYears
        {
            get;
            private set;
        }

       

        public IStudReqRepo StudReqs
        {
            get;
            private set;
        }

        public IStudReqTypeRepo StudentReqTypes
        {
            get;
            private set;
        }


        public IStudentRepo Students
        {
            get;
            private set;
        }


        public Core.IRepositories.Inventory.IInvDetailRepo InvDetails
        {
            get;
            private set;
        }

        public Core.IRepositories.Inventory.IInvLocationRepo InvLocations
        {
            get;
            private set;
        }

        public Core.IRepositories.Inventory.IInvRecordRepo InvRecords
        {
            get;
            private set;
        }

        public IQtyInvRepo QtyInvs
        {
            get;
            private set;
        }


        public Core.IRepositories.Inventory.IInvTypeRepo InvTypes
        {
            get;
            private set;
        }


        public IInvStatRepo InvStats
        {
            get;
            private set;
        }



        

        public Core.IRepositories.Logs.IUserActivityLogRepo UserActivityLogs
        {
            get;
            private set;
        }


        public Core.IRepositories.Logs.ISystemLogRepo SystemLogs
        {
            get;
            private set;
        }


        public IVenueRepo Venues
        {
            get;
            private set;
        }

        public IOfficeRepo Offices
        {
            get;
            private set;
        }

        public IReservationRepo Reservations
        {
            get;
            private set;
        }

        public IItemRepo Items
        {
            get;
            private set;
        }

        public IEmployeeRepo Employees
        {
            get;
            private set;
        }

        public IClassSchedule ClassSchedules
        {
            get;
            private set;
        }
    }
}

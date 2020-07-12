using API.Queries.Core.IRepositories;
using API.Queries.Core.IRepositories.Auth;
using API.Queries.Core.IRepositories.Common;
using API.Queries.Core.IRepositories.Inventory;
using API.Queries.Core.IRepositories.Logs;
using API.Queries.Core.IRepositories.Person;
using API.Queries.Core.IRepositories.Schedule;
using API.Queries.Core.IRepositories.SG;
using API.Queries.Core.IRepositories.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common = API.Queries.Core.IRepositories.Common;

namespace API.Queries.Core
{
    public interface IUnitOfWork : IDisposable
    {

        IUserActivityLogRepo UserActivityLogs { get; }
        ISystemLogRepo SystemLogs { get; }
        IUserRepository Users { get;}
        IPermissionRepository Permissions { get;}

        ISGReportRepo SGReports { get; }
        IRoleRepo Roles { get; }

        Common.ICollegeRepo Colleges { get; }
        Common.ICourseRepo Courses { get; }
        Common.ILocationRepo Locations { get; }
        Common.IMajorRepo Majors { get; }
        Common.ISchoolYearRepo SchoolYears { get; }
        IStudentRepo Students { get; }
        IStudReqRepo StudReqs { get; }
        IStudReqTypeRepo StudentReqTypes { get; }

        IInvDetailRepo InvDetails { get; }

        IInvLocationRepo InvLocations { get; }

        IInvRecordRepo InvRecords { get; }

        IQtyInvRepo QtyInvs { get; }
        IInvTypeRepo InvTypes { get; }

        IInvStatRepo InvStats { get; }

        IVenueRepo Venues { get; }
        IOfficeRepo Offices { get; }
        IReservationRepo Reservations { get;  }
        IItemRepo Items { get;  }
        IEmployeeRepo Employees { get; }
        IClassSchedule ClassSchedules { get; }
        int Complete();
    }
}

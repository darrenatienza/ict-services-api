using API.Queries.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Queries.Core.IRepositories.Person;
using API.Queries.Core.Domain.Schedule;
using API.Queries.Core.IRepositories.Schedule;

namespace API.Queries.Persistence.Repositories.Person
{
    public class ClassScheduleRepo : Repository<ClassSchedule>, IClassSchedule
    {

        public ClassScheduleRepo(DataContext _context)
            : base(_context)
        {
        }
        public DataContext DataContext
        {
            get
            {
                return Context as DataContext;
            }
        }

        public IEnumerable<ClassSchedule> GetAll(int roomID, string semester, int schoolYearID)
        {
            return DataContext.ClassSchedules.Where(r => r.RoomID == roomID && r.Semester == semester && r.SchoolYearID == schoolYearID);
        }
    }
}

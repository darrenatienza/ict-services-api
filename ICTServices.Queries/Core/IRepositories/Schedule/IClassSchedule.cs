using API.Queries.Core.Domain.Person;
using API.Queries.Core.Domain.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Schedule
{
    public interface IClassSchedule : IRepository<ClassSchedule>
    {
        IEnumerable<ClassSchedule> GetAll(int roomID, string semester, int schoolYearID);
    }
}

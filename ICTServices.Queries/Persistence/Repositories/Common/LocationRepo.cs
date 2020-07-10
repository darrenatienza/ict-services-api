using API.Queries.Core.Domain.Common;
using API.Queries.Core.IRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Queries.Persistence.Repositories.Common
{
    public class LocationRepo : Repository<Location>, ILocationRepo
    {

        public LocationRepo(DataContext _context)
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

        public IEnumerable<Location> GetAllByStudentReqID(int studentReqID)
        {
            return DataContext.Locations.Where(rec => rec.StudentReqTypeID == studentReqID);
        }
    }
}

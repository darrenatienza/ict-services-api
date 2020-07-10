using API.Queries.Core.Domain.Common;
using API.Queries.Core.IRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Queries.Persistence.Repositories.Common
{
    public class MajorRepo : Repository<Major>, IMajorRepo
    {


        public MajorRepo(DataContext _context)
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

        public IEnumerable<Major> GetAll(int courseID)
        {
            return DataContext.Majors.Where(rec => rec.CourseID == courseID);
        }
    }
}

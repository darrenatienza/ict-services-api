using API.Queries.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Queries.Core.IRepositories.Common
{
    public interface ICourseRepo : IRepository<Course>
    {
        IEnumerable<Course> GetAll(int collegeID);
    }
}

using API.Queries.Core.Domain.Inventory;
using API.Queries.Core.IRepositories.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API.Queries.Core.Domain.Logs;
using API.Queries.Core.IRepositories.Logs;
namespace API.Queries.Persistence.Repositories.Logs
{
    public class SystemLogRepo : Repository<SystemLog>, ISystemLogRepo
    {


        public SystemLogRepo(DataContext _context)
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
    }
}

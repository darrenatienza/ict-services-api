using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.ERBS;
using API.Queries.Core.IRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Persistence.Repositories.Common
{
    public class ItemRepo : Repository<Item>, IItemRepo
    {


        public ItemRepo(DataContext _context)
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

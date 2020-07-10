using API.Queries.Core.Domain.Common;
using API.Queries.Core.IRepositories.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Persistence.Repositories.Inventory
{
    public class InvTypeRepo : Repository<InvType>, IInvTypeRepo
    {


        public InvTypeRepo(DataContext _context)
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

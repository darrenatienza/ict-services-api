using API.Queries.Core.Domain.Auth;
using API.Queries.Core.IRepositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Persistence.Repositories.Auth
{
    public class RoleRepo : Repository<Role>, IRoleRepo
    {
        public RoleRepo(DataContext context)
            : base(context)
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

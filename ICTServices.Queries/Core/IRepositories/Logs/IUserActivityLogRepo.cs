using API.Queries.Core.Domain.Inventory;
using API.Queries.Core.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Logs
{
    public interface IUserActivityLogRepo : IRepository<UserActivityLog>
    {

        IEnumerable<UserActivityLog> GetAll(Guid recordID);
    }
}

using API.Queries.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Inventory
{
    public interface IInvDetailRepo : IRepository<InvDetail>
    {
        IEnumerable<InvDetail> GetAll_Criteria(string criteria);

        IEnumerable<InvDetail> GetAll(int invTypeID);

        IEnumerable<InvDetail> GetAll_Criteria(string criteria, string type);
    }
}

using API.Queries.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Inventory
{
    public interface IQtyInvRepo : IRepository<QtyInv>
    {
        IEnumerable<QtyInv> GetAll_Criteria(string criteria);

        QtyInv GetV1_1(int qtyInvID);

        IEnumerable<QtyInv> GetAll_CriteriaV1_1(string criteria);

        IEnumerable<QtyInv> GetAll_Criteria(string type, string location, string status);
    }
}

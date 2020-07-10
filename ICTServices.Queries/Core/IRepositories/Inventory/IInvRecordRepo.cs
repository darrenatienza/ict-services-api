using API.Queries.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Inventory
{
    public interface IInvRecordRepo : IRepository<InvRecord>
    {
        IEnumerable<InvRecord> GetAll_Criteria(string criteria);

        InvRecord GetInvRecord(int invRecordID);

        string GetLastEquipNum();

        int GetLastEquipNum(int invTypeID);

        IEnumerable<InvRecord> GetAll_Criteria(string criteria, int qtyInv);

        int GetCountByQtyInvID(int qtyInvID);

        bool CheckIfExists(string propertyNum);

        IEnumerable<InvRecord> GetAll_Criteria(string criteria, string location, string type, string status);

        IEnumerable<InvRecord> GetAllByInvDetailID(int invDetailID);




        InvRecord GetInvRecord(string propNum);
    }
}

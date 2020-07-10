using API.Queries.Core.Domain.Inventory;
using API.Queries.Core.IRepositories.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace API.Queries.Persistence.Repositories.Inventory
{
    public class InvRecordRepo : Repository<InvRecord>, IInvRecordRepo
    {


        public InvRecordRepo(DataContext _context)
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


        public IEnumerable<InvRecord> GetAll_Criteria(string criteria)
        {
            return DataContext.InvRecords.Include(rec => rec.InvDetail.InvType)
                 .Where(rec => (rec.Status.Contains("") 
                     && rec.InvDetail.InvType.Description.Contains(""))
                     && (rec.PropertyNum.Contains(criteria)
                     && String.Concat(rec.InvDetail.InvType.Code,rec.EquipNum).Contains(criteria))
                     );
        }


        public InvRecord GetInvRecord(int invRecordID)
        {
            return DataContext.InvRecords
                .Include(rec => rec.InvDetail.InvType)
                .Include(rec => rec.QtyInv.InvType)
                .Include(rec => rec.InvLocation)
                .Include(rec => rec.InvStat)
                .FirstOrDefault(rec =>rec.InvRecordID == invRecordID);
        }


       
           
        


        public string GetLastEquipNum()
        {
            return DataContext.InvRecords.OrderByDescending(rec => rec.InvRecordID).Select(rec => rec.EquipNum).FirstOrDefault();
        }


        public int GetLastEquipNum(int invTypeID)
        {
            //select only the equip number of table
            var obj = DataContext.InvRecords
                .OrderByDescending(rec => rec.InvRecordID)
                .FirstOrDefault(rec => rec.InvDetail.InvTypeID == invTypeID);
            return obj == null ? 00000 : int.Parse(obj.EquipNum);

        }


        public IEnumerable<InvRecord> GetAll_Criteria(string criteria, int qtyInvID)
        {
            return DataContext.InvRecords.Include(rec => rec.QtyInv.InvType)
                  .Where(rec => (rec.PropertyNum.Contains(criteria) || rec.Status.Contains(criteria)) && rec.QtyInvID == qtyInvID);
        }


        public int GetCountByQtyInvID(int qtyInvID)
        {
            return DataContext.InvRecords.Where(rec => rec.QtyInvID == qtyInvID).Count();
        }


        public bool CheckIfExists(string propertyNum)
        {
            var obj = DataContext.InvRecords.FirstOrDefault(rec => rec.PropertyNum == propertyNum);
            return obj != null ? true : false;
        }


        public IEnumerable<InvRecord> GetAll_Criteria(string criteria, string location, string type, string status)
        {
            //for multiple column search with one value like criteria to search on firstname middle name last name, use
            // OR but for multiple column search with each single value use AND

            #region Version 1 to get inventory records
            var firstRes = DataContext.InvRecords
                   .Include(rec => rec.InvDetail.InvType)
                   .Include(rec => rec.InvLocation)
                   .Include(rec => rec.InvStat)
                    .Where(rec => (rec.Status.Contains(status) || rec.InvStat.Description.Contains(status)) // changes: add invstat description filtering for new api version 1_2 or later
                        && rec.InvDetail.InvType.Description.Contains(type)
                        && rec.InvLocation.Description.Contains(location)
                        && ((rec.PropertyNum.Contains(criteria)
                        || String.Concat(rec.InvDetail.InvType.Code, rec.EquipNum).Contains(criteria)))
                        );
            
            #endregion

           
            return firstRes; // return the result
        }


        public IEnumerable<InvRecord> GetAllByInvDetailID(int invDetailID)
        {
            return DataContext.InvRecords
                .Include(rec => rec.InvDetail.InvType)
                .Include(rec => rec.InvLocation)
                .Include(r => r.InvStat)
                 .Where(rec => rec.InvDetailID == invDetailID
                     );
        }

        public InvRecord GetInvRecord(string propNum)
        {
            return DataContext.InvRecords.FirstOrDefault(r => r.PropertyNum == propNum);
        }
    }
}

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
    public class QtyInvRepo : Repository<QtyInv>,IQtyInvRepo
    {


        public QtyInvRepo(DataContext _context)
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

        public override QtyInv Get(int id)
        {
            return DataContext.QtyInvs
                .Include(qtyinvs => qtyinvs.InvStat)
                .Include(qtyinvs => qtyinvs.InvLocation)
                .Include(qtyinvs => qtyinvs.InvType)
                .FirstOrDefault(qtyinvs => qtyinvs.QtyInvID == id);

        }
        public  IEnumerable<QtyInv> GetAll_Criteria(string criteria)
        {
            //selective includes inside object
            // https://www.daniweb.com/programming/software-development/tutorials/495287/selective-includes-with-entity-framework#
            var qtyInvs = DataContext.QtyInvs
                .Include(rec => rec.InvLocation)
                .Include(rec => rec.InvType)
                .Include(rec => rec.InvStat)
                .Where(rec => rec.InvType.Description.Contains(criteria)
                    || rec.InvLocation.Description.Contains(criteria)).ToList();
            List<QtyInv> newQtyInvs = new List<QtyInv>();
            foreach (var item in qtyInvs)
            {

                item.InvRecCount = DataContext.InvRecords.Where(rec => rec.InvDetail.InvTypeID == item.InvTypeID && rec.InvLocationID == item.InvLocationID).Count();
                newQtyInvs.Add(item);
            }
            return newQtyInvs;

            
        }
        public IEnumerable<QtyInv> GetAll_CriteriaV1_1(string criteria)
        {
            var qtyInvs = DataContext.QtyInvs
                .Include(rec => rec.InvLocation)
                .Include(rec => rec.InvType)
                .Where(rec => rec.InvType.Description.Contains(criteria)
                    || rec.InvLocation.Description.Contains(criteria)).ToList();
            List<QtyInv> newQtyInvs = new List<QtyInv>();
            foreach (var item in qtyInvs)
            {

                item.InvRecCount = DataContext.InvRecords.Where(rec => rec.InvDetail.InvTypeID == item.InvTypeID && rec.InvLocationID == item.InvLocationID).Count();
                newQtyInvs.Add(item);
            }
            return newQtyInvs;
        }
        public QtyInv GetV1_1(int qtyInvID)
        {
            return DataContext.QtyInvs
                .Include(rec => rec.InvLocation)
                .Include(rec => rec.InvType)
                .FirstOrDefault(rec => rec.QtyInvID == qtyInvID);
        }




        public IEnumerable<QtyInv> GetAll_Criteria(string type, string location, string status)
        {
            var qtyInvs = DataContext.QtyInvs
                 .Include(rec => rec.InvLocation)
                 .Include(rec => rec.InvType)
                 .Include(rec => rec.InvStat)
                 .Where(rec => rec.InvType.Description.Contains(type)
                     && rec.InvLocation.Description.Contains(location)
                     && rec.InvStat.Description.Contains(status)).ToList();
            List<QtyInv> newQtyInvs = new List<QtyInv>();
            foreach (var item in qtyInvs)
            {

                item.InvRecCount = DataContext.InvRecords
                    .Where(rec => rec.InvDetail.InvTypeID == item.InvTypeID 
                        && rec.InvLocationID == item.InvLocationID
                        // updated to retrived previous records with null invStatID
                        && (rec.InvStat.Description == item.InvStat.Description || rec.Status == item.InvStat.Description)).Count();
                newQtyInvs.Add(item);
            }
            return newQtyInvs;
        }
    }
}

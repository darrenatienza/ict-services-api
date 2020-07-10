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
    public class InvDetailRepo : Repository<InvDetail>, IInvDetailRepo
    {


        public InvDetailRepo(DataContext _context)
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


        public IEnumerable<InvDetail> GetAll_Criteria(string criteria)
        {
            return DataContext.InvDetails.Include(rec => rec.InvType).Where(rec => rec.Description.Contains(criteria) || rec.InvType.Description.Contains(criteria));
        }


        public IEnumerable<InvDetail> GetAll(int invTypeID)
        {
            return DataContext.InvDetails.Where(rec => rec.InvTypeID == invTypeID);
        }
        public override InvDetail Get(int id)
        {
            return DataContext.InvDetails.Include(rec => rec.InvType).FirstOrDefault(rec => rec.InvDetailID == id);
        }


        public IEnumerable<InvDetail> GetAll_Criteria(string criteria, string type)
        {
            return DataContext.InvDetails.Include(rec => rec.InvType)
                .Where(rec => rec.InvType.Description.Contains(type) && rec.Description.Contains(criteria));
        }
    }
}

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
    public class InvStatRepo : Repository<InvStat>,IInvStatRepo
    {


        public InvStatRepo(DataContext _context)
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

        /// <summary>
        /// Get Inventory Status 
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public InvStat Get(string description)
        {
            return DataContext.InvStats.FirstOrDefault(r => r.Description == description);
        }
    }
}

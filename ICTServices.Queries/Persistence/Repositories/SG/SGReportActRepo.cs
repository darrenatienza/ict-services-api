using ICTServices.Queries.Core.Domain.SG;
using a = ICTServices.Queries.Core.IRepositories.ISGRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICTServices.Queries.Core.IRepositories.ISGRepo;

namespace ICTServices.Queries.Persistence.Repositories.SGRepo
{
    /// <summary>
    /// Security Guard Actions Repo
    /// </summary>
    public class SGReportActRepo: Repository<ReportAct>, ISGReportActRepo
    {
        public SGReportActRepo(DataContext context)
            :base(context)
        {
            
        }
    }
}

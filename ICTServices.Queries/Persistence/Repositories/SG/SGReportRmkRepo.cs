using ICTServices.Queries.Core.Domain.SG;
using ICTServices.Queries.Core.IRepositories.ISGRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTServices.Queries.Persistence.Repositories.SGRepo
{
    /// <summary>
    /// Security Guard Remarks Repo
    /// </summary>
    public class SGReportRmkRepo: Repository<ReportRmk>, ISGReportRmkRepo
    {
        public SGReportRmkRepo(DataContext context)
            :base(context)
        {

        }
    }
}

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
    /// Security Guard Description Repo
    /// </summary>
    public class SGReportDescRepo: Repository<ReportDesc>, ISGReportDescRepo
    {
        public SGReportDescRepo(DataContext context)
            :base(context)
        {

        }
    }
}

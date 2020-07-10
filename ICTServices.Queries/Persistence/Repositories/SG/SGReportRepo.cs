using API.Queries.Core.Domain.SG;
using API.Queries.Core.IRepositories.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace API.Queries.Persistence.Repositories.SG
{
    /// <summary>
    /// Security Guard Report Repo
    /// </summary>
    public class SGReportRepo : Repository<Report>, ISGReportRepo
    {
        public SGReportRepo(DataContext context)
            :base(context)
        {

        }
        public DataContext DataContext
        {
            get
            {
                return Context as DataContext;
            }
        }
        public IEnumerable<Report> GetAllReports()
        {
            return DataContext.SGReports;
        }


        public IEnumerable<Report> GetAllReports(DateTime dateFrom, DateTime dateTo)
        {
            return DataContext.SGReports.Where(r => DbFunctions.TruncateTime(r.Date) >= DbFunctions.TruncateTime(dateFrom) && DbFunctions.TruncateTime(r.Date) <= DbFunctions.TruncateTime(dateTo));
        }


        public Report GetLast()
        {
            return DataContext.SGReports.OrderByDescending(r => r.ReportID).FirstOrDefault();
        }
    }
}

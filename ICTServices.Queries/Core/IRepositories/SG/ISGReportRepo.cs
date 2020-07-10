using API.Queries.Core.Domain.SG;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.SG
{
    /// <summary>
    /// Security Guard Report Respository Interface
    /// </summary>
    public interface ISGReportRepo : IRepository<Report>
    {
        IEnumerable<Report> GetAllReports();

        IEnumerable<Report> GetAllReports(DateTime dateFrom, DateTime dateTo);

        Report GetLast();
    }
}

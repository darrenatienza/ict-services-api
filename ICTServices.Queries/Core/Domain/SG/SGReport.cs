using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.SG
{
    /// <summary>
    /// Security Guard Reports
    /// </summary>
    [Table("SG.Reports")]
    public class Report
    {
        public Report()
        {
            
        }
        public int ReportID { get; set; }
        public DateTime Date { get; set; }
        public string Desc { get; set; }
        public string Personnel { get; set; }
        public string Acts { get; set; }
        public string Rmks { get; set; }

    }
}

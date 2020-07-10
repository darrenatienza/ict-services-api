using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTServices.Queries.Core.Domain.SG
{
    /// <summary>
    /// Security Guards Actions
    /// </summary>
    [Table("SG.ReportActs")]
    public class ReportAct
    {
        public ReportAct()
        {

        }
        public int ReportActID { get; set;}
        public string Description { get; set; }
        public virtual Report Report { get; set; }
        public int ReportID { get; set; }
    }
}

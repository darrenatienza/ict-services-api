using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTServices.Queries.Core.Domain.SG
{
    /// <summary>
    /// Security Report Remarks
    /// </summary>
    [Table("SG.ReportRmks")]
    public class ReportRmk
    {
        public ReportRmk()
        {

        }

        public int ReportRmkID { get; set; }
        public string Description { get; set; }
        public virtual Report Report { get; set; }
        public int ReportID { get; set; }
    }
}

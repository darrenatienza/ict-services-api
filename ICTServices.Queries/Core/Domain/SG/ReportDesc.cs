using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTServices.Queries.Core.Domain.SG
{
    /// <summary>
    /// Security Guard Descriptions
    /// </summary>
    [Table("SG.ReportDescs")]
    public class ReportDesc
    {
        public ReportDesc()
        {

        }
        public int ReportDescID { get; set; }
        public virtual Report Report { get; set; }
        public int ReportID { get; set; }
        public string Description { get; set; }
    }
}

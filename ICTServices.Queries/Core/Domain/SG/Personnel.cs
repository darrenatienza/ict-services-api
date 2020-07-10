using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTServices.Queries.Core.Domain.SG
{
    /// <summary>
    /// Security Guard Personels
    /// </summary>
    [Table("SG.Personnels")]
    public class Personnel
    {
        public Personnel()
        {
            SGReports = new HashSet<Report>();
        }
        public int PersonnelID { get; set; }
        public string FullName { get; set; }
        public ICollection<Report> SGReports { get; set; }
    }
}

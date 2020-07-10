using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.Majors")]
    public class Major
    {
        public Major() { }
        public int MajorID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual Course Course { get; set; }
        public int CourseID { get; set; }
    }
}

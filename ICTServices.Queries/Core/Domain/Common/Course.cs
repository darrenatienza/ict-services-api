using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.Courses")]
    public class Course
    {
        public Course()
        {

        }
        public int CourseID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual College College { get; set; }
        public int CollegeID { get; set; }
    }
}

using API.Queries.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Person
{
    /// <summary>
    /// Student Records Class
    /// </summary>
    [Table("Person.Students")]
    public class Student
    {
        public Student()
        {

        }

        public int StudentID { get; set; }
        public string SrCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public virtual College College { get; set; }
        public int CollegeID { get; set; }
        public virtual Course Course { get; set; }
        public virtual int CourseID { get; set; }
        public virtual Major Major { get; set; }
        public int MajorID { get; set; }
        public string YearLevel { get; set; }
    }
}

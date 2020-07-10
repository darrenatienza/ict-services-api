using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.ERBS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Person
{
    [Table("Person.Employees")]
    public class Employee
    {
        private Office office;
        public Employee()
        {
 
            Reservations = new HashSet<Reservation>();
        }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual Office Office
        {
            get;
            set;
        }
        public int? OfficeID { get; set; }
        public virtual College College { get; set; }
        public int? CollegeID { get; set; }
        
        public virtual EmployeeType EmployeeType { get; set; }
        public int? EmployeeTypeID { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}

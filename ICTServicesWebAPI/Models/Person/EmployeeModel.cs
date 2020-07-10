using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Person
{
    public class EmployeeListDto
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string College { get; set; }
        public string Office { get; set; }

    }

}
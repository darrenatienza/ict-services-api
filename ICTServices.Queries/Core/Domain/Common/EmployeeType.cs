using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.EmployeeTypes")]
    public class EmployeeType
    {
        public int EmployeeTypeID { get; set; }
        public string Name { get; set; }
    }
}

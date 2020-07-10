using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.Colleges")]
    public class College
    {
        public College(){

        }
        public int CollegeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

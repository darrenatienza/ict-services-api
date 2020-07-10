
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.Locations")]
    public class Location
    {
        public Location()
        {

        }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public StudentReqType StudentReqType { get; set; }
        public int StudentReqTypeID { get; set; }
    }
}

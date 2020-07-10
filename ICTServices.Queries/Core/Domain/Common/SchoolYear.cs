using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    [Table("Common.SchoolYears")]
    public class SchoolYear
    {
        public SchoolYear()
        {

        }
        public int SchoolYearID { get; set; }
        public string Description { get; set; }
    }
}

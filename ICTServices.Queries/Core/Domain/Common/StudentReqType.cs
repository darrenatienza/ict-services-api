using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    /// <summary>
    /// Student Request Types Class
    /// </summary>
    [Table("Common.StudentReqTypes")]
    public class StudentReqType
    {
        public StudentReqType()
        {

        }
        public int StudentReqTypeID { get; set; }
        public string Description { get; set; }
    }
}

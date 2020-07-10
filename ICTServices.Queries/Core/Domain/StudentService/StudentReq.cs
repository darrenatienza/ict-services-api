using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.StudentService
{
    /// <summary>
    /// Student Request Class
    /// </summary>
    [Table("StudentService.StudentReqs")]
    public class StudentReq
    {
        public StudentReq()
        {

        }
        public int StudentReqID { get; set; }
        public Student Student { get; set; }
        public int StudentID { get; set; }
        /// <summary>
        /// Date when the record was generated
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Type of Request. Eg ID or Soft Copy of ID etc
        /// </summary>
        public virtual StudentReqType StudentReqType { get; set; }
        public int StudentReqTypeID { get; set; }
        /// <summary>
        /// Receipt Number if request need to pay
        /// </summary>
        public string ReceiptNum { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public int SchoolYearID { get; set; }
        public string Semester { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsClaimed { get; set; }
        /// <summary>
        /// Indicates where the request is located
        /// </summary>
        public virtual Location Location { get; set; }
        public int LocationID { get; set; }
        public DateTime ClaimedDate { get; set; }
        /// <summary>
        /// Reason For Request
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Other Details
        /// </summary>
        public string Remarks { get; set; }
        public bool isPrintReady { get; set; }

    }
}

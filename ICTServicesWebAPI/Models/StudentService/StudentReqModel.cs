using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.StudentService
{
    public class StudentReqModel
    {
        public StudentReqModel() { }


        public int StudentReqID { get; set; }
        public int StudentID { get; set; }
        public string StudentSrCode { get; set; }
        public string StudentFullName { get; set; }
        /// <summary>
        /// Date when the record was generated
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Type of Request. Eg ID or Soft Copy of ID etc
        /// </summary>
        public int StudentReqTypeID { get; set; }
        public string StudentReqTypeDescription { get; set; }
        /// <summary>
        /// Receipt Number if request need to pay
        /// </summary>
        public string ReceiptNum { get; set; }
        public int SchoolYearID { get; set; }
        public string SchoolYearDescription { get; set; }
        public string Semester { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsClaimed { get; set; }
        /// <summary>
        /// Indicates where the request is located
        /// </summary>
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

        public bool IsPrintReady { get; set; }
    }
}
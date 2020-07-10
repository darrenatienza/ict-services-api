using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Person
{
    public class StudentModel
    {
        public StudentModel() { }
        public int StudentID { get; set; }
        public string SrCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName {get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName +" "+ LastName; } }
        public int CollegeID { get; set; }
        public string CollegeDescription { get; set; }
        public int CourseID { get; set; }
        public string CourseDescription {  get; set; }
        public int MajorID { get; set; }
        public string MajorDescription {  get; set; }
        public string YearLevel { get; set; }

        public string CollegeCode {  get; set; }

        public string CourseCode {  get; set; }

        public string MajorCode {  get; set; }
    }
}
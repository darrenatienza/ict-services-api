using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Common
{
    public class CourseModel
    {
        public CourseModel() { }
        public int CourseID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
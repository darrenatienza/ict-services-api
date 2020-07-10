using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Common
{
    public class MajorModel
    {
        public MajorModel() { }
        public int MajorID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
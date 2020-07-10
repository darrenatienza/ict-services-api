using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Jwt.Models.Common;

namespace API.Jwt.Models.Common.v1
{
    public class LogListModel
    {
        public DateTime CreateDate { get; set; }

        public string Message { get; set; }

        public string UserBy { get; set; }
    }
    public class Obj
    {
        public string test { get; set; }
    }
    public class PostLogModel
    {
        public PostLogModel()
        {
            
        }
        public DateTime TimeStamp { get; set; }

        public string Message { get; set; }

        public object[] Additional { get; set; }
        
    }
}
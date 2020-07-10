using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1
{
    public class UserActivityLogListDto
    {
        public DateTime CreateTimeStamp { get; set; }

        public string User { get; set; }

        public string Message { get; set; }
    }
}
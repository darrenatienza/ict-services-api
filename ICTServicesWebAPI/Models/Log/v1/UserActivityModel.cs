using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Log.v1
{
    public class UserActivityModel
    {
        public string Action { get; set; }
        public string Message { get; set; }
        public Guid UserGuid { get; set; }
        public Guid RecordGuid { get; set; }
    }
}
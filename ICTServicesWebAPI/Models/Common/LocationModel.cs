using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Common
{
    public class LocationModel
    {
        public LocationModel()
        {

        }
        public int LocationID { get; set; }
        public string Description { get; set; }
    }
}
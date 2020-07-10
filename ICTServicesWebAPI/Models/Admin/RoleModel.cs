using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Admin
{
    public class RoleModel
    {
        public RoleModel()
        {

        }
        public int RoleID { get; set; }
        public string Description { get; set; }
    }
}
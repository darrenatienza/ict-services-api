using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1
{
    public class InvTypeModel
    {
        public InvTypeModel() { }


        public int InvTypeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v2
{
    public class InvDetailModel
    {
        public InvDetailModel() { }
        public int InvDetailID { get; set; }
        public string Description { get; set; }
        public int  InvTypeID { get; set; }
        public string Specs { get; set; }
        public string OtherDetails { get; set; }

        public string InvType_Description { get; set; }
    }
}
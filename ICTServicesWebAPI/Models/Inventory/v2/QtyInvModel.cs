using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v2
{
    public class QtyInvModel
    {
        public int QtyInvID { get; set; }
        public string InvLocation_Description { get; set; }
        public string InvType_Description { get; set; }
        public int Count { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_1
{
    public class ReadOneQtyInvModel 
    {
        public string Remarks { get; set; }
        public int QtyInvID { get; set; }
        public int Count { get; set; }
        public string InvLocation_Description { get; set; }
        public string InvType_Description { get; set; }
    }
    public class ReadAllQtyInvModel
    {
        public int QtyInvID { get; set; }
        public string InvLocation_Description { get; set; }
        public string InvType_Description { get; set; }
        public int Count { get; set; }
        public int InvRecCount { get; set; }
        public int Total
        {
            get
            {
                return Count + InvRecCount;
            }
        }
    }
   
    
}
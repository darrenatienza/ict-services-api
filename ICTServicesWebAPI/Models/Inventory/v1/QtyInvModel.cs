using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1
{
    public class ReadOneQtyInvModel 
    {

        public int QtyInvID { get; set; }
        public int InvLocationID { get; set; }
        public int InvTypeID { get; set; }
        public int Count { get; set; }
        public int InvRecCount { get; set; }
        public List<InvStatCountModel> InvStatCountModel { get; set; }
        public int Total
        {
            get
            {
                return Count + InvRecCount;
            }
        }
        public string Remarks { get; set; }

        public int? invStatID { get; set; }
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
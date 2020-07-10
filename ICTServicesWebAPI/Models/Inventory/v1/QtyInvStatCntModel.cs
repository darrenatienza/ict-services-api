using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1
{
    public class ReadOneQtyInvStatCntModel
    {

        public int QtyInvID { get; set; }
        public int InvLocationID { get; set; }
        public int InvTypeID { get; set; }
        public int Count { get; set; }
        public int InvRecCount { get; set; }
        public int Total
        {
            get
            {
                return Count + InvRecCount;
            }
        }
        public string Remarks { get; set; }
    }
    public class ReadAllQtyInvStatCntModel
    {

        public int Count { get; set; }

        public string InvStat_Description { get; set; }

        public int QtyInvStatCntID { get; set; }
    }
    
   
    
}
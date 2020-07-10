using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_2
{
    public class ReadAllQtyInvModel
    {
        public int QtyInvID { get; set; }
        public string InvLocation_Description { get; set; }
        public string InvType_Description { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Count from Inventory Records Table
        /// </summary>
        public int InvRecCount { get; set; } 
        public string InvStat_Description { get; set; }
        public int Total
        {
            get
            {
                return Count + InvRecCount;
            }
        }
    }
   
    
}
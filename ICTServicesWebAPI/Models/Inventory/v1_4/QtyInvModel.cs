using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_4
{
    public class ReadAllQtyInvModel
    {
        public ReadAllQtyInvModel()
        {
            UnRecInvStats = new List<ReadAllInvStatModel>();
            RecInvStats = new List<ReadAllInvStatModel>();
        }
        public int QtyInvID { get; set; }
        public string InvLocation_Description { get; set; }
        public string InvType_Description { get; set; }

        public List<ReadAllInvStatModel> UnRecInvStats { get; set; }
        public List<ReadAllInvStatModel> RecInvStats { get; set; }
        public int Total
        {
            get
            {
                return 0;
            }
        }

        
    }
    
   
    
}
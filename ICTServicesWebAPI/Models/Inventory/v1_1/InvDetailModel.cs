using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_1
{
    public class InvDetailModel
    {
        public InvDetailModel() { }
        public int InvDetailID { get; set; }
        public string Description { get; set; }
        public int  InvTypeID { get; set; }
        public string Specs { get; set; }
        public string ImageString { get; set; }
        public string OtherDetails { get; set; }


        public string InvType_Description { get; set; }
    }
    public class InvDetailListModel
    {
        public InvDetailListModel() { }
        public int InvDetailID { get; set; }
        public string Description { get; set; }
        public string Specs { get; set; }
        public string InvType_Description { get; set; }
    }
}
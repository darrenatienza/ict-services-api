using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_2
{
    public class InvDetailModel
    {
        public InvDetailModel() { }   
        public string Description { get; set; }


        public int InvDetailID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v2
{
    public class InvRecordModel
    {
        public InvRecordModel() { }
        public int InvRecordID { get; set; }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public int InvDetail_Description { get; set; }
        public int InvLocation_Description { get; set; }
        public int QtyInv_Description { get; set; }
        public DateTime DateAcquired { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_1_1
{
    public class InvRecordListDTO
    {
        public string InvLocation_Description;
        public string Status;

        public int InvRecordID { get; set; }

        public string PropertyNum { get; set; }

        public string EquipNum { get; set; }
    }
}
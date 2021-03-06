﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1
{
    public class InvRecordModel
    {
        public InvRecordModel() { }
        public int InvRecordID { get; set; }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public int InvDetailID { get; set; }
        public int InvLocationID { get; set; }
        public int QtyInvID { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
    public class ReadAllInvRecords
    {
        public ReadAllInvRecords() { }
        public int InvRecordID { get; set; }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public string InvLocation_Description { get; set; }
        public string Status { get; set; }
    }
}
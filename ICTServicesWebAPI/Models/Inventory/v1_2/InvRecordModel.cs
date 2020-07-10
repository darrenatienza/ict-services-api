using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.Inventory.v1_2
{
    public class InvRecordListModel
    {
        public InvRecordListModel() { }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public string InvType_Desc { get; set; }
        public string InvLoc_Desc { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Status { get; set; }

        public int InvRecordID { get; set; }

        public Guid? InvRecordGuid { get; set; }
    }
    public class InvRecordDetailDTO
    {
        public InvRecordDetailDTO() { }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public string InvType_Desc { get; set; }
        public string InvLoc_Desc { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Status { get; set; }

        public int InvRecordID { get; set; }

        public int InvLocationID { get; set; }

        public int InvDetailID { get; set; }

        public int InvTypeID1 { get; set; }

        public string Remarks { get; set; }

        public int? InvStatID { get; set; }

        public int InvTypeID { get; set; }

        public Guid? InvRecordGuid { get; set; }
    }
    public class AddInvRecordDTO
    {

        public AddInvRecordDTO() { }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Status { get; set; }
        public int InvDetailID { get; set; }
        public int InvLocationID { get; set; }
        public string Remarks { get; set; }
        public int InvStatID { get; set; }
    }
    public class EditInvRecordDTO
    {
        public EditInvRecordDTO() { }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Status { get; set; }
        public int InvStatID { get; set; }
        public int InvDetailID { get; set; }
        public int InvLocationID { get; set; }
        public string Remarks { get; set; }
 
    }
}
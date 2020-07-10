using API.Queries.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Inventory
{
    /// <summary>
    /// Inventory Records
    /// </summary>
    [Table("Inventory.InventoryRecords")]
    public class InvRecord
    {
        public InvRecord()
        {

        }
        public int InvRecordID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? InvRecordGUID { get; set; }
        public string PropertyNum { get; set; }
        public string EquipNum { get; set; }
        public virtual InvDetail InvDetail { get; set; }
        public int InvDetailID { get; set; }
        public virtual InvLocation InvLocation { get; set; }
        public int InvLocationID { get; set; }
        public virtual QtyInv QtyInv { get; set; }
        public int? QtyInvID { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Status { get; set; }
        public virtual InvStat InvStat { get; set; }
        public int? InvStatID { get; set; }
        public string Remarks { get; set; }

    }
}

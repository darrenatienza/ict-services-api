using API.Queries.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Inventory
    
{

    [Table("Inventory.QuantityInventory")]
    /// <summary>
    /// Inventory Records
    /// </summary>
    public class QtyInv
    {
        
        
        public QtyInv() {
            InvRecords = new HashSet<InvRecord>();
        }
        public int QtyInvID { get; set;}
      
        public Guid? IdentityID { get; set; }

        public int InvLocationID { get; set; }
        public int Count { get; set; }

        public virtual InvType InvType { get; set; }
        public int InvTypeID { get; set; }
        public virtual InvLocation InvLocation { get; set; }

        [NotMapped]
        public int InvRecCount { get; set; }

        public virtual InvStat InvStat { get; set; }
        public int? InvStatID { get; set; }

        public string Remarks { get; set; }
        public ICollection<InvRecord> InvRecords { get; set; }

    }
}

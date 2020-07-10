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
    /// Inventory Details
    /// </summary>
    [Table("Inventory.InventoryDetails")]
    public class InvDetail
    {
        public InvDetail()
        {
            InvRecords = new HashSet<InvRecord>();
        }
        public int InvDetailID { get; set; }
        public Guid? IdentityID { get; set; }
        public string Description { get; set; }
        public virtual InvType InvType { get; set; }
        public int InvTypeID { get; set; }
        public string Specs { get; set; }
        public string OtherDetails { get; set; }
        public IEnumerable<InvRecord> InvRecords { get; set; }
    }
}

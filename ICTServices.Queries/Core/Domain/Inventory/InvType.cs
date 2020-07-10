using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Common
{
    /// <summary>
    /// Inventory Types
    /// </summary>
    [Table("Inventory.InventoryTypes")]
    public class InvType
    {
        public InvType()
        {

        }
        public int InvTypeID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Inventory
{
    [Table("Inventory.InventoryStatus")]
    public class InvStat
    {
        public InvStat()
        {

        }
        public int InvStatID {get; set;}
        public string Description { get; set; }

    }
}

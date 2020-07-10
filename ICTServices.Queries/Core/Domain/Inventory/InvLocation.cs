using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.Inventory
{
    /// <summary>
    /// Inventory Locations
    /// </summary>
    [Table("Inventory.InventoryLocations")]
    public class InvLocation
    {
        public InvLocation()
        {

        }
        public int InvLocationID { get; set; }
        public string Description { get; set; }


    }
}

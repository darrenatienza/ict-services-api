using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.ERBS
{
    [Table("ERBS.Items")]
    public class Item
    {
        public Item() { }
        public int ItemID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

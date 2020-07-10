using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.ERBS
{
    [Table("ERBS.Venues")]
    public class Venue
    {
        public Venue() 
        {
            Reservations = new HashSet<Reservation>(); 
        }
        public int VenueID { get; set; }
        public string Description { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}

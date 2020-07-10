using API.Queries.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.Domain.ERBS
{
    [Table("ERBS.Reservations")]
    public class Reservation
    {
        public Reservation()
        {
            Venues = new HashSet<Venue>();
        }
        public int ReservationID { get; set; }
        public DateTime CreateTimeStamp { get; set; }
        public virtual Item Item { get; set; }
        public int ItemID { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        /// <summary>
        /// Start of reservation
        /// </summary>
        public DateTime DateTimeFrom { get; set; }
        /// <summary>
        /// End of reservation
        /// </summary>
        public DateTime DateTimeTo { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        /// <summary>
        /// Place where the equipment will use.
        /// </summary>
        public ICollection<Venue> Venues { get; set; }
    }
}

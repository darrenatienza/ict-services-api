using API.Queries.Core.Domain.ERBS;
using API.Queries.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Persistence.EntityConfiguration
{
    public class ReservationConfig : EntityTypeConfiguration<Reservation>
    {
        public ReservationConfig()
        {
            HasMany(u => u.Venues)
                 .WithMany(p => p.Reservations)
                 .Map(m =>
                 {

                     m.ToTable("VenueReservations", "ERBS");
                     m.MapLeftKey("ReservationID");
                     m.MapRightKey("VenueID");
                 });
        }
        
    }
}

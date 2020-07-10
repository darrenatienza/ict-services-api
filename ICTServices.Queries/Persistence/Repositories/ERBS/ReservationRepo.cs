using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.ERBS;
using API.Queries.Core.IRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace API.Queries.Persistence.Repositories.Common
{
    public class ReservationRepo : Repository<Reservation>, IReservationRepo
    {


        public ReservationRepo(DataContext _context)
            : base(_context)
        {
        }
        public DataContext DataContext
        {
            get
            {
                return Context as DataContext;
            }
        }
        

        public IEnumerable<Reservation> GetAllReservations()
        {
            return DataContext.Reservations
                .Include(r => r.Venues)
                .Include(r => r.Employee)
                .Include(r => r.Item);
        }


        public Reservation GetByReservationID(int reservationID)
        {
            return DataContext.Reservations.Include(r => r.Venues)
                .FirstOrDefault(r => r.ReservationID == reservationID);
        }
    }
}

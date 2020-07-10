using API.Queries.Core.Domain.Common;
using API.Queries.Core.Domain.ERBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Queries.Core.IRepositories.Common
{
    public interface IReservationRepo : IRepository<Reservation>
    {
        IEnumerable<Reservation> GetAllReservations();

        Reservation GetByReservationID(int reservationID);
    }
}

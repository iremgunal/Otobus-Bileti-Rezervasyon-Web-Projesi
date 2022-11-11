using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Data.Abstract
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<List<Trip>> GetTripsAsync(int fromWhereId, int toWhereId, DateTime tripDate);
    }
}

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
        int GetTrips(int tripId);
       public Task<Trip> GetSeatCapacity(int id);
        Task<Trip> GetBusInfo(int id);
        Task<Trip> GetTripById(int id);

        int GetSeats(int id);
        decimal GetPrice(int id);



    }
}

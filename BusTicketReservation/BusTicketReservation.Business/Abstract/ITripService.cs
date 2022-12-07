using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Abstract
{
    public interface ITripService
    {
        Task<Trip> GetByIdAsync(int id);
        Task<List<Trip>> GetAllAsync();
        Task CreateAsync(Trip trip);
        void Update(Trip trip);
        void Delete(Trip trip);
        Task<List<Trip>> GetTripsAsync(int fromWhereId , int toWhereId , DateTime tripDate);
        int GetTrips(int tripId);
       public Task<Trip> GetSeatCapacity(int id);
        Task<Trip> GetBusInfo(int id);
        Task<Trip> GetTripById(int id);
        int GetSeats(int id);
        decimal GetPrice(int id);

    }
}

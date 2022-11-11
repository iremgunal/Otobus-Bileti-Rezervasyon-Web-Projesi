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
        void Delete(int id);
        Task<List<Trip>> GetTripsAsync(int fromWhereId , int toWhereId , DateTime tripDate);

    }
}

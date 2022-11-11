using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Concrete
{
    public class TripManager : ITripService
    {
        private ITripRepository _tripRepository;

        public TripManager(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public Task CreateAsync(Trip trip)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await _tripRepository.GetAllAsync();
        }

        public Task<Trip> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Trip>> GetTripsAsync(int fromWhereId, int toWhereId, DateTime tripDate)
        {
            return await _tripRepository.GetTripsAsync(fromWhereId,  toWhereId,  tripDate);
        }

        public void Update(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task CreateAsync(Trip trip)
        {
            await _tripRepository.CreateAsync(trip);
        }

        public void Delete(Trip trip)
        {
            _tripRepository.Delete(trip);
        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await _tripRepository.GetAllAsync();
        }

        public async Task<Trip> GetBusInfo(int id)
        {
            return await _tripRepository.GetBusInfo(id);
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
          return  await _tripRepository.GetByIdAsync(id);
        }

        public decimal GetPrice(int id)
        {
          return  _tripRepository.GetPrice(id);
        }

        public async Task<Trip> GetSeatCapacity(int id)
        {
           return await _tripRepository.GetSeatCapacity(id);
        }

        public int GetSeats(int id)
        {
            return _tripRepository.GetSeats(id);
        }

        public async Task<Trip> GetTripById(int id)
        {
            return await _tripRepository.GetTripById(id);
        }

        public int GetTrips(int tripId)
        {
            return _tripRepository.GetTrips(tripId);
        }

        public async Task<List<Trip>> GetTripsAsync(int fromWhereId, int toWhereId, DateTime tripDate)
        {
            return await _tripRepository.GetTripsAsync(fromWhereId,  toWhereId,  tripDate);
        }

       

        public void Update(Trip trip)
        {
            _tripRepository.Update(trip);
        }
    }
}

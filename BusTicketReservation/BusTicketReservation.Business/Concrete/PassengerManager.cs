using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Concrete
{
    public class PassengerManager : IPassengerService
    {
        private IPassengerRepository _passengerRepository;

        public PassengerManager(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task CreateAsync(Passenger passenger)
        {
            await _passengerRepository.CreateAsync(passenger);
        }

        public async Task CreateAsync(Passenger passenger, int seatNumber, int id)
        {
            await _passengerRepository.CreateAsync(passenger, seatNumber, id);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Passenger>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Passenger> GetByIdAsync(int id)
        {
            return await _passengerRepository.GetByIdAsync(id);
        }

       

        public void Update(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}

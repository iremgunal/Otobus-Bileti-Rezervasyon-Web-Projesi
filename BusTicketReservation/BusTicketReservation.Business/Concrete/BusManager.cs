using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Concrete
{
    public class BusManager : IBusService
    {
        private IBusRepository _busRepository;

        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task CreateAsync(Bus bus)
        {
            await _busRepository.CreateAsync(bus);
        }

        public void Delete(Bus bus)
        {
            _busRepository.Delete(bus);
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            return await _busRepository.GetAllAsync();  
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            return await _busRepository.GetByIdAsync(id);
        }

        public int GetSeats(int id)
        {
            return _busRepository.GetSeats(id);
        }

        public void Update(Bus bus)
        {
             _busRepository.Update(bus);
        }
    }
}

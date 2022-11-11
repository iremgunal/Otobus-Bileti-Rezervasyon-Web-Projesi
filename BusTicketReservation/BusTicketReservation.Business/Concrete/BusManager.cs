using BusTicketReservation.Business.Abstract;
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
        public Task CreateAsync(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bus>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bus> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Bus bus)
        {
            throw new NotImplementedException();
        }
    }
}

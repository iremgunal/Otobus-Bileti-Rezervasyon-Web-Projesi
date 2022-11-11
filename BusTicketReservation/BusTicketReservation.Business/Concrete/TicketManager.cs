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
    public class TicketManager : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task CreateAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}

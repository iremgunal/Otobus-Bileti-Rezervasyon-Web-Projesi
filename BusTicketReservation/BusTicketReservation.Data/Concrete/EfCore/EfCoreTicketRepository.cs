using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Data.Concrete.EfCore
{
    public class EfCoreTicketRepository : EfCoreGenericRepository<Ticket> , ITicketRepository
    {
        public EfCoreTicketRepository(BusContext _dbContext) : base(_dbContext)
        {

        }
        private BusContext context
        {
            get
            {
                return _dbContext as BusContext;
            }
        }

        public async Task<Ticket> GetTicketDetails(int id)
        {
            return await context
                .Tickets
                .Where(t => t.TicketId == id)
                .Include(t => t.Trip)
                .Include(t => t.Passenger)
                .FirstOrDefaultAsync();
        }
       


        public async Task<Ticket> GetTicketByTrip(int id)
        {
            return await context
                .Tickets
                .Where(t => t.TripId == id)
                .FirstOrDefaultAsync();
        }

        public List<int> GetReservedSeat(int id)
        {
            return context.Tickets
               .Where(t => t.TripId == id)
               .Select(t => t.SeatNo)
               .ToList();
        }
    }
}

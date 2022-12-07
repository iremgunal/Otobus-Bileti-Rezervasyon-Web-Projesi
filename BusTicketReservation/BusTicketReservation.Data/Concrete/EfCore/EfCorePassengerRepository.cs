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
    public class EfCorePassengerRepository : EfCoreGenericRepository<Passenger> , IPassengerRepository
    {
        public EfCorePassengerRepository(BusContext _dbContext) : base(_dbContext)
        {

        }
        private BusContext context
        {
            get
            {
                return _dbContext as BusContext;
            }
        }

        public async Task CreateAsync(Passenger passenger, int seatNumber, int id)
        {
            await context.Passengers.AddAsync(passenger);
            await context.SaveChangesAsync();

            var ticket = context.Tickets
                .Select(ticket => new Ticket
                {
                    PassengerId = passenger.PassengerId,
                    TripId = id,
                    SeatNo = seatNumber,
                    BusId = id
                }).FirstOrDefault();
            await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();
        }

       
    }
}

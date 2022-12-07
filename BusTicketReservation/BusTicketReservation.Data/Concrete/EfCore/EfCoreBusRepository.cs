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
    public class EfCoreBusRepository : EfCoreGenericRepository<Bus> , IBusRepository
    {
        public EfCoreBusRepository(BusContext _dbContext) : base(_dbContext)
        {

        }
        private BusContext context
        {
            get
            {
                return _dbContext as BusContext;
            }
        }

        public int GetSeats(int id)
        {
            var result = context
              .Trips
              .Where(t=>t.TripId==id)
              .Include(t=>t.Bus)
              .FirstOrDefault();
            return result.Bus.SeatCapacity;
        }
    }
}

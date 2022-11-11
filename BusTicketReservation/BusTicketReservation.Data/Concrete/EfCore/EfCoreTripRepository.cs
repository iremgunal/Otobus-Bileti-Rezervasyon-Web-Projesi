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
    public class EfCoreTripRepository : EfCoreGenericRepository<Trip> , ITripRepository
    {
        public EfCoreTripRepository(BusContext _dbContext) : base(_dbContext)
        {

        }
        private BusContext context
        {
            get
            {
                return _dbContext as BusContext;
            }
        }

    
        public async Task<List<Trip>> GetTripsAsync(int fromWhereId, int toWhereId, DateTime tripDate)
        {
            return await context
                .Trips
                .Where(t => t.FromWhereId == fromWhereId && t.ToWhereId == toWhereId && t.TripDate == tripDate)
                .Include(t=>t.FromWhere)
                .Include(t=>t.ToWhere)                
                .ToListAsync();
        }
    }
}

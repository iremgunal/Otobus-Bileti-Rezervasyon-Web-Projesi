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

        public Task<Trip> GetBusInfo(int id)
        {
            throw new NotImplementedException();
        }

        public decimal GetPrice(int id)
        {
            return context
                .Trips
                .Where(t => t.TripId == id)
                .Select(t => t.Price)
                .FirstOrDefault();
        }

        public async Task<Trip> GetSeatCapacity(int id)
        {
            return await context
                .Trips
                .Where(t => t.TripId == id)
                .Include(t => t.Tickets)
                .Include(t => t.Bus)
                .FirstOrDefaultAsync();
        }

        public int GetSeats(int id)
        {
            var result = context
               .Trips
               .Where(t => t.TripId == id)
               .Include(t => t.Bus)
               .FirstOrDefault();
            return result.Bus.SeatCapacity;
        }

        public async Task<Trip> GetTripById(int id)
        {
            return await context
                 .Trips
                 .Where(t => t.TripId == id)
                 .Include(t => t.FromWhere)
                 .Include(t => t.ToWhere)
                 .FirstOrDefaultAsync();
        }

        public int GetTrips(int tripId)
        {
            return context
                .Trips
                .Where(t => t.TripId == tripId)
                .Include(t=>t.Tickets)
                .Include(t=>t.Bus.BusId)              
                .Select(t => t.Bus.SeatCapacity)                
                .FirstOrDefault();
                
            
                
                
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

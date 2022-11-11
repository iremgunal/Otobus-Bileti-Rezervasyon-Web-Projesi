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
    public class EfCoreCityRepository : EfCoreGenericRepository<City>, ICityRepository 
    {
        public EfCoreCityRepository(BusContext _dbContext) : base(_dbContext)
        {

        }
        private BusContext context
        {
            get
            {
                return _dbContext as BusContext;
            }
        }

        public async Task<List<City>> GellAllCitiesAsync(int id)
        {
            
            return await context
                .Set<City>()
                .ToListAsync();
        }
    }
}

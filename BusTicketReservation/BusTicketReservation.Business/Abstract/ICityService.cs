using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Abstract
{
    public interface ICityService
    {
        Task<City> GetByIdAsync(int id);
        Task<List<City>> GetAllAsync();

        Task CreateAsync(City city);
        void Update(City city);
        void Delete(City city);
        Task<List<City>> GellAllCitiesAsync(int id);
    }
}

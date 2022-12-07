using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Abstract
{
    public interface IBusService
    {
        Task<Bus> GetByIdAsync(int id);
        Task<List<Bus>> GetAllAsync();

        Task CreateAsync(Bus bus);
        void Update(Bus bus);
        void Delete(Bus bus);

        int GetSeats(int id);
    }
}

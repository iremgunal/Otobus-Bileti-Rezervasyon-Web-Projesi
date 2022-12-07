using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Data.Abstract
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        Task CreateAsync(Passenger passenger, int seatNumber, int id);


    }
}

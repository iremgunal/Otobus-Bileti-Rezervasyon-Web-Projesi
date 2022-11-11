using BusTicketReservation.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicketReservation.WebUI.Models
{
    public class TicketRouteModel
    {
        public List<City> Cities { get; set; }

        public int FromWhereId { get; set; }
        public int ToWhereId { get; set; }
        public DateTime TripDate { get; set; }

    }
}

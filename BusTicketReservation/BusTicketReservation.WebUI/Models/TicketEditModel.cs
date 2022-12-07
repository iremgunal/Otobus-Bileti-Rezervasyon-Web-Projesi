using BusTicketReservation.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicketReservation.WebUI.Models
{
    public class TicketEditModel
    {
        public int TicketId { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public Trip Trip { get; set; }
        public int TripId { get; set; }
        public int SeatNo { get; set; }
    }
}

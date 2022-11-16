using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Entity
{
    public class Ticket 
    {
        public int TicketId { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public Trip Trip { get; set; }
        public int TripId { get; set; }
        [Required()]
        public int SeatNo { get; set; }


    }
}

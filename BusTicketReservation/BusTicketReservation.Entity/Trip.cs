using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Entity
{
    public class Trip
    {
        
        public int TripId { get; set; }
        public DateTime TripTime { get; set; }
        public DateTime TripDate { get; set; }
        public int FromWhereId { get; set; }
        [ForeignKey("FromWhereId")]
        public City FromWhere { get; set; }
        public int ToWhereId { get; set; }
        [ForeignKey("ToWhereId")]
        public City ToWhere { get; set; }
        public decimal Price { get; set; }
        //public City City { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Bus Bus { get; set; }
        public int BusId { get; set; }
    }
}

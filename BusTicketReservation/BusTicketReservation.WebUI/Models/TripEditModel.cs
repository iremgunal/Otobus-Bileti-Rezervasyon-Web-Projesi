using BusTicketReservation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicketReservation.WebUI.Models
{
    public class TripEditModel
    {
        public List<City> Cities { get; set; }
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

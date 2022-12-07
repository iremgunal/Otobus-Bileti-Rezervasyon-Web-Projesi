using BusTicketReservation.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicketReservation.WebUI.Models
{
    public class TicketReservationModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public decimal Price { get; set; }
        public Trip Trip { get; set; }
        public Bus Bus { get; set; }
        public int BusId { get; set; }
        public int TripId { get; set; }
        public City FromWhere { get; set; }
        public City ToWhere { get; set; }
        public List<City> Cities { get; set; }
        [Required(ErrorMessage = "Card Number  is required.")]

        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Card Holder Name  is required.")]

        public string CardHolderName { get; set; }
        [Required(ErrorMessage = "Identity Number  is required.")]

        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "Expire Month  is required.")]

        public string ExpireMonth { get; set; }
        [Required(ErrorMessage = "Expire Year  is required.")]

        public string ExpireYear { get; set; }
        [Required(ErrorMessage = "Cvc  is required.")]

        public string Cvc { get; set; }
        public int FromWhereId { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime TripTime { get; set; }
        public int ToWhereId { get; set; }
        public int SeatCapacity { get; set; }
        [Required(ErrorMessage = "Please select seat.")]

        public int SeatNo { get; set; }
        public Ticket Ticket { get; set; }

    }
}

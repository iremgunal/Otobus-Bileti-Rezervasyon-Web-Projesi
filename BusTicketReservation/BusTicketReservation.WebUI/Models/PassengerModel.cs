using System.ComponentModel.DataAnnotations;

namespace BusTicketReservation.WebUI.Models
{
    public class PassengerModel
    {
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string PhoneNumber { get; set; }
    }
}

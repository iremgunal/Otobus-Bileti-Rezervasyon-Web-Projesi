using Microsoft.AspNetCore.Identity;


namespace BusTicketReservation.WebUI.Identity
{
    public class MyIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BusTicketReservation.WebUI.Models
{
    public class LoginModel

    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Entity
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }


    }
}

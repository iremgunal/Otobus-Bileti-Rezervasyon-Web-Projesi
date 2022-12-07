﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusTicketReservation.WebUI.Identity
{
    public class MyIdentityContext : IdentityDbContext<MyIdentityUser>
    {
        public MyIdentityContext(DbContextOptions<MyIdentityContext> options) : base(options)
        {

        }
    }
}

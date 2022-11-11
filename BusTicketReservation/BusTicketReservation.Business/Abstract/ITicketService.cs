﻿using BusTicketReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Business.Abstract
{
    public interface ITicketService
    {
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync();
        Task CreateAsync(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);

    }
}

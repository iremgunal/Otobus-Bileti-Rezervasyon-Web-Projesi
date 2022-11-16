using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Entity;
using BusTicketReservation.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BusTicketReservation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ITicketService _ticketService;
        private readonly IBusService _busService;
        private readonly ITripService _tripService;
        private readonly IPassengerService _passengerService;

        public HomeController(ICityService cityService, ITicketService ticketService,  IBusService busService, ITripService tripService, IPassengerService passengerService)
        {
            _cityService = cityService;
            _ticketService = ticketService;
            _busService = busService;
            _tripService = tripService;
            _passengerService = passengerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _cityService.GetAllAsync();

            TicketRouteModel ticketRouteModel = new TicketRouteModel()
            {
                Cities = result
            };
           
            return View(ticketRouteModel);

        }

        public async Task<IActionResult> TripList(TicketRouteModel ticketRouteModel)
        {
            if (ModelState.IsValid)
            {
               
                var tripList = await _tripService.GetTripsAsync(ticketRouteModel.FromWhereId , ticketRouteModel.ToWhereId , ticketRouteModel.TripDate);
               

                List<TripListModel> tripModel = tripList.Select(t => new TripListModel
                {
                    Price = t.Price,
                    TripTime = t.TripTime,
                    FromWhereId = t.FromWhereId,
                    ToWhereId = t.ToWhereId,
                    FromWhere = t.FromWhere,
                    ToWhere=t.ToWhere

                }).ToList();
                    return View(tripModel);        
               
                    

               
            }
            else
            {
                return View(null);
            }

            
        }
        public async Task<IActionResult> SeatSelect()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SeatSelect()
        //{


        //    return View();
        //}

     
        public IActionResult Passenger()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Passenger(PassengerModel passengerModel)
        {
            if (ModelState.IsValid)
            {
                Passenger passenger = new Passenger()
                {
                    FirstName = passengerModel.FirstName,
                    LastName = passengerModel.LastName,
                    Email = passengerModel.Email,
                    PhoneNumber = passengerModel.PhoneNumber
                };
                var result = _passengerService.CreateAsync(passenger);
                
            }
            return View(passengerModel);
        }

        //public async  Task<IActionResult> Ticket(PassengerModel passengerModel, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var tickets = await _passengerService.GetByIdAsync(id);
        //        TicketModel ticketModel = new TicketModel()
        //        {
        //            FirstName = tickets.FirstName,
        //            LastName = tickets.LastName,
        //            Email = tickets.Email,
        //            PhoneNumber = tickets.PhoneNumber
        //        };
        //        return View(ticketModel);
        //    }

        //    return View();
        //}

    }
}
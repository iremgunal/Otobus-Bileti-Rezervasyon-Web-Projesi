using BusTicketReservation.Business.Abstract;
using BusTicketReservation.WebUI.Identity;
using BusTicketReservation.Entity;
using BusTicketReservation.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BusTicketReservation.Core;
//using BusTicketReservation.Core;

namespace BusTicketReservation.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ITicketService _ticketService;
        private readonly IBusService _busService;
        private readonly ITripService _tripService;
        private readonly IPassengerService _passengerService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ICityService cityService, ITicketService ticketService, IBusService busService, ITripService tripService, IPassengerService passengerService, UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _cityService = cityService;
            _ticketService = ticketService;
            _busService = busService;
            _tripService = tripService;
            _passengerService = passengerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region RoleActions

        public async Task<IActionResult> RoleList()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = roleModel.Name };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Congratulations!", "The role has been successfully created.", "success");
                    return RedirectToAction("RoleList");
                }
            }
            return View(roleModel);
        }

        public async Task<IActionResult> RoleEdit(string id)
        {
            var users = await _userManager.Users.ToListAsync();
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<MyIdentityUser>();
            var nonMembers = new List<MyIdentityUser>();
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);              
            }
            RoleDetails roleDetails = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetails);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel roleEditModel)
        {
            if (ModelState.IsValid)
            {
                //Seçili role eklenecek userlar
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                //Seçili rolden çıkarılacak userlar
                foreach (var userId in roleEditModel.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return Redirect($"/Admin/RoleEdit/{roleEditModel.RoleId}");
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Delete Failed!", "There are users in this role, you need to delete the users first.", "danger");
                    return RedirectToAction("RoleList");
                }
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Successful!", "The deletion is complete.", "success");
            }
            return RedirectToAction("RoleList");
        }
        #endregion




        #region UserActions
        public async Task<IActionResult> UserList()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        public async Task<IActionResult> UserCreate()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles);
                    TempData["AlertMessage"] = Jobs.CreateMessage("Successful!", "User created successfully!", "success");
                    return RedirectToAction("UserList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return RedirectToAction("UserList"); }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                if (user != null)
                {
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.UserName = userModel.UserName;
                    user.Email = userModel.Email;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        userModel.SelectedRoles = userModel.SelectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, userModel.SelectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userModel.SelectedRoles).ToArray<string>());
                        TempData["AlertMessage"] = Jobs.CreateMessage("Successful!", "The registration has been successfully edited.", "success");
                        return RedirectToAction("UserList");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                    return View(userModel);
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("Error!", "No such user found!", "danger");
            }
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> ChangeUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = user.Id };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordModel changePasswordModel)
        {           

            var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
            var userPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, userPassToken, changePasswordModel.NewPassword);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Successful!", "Congratulations, the password has been changed", "success");
                return RedirectToAction("UserList");
            }
            return View(changePasswordModel);

        }

        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Successful!", "The deletion is complete.", "success");
            }
            return RedirectToAction("UserList");
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }


        #region Trip
        public async Task<IActionResult> AllTripList()
        {
            var trips = await _tripService.GetAllAsync();
            ViewBag.cities = await _cityService.GetAllAsync();
            return View(trips);
        }




        public async Task<IActionResult> TripEdit(int id)
        {
            var trip = await _tripService.GetSeatCapacity(id);
            var cities = await _cityService.GetAllAsync();
            TripEditModel tripEdit = new TripEditModel()
            {
                TripId = trip.TripId,
                TripDate = trip.TripDate,
                TripTime = trip.TripTime,
                FromWhere = trip.FromWhere,
                FromWhereId = trip.FromWhereId,
                ToWhereId = trip.ToWhereId,
                ToWhere = trip.ToWhere,
                Price = trip.Price,
                BusId = trip.BusId,
                Cities = cities
            };
            return View(tripEdit);
        }
        [HttpPost]
        public async Task<IActionResult> TripEdit(TripEditModel tripEdit)
        {
            if (ModelState.IsValid)
            {
                var trip = await _tripService.GetByIdAsync(tripEdit.TripId);

                if (trip == null)
                {
                    return NotFound();
                }
                trip.FromWhere = tripEdit.FromWhere;
                trip.ToWhere = tripEdit.ToWhere;
                trip.TripTime = tripEdit.TripTime;
                trip.TripDate = tripEdit.TripDate;
                trip.FromWhereId = tripEdit.FromWhereId;
                trip.ToWhereId = tripEdit.ToWhereId;
                trip.BusId = tripEdit.BusId;
                trip.Price = tripEdit.Price;

                _tripService.Update(trip);
                return RedirectToAction("AllTripList");
            }

            return View(tripEdit);
        }



        public async Task<IActionResult> TripCreate()
        {
            var cities = await _cityService.GetAllAsync();
            TripCreateModel tripCreate = new TripCreateModel()
            {

                Cities = cities
            };
            return View(tripCreate);

        }

        [HttpPost]
        public async Task<IActionResult> TripCreate(TripCreateModel tripCreate)
        {
            if (ModelState.IsValid)
            {

                Trip trip = new Trip()
                {
                    TripId = tripCreate.TripId,
                    FromWhere = tripCreate.FromWhere,
                    FromWhereId = tripCreate.FromWhereId,
                    ToWhereId = tripCreate.ToWhereId,
                    ToWhere = tripCreate.ToWhere,
                    TripTime = tripCreate.TripTime,
                    TripDate = tripCreate.TripDate,
                    BusId = tripCreate.BusId,
                    Price = tripCreate.Price,


                };
                await _tripService.CreateAsync(trip);
                return RedirectToAction("AllTripList");
            }

            return View(tripCreate);
        }





        public async Task<IActionResult> TripDelete(int id)
        {
            Trip trip = await _tripService.GetByIdAsync(id);
            if (trip != null)
            {
                _tripService.Delete(trip);
            }
            return RedirectToAction("AllTripList");
        }

        #endregion





        #region BusList
        public async Task<IActionResult> BusList()
        {
            var buses = await _busService.GetAllAsync();
            return View(buses);
        }
        #endregion

        #region BusEdit
        public async Task<IActionResult> BusEdit(int id)
        {
            var bus = await _busService.GetByIdAsync(id);
            BusEditModel busEdit = new BusEditModel()
            {
                BusId = bus.BusId,
                SeatCapacity = bus.SeatCapacity
            };
            return View(busEdit);
        }
        [HttpPost]
        public async Task<IActionResult> BusEdit(BusEditModel busEdit)
        {
            if (ModelState.IsValid)
            {
                var bus = await _busService.GetByIdAsync(busEdit.BusId);

                if (bus == null)
                {
                    return NotFound();
                }
                bus.SeatCapacity = busEdit.SeatCapacity;


                _busService.Update(bus);
                return RedirectToAction("BusList");
            }

            return View(busEdit);
        }

        #endregion

        #region BusCreate

        public IActionResult BusCreate()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BusCreate(BusEditModel busModel)
        {
            if (ModelState.IsValid)
            {

                Bus bus = new Bus()
                {
                    SeatCapacity = busModel.SeatCapacity
                };
                await _busService.CreateAsync(bus);
                return RedirectToAction("BusList");
            }

            return View(busModel);
        }

        #endregion

        #region BusDelete
        public async Task<IActionResult> BusDelete(int id)
        {
            Bus bus = await _busService.GetByIdAsync(id);
            if (bus != null)
            {
                _busService.Delete(bus);
            }
            return RedirectToAction("BusList");
        }

        #endregion

        #region CityList
        public async Task<IActionResult> CityList()
        {
            var city = await _cityService.GetAllAsync();
            return View(city);
        }

        #endregion

        #region CityEdit

        public async Task<IActionResult> CityEdit(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            CityEditModel cityModel = new CityEditModel()
            {
                CityId = city.CityId,
                CityName = city.CityName
            };
            return View(cityModel);
        }
        [HttpPost]
        public async Task<IActionResult> CityEdit(CityEditModel cityModel)
        {
            if (ModelState.IsValid)
            {
                var city = await _cityService.GetByIdAsync(cityModel.CityId);

                if (city == null)
                {
                    return NotFound();
                }
                city.CityName = cityModel.CityName;


                _cityService.Update(city);
                return RedirectToAction("CityList");
            }

            return View(cityModel);
        }
        #endregion

        #region CityCreate
        public IActionResult CityCreate()
        {

            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> CityCreate(CityEditModel cityModel)
        {
            if (ModelState.IsValid)
            {

                City city = new City()
                {
                    CityName = cityModel.CityName
                };
                await _cityService.CreateAsync(city);
                return RedirectToAction("CityList");
            }

            return View(cityModel);
        }

        #endregion

        #region CityDelete

        public async Task<IActionResult> CityDelete(int id)
        {
            City city = await _cityService.GetByIdAsync(id);
            if (city != null)
            {
                _cityService.Delete(city);
            }
            return RedirectToAction("CityList");
        }
        #endregion

        #region TicketList
        public async Task<IActionResult> TicketList()
        {
            var tickets = await _ticketService.GetAllAsync();
            return View(tickets);
           
        }

        //public async Task<IActionResult> TicketEdit(int id)
        //{
        //    var ticket = await _ticketService.GetByIdAsync(id);
        //    TicketEditModel ticketEdit = new TicketEditModel()
        //    {
        //        TicketId = ticket.TicketId,
        //        BusId = ticket.BusId,
        //        PassengerId = ticket.PassengerId,
        //        TripId = ticket.TripId,
        //        SeatNo = ticket.SeatNo
        //    };
        //    return View(ticketEdit);
        //}

        //[HttpPost]
        //public async Task<IActionResult> TicketEdit(TicketEditModel ticketEdit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var ticket = await _ticketService.GetByIdAsync(ticketEdit.TicketId);

        //        if (ticket == null)
        //        {
        //            return NotFound();
        //        }
        //        ticket.SeatNo = ticketEdit.SeatNo;
        //        ticket.BusId = ticketEdit.BusId;
        //        ticket.PassengerId = ticketEdit.PassengerId;
        //        ticket.TripId = ticketEdit.TripId;


        //        _ticketService.Update(ticket);
        //        return RedirectToAction("TicketList");
        //    }

        //    return View(ticketEdit);
        //}

        public async Task<IActionResult> TicketDelete(int id)
        {
            Ticket ticket = await _ticketService.GetByIdAsync(id);
            if (ticket != null)
            {
                _ticketService.Delete(ticket);
            }
            return RedirectToAction("TicketList");
        }

        #endregion



    }
}

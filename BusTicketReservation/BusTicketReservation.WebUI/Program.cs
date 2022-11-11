using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Business.Concrete;
using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BusContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddScoped<ICityRepository,EfCoreCityRepository>();

builder.Services.AddScoped<ITicketRepository, EfCoreTicketRepository>();
builder.Services.AddScoped<ITripRepository, EfCoreTripRepository>();
builder.Services.AddScoped<IBusRepository, EfCoreBusRepository>();
builder.Services.AddScoped<IPassengerRepository, EfCorePassengerRepository>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ITicketService, TicketManager>();

builder.Services.AddScoped<IBusService, BusManager>();
builder.Services.AddScoped<ITripService, TripManager>();
builder.Services.AddScoped<IPassengerService, PassengerManager>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

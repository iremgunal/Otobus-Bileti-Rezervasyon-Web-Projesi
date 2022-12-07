using BusTicketReservation.Business.Abstract;
using BusTicketReservation.Business.Concrete;
using BusTicketReservation.Data.Abstract;
using BusTicketReservation.Data.Concrete.EfCore;
using BusTicketReservation.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyIdentityContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<MyIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MyIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".BusTicketReservation.Security.Cookie"
    };

});



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

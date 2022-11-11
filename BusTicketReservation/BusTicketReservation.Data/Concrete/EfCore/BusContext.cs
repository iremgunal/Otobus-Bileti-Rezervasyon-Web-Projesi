using BusTicketReservation.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservation.Data.Concrete.EfCore
{
    public class BusContext : DbContext
    {
        public BusContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Trip> Trips { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder
                .Entity<City>()
                .HasData(

               new City() { CityId = 1, CityName = "İstanbul" },
               new City() { CityId = 2, CityName = "Kocaeli" },
               new City() { CityId = 3, CityName = "Düzce" },
               new City() { CityId = 4, CityName = "Samsun" },
               new City() { CityId = 5, CityName = "Ordu" },
               new City() { CityId = 6, CityName = "Antalya" },
               new City() { CityId = 7, CityName = "Afyon" },
               new City() { CityId = 8, CityName = "Kütahya" }

                );
            modelBuilder
                .Entity<Bus>()
                .HasData(
                new Bus() { BusId = 1, SeatCapacity = 40 },
                new Bus() { BusId = 2, SeatCapacity = 40 },
                new Bus() { BusId = 3, SeatCapacity = 40 },
                new Bus() { BusId = 4, SeatCapacity = 40 },
                new Bus() { BusId = 5, SeatCapacity = 40 },
                new Bus() { BusId = 6, SeatCapacity = 40 }
                );
            modelBuilder
                .Entity<Trip>()
                .HasData(
                new Trip() { TripId = 1, TripDate = new DateTime(2022, 12, 25), FromWhereId =1, ToWhereId = 5, Price = 100, BusId = 1 },
                new Trip() { TripId = 2, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 3, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 3, Price = 100, BusId = 1 },
                new Trip() { TripId = 4, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 4, Price = 100, BusId = 1 },
                new Trip() { TripId = 5, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 3, Price = 100, BusId = 1 },
                new Trip() { TripId = 6, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 4, Price = 100, BusId = 1 },
                new Trip() { TripId = 7, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 5, Price = 100, BusId = 1 },
                new Trip() { TripId = 8, TripDate = new DateTime(2022, 12, 25), FromWhereId = 3, ToWhereId = 4, Price = 100, BusId = 1 },
                new Trip() { TripId = 9, TripDate = new DateTime(2022, 12, 25), FromWhereId = 3, ToWhereId = 5, Price = 100, BusId = 1 },
                new Trip() { TripId = 10, TripDate = new DateTime(2022, 12, 25), FromWhereId = 4, ToWhereId = 5, Price = 100, BusId = 1 },
                new Trip() { TripId = 11, TripDate = new DateTime(2022, 12, 25), FromWhereId = 6, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 12, TripDate = new DateTime(2022, 12, 25), FromWhereId = 6, ToWhereId = 7, Price = 100, BusId = 1 },
                new Trip() { TripId = 13, TripDate = new DateTime(2022, 12, 25), FromWhereId = 6, ToWhereId = 8, Price = 100, BusId = 1 },
                new Trip() { TripId = 14, TripDate = new DateTime(2022, 12, 25), FromWhereId = 6, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 15, TripDate = new DateTime(2022, 12, 25), FromWhereId = 7, ToWhereId = 8, Price = 100, BusId = 1 },
                new Trip() { TripId = 16, TripDate = new DateTime(2022, 12, 25), FromWhereId = 7, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 17, TripDate = new DateTime(2022, 12, 25), FromWhereId = 7, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 18, TripDate = new DateTime(2022, 12, 25), FromWhereId = 8, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 19, TripDate = new DateTime(2022, 12, 25), FromWhereId = 8, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 20, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 21, TripDate = new DateTime(2022, 12, 25), FromWhereId = 5, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 22, TripDate = new DateTime(2022, 12, 25), FromWhereId = 5, ToWhereId = 4, Price = 100, BusId = 1 },
                new Trip() { TripId = 23, TripDate = new DateTime(2022, 12, 25), FromWhereId = 5, ToWhereId = 3, Price = 100, BusId = 1 },
                new Trip() { TripId = 24, TripDate = new DateTime(2022, 12, 25), FromWhereId = 5, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 25, TripDate = new DateTime(2022, 12, 25), FromWhereId = 4, ToWhereId = 3, Price = 100, BusId = 1 },
                new Trip() { TripId = 26, TripDate = new DateTime(2022, 12, 25), FromWhereId = 4, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 27, TripDate = new DateTime(2022, 12, 25), FromWhereId = 4, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 28, TripDate = new DateTime(2022, 12, 25), FromWhereId = 3, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 29, TripDate = new DateTime(2022, 12, 25), FromWhereId = 3, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 30, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 1, Price = 100, BusId = 1 },
                new Trip() { TripId = 31, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 6, Price = 100, BusId = 1 },
                new Trip() { TripId = 32, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 2, Price = 100, BusId = 1 },
                new Trip() { TripId = 33, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 8, Price = 100, BusId = 1 },
                new Trip() { TripId = 34, TripDate = new DateTime(2022, 12, 25), FromWhereId = 1, ToWhereId = 7, Price = 100, BusId = 1 },
                new Trip() { TripId = 35, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 8, Price = 100, BusId = 1 },
                new Trip() { TripId = 36, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 7, Price = 100, BusId = 1 },
                new Trip() { TripId = 37, TripDate = new DateTime(2022, 12, 25), FromWhereId = 2, ToWhereId = 6, Price = 100, BusId = 1 },
                new Trip() { TripId = 38, TripDate = new DateTime(2022, 12, 25), FromWhereId = 8, ToWhereId = 7, Price = 100, BusId = 1 },
                new Trip() { TripId = 39, TripDate = new DateTime(2022, 12, 25), FromWhereId = 8, ToWhereId = 6, Price = 100, BusId = 1 },
                new Trip() { TripId = 40, TripDate = new DateTime(2022, 12, 25), FromWhereId = 7, ToWhereId = 6, Price = 100, BusId = 1 }



                );



            modelBuilder
                .Entity<Passenger>()
                .HasData(
                new Passenger() { PassengerId = 1, FirstName = "İrem", LastName = "Günal", Email = "iremgunal@gmail.com", PhoneNumber = "01234567891" },
                new Passenger() { PassengerId = 2, FirstName = "Enver", LastName = "Korkmaz", Email = "enverkorkmaz17@gmail.com", PhoneNumber = "01234567892" }

                );
            modelBuilder
                .Entity<Ticket>()
                .HasData(
                new Ticket() { TicketId = 1, PassengerId = 1, BusId = 1, TripId = 1, SeatNo = 1 }
                );

        }
    }
}

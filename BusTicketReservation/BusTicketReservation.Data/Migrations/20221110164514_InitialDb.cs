using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketReservation.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeatCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TripDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FromWhereId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToWhereId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Cities_FromWhereId",
                        column: x => x.FromWhereId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Cities_ToWhereId",
                        column: x => x.ToWhereId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TripId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatNo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "SeatCapacity" },
                values: new object[] { 1, 40 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "SeatCapacity" },
                values: new object[] { 2, 40 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "SeatCapacity" },
                values: new object[] { 3, 40 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "SeatCapacity" },
                values: new object[] { 4, 40 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "SeatCapacity" },
                values: new object[] { 5, 40 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "BusId", "SeatCapacity" },
                values: new object[] { 6, 40 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 1, "İstanbul" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 2, "Kocaeli" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 3, "Düzce" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 4, "Samsun" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 5, "Ordu" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 6, "Antalya" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 7, "Afyon" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 8, "Kütahya" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "iremgunal@gmail.com", "İrem", "Günal", "01234567891" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "enverkorkmaz17@gmail.com", "Enver", "Korkmaz", "01234567892" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 1, 1, 1, 100m, 5, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 2, 1, 1, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 3, 1, 1, 100m, 3, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 4, 1, 1, 100m, 4, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 5, 1, 2, 100m, 3, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 6, 1, 2, 100m, 4, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 7, 1, 2, 100m, 5, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 8, 1, 3, 100m, 4, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 9, 1, 3, 100m, 5, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 10, 1, 4, 100m, 5, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 11, 1, 6, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 12, 1, 6, 100m, 7, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 13, 1, 6, 100m, 8, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 14, 1, 6, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 15, 1, 7, 100m, 8, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 16, 1, 7, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 17, 1, 7, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 18, 1, 8, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 19, 1, 8, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 20, 1, 2, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 21, 1, 5, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 22, 1, 5, 100m, 4, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 23, 1, 5, 100m, 3, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 24, 1, 5, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 25, 1, 4, 100m, 3, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 26, 1, 4, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 27, 1, 4, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 28, 1, 3, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 29, 1, 3, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 30, 1, 2, 100m, 1, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 31, 1, 1, 100m, 6, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 32, 1, 1, 100m, 2, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 33, 1, 1, 100m, 8, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 34, 1, 1, 100m, 7, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 35, 1, 2, 100m, 8, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 36, 1, 2, 100m, 7, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 37, 1, 2, 100m, 6, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 38, 1, 8, 100m, 7, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 39, 1, 8, 100m, 6, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "BusId", "FromWhereId", "Price", "ToWhereId", "TripDate", "TripTime" },
                values: new object[] { 40, 1, 7, 100m, 6, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "BusId", "PassengerId", "SeatNo", "TripId" },
                values: new object[] { 1, 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BusId",
                table: "Tickets",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_FromWhereId",
                table: "Trips",
                column: "FromWhereId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ToWhereId",
                table: "Trips",
                column: "ToWhereId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

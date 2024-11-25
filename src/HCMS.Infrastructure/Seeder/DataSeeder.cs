using HCMS.Domain.Entities;
using HCMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Seeder
{
    internal class DataSeeder : IDataSeeder
    {
        private readonly HCMSDbContext _context;

        public DataSeeder(HCMSDbContext context)
        {
            _context = context;
        }
        public async Task SeedData()
        {
            // Check if there are any shifts in the database
            if (!await _context.Shifts.AnyAsync())
            {
                // Create seasons if they don't exist
                var season1 = new Season
                {
                    SeasonId = Guid.NewGuid(),
                    Name = "2024 Spring Season",
                    StartDate = new DateOnly(2024, 3, 1),
                    EndDate = new DateOnly(2024, 6, 1),
                    Year = 2025,
                    LocationCity = "NS"

                };

                var season2 = new Season
                {
                    SeasonId = Guid.NewGuid(),
                    Name = "2024 Summer Season",
                    StartDate = new DateOnly(2024, 6, 1),
                    EndDate = new DateOnly(2024, 9, 1),
                    LocationCity = "NS",
                    Year = 2025
                };

                // Add the seasons to the context
                await _context.Seasons.AddRangeAsync(season1, season2);

                // Create shifts if they don't exist
                var shift1 = new Shift
                {
                    StartDate = new DateOnly(2024, 3, 1),
                    EndDate = new DateOnly(2024, 3, 10),
                    OrderNumber = 1,
                    NumberOfPlayers = 20,
                    SeasonId = season1.SeasonId
                };

                var shift2 = new Shift
                {
                    StartDate = new DateOnly(2024, 4, 1),
                    EndDate = new DateOnly(2024, 4, 10),
                    OrderNumber = 2,
                    NumberOfPlayers = 25,
                    SeasonId = season2.SeasonId
                };

                // Add the shifts to the context
                await _context.Shifts.AddRangeAsync(shift1, shift2);

                // Create players if they don't exist
                var player1 = new Player
                {
                    UserId = Guid.NewGuid(),
                    Name = "John",
                    Surname = "Doe",
                    Email = "john.doe@example.com",
                    Password = "password123", // Replace with a hashed password in production
                    PhoneNumber = "1234567890",
                    DateOfBirdth = new DateOnly(2000, 5, 10),
                    Gender = "Male",
                    HomeTown = "New York",
                    Position = "Forward",
                    TeamName = "Team A",
                    EquipmentSize = "M",
                    ParentEmail = "parent.john.doe@example.com",
                    ShiftApplications = new List<ShiftApplication>()
                };

                var player2 = new Player
                {
                    UserId = Guid.NewGuid(),
                    Name = "Jane",
                    Surname = "Smith",
                    Email = "jane.smith@example.com",
                    Password = "password123", // Replace with a hashed password in production
                    PhoneNumber = "0987654321",
                    DateOfBirdth = new DateOnly(2001, 8, 22),
                    Gender = "Female",
                    HomeTown = "Los Angeles",
                    Position = "Goalkeeper",
                    TeamName = "Team B",
                    EquipmentSize = "L",
                    ParentEmail = "parent.jane.smith@example.com",
                    ShiftApplications = new List<ShiftApplication>()
                };

                // Add the players to the context
                await _context.Users.AddRangeAsync(player1, player2);

                // Create applications linking players to shifts
                var application1 = new ShiftApplication
                {
                    PlayerId = player1.UserId,
                    ShiftId = shift1.ShiftId,
                    Player = player1,
                    Shift = shift1,
                    DateOfApply = DateOnly.FromDateTime(DateTime.Now),
                    StatusOfApplication = "Pending"
                };

                var application2 = new ShiftApplication
                {
                    PlayerId = player2.UserId,
                    ShiftId = shift2.ShiftId,
                    Player = player2,
                    Shift = shift2,
                    DateOfApply = DateOnly.FromDateTime(DateTime.Now),
                    StatusOfApplication = "Approved"
                };

                // Add the applications to the context
                await _context.ShiftApplications.AddRangeAsync(application1, application2);

                // Save changes asynchronously
                await _context.SaveChangesAsync();
            }
        }

    }
}


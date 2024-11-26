using HCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Persistence
{
    public class HCMSDbContext : DbContext 
    {
        public HCMSDbContext(DbContextOptions<HCMSDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CampEvent> CampEvents { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<ShiftApplication> ShiftApplications { get; set; }

        public DbSet<TestingRecord> TestingRecords { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Admin>("Admin")
                .HasValue<Coach>("Coach")
                .HasValue<Player>("Player");

            modelBuilder.Entity<Player>()
                .Property(p => p.EquipmentSize)
                .HasColumnName("EquipmentSize");
            modelBuilder.Entity<Coach>()
                .Property(p => p.EquipmentSize)
                .HasColumnName("EquipmentSize");
            modelBuilder.Entity<Player>()
                .Property(p => p.TeamName)
                .HasColumnName("TeamName");
            modelBuilder.Entity<Coach>()
                .Property(p => p.TeamName)
                .HasColumnName("TeamName");

            modelBuilder.Entity<Shift>()
                .HasOne(s => s.Season)
                .WithMany(se => se.Shifts)
                .HasForeignKey(s => s.SeasonId);

            modelBuilder.Entity<ShiftApplication>()
                .HasKey(a => new { a.PlayerId, a.ShiftId }); 

            modelBuilder.Entity<ShiftApplication>()
                .HasOne(a => a.Player)
                .WithMany(p => p.ShiftApplications)
                .HasForeignKey(a => a.PlayerId);

            modelBuilder.Entity<ShiftApplication>()
                .HasOne(a => a.Shift)
                .WithMany(s => s.ShiftApplications)
                .HasForeignKey(a => a.ShiftId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Shift)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.ShiftId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Player)
                .WithMany(p => p.Groups);

            modelBuilder.Entity<CampEvent>()
                .HasMany(e => e.Groups)
                .WithMany(g => g.CampEvents);

            modelBuilder.Entity<TestingRecord>()
                .HasOne(t => t.Player)
                .WithMany(P => P.TestingRecords)
                .HasForeignKey(t => t.PlayerId);
            modelBuilder.Entity<CampEvent>()
                .HasOne(e => e.Coach) 
                .WithMany(c => c.CampEvents) 
                .HasForeignKey(e => e.CoachId) 
                .OnDelete(DeleteBehavior.SetNull); 
        }

    }
}

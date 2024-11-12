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
        public DbSet<Event> Events { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Shift> Shifts { get; set; }

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
        }
    }
}

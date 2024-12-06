using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Repositories
{
    internal class CoachesRepository : ICoachesRepository
    {
        internal HCMSDbContext _context;
        public CoachesRepository(HCMSDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> UserWithEmailExists(string email)
        {
            var coach = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (coach == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public async Task<Guid> Create(Coach coach)
        {
            _context.Users.Add(coach);
            await _context.SaveChangesAsync();
            return coach.UserId;
        }

        public async Task Delete(Coach coach)
        {
            _context.Users.Remove(coach);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Coach>> GetAllAsync()
        {
            return await _context.Users
              .OfType<Coach>()
              .ToListAsync();
        }

        public async Task<Coach?> GetById(Guid id)
        {
            return await _context.Users
                .OfType<Coach>()
                .FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}

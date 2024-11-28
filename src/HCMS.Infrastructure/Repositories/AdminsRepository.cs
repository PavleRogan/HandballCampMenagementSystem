using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Repositories
{
    internal class AdminsRepository : IAdminsRepository
    {
        internal HCMSDbContext _context;
        public AdminsRepository(HCMSDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> AdminWithEmailExists(string email)
        {
            var admin = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (admin == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<Guid> Create(Admin admin)
        {
            _context.Users.Add(admin);
            await _context.SaveChangesAsync();
            return admin.UserId;
        }

        public async Task Delete(Admin admin)
        {

            _context.Users.Remove(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Users
              .OfType<Admin>()
              .ToListAsync();
        }

        public async Task<Admin?> GetById(Guid id)
        {
            return await _context.Users
                .OfType<Admin>()
                .FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

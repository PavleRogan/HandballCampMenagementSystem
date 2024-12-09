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
    internal class ShiftApplicationsRepository : IShiftApplicationsRepository
    {
        internal HCMSDbContext _context;
        public ShiftApplicationsRepository(HCMSDbContext context)
        {
            this._context = context;
        }
        public async Task<ShiftApplication> Create(ShiftApplication application)
        {
             _context.ShiftApplications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task Delete(ShiftApplication shiftApplication)
        {
            _context.ShiftApplications.Remove(shiftApplication);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShiftApplication>> GetAllAsync()
        {
            return await _context.ShiftApplications.ToListAsync();
        }

        public async Task<ShiftApplication?> GetByIds(Guid shiftId, Guid playerId)
        {
            return await _context.ShiftApplications
            .FirstOrDefaultAsync(sa => sa.ShiftId == shiftId && sa.PlayerId == playerId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

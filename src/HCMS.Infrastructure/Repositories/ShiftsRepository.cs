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
    internal class ShiftsRepository : IShiftsRepository
    {
        internal HCMSDbContext _context;
        public ShiftsRepository(HCMSDbContext context) {
            this._context = context;
        }
        public async Task<Guid> CreateAsync(Shift shift)
        {
            await _context.Shifts.AddAsync(shift);
            await _context.SaveChangesAsync();
            return shift.ShiftId;

        }

        public async Task DeleteAsync(Shift shift)
        {
             _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Shift>> GetAllAsync()
        {
            var shifts = await _context.Shifts.ToListAsync();
            return shifts;
        }

        public async Task<Shift?> GetByIdAsync(Guid shiftId)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.ShiftId == shiftId);
            return shift;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

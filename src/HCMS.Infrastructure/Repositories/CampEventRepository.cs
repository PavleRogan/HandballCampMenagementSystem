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
    internal class CampEventRepository : ICampEventsRepository
    {
        internal HCMSDbContext _context;
        public CampEventRepository(HCMSDbContext context)
        {
            this._context = context;
        }
        public async Task<Guid> Create(CampEvent campEvent)
        {
            _context.CampEvents.Add(campEvent);
            await _context.SaveChangesAsync();
            return campEvent.CampEventId;
        }

        public async Task Delete(CampEvent campEvent)
        {
            _context.CampEvents.Remove(campEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CampEvent>> GetAllAsync()
        {
            var ce = await _context.CampEvents.ToListAsync();
            return ce;
        }

        public async Task<IEnumerable<CampEvent>> GetByGroupId(Guid groupId)
        {
            return await _context.CampEvents
                           .Where(ce => ce.Groups.Any(g => g.GroupId == groupId)) 
                           .Include(ce => ce.Groups)  
                           .ToListAsync();
        }

        public async Task<CampEvent?> GetById(Guid id)
        {
            var ce = await _context.CampEvents.Include(ce => ce.Groups).FirstOrDefaultAsync(s => s.CampEventId == id);
            return ce;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

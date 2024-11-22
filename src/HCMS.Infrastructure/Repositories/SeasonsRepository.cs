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
    internal class SeasonsRepository : ISeasonsRepository
    {
        internal HCMSDbContext _context;
        public SeasonsRepository(HCMSDbContext context) {
            this._context = context;
        }
        public async Task<Guid> Create(Season season)
        {
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
            return season.SeasonId;
        }

        public async Task Delete(Season season)
        {
            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Season>> GetAllAsync()
        {
            var seasons = await _context.Seasons.ToListAsync();
            return seasons;
        }

        public async Task<Season?> GetById(Guid seasonId)
        {
            var season = await _context.Seasons.FirstOrDefaultAsync(s => s.SeasonId == seasonId);
            return season;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

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
    internal class PlayersRepository : IPlayersRepository
    {
        internal HCMSDbContext _context;
        public PlayersRepository(HCMSDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(Player player)
        {
            _context.Users.Remove(player);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Users
              .OfType<Player>()
              .ToListAsync();
        }

        public async Task<Player?> GetById(Guid id)
        {

            return await _context.Users
                .OfType<Player>() 
                .FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

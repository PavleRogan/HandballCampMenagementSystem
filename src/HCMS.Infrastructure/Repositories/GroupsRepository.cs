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
    internal class GroupsRepository : IGroupsRepository
    {
        internal HCMSDbContext _context;
        public GroupsRepository(HCMSDbContext context)
        {
            this._context = context;
        }

        public async Task AddPlayerToGroup(Group group, Player player)
        {
            group.Player.Add(player);

            await _context.SaveChangesAsync();

        }

        public async Task<Guid> Create(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group.GroupId;
        }

        public async Task Delete(Group group)
        {
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var groups = await _context.Groups.ToListAsync();
            return groups;
        }

        public async Task<Group?> GetById(Guid id)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(s => s.GroupId == id);
            return group;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

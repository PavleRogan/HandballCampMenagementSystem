using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface IGroupsRepository
    {
        Task<Guid> Create(Group group);
        Task<Group?> GetById(Guid id);
        Task<IEnumerable<Group>> GetAllAsync();
        Task SaveChangesAsync();
        Task Delete(Group group);

        Task AddPlayerToGroup(Group group,Player player);
    }
}

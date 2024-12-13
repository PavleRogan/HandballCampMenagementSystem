using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface IPlayersRepository
    {
        Task<Guid> Create(Player player);
        Task<Player?> GetById(Guid id);
        Task<IEnumerable<Player>> GetAllAsync();
        Task SaveChangesAsync();
        Task Delete(Player player);
    }
}

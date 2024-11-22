using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface ISeasonsRepository
    {
        Task<Guid> Create(Season season);
        Task<Season?> GetById(Guid seasonId);
        Task<IEnumerable<Season>> GetAllAsync();

        Task SaveChangesAsync();

        Task Delete(Season season);

    }
}

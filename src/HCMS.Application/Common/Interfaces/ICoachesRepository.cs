using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface ICoachesRepository
    {
        Task<Guid> Create(Coach coach);

        Task<Coach?> GetById(Guid id);
        Task<IEnumerable<Coach>> GetAllAsync();
        Task SaveChangesAsync();
        Task Delete(Coach coach);

        Task<bool> UserWithEmailExists(string email);
    }
}

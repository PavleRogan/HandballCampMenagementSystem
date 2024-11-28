using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface IAdminsRepository
    {
        Task<Guid> Create(Admin admin);

        Task<Admin?> GetById(Guid id);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task SaveChangesAsync();
        Task Delete(Admin admin);

        Task<bool> AdminWithEmailExists(string email);
    }
}

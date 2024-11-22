using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface IShiftsRepository
    {
        Task<Guid> CreateAsync(Shift shift);
        Task<Shift?> GetByIdAsync(Guid shiftId);
        Task<IEnumerable<Shift>> GetAllAsync();

        Task SaveChangesAsync();

        Task DeleteAsync(Shift shift);
    }
}

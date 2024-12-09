using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface IShiftApplicationsRepository
    {
        Task<ShiftApplication> Create(ShiftApplication application);
        Task<ShiftApplication?> GetByIds(Guid shiftId, Guid playerId);
        Task<IEnumerable<ShiftApplication>> GetAllAsync();

        Task SaveChangesAsync();

        Task Delete(ShiftApplication shiftApplication);
    }
}

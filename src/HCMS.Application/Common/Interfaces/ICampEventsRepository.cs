using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface ICampEventsRepository
    {
        Task<Guid> Create(CampEvent campEvent);
        Task<CampEvent?> GetById(Guid id);
        Task<IEnumerable<CampEvent>> GetAllAsync();

        Task<IEnumerable<CampEvent>> GetByGroupId(Guid groupId);
        Task SaveChangesAsync();
        Task Delete(CampEvent campEvent);
    }
}

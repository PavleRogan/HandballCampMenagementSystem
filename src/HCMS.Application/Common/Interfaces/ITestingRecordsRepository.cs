using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Common.Interfaces
{
    public interface ITestingRecordsRepository
    {
        Task<Guid> CreateAsync(TestingRecord record);
        Task<TestingRecord?> GetByIdAsync(Guid recordId);
        Task<IEnumerable<TestingRecord>> GetByPlayerIdAsync(Guid playerId);

        Task<IEnumerable<TestingRecord>> GetAllAsync();

        Task SaveChangesAsync();

        Task DeleteAsync(TestingRecord record);
    }
}

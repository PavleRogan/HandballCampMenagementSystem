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
    internal class TestingRecordsRepository : ITestingRecordsRepository
    {
        internal HCMSDbContext _context;
        public TestingRecordsRepository(HCMSDbContext context)
        {
            this._context = context;
        }

        public async Task<Guid> CreateAsync(TestingRecord record)
        {

            await _context.TestingRecords.AddAsync(record);
            await _context.SaveChangesAsync();
            return record.TestingRecordId;
        }

        public async Task DeleteAsync(TestingRecord record)
        {
            _context.TestingRecords.Remove(record);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TestingRecord>> GetAllAsync()
        {
            var records = await _context.TestingRecords.ToListAsync();
            return records;
        }

        public async Task<TestingRecord?> GetByIdAsync(Guid recordId)
        {
            var record = await _context.TestingRecords.FirstOrDefaultAsync(r => r.TestingRecordId == recordId);
            return record;
        }

        public async Task<IEnumerable<TestingRecord>> GetByPlayerIdAsync(Guid playerId)
        {
            var records = await _context.TestingRecords
                .Where(record => record.PlayerId == playerId)
                .ToListAsync();
            return records;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

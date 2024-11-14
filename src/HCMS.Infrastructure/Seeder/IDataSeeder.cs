using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Seeder
{
    public interface IDataSeeder
    {
        Task SeedData();
    }
}

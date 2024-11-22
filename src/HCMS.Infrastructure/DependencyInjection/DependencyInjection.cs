using HCMS.Application.Common.Interfaces;
using HCMS.Infrastructure.Persistence;
using HCMS.Infrastructure.Repositories;
using HCMS.Infrastructure.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HCMSDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDataSeeder, DataSeeder>();

            services.AddScoped<ISeasonsRepository,SeasonsRepository>();
            services.AddScoped<IShiftsRepository, ShiftsRepository>();


            return services;
        }
    }
}

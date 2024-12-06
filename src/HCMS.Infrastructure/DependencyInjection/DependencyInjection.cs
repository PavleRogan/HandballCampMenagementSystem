using HCMS.Application.Common.Interfaces;
using HCMS.Infrastructure.Helpers;
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
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
            });

            services.AddScoped<IDataSeeder, DataSeeder>();

            services.AddScoped<ISeasonsRepository,SeasonsRepository>();
            services.AddScoped<IShiftsRepository, ShiftsRepository>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<ICampEventsRepository, CampEventRepository>();
            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<IAdminsRepository, AdminsRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICoachesRepository, CoachesRepository>();



            return services;
        }
    }
}

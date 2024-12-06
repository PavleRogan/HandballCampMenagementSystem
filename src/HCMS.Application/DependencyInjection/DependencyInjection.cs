using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HCMS.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var appAssembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            });

            services.AddAutoMapper(appAssembly);

            services.AddValidatorsFromAssembly(appAssembly).AddFluentValidationAutoValidation();

            return services;

        } 
    }
}

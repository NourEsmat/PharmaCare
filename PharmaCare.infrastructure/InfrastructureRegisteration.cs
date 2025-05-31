using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PharmaCare.Core;
using PharmaCare.Core.Interfaces;
using PharmaCare.Core.Services;
using PharmaCare.infrastructure.Data;
using PharmaCare.infrastructure.Repositories;
using PharmaCare.infrastructure.Repositories.Service;

namespace PharmaCare.infrastructure
{
    public static class InfrastructureRegisteration
    {
        public static IServiceCollection infrastucrtureConfiguration(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IImageManagmentService, ImageManagmentService>();

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider
                (Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddDbContext<AppDBContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("PharmaCareDB"));

            });
            return services;
        }
    }
}

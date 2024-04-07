using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Core.Settings;
using RealEstate.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services, DatabaseConfigurationSettings configurationSettings)
        {
            services.AddDbContext<RealEstateDbContext>(options =>
                    options.UseSqlServer(configurationSettings.ConnectionString));

            services.AddScoped(typeof(EFRepository<>));

            services.AddScoped<IItemAttributeMappingRepository, ItemAttributeMappingRepository>();
            services.AddScoped<IItemAttributeRepository, ItemAttributeRepository>();
            services.AddScoped<IItemAttributeValueRepository, ItemAttributeValueRepository>();
            services.AddScoped<IItemImageRepository, ItemImageRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();


            return services;
        }
    }
}

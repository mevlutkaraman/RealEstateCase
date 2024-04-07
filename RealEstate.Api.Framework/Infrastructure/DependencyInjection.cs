using Microsoft.Extensions.DependencyInjection;
using RealEstate.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Api.Framework.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {


            services.AddScoped<IItemAttributeMappingService, ItemAttributeMappingService>();
            services.AddScoped<IItemAttributeService, ItemAttributeService>();
            services.AddScoped<IItemAttributeValueService, ItemAttributeValueService>();
            services.AddScoped<IItemService, ItemService>();

            return services;
        }
    }
}

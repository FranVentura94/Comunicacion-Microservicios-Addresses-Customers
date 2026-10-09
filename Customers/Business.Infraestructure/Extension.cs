using BuildingBlocks.Rest.Builders;
using BuildingBlocks.Rest.Extensions;
using BuildingBlocks.Rest.Interfaces.IServices;
using Business.Core.Interfaces.Services;
using Business.Infraestructure.ApiAddresses;
using Business.Infraestructure.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.Infraestructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRequestLogging(configuration);
            services.AddHttpClient<IRest, RestBuilder>(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30);
            });
            services.AddScoped<IAddressService, AddressService>();
            services.AddAutoMapper(config => config.AddProfile<MapperProfile>());
            return services;
        }
    }
}
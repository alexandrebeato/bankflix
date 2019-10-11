using AutoMapper;
using Bankflix.API.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bankflix.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfiguration.RegisterMappings());
        }
    }
}

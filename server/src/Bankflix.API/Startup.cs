using Agencia.Infra.CrossCutting.IoC;
using AutoMapper;
using Bankflix.API.Mapper;
using Bankflix.API.Models;
using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bankflix.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IUsuario, AspNetUser>();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            AutoMapperConfiguration.RegisterMappings();
            BootstrapperAgencia.RegistrarServicos(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

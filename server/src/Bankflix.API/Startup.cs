using Agencia.Infra.CrossCutting.DependencyRegistration;
using AutoMapper;
using Bankflix.API.Configurations;
using Bankflix.API.Mapper;
using Bankflix.API.Models;
using Clientes.Infra.CrossCutting.DependencyRegistration;
using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using Core.Domain.Repository;
using Core.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movimentacoes.Infra.CrossCutting.DependencyRegistration;

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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.ConfigurarAutenticacao();
            services.ConfigurarServicosFila();
            services.AddAutoMapper();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IUsuario, AspNetUser>();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IMongoSequenceRepository, MongoSequenceRepository>();
            services.AddHostedService<QueueHostedService>();
            AutoMapperConfiguration.RegisterMappings();
            BootstrapperAgencia.RegistrarServicos(services);
            BootstrapperClientes.RegistrarServicos(services);
            BootstrapperMovimentacoes.RegistrarServicos(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

using Clientes.Commands.Clientes;
using Clientes.Commands.Contas;
using Clientes.CommandStack.Clientes.Events;
using Clientes.CommandStack.Clientes.Handlers;
using Clientes.CommandStack.Contas.Handlers;
using Clientes.Domain.Clientes.Repository;
using Clientes.Domain.Contas.Repository;
using Clientes.Infra.Data.Mongo.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Infra.CrossCutting.DependencyRegistration
{
    public static class BootstrapperClientes
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();

            services.AddScoped<IRequestHandler<CadastrarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RecusarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<CriarContaCommand, bool>, ContaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarValorSaldoContaCommand, bool>, ContaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverValorSaldoContaCommand, bool>, ContaCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteCadastradoEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteAprovadoEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteRecusadoEvent>, ClienteEventHandler>();
        }
    }
}

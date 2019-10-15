using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Movimentacoes.Commands.Depositos;
using Movimentacoes.Commands.Movimentacoes;
using Movimentacoes.Commands.Transferencias;
using Movimentacoes.CommandStack.Depositos.Events;
using Movimentacoes.CommandStack.Depositos.Handlers;
using Movimentacoes.CommandStack.Movimentacoes.Handlers;
using Movimentacoes.CommandStack.Transferencias.Events;
using Movimentacoes.CommandStack.Transferencias.Handlers;
using Movimentacoes.Domain.Clientes.Repository;
using Movimentacoes.Domain.Contas.Repository;
using Movimentacoes.Domain.Depositos.Repository;
using Movimentacoes.Domain.Movimentacoes.Repository;
using Movimentacoes.Domain.Transferencias.Repository;
using Movimentacoes.Infra.Data.Mongo.Repository;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Infra.CrossCutting.IoC
{
    public class BootstrapperMovimentacoes
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IDepositoRepository, DepositoRepository>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();

            services.AddScoped<IRequestHandler<SolicitarDepositoCommand, bool>, DepositoCommandHandler>();
            services.AddScoped<IRequestHandler<EfetuarDepositoCommand, bool>, DepositoCommandHandler>();
            services.AddScoped<IRequestHandler<SolicitarTransferenciaCommand, bool>, TransferenciaCommandHandler>();
            services.AddScoped<IRequestHandler<EfetuarTransferenciaCommand, bool>, TransferenciaCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarMovimentacaoCommand, bool>, MovimentacaoCommandHandler>();

            services.AddScoped<INotificationHandler<DepositoSolicitadoEvent>, DepositoEventHandler>();
            services.AddScoped<INotificationHandler<TransferenciaSolicitadaEvent>, TransferenciaEventHandler>();
        }

        public static IEnumerable<Type> RegistrarComandosFila()
        {
            yield return typeof(EfetuarDepositoCommand);
            yield return typeof(EfetuarTransferenciaCommand);
        }
    }
}

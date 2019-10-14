using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Movimentacoes.Commands.Movimentacoes;
using Movimentacoes.CommandStack.Movimentacoes.Adapters;
using Movimentacoes.Domain.Clientes.Repository;
using Movimentacoes.Domain.Contas.Repository;
using Movimentacoes.Domain.Movimentacoes.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movimentacoes.CommandStack.Movimentacoes.Handlers
{
    public class MovimentacaoCommandHandler : CommandHandler, IRequestHandler<RegistrarMovimentacaoCommand, bool>
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;

        public MovimentacaoCommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IMovimentacaoRepository movimentacaoRepository, IContaRepository contaRepository, IClienteRepository clienteRepository) : base(mediator, notifications)
        {
            _movimentacaoRepository = movimentacaoRepository ?? throw new ArgumentNullException(nameof(movimentacaoRepository));
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public Task<bool> Handle(RegistrarMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.ObterPorId(request.ContaId);
            var cliente = _clienteRepository.ObterPorId(conta.ClienteId);
            var movimentacao = MovimentacaoAdapter.ToMovimentacao(request);
            movimentacao.DefinirConta(conta.Id, conta.Numero, conta.DigitoVerificador, cliente.Id, cliente.NomeCompleto, cliente.Cpf);
            movimentacao.DefinirVinculo(request.VinculadoId, request.TipoVinculo);

            if (!movimentacao.EstaConsistente())
            {
                NotificarValidacoesErro(movimentacao.ValidationResult);
                return Falha();
            }

            _movimentacaoRepository.Inserir(movimentacao);
            return Sucesso();
        }
    }
}

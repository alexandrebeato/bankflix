using Clientes.Commands.Contas;
using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Movimentacoes.Commands.Depositos;
using Movimentacoes.Commands.Movimentacoes;
using Movimentacoes.CommandStack.Depositos.Adapters;
using Movimentacoes.CommandStack.Depositos.Events;
using Movimentacoes.Domain.Clientes.Repository;
using Movimentacoes.Domain.Contas.Repository;
using Movimentacoes.Domain.Depositos.Repository;
using Movimentacoes.Domain.Movimentacoes.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movimentacoes.CommandStack.Depositos.Handlers
{
    public class DepositoCommandHandler : CommandHandler, IRequestHandler<SolicitarDepositoCommand, bool>,
                                                          IRequestHandler<EfetuarDepositoCommand, bool>
    {
        private readonly IDepositoRepository _depositoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuario _usuario;

        public DepositoCommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IDepositoRepository depositoRepository, IContaRepository contaRepository, IClienteRepository clienteRepository, IUsuario usuario) : base(mediator, notifications)
        {
            _depositoRepository = depositoRepository ?? throw new ArgumentNullException(nameof(depositoRepository));
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public Task<bool> Handle(SolicitarDepositoCommand request, CancellationToken cancellationToken)
        {
            if (request.ClienteId != _usuario.ObterAutenticadoId())
            {
                NotificarErro(nameof(request.ClienteId), "Não foi possível solicitar o depósito.");
                return Falha();
            }

            var cliente = _clienteRepository.ObterPorId(request.ClienteId);

            if (cliente == null)
            {
                NotificarErro(nameof(cliente), "Cliente inexistente.");
                return Falha();
            }

            var conta = _contaRepository.ObterPorCliente(cliente.Id);

            if (conta == null)
            {
                NotificarErro(nameof(conta), "O cliente não possuir conta.");
                return Falha();
            }

            var deposito = DepositoAdapter.ToDeposito(request);
            deposito.DefinirConta(conta.Id, conta.Numero, conta.DigitoVerificador, cliente.Id, cliente.NomeCompleto, cliente.Cpf);

            if (!deposito.EstaConsistente())
            {
                NotificarValidacoesErro(deposito.ValidationResult);
                return Falha();
            }

            _depositoRepository.Inserir(deposito);
            _mediator.RaiseEvent(DepositoAdapter.ToDepositoSolicitadoEvent(request));
            return Sucesso();
        }

        public async Task<bool> Handle(EfetuarDepositoCommand request, CancellationToken cancellationToken)
        {
            var deposito = _depositoRepository.ObterPorId(request.Id);
            await _mediator.SendCommand(new AdicionarValorSaldoContaCommand(deposito.Conta.Id, deposito.Valor));

            if (_notifications.HasNotifications())
            {
                deposito.Cancelar(string.Join("|", _notifications.GetNotifications()));
                _depositoRepository.Atualizar(deposito);
                return false;
            }

            deposito.Efetuar();
            _depositoRepository.Atualizar(deposito);
            await _mediator.SendCommand(new RegistrarMovimentacaoCommand(Guid.NewGuid(), deposito.Conta.Id, request.Id, TipoMovimentacao.Entrada, TipoVinculo.Deposito, deposito.Valor, DateTime.UtcNow));
            return true;
        }
    }
}

using Clientes.Commands.Contas;
using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Movimentacoes.Commands.Movimentacoes;
using Movimentacoes.Commands.Transferencias;
using Movimentacoes.CommandStack.Transferencias.Adapters;
using Movimentacoes.Domain.Clientes;
using Movimentacoes.Domain.Clientes.Repository;
using Movimentacoes.Domain.Contas;
using Movimentacoes.Domain.Contas.Repository;
using Movimentacoes.Domain.Movimentacoes.Enums;
using Movimentacoes.Domain.Transferencias.Repository;
using Movimentacoes.Domain.Transferencias.Validations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movimentacoes.CommandStack.Transferencias.Handlers
{
    public class TransferenciaCommandHandler : CommandHandler, IRequestHandler<SolicitarTransferenciaCommand, bool>,
                                                               IRequestHandler<EfetuarTransferenciaCommand, bool>
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;

        public TransferenciaCommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, ITransferenciaRepository transferenciaRepository, IContaRepository contaRepository, IClienteRepository clienteRepository) : base(mediator, notifications)
        {
            _transferenciaRepository = transferenciaRepository ?? throw new ArgumentNullException(nameof(transferenciaRepository));
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        private Cliente ObterClienteExistente(Guid id)
        {
            var cliente = _clienteRepository.ObterPorId(id);

            if (cliente != null)
                return cliente;

            NotificarErro(nameof(cliente), "Cliente inexistente.");
            return null;
        }

        private Conta ObterContaExistentePorCliente(Guid clienteId)
        {
            var conta = _contaRepository.ObterPorCliente(clienteId);

            if (conta != null)
                return conta;

            NotificarErro(nameof(conta), "Conta inexistente.");
            return null;
        }

        private Conta ObterContaExistentePorNumero(string numero, string digitoVerificador)
        {
            var conta = _contaRepository.ObterPorNumeroComDigitoVerificador(numero, digitoVerificador);

            if (conta != null)
                return conta;

            NotificarErro(nameof(conta), "Conta inexistente.");
            return null;
        }

        public Task<bool> Handle(SolicitarTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var clienteOrigem = ObterClienteExistente(request.ClienteOrigemId);

            if (clienteOrigem == null)
                return Falha();

            var contaOrigem = ObterContaExistentePorCliente(clienteOrigem.Id);

            if (contaOrigem == null)
                return Falha();

            var contaDestino = ObterContaExistentePorNumero(request.NumeroContaDestino, request.DigitoVerificadorContaDestino);

            if (contaDestino == null)
                return Falha();

            var clienteDestino = ObterClienteExistente(contaDestino.ClienteId);

            if (clienteDestino == null)
                return Falha();

            var transferencia = TransferenciaAdapter.ToTransferencia(request);
            transferencia.DefinirContaOrigem(contaOrigem.Id, contaOrigem.Numero, contaOrigem.DigitoVerificador, clienteOrigem.Id, clienteOrigem.NomeCompleto, clienteOrigem.Cpf);
            transferencia.DefinirContaDestino(contaDestino.Id, contaDestino.Numero, contaDestino.DigitoVerificador, clienteDestino.Id, clienteDestino.NomeCompleto, clienteDestino.Cpf);

            if (!transferencia.EstaConsistente())
            {
                NotificarValidacoesErro(transferencia.ValidationResult);
                return Falha();
            }

            transferencia.NewValidationResult(new TransferenciaEstaConsistenteParaCadastroValidation(transferencia, _contaRepository).Validate(transferencia));

            if (!transferencia.ValidationResult.IsValid)
            {
                NotificarValidacoesErro(transferencia.ValidationResult);
                return Falha();
            }

            _transferenciaRepository.Inserir(transferencia);
            _mediator.RaiseEvent(TransferenciaAdapter.ToTransferenciaSolicitadaEvent(request));
            return Sucesso();
        }

        public async Task<bool> Handle(EfetuarTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var transferencia = _transferenciaRepository.ObterPorId(request.Id);
            await _mediator.SendCommand(new RemoverValorSaldoContaCommand(transferencia.ContaOrigem.Id, transferencia.Valor));

            if (_notifications.HasNotifications())
            {
                transferencia.Recusar(string.Join("|", _notifications.GetNotifications()));
                _transferenciaRepository.Atualizar(transferencia);
                return false;
            }

            await _mediator.SendCommand(new AdicionarValorSaldoContaCommand(transferencia.ContaDestino.Id, transferencia.Valor));

            if (_notifications.HasNotifications())
            {
                await _mediator.SendCommand(new AdicionarValorSaldoContaCommand(transferencia.ContaOrigem.Id, transferencia.Valor));
                transferencia.Recusar(string.Join("|", _notifications.GetNotifications()));
                _transferenciaRepository.Atualizar(transferencia);
                return false;
            }

            transferencia.Efetuar();
            _transferenciaRepository.Atualizar(transferencia);
            await _mediator.SendCommand(new RegistrarMovimentacaoCommand(Guid.NewGuid(), transferencia.ContaOrigem.Id, TipoMovimentacao.Saida, TipoVinculo.Transferencia, transferencia.Valor, DateTime.UtcNow));
            await _mediator.SendCommand(new RegistrarMovimentacaoCommand(Guid.NewGuid(), transferencia.ContaDestino.Id, TipoMovimentacao.Entrada, TipoVinculo.Transferencia, transferencia.Valor, DateTime.UtcNow));
            return true;
        }
    }
}

using Clientes.Commands.Contas;
using Clientes.Domain.Contas;
using Clientes.Domain.Contas.Repository;
using Clientes.Domain.Contas.Validations;
using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.CommandStack.Contas.Handlers
{
    public class ContasCommandHandlers : CommandHandler, IRequestHandler<CriarContaCommand, bool>,
                                                         IRequestHandler<AdicionarValorSaldoContaCommand, bool>,
                                                         IRequestHandler<RemoverValorSaldoContaCommand, bool>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMongoSequenceRepository _mongoSequenceRepository;

        public ContasCommandHandlers(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IContaRepository contaRepository, IMongoSequenceRepository mongoSequenceRepository) : base(mediator, notifications)
        {
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
            _mongoSequenceRepository = mongoSequenceRepository ?? throw new ArgumentNullException(nameof(mongoSequenceRepository));
        }

        private Conta ObterContaExistente(Guid id)
        {
            var conta = _contaRepository.ObterPorId(id);

            if (conta != null)
                return conta;

            NotificarErro(nameof(conta), "Conta inexistente.");
            return null;
        }

        public Task<bool> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            var proximoNumeroConta = _mongoSequenceRepository.ObterProximoValor(typeof(Conta).Name);
            var numeroConta = proximoNumeroConta.ToString().PadLeft(10, '0');
            var digitoVerificador = new Random().Next(0, 10).ToString();
            var conta = Conta.Factory.CriarNovaConta(request.Id, request.ClienteId, numeroConta, digitoVerificador, request.DataHoraCriacao);

            if (!conta.EstaConsistente())
            {
                NotificarValidacoesErro(conta.ValidationResult);
                return Falha();
            }

            conta.NewValidationResult(new ContaEstaConsistenteParaCadastroValidation(conta, _contaRepository).Validate(conta));

            if (!conta.ValidationResult.IsValid)
            {
                NotificarValidacoesErro(conta.ValidationResult);
                return Falha();
            }

            _contaRepository.Inserir(conta);
            return Sucesso();
        }

        public Task<bool> Handle(AdicionarValorSaldoContaCommand request, CancellationToken cancellationToken)
        {
            var conta = ObterContaExistente(request.ContaId);

            if (conta == null)
                return Falha();

            conta.AdicionarValorSaldo(request.Valor);
            _contaRepository.Atualizar(conta);
            return Sucesso();
        }

        public Task<bool> Handle(RemoverValorSaldoContaCommand request, CancellationToken cancellationToken)
        {
            var conta = ObterContaExistente(request.ContaId);

            if (conta == null)
                return Falha();

            if (conta.SaldoDisponivel < request.Valor)
            {
                NotificarErro(nameof(request.Valor), "Saldo insuficiente.");
                return Falha();
            }

            conta.RemoverValorSaldo(request.Valor);
            _contaRepository.Atualizar(conta);
            return Sucesso();
        }
    }
}

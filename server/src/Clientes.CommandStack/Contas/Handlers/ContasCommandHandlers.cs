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
    public class ContasCommandHandlers : CommandHandler, IRequestHandler<CriarContaCommand, bool>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMongoSequenceRepository _mongoSequenceRepository;

        public ContasCommandHandlers(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IContaRepository contaRepository, IMongoSequenceRepository mongoSequenceRepository) : base(mediator, notifications)
        {
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
            _mongoSequenceRepository = mongoSequenceRepository ?? throw new ArgumentNullException(nameof(mongoSequenceRepository));
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
    }
}

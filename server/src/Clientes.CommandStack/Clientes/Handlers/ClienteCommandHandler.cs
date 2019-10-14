using Clientes.Commands.Clientes;
using Clientes.CommandStack.Clientes.Adapters;
using Clientes.Domain.Clientes;
using Clientes.Domain.Clientes.Repository;
using Clientes.Domain.Clientes.Validations;
using Core.Domain.CommandHandlers;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.CommandStack.Clientes.Handlers
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<CadastrarClienteCommand, bool>,
                                                         IRequestHandler<AprovarClienteCommand, bool>,
                                                         IRequestHandler<RecusarClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IClienteRepository clienteRepository) : base(mediator, notifications)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        private bool ValidarCliente(Cliente cliente)
        {
            if (cliente.EstaConsistente())
                return true;

            NotificarValidacoesErro(cliente.ValidationResult);
            return false;
        }

        private Cliente ObterClienteExistente(Guid id)
        {
            var cliente = _clienteRepository.ObterPorId(id);

            if (cliente != null)
                return cliente;

            NotificarErro(nameof(cliente), "Cliente inexistente.");
            return null;
        }

        public Task<bool> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = ClienteAdapter.ToCliente(request);

            if (!ValidarCliente(cliente))
                return Falha();

            cliente.NewValidationResult(new ClienteEstaConsistenteParaCadastroValidation(cliente, _clienteRepository).Validate(cliente));

            if (!cliente.ValidationResult.IsValid)
            {
                NotificarValidacoesErro(cliente.ValidationResult);
                return Falha();
            }

            _clienteRepository.Inserir(cliente);
            _mediator.RaiseEvent(ClienteAdapter.ToClienteCadastradoEvent(request));
            return Sucesso();
        }

        public Task<bool> Handle(AprovarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = ObterClienteExistente(request.Id);

            if (cliente == null)
                return Falha();

            cliente.Aprovar();

            if (!ValidarCliente(cliente))
                return Falha();

            _clienteRepository.Atualizar(cliente);
            _mediator.RaiseEvent(ClienteAdapter.ToClienteAprovadoEvent(request));
            return Sucesso();
        }

        public Task<bool> Handle(RecusarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = ObterClienteExistente(request.Id);

            if (cliente == null)
                return Falha();

            cliente.Recusar();

            if (!ValidarCliente(cliente))
                return Falha();

            _clienteRepository.Atualizar(cliente);
            _mediator.RaiseEvent(ClienteAdapter.ToClienteRecusadoEvent(request));
            return Sucesso();
        }
    }
}

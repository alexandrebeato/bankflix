using Clientes.Commands.Clientes;
using Clientes.CommandStack.Clientes.Events;
using Clientes.Domain.Clientes;

namespace Clientes.CommandStack.Clientes.Adapters
{
    public static class ClienteAdapter
    {
        public static Cliente ToCliente(CadastrarClienteCommand command) =>
            Cliente.Factory.CriarNovoCliente(command.Id, command.NomeCompleto, command.Cpf, command.DataNascimento, command.Email, command.Telefone, command.Senha, command.DataHoraCriacao);

        public static ClienteCadastradoEvent ToClienteCadastradoEvent(CadastrarClienteCommand command) =>
            new ClienteCadastradoEvent(command.Id);

        public static ClienteAprovadoEvent ToClienteAprovadoEvent(AprovarClienteCommand command) =>
            new ClienteAprovadoEvent(command.Id);

        public static ClienteRecusadoEvent ToClienteRecusadoEvent(RecusarClienteCommand command) =>
            new ClienteRecusadoEvent(command.Id);
    }
}

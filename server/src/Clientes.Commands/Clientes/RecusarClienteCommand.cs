using Core.Domain.Commands;
using System;

namespace Clientes.Commands.Clientes
{
    public class RecusarClienteCommand : Command
    {
        public RecusarClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}

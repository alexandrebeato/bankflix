using Core.Domain.Commands;
using System;

namespace Clientes.Commands.Clientes
{
    public class AprovarClienteCommand : Command
    {
        public AprovarClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

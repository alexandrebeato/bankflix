using Core.Domain.Commands;
using System;

namespace Movimentacoes.Commands.Transferencias
{
    public class EfetuarTransferenciaCommand : Command
    {
        public EfetuarTransferenciaCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

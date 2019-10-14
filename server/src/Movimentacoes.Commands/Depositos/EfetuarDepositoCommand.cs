using Core.Domain.Commands;
using System;

namespace Movimentacoes.Commands.Depositos
{
    public class EfetuarDepositoCommand : Command
    {
        public EfetuarDepositoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

using Core.Domain.Events;
using System;

namespace Movimentacoes.CommandStack.Depositos.Events
{
    public class DepositoSolicitadoEvent : Event
    {
        public DepositoSolicitadoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

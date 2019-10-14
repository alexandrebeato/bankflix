using Core.Domain.Events;
using System;

namespace Movimentacoes.CommandStack.Transferencias.Events
{
    public class TransferenciaSolicitadaEvent : Event
    {
        public TransferenciaSolicitadaEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

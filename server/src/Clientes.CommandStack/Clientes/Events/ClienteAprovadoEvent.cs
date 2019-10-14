using Core.Domain.Events;
using System;

namespace Clientes.CommandStack.Clientes.Events
{
    public class ClienteAprovadoEvent : Event
    {
        public ClienteAprovadoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

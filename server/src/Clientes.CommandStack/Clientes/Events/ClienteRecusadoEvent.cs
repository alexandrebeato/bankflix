using Core.Domain.Events;
using System;

namespace Clientes.CommandStack.Clientes.Events
{
    public class ClienteRecusadoEvent : Event
    {
        public ClienteRecusadoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

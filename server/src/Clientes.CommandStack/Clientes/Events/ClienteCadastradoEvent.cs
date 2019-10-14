using Core.Domain.Events;
using System;

namespace Clientes.CommandStack.Clientes.Events
{
    public class ClienteCadastradoEvent : Event
    {
        public ClienteCadastradoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

using MediatR;
using System;

namespace Core.Domain.Events
{
    public abstract class Event : Message, INotification
    {
        protected DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}

using Core.Domain.Events;
using System;

namespace Core.Domain.Commands
{
    public abstract class Command : Message
    {
        protected DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}

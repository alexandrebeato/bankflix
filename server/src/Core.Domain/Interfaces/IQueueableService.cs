using System;
using System.Collections.Generic;

namespace Core.Domain.Interfaces
{
    public interface IQueueableService
    {
        List<Type> Comandos { get; set; }
        void AdicionarComando(Type comando);
    }
}

using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Services
{
    public class QueueableService : IQueueableService
    {
        public QueueableService()
        {
            Comandos = new List<Type>();
        }

        public QueueableService(List<Type> comandos)
        {
            Comandos = comandos;
        }

        public QueueableService(IEnumerable<Type> comandos)
        {
            Comandos = comandos.ToList();
        }

        public List<Type> Comandos { get; set; }

        public void AdicionarComando(Type comando)
        {
            if (Comandos == null)
                Comandos = new List<Type>();

            if (Comandos.Contains(comando))
                return;

            Comandos.Add(comando);
        }
    }
}

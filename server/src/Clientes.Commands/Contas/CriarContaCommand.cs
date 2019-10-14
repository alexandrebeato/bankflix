using Core.Domain.Commands;
using System;

namespace Clientes.Commands.Contas
{
    public class CriarContaCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public CriarContaCommand(Guid id, Guid clienteId, DateTime dataHoraCriacao)
        {
            Id = id;
            ClienteId = clienteId;
            DataHoraCriacao = dataHoraCriacao;
        }
    }
}

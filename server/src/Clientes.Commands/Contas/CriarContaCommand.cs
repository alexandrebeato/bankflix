using Core.Domain.Commands;
using System;

namespace Clientes.Commands.Contas
{
    public class CriarContaCommand : Command
    {
        public CriarContaCommand(Guid id, Guid clienteId, DateTime dataHoraCriacao)
        {
            Id = id;
            ClienteId = clienteId;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public Guid ClienteId { get; }
        public DateTime DataHoraCriacao { get; }
    }
}

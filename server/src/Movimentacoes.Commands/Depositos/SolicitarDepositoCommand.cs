using Core.Domain.Commands;
using System;

namespace Movimentacoes.Commands.Depositos
{
    public class SolicitarDepositoCommand : Command
    {
        public SolicitarDepositoCommand(Guid id, Guid clienteId, long valor, DateTime dataHoraCriacao)
        {
            Id = id;
            ClienteId = clienteId;
            Valor = valor;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public Guid ClienteId { get; }
        public long Valor { get; }
        public DateTime DataHoraCriacao { get; }
    }
}

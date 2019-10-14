using Core.Domain.Commands;
using System;

namespace Movimentacoes.Commands.Depositos
{
    public class SolicitarDepositoCommand : Command
    {
        public SolicitarDepositoCommand(Guid id, long valor, DateTime dataHoraCriacao)
        {
            Id = id;
            Valor = valor;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public long Valor { get; }
        public DateTime DataHoraCriacao { get; }
    }
}

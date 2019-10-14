using Core.Domain.Commands;
using System;

namespace Movimentacoes.Commands.Transferencias
{
    public class SolicitarTransferenciaCommand : Command
    {
        public SolicitarTransferenciaCommand(Guid id, long valor, DateTime dataHoraCriacao)
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

using Movimentacoes.Domain.Movimentacoes.Enums;
using System;

namespace Movimentacoes.Commands.Movimentacoes
{
    public class RegistrarMovimentacaoCommand
    {
        public RegistrarMovimentacaoCommand(Guid id, Guid contaId, TipoMovimentacao tipoMovimentacao, TipoVinculo tipoVinculo, long valor, DateTime dataHoraCriacao)
        {
            Id = id;
            ContaId = contaId;
            TipoMovimentacao = tipoMovimentacao;
            TipoVinculo = tipoVinculo;
            Valor = valor;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public Guid ContaId { get; }
        public TipoMovimentacao TipoMovimentacao { get; }
        public TipoVinculo TipoVinculo { get; }
        public long Valor { get; }
        public DateTime DataHoraCriacao { get; }
    }
}

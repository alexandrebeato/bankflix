using Core.Domain.Commands;
using Movimentacoes.Domain.Movimentacoes.Enums;
using System;

namespace Movimentacoes.Commands.Movimentacoes
{
    public class RegistrarMovimentacaoCommand : Command
    {
        public RegistrarMovimentacaoCommand(Guid id, Guid contaId, Guid vinculadoId, TipoMovimentacao tipoMovimentacao, TipoVinculo tipoVinculo, long valor, DateTime dataHoraCriacao)
        {
            Id = id;
            ContaId = contaId;
            VinculadoId = vinculadoId;
            TipoMovimentacao = tipoMovimentacao;
            TipoVinculo = tipoVinculo;
            Valor = valor;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public Guid ContaId { get; }
        public Guid VinculadoId { get; }
        public TipoMovimentacao TipoMovimentacao { get; }
        public TipoVinculo TipoVinculo { get; }
        public long Valor { get; }
        public DateTime DataHoraCriacao { get; }
    }
}

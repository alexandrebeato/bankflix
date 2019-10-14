using Movimentacoes.Commands.Movimentacoes;
using Movimentacoes.Domain.Movimentacoes;

namespace Movimentacoes.CommandStack.Movimentacoes.Adapters
{
    public static class MovimentacaoAdapter
    {
        public static Movimentacao ToMovimentacao(RegistrarMovimentacaoCommand command) =>
            Movimentacao.Factory.CriarMovimentacao(command.Id, command.TipoMovimentacao, command.Valor, command.DataHoraCriacao);
    }
}

using Movimentacoes.Commands.Transferencias;
using Movimentacoes.CommandStack.Transferencias.Events;
using Movimentacoes.Domain.Transferencias;

namespace Movimentacoes.CommandStack.Transferencias.Adapters
{
    public static class TransferenciaAdapter
    {
        public static Transferencia ToTransferencia(SolicitarTransferenciaCommand command) =>
            Transferencia.Factory.CriarTransferencia(command.Id, command.Valor, command.DataHoraCriacao);

        public static TransferenciaSolicitadaEvent ToTransferenciaSolicitadaEvent(SolicitarTransferenciaCommand command) =>
            new TransferenciaSolicitadaEvent(command.Id);
    }
}

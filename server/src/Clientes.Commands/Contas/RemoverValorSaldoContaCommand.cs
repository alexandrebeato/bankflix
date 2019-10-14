using Core.Domain.Commands;
using System;

namespace Clientes.Commands.Contas
{
    public class RemoverValorSaldoContaCommand : Command
    {
        public RemoverValorSaldoContaCommand(Guid contaId, long valor)
        {
            ContaId = contaId;
            Valor = valor;
        }

        public Guid ContaId { get; }
        public long Valor { get; }
    }
}

using Clientes.Commands.Contas;
using Movimentacoes.Commands.Depositos;
using Movimentacoes.CommandStack.Depositos.Events;
using Movimentacoes.Domain.Depositos;
using System;

namespace Movimentacoes.CommandStack.Depositos.Adapters
{
    public static class DepositoAdapter
    {
        public static Deposito ToDeposito(SolicitarDepositoCommand command) =>
            Deposito.Factory.CriarDeposito(command.Id, command.Valor, command.DataHoraCriacao);

        public static DepositoSolicitadoEvent ToDepositoSolicitadoEvent(SolicitarDepositoCommand command) =>
            new DepositoSolicitadoEvent(command.Id);
    }
}

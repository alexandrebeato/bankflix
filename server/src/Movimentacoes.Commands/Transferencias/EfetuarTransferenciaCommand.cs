using System;

namespace Movimentacoes.Commands.Transferencias
{
    public class EfetuarTransferenciaCommand
    {
        public EfetuarTransferenciaCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

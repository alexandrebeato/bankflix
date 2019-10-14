using Core.Domain.Commands;
using System;

namespace Movimentacoes.Commands.Transferencias
{
    public class SolicitarTransferenciaCommand : Command
    {
        public SolicitarTransferenciaCommand(Guid id, Guid clienteOrigemId, string numeroContaDestino, string digitoVerificadorContaDestino, long valor, DateTime dataHoraCriacao)
        {
            Id = id;
            ClienteOrigemId = clienteOrigemId;
            NumeroContaDestino = numeroContaDestino;
            DigitoVerificadorContaDestino = digitoVerificadorContaDestino;
            Valor = valor;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public Guid ClienteOrigemId { get; }
        public string NumeroContaDestino { get; }
        public string DigitoVerificadorContaDestino { get; }
        public long Valor { get; }
        public DateTime DataHoraCriacao { get; }
    }
}

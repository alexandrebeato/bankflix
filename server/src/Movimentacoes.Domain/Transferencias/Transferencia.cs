using Core.Domain.Models;
using Movimentacoes.Domain.Transferencias.Enums;
using Movimentacoes.Domain.Transferencias.Validations;
using Movimentacoes.Domain.Transferencias.ValueObjects;
using System;

namespace Movimentacoes.Domain.Transferencias
{
    public class Transferencia : Entity<Transferencia>
    {
        private Transferencia() { }

        public Conta ContaOrigem { get; private set; }
        public Conta ContaDestino { get; private set; }
        public long Valor { get; private set; }
        public SituacaoTransferencia Situacao { get; private set; }
        public string MotivoRecusa { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public void DefinirContaOrigem(Guid contaId, string numero, string digitoVerificador, Guid clienteId, string nomeCompleto, string cpf) =>
            ContaOrigem = Conta.Factory.CriarConta(contaId, numero, digitoVerificador, clienteId, nomeCompleto, cpf);

        public void DefinirContaDestino(Guid contaId, string numero, string digitoVerificador, Guid clienteId, string nomeCompleto, string cpf) =>
            ContaDestino = Conta.Factory.CriarConta(contaId, numero, digitoVerificador, clienteId, nomeCompleto, cpf);

        public void Efetuar() => Situacao = SituacaoTransferencia.Efetuada;

        public void Recusar(string motivoRecusa)
        {
            Situacao = SituacaoTransferencia.Recusada;
            MotivoRecusa = motivoRecusa;
        }

        public override bool EstaConsistente()
        {
            ValidationResult = new TransferenciaEstaConsistenteValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static Transferencia CriarTransferencia(Guid id, long valor, DateTime dataHoraCriacao) =>
                new Transferencia
                {
                    Id = id,
                    Valor = valor,
                    Situacao = SituacaoTransferencia.Pendente,
                    MotivoRecusa = string.Empty,
                    DataHoraCriacao = dataHoraCriacao
                };
        }
    }
}

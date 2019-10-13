using Core.Domain.Models;
using Movimentacoes.Domain.Depositos.Enums;
using Movimentacoes.Domain.Depositos.Validations;
using Movimentacoes.Domain.Depositos.ValueObjects;
using System;

namespace Movimentacoes.Domain.Depositos
{
    public class Deposito : Entity<Deposito>
    {
        private Deposito() { }

        public Conta Conta { get; private set; }
        public long Valor { get; private set; }
        public SituacaoDeposito Situacao { get; private set; }
        public string MotivoCancelamento { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public void DefinirConta(Guid contaId, string numero, string digitoVerificador, Guid clienteId, string nomeCompleto, string cpf) =>
            Conta = Conta.Factory.CriarConta(contaId, numero, digitoVerificador, clienteId, nomeCompleto, cpf);

        public void Efetuar() => Situacao = SituacaoDeposito.Efetuado;

        public void Cancelar(string motivoCancelamento)
        {
            Situacao = SituacaoDeposito.Cancelado;
            MotivoCancelamento = motivoCancelamento;
        }

        public override bool EstaConsistente()
        {
            ValidationResult = new DepositoEstaConsistenteValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static Deposito CriarDeposito(Guid id, long valor, DateTime dataHoraCriacao) =>
                new Deposito
                {
                    Id = id,
                    Valor = valor,
                    Situacao = SituacaoDeposito.Pendente,
                    MotivoCancelamento = string.Empty,
                    DataHoraCriacao = dataHoraCriacao
                };
        }
    }
}

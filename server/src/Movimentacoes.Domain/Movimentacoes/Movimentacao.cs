using Core.Domain.Models;
using Movimentacoes.Domain.Movimentacoes.Enums;
using Movimentacoes.Domain.Movimentacoes.Validations;
using Movimentacoes.Domain.Movimentacoes.ValueObjects;
using System;

namespace Movimentacoes.Domain.Movimentacoes
{
    public class Movimentacao : Entity<Movimentacao>
    {
        public Movimentacao() { }

        public Conta Conta { get; private set; }
        public TipoMovimentacao Tipo { get; private set; }
        public Vinculo Vinculo { get; private set; }
        public long Valor { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public void DefinirConta(Guid contaId, string numero, string digitoVerificador, Guid clienteId, string nomeCompleto, string cpf) =>
            Conta = Conta.Factory.CriarConta(contaId, numero, digitoVerificador, clienteId, nomeCompleto, cpf);

        public void DefinirVinculo(Guid vinculadoId, TipoVinculo tipo) =>
            Vinculo = Vinculo.Factory.CriarVinculo(vinculadoId, tipo);

        public override bool EstaConsistente()
        {
            ValidationResult = new MovimentacaoEstaConsistenteValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static Movimentacao CriarMovimentacao(Guid id, TipoMovimentacao tipo, long valor, DateTime dataHoraCriacao) =>
                new Movimentacao
                {
                    Id = id,
                    Tipo = tipo,
                    Valor = valor,
                    DataHoraCriacao = dataHoraCriacao
                };
        }
    }
}

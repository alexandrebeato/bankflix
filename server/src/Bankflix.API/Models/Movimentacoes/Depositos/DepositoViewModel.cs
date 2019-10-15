using Movimentacoes.Domain.Depositos.Enums;
using System;

namespace Bankflix.API.Models.Movimentacoes.Depositos
{
    public class DepositoViewModel
    {
        public Guid Id { get; set; }
        public ContaViewModel Conta { get; set; }
        public long Valor { get; set; }
        public SituacaoDeposito Situacao { get; set; }
        public string MotivoCancelamento { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public decimal ValorEmReais
        {
            get
            {
                return Math.Round((decimal)Valor / 100, 2, MidpointRounding.AwayFromZero);
            }
        }
    }

    public class ContaViewModel
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }

    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
    }
}

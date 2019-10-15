using Movimentacoes.Domain.Transferencias.Enums;
using System;

namespace Bankflix.API.Models.Movimentacoes.Transferencias
{
    public class TransferenciaViewModel
    {
        public Guid Id { get; set; }
        public ContaViewModel ContaOrigem { get; set; }
        public ContaViewModel ContaDestino { get; set; }
        public long Valor { get; set; }
        public SituacaoTransferencia Situacao { get; set; }
        public string MotivoRecusa { get; set; }
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

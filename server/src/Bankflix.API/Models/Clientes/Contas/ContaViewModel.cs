using System;

namespace Bankflix.API.Models.Clientes.Contas
{
    public class ContaViewModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public long SaldoDisponivel { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public decimal SaldoDisponivelEmReais
        {
            get
            {
                return Math.Round((decimal)SaldoDisponivel / 100, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}

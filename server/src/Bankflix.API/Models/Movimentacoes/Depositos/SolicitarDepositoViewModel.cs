using System;
using System.ComponentModel.DataAnnotations;

namespace Bankflix.API.Models.Movimentacoes.Depositos
{
    public class SolicitarDepositoViewModel
    {
        public SolicitarDepositoViewModel()
        {
            Id = Guid.NewGuid();
            DataHoraCriacao = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "É obrigatório possuir um valor para depósito.")]
        public decimal Valor { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public long ValorEmCentavos
        {
            get
            {
                return (long)(Valor * 100);
            }
        }
    }
}

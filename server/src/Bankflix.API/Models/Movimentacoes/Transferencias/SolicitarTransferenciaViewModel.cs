using System;
using System.ComponentModel.DataAnnotations;

namespace Bankflix.API.Models.Movimentacoes.Transferencias
{
    public class SolicitarTransferenciaViewModel
    {
        public SolicitarTransferenciaViewModel()
        {
            Id = Guid.NewGuid();
            DataHoraCriacao = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ClienteOrigemId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o número da conta de destino.")]
        public string NumeroContaDestino { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o dígito verificador da conta de destino.")]
        public string DigitoVerificadorContaDestino { get; set; }

        [Required(ErrorMessage = "É obrigatório possuir um valor para transferir.")]
        public decimal Valor { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public long ValorEmCentavos
        {
            get
            {
                return (long)Math.Round(Valor, 2, MidpointRounding.AwayFromZero) * 100;
            }
        }
    }
}

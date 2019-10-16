using System;
using System.ComponentModel.DataAnnotations;

namespace Bankflix.API.Models.Movimentacoes.Movimentacoes
{
    public class PeriodoMovimentacoesViewModel
    {
        [Required(ErrorMessage = "É obrigatório possuir data inicial.")]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "É obrigatório possuir data final.")]
        public DateTime DataFinal { get; set; }
    }
}

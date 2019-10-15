using Movimentacoes.Domain.Movimentacoes.Enums;
using System;

namespace Bankflix.API.Models.Movimentacoes.Movimentacoes
{
    public class MovimentacaoViewModel
    {
        public Guid Id { get; set; }
        public ContaViewModel Conta { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public VinculoViewModel Vinculo { get; set; }
        public long Valor { get; set; }
        public DateTime DataHoraCriacao { get; set; }
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

    public class VinculoViewModel
    {
        public Guid VinculadoId { get; set; }
        public TipoVinculo Tipo { get; set; }
    }
}

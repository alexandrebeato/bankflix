using System;

namespace Bankflix.API.Models.Agencia
{
    public class AgenciaViewModel
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public DadosBancariosViewModel DadosBancarios { get; set; }
    }
}

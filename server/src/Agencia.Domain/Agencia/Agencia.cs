using Agencia.Domain.Agencia.Validations;
using Agencia.Domain.Agencia.ValueObjects;
using Core.Domain.Models;
using System;

namespace Agencia.Domain.Agencia
{
    public class Agencia : Entity<Agencia>
    {
        private Agencia() { }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string Senha { get; private set; }
        public DadosBancarios DadosBancarios { get; private set; }

        public void DefinirDadosBancarios(DadosBancarios dadosBancarios)
        {
            DadosBancarios = dadosBancarios;
        }

        public override bool EstaConsistente()
        {
            ValidationResult = new AgenciaEstaConsistenteValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static Agencia CriarAgenciaPadrao(Guid id, string razaoSocial, string nomeFantasia, string cnpj, string senha, long numeroAgencia, int digitoVerificador)
            {
                var dadosBancarios = DadosBancarios.Factory.CriarDadosBancarios(numeroAgencia, digitoVerificador);

                var agenciaPadrao = new Agencia
                {
                    Id = id,
                    RazaoSocial = razaoSocial,
                    NomeFantasia = nomeFantasia,
                    Cnpj = cnpj,
                    Senha = senha
                };

                agenciaPadrao.DefinirDadosBancarios(dadosBancarios);
                return agenciaPadrao;
            }
        }
    }
}

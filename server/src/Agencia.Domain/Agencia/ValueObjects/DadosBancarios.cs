using Core.Domain.ValueObjects;

namespace Agencia.Domain.Agencia.ValueObjects
{
    public class DadosBancarios : ValueObject<DadosBancarios>
    {
        private DadosBancarios() { }

        public string NumeroAgencia { get; private set; }
        public string DigitoVerificador { get; private set; }

        public static class Factory
        {
            public static DadosBancarios CriarDadosBancarios(string numeroAgencia, string digitoVerificador)
            {
                return new DadosBancarios
                {
                    NumeroAgencia = numeroAgencia,
                    DigitoVerificador = digitoVerificador
                };
            }
        }
    }
}

using Core.Domain.ValueObjects;

namespace Agencia.Domain.Agencia.ValueObjects
{
    public class DadosBancarios : ValueObject<DadosBancarios>
    {
        private DadosBancarios() { }

        public long NumeroAgencia { get; private set; }
        public int DigitoVerificador { get; private set; }

        public static class Factory
        {
            public static DadosBancarios CriarDadosBancarios(long numeroAgencia, int digitoVerificador)
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

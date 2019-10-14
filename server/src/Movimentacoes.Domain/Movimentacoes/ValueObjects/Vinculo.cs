using Core.Domain.ValueObjects;
using Movimentacoes.Domain.Movimentacoes.Enums;
using System;

namespace Movimentacoes.Domain.Movimentacoes.ValueObjects
{
    public class Vinculo : ValueObject<Vinculo>
    {
        private Vinculo() { }

        public Guid VinculadoId { get; private set; }
        public TipoVinculo Tipo { get; private set; }

        public static class Factory
        {
            public static Vinculo CriarVinculo(Guid vinculadoId, TipoVinculo tipo) =>
                new Vinculo
                {
                    VinculadoId = vinculadoId,
                    Tipo = tipo
                };
        }
    }
}

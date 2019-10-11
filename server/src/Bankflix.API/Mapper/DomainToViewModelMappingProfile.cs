using Agencia.Domain.Agencia.ValueObjects;
using AutoMapper;
using Bankflix.API.Models.Agencia;

namespace Bankflix.API.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            MapearContextoAgencia();
        }

        private void MapearContextoAgencia()
        {
            CreateMap<Agencia.Domain.Agencia.Agencia, AgenciaViewModel>();
            CreateMap<DadosBancarios, DadosBancariosViewModel>();
        }
    }
}

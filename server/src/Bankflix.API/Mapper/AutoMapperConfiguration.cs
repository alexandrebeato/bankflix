using AutoMapper;

namespace Bankflix.API.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(p =>
            {
                p.AddProfile(new DomainToViewModelMappingProfile());
                p.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}

using AutoMapper;

namespace view_models.Models
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            MapperConfiguration.CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
using AutoMapper;

namespace view_models.Models
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}
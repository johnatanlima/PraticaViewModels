
using AutoMapper;

namespace view_models.Models
{
    public class AutoMapperConfig{
    public static void RegisterMappings()
    {
        Mapper.Initialize(x =>
        {
            x.AddProfile<DomainToViewModelMappingProfile>();
            x.AddProfile<ViewModelToDomainMappingProfile>();
        });
    }
}
}
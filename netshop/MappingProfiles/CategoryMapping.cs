using AutoMapper;
using netshop.Dtos;
using netshop.Entities;

namespace netshop.MappingProfiles
{
  public class CategoryMapping : Profile
  {
    public CategoryMapping()
    {
      CreateMap<CategoryCreateDTO, CategoryEntity>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Created, o => o.MapFrom(s => DateTime.Now.Date));
    }
  }
}

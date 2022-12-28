using AutoMapper;
using netshop.Dtos;
using netshop.Entities;

namespace netshop.MappingProfiles
{
  public class ItemMappings : Profile
  {
    public ItemMappings()
    {
      CreateMap<ItemEntity, ItemDto>().ReverseMap();
      CreateMap<ItemCreateDto, ItemEntity>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId));
    }
  }
}

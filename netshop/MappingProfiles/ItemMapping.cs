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
    }
  }
}

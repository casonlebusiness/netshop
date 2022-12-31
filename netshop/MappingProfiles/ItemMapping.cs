using AutoMapper;
using netshop.Dtos;
using netshop.Entities;
using netshop.Helpers;

namespace netshop.MappingProfiles
{
  public class ItemMappings : Profile
  {
    public ItemMappings()
    {
      CreateMap<ItemEntity, ItemDto>().ReverseMap();
      CreateMap<ItemEntity, ItemDto>().ForMember(d => d.ImageURL, o => o.MapFrom(s => BlobExtension.GenerateBlobUrl(s.ImagePath!)));
      CreateMap<ItemCreateDto, ItemEntity>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId));
    }
  }
}

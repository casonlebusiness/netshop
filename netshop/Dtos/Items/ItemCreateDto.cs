using netshop.Entities;

namespace netshop.Dtos
{
  public class ItemCreateDto
  {
    public string? Name { get; set; }
    public string? CategoryId { get; set; }
  }
}
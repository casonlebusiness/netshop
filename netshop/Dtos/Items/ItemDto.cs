using netshop.Entities;

namespace netshop.Dtos
{
  public class ItemDto
  {
    public int Id;
    public string? Name { get; set; }
    public DateTime Created { get; set; }
    public CategoryEntity? Category { get; set; }
    public string? ImageURL { get; set; }
  }
}
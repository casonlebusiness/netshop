namespace netshop.Entities
{
  public class ItemEntity
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Created { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public string? ImagePath { get; set; }
  }
}

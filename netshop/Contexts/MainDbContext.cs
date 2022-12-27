using Microsoft.EntityFrameworkCore;
using netshop.Entities;

namespace netshop.DBContext
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> options)
            : base(options)
        {
        }

        public DbSet<FoodEntity> FoodItems { get; set; } = null!;
        public DbSet<ItemEntity> Items { get; set; } = null!;
    }
}

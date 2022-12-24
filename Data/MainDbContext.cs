using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace net_shop.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<MainDbContext> TodoItems { get; set; } = null!;
    }
}
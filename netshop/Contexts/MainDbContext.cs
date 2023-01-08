using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using netshop.Entities;
using samples.Models;

namespace netshop.DBContext
{
    public class MainDBContext : ApiAuthorizationDbContext<UserEntity>
    {
        public MainDBContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
        public DbSet<FoodEntity> FoodItems { get; set; } = null!;
        public DbSet<ItemEntity> Items { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
    }
}

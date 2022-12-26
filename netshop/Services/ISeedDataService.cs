using netshop.Repositories;

namespace netshop.Services
{
    public interface ISeedDataService
    {
        void Initialize(FoodDbContext context);
    }
}

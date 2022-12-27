using netshop.Repositories;
using netshop.DBContext;

namespace netshop.Services
{
    public interface ISeedDataService
    {
        void Initialize(MainDBContext context);
    }
}

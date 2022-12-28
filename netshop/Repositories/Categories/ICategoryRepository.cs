using netshop.Entities;
using netshop.Models;

namespace netshop.Repositories
{
    public interface ICategoryRepo
    {
        void Add(CategoryEntity item);
        bool Save();
    }
}

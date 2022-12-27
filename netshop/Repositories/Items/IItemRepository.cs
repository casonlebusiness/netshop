using netshop.Entities;
using netshop.Models;

namespace netshop.Repositories
{
    public interface IItemRepository
    {
        ItemEntity GetSingle(int id);
        void Add(ItemEntity item);
        void Delete(int id);
        ItemEntity Update(int id, ItemEntity item);
        IQueryable<ItemEntity> GetAll(QueryParameters queryParameters);
        int Count();
        bool Save();
    }
}

using netshop.Entities;
using netshop.Helpers;
using netshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using netshop.DBContext;

namespace netshop.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MainDBContext _mainDBContext;

        public ItemRepository(MainDBContext foodDbContext)
        {
            _mainDBContext = foodDbContext;
        }

        public ItemEntity GetSingle(int id)
        {
            return _mainDBContext.Items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ItemEntity item)
        {
            _mainDBContext.Items.Add(item);
        }

        public void Delete(int id)
        {
            ItemEntity foodItem = GetSingle(id);
            _mainDBContext.Items.Remove(foodItem);
        }

        public ItemEntity Update(int id, ItemEntity item)
        {
            _mainDBContext.Items.Update(item);
            return item;
        }

        public IQueryable<ItemEntity> GetAll(QueryParameters queryParameters)
        {
            IQueryable<ItemEntity> _allItems = _mainDBContext.Items.OrderBy(queryParameters.OrderBy,
              queryParameters.IsDescending());

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        public int Count()
        {
            return _mainDBContext.Items.Count();
        }

        public bool Save()
        {
            return (_mainDBContext.SaveChanges() >= 0);
        }
    }
}

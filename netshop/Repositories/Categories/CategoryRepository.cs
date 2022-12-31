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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MainDBContext _mainDBContext;

        public CategoryRepo(MainDBContext mainDBContext)
        {
            _mainDBContext = mainDBContext;
        }

        public void Add(CategoryEntity category)
        {
            _mainDBContext.Categories.Add(category);
        }

        public CategoryEntity GetSingle(int id) {
          
            CategoryEntity foundRecord = _mainDBContext.Categories.FirstOrDefault(category => category.Id == id);
            if (foundRecord == null) {
                throw new Exception();
            }
            return foundRecord;
        } 

        public bool Save()
        {
            return (_mainDBContext.SaveChanges() >= 0);
        }
    }
}

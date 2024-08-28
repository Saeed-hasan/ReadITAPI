using ReadITAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ReadITAPI.Repository
{
    public class categoryRepository : IcategoryRepository
    {
        private readonly MyDbContext _mydbconnection;
        public categoryRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }
        public List<Category> GetAll()
        {
           var cat1 = _mydbconnection.categories.ToList();
            return cat1;
        }
        public Category Include(int id)
        {
            var category = _mydbconnection.categories.Include(c => c.Books).FirstOrDefault(c => c.category_id == id);
            if (category != null)
            {
                return (category);
            }
            return null;
        }
        public Category Get(int id)
        {
            Category? cat1 = _mydbconnection.categories.Where(c => c.category_id == id).FirstOrDefault();
            if(cat1 != null)
            {
                return cat1;
            }
            return null;
        }
        public void Add(Category category)
        {
            _mydbconnection.categories.Add(category);
            _mydbconnection.SaveChanges();
        }
        public void Remove(Category category)
        {
            Category? cat1 = _mydbconnection.categories.Where(c => c.category_id == category.category_id).FirstOrDefault();
            if (cat1 != null)
            {
                _mydbconnection.categories.Remove(cat1);
                _mydbconnection.SaveChanges();
            }
        }
        public void Edit(Category category)
        {
            Category? categoryInDB = _mydbconnection.categories.Where(c => c.category_id == category.category_id).FirstOrDefault();
            if( categoryInDB != null )
            {
                categoryInDB.category_name = category.category_name;
                category.Books = categoryInDB.Books;
                _mydbconnection.categories.Update(categoryInDB);
                _mydbconnection.SaveChanges();
            }
        }
    }
}

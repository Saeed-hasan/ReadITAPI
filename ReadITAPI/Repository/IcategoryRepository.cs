using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IcategoryRepository : IRepository<Category>
    {
        public void Edit(Category category);
        public Category Include(int id);
    }
}

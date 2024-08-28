using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IbookRepository : IRepository<Book>
    {
        public bool Edit(Book book);
    }
}

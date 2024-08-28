using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public class bookRepository : IbookRepository
    {
        private readonly MyDbContext _mydbconnection;
        public bookRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }

        public List<Book> GetAll()
        {
            var book1 = _mydbconnection.books.ToList();
            return book1;
        }

        public Book Get(int id)
        {
            Book book1 = _mydbconnection.books.Where(u => u.book_ISBN == id).FirstOrDefault();
            if (book1 != null)
            {
                return book1;
            }
            return null;
        }

        public void Add(Book book)
        {
            _mydbconnection.books.Add(book);
            _mydbconnection.SaveChanges();
        }

        public void Remove(Book? book)
        {
            Book? book1 = _mydbconnection.books.Where(u => u.book_ISBN == book.book_ISBN).FirstOrDefault();
            bool success = false;
            if (book1 != null)
            {
                _mydbconnection.books.Remove(book1);
                _mydbconnection.SaveChanges();
                success = true;
            }

        }

        public bool Edit(Book book_x)
        {
            Book? book1 = _mydbconnection.books.Find(book_x.book_ISBN);
            bool success = false;
            if (book1 != null)
            {
                book1.price = book_x.price;
                book1.copies = book_x.copies;
                book1.Book_Author = book_x.Book_Author;
                book1.Book_Title = book_x.Book_Title;
                book1.Book_Description = book_x.Book_Description;
                book1.ImageUrl = book_x.ImageUrl;
                book1.fk_Publisher_id = book_x.fk_Publisher_id;
                book1.category_id = book_x.category_id;
                _mydbconnection.books.Update(book1);
                _mydbconnection.SaveChanges();
                success = true;
            }

            return success;
        }
    }
}
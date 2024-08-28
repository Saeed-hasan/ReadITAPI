using Microsoft.EntityFrameworkCore;
using ReadITAPI.Models;
using System.Net;

namespace ReadITAPI.Repository
{
    public class salesRepository : IsalesRepository
    {
        private readonly MyDbContext _mydbconnection;
        public salesRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }

        public List<Sales> GetAll()
        {
            var sales1 = _mydbconnection.Sales.ToList();
            return sales1;
        }

        public Sales Get(int id)
        {
            Sales sales1 = _mydbconnection.Sales.Where(u => u.Id == id).FirstOrDefault();
            if (sales1 != null)
            {
                return sales1;
            }
            return null;
        }

        public void Add(Sales sales)
        {
            _mydbconnection.Sales.Add(sales);
            _mydbconnection.SaveChanges();
        }

        public void Remove(Sales sales)
        {
            Sales? sales1 = _mydbconnection.Sales.Where(u => u.Id == sales.Id).FirstOrDefault();
            if (sales1 != null)
            {
                _mydbconnection.Sales.Remove(sales1);
                _mydbconnection.SaveChanges();
            }
        }

        public void Edit(Sales sales)
        {
            Sales? sales1 = _mydbconnection.Sales.Where(u => u.Id == sales.Id).FirstOrDefault();
            if (sales1 != null)
            {
                sales1.Date = sales.Date;
                sales1.Application_UserId = sales.Application_UserId;
                sales1.fk_book_ISBN = sales.fk_book_ISBN;
                _mydbconnection.Sales.Update(sales1);
                _mydbconnection.SaveChanges();
            }
        }

        public int GetSalesLastThreeMonths(int bookId)
        {
            // Calculate the count of sales for the given book within the last three months
            int salesLastThreeMonths = _mydbconnection.Sales
                .Count(s => s.fk_book_ISBN == bookId && s.Date >= DateTime.Now.AddMonths(-3));

            return salesLastThreeMonths;
        }
    }
}

using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IsalesRepository : IRepository<Sales>
    {
        public void Edit(Sales sales);
        int GetSalesLastThreeMonths(int bookId);
    }
}

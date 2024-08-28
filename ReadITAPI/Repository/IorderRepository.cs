using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IorderRepository : IRepository<Order>
    {
        public void Edit(Order order);
        public bool order(int user, int isbn);
        public bool Buy(int user, int isbn);
    }
}

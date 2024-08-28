using ReadITAPI.Repository;

namespace ReadITAPI.Models
{
    public interface IpublisherRepository : IRepository<Publisher>
    {
        public void Edit(Publisher publisher);
    }
}

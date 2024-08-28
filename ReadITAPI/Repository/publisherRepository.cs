using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public class publisherRepository : IpublisherRepository
    {
        private readonly MyDbContext _mydbconnection;
        public publisherRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }

        public List<Publisher> GetAll()
        {
            var publisher1 = _mydbconnection.publishers.ToList();
            return publisher1;
        }

        public Publisher Get(int id)
        {
            Publisher publisher1 = _mydbconnection.publishers.Where(u => u.Publisher_Id == id).FirstOrDefault();
            if (publisher1 != null)
            {
                return publisher1;
            }
            return null;
        }

        public void Add(Publisher publisher)
        {
            _mydbconnection.publishers.Add(publisher);
            _mydbconnection.SaveChanges();
        }

        public void Remove(Publisher? pub)
        {
            Publisher? publisher1 = _mydbconnection.publishers.Where(u => u.Publisher_Id == pub.Publisher_Id).FirstOrDefault();
            if (publisher1 != null)
            {
                _mydbconnection.publishers.Remove(publisher1);
                _mydbconnection.SaveChanges();
            }
        }

        public void Edit(Publisher publisher_x)
        {
            Publisher? publisher1 = _mydbconnection.publishers.Where(u => u.Publisher_Id == publisher_x.Publisher_Id).FirstOrDefault();
            if (publisher1 != null)
            {
                publisher1.Publisher_Name = publisher_x.Publisher_Name;
                publisher1.Publisher_Address = publisher_x.Publisher_Address;
                _mydbconnection.publishers.Update(publisher1);
                _mydbconnection.SaveChanges();
            }
        }
    }
}

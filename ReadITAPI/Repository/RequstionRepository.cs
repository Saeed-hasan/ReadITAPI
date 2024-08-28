using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public class RequstionRepository : IRequstionRepository
    {
        private readonly MyDbContext _mydbconnection;
        public RequstionRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }

        public List<Requstion> GetAll()
        {
            var requstion1 = _mydbconnection.Requstions.ToList();
            return requstion1;
        }

        public List<Requstion> Getallrequestforparticularpublisher(int id)
        {
            var request = _mydbconnection.Requstions.Where(r=>r.fk_Publisher_id == id).ToList();
            if (request != null)
            {
                return request;
            }
            return null;
        }

        public Requstion Get(int id)
        {
            Requstion req1 = _mydbconnection.Requstions.Where(u => u.Id == id).FirstOrDefault();
            if (req1 != null)
            {
                return req1;
            }
            return null;
        }

        public void Add(Requstion requstion)
        {
            _mydbconnection.Requstions.Add(requstion);
            _mydbconnection.SaveChanges();
        }

        public void Remove(Requstion requstion)
        {
            Requstion request = _mydbconnection.Requstions.Where(u => u.Id == requstion.Id).FirstOrDefault();
            if (request != null)
            {
                var book = _mydbconnection.books.Find(request.fk_book_ISBN);
                if (book != null)
                {
                    // Increase the number of copies by the number of orders
                    int ordercount = _mydbconnection.orders.Count(o => o.fk_book_ISBN == book.book_ISBN);
                    book.copies += ordercount;
                    _mydbconnection.SaveChanges();
                    // Delete orders associated with the requisition( OrdersToDelet is list)
                    IorderRepository orderRepo = new orderRepository(_mydbconnection);
                    var OrdersToDelet = _mydbconnection.orders.Where(o => o.fk_book_ISBN == book.book_ISBN).ToList();
                    foreach (var order in OrdersToDelet)
                    {
                        orderRepo.Remove(order);
                    }
                    _mydbconnection.SaveChanges();
                }
                // Delete the requisition
                _mydbconnection.Requstions.Remove(request);
                _mydbconnection.SaveChanges();
            }
            
        }

        public void Edit(Requstion req)
        {
            Requstion? req1 = _mydbconnection.Requstions.Where(u => u.Id == req.Id).FirstOrDefault();
            if (req1 != null)
            {
                req1.Status = req.Status;
                req1.fk_Publisher_id = req.fk_Publisher_id;
                req1.fk_book_ISBN = req.fk_book_ISBN;
                _mydbconnection.Requstions.Update(req1);
                _mydbconnection.SaveChanges();
            }
        }

        public void CommitRequest(Requstion requstion)
        {
            Requstion? request = _mydbconnection.Requstions.Where(r => r.Id == requstion.Id).FirstOrDefault();
            if (request != null)
            {
                request.Status = "Commited";
                _mydbconnection.Requstions.Update(request);
                _mydbconnection.SaveChanges();
            }
        }
    }
}

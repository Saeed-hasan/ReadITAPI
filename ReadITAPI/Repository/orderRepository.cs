using ReadITAPI.Models;
namespace ReadITAPI.Repository
{
    public class orderRepository : IorderRepository
    {
        private readonly MyDbContext _mydbconnection;
        public orderRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }

        public List<Order> GetAll()
        {
            var order1 = _mydbconnection.orders.ToList();
            return order1;
        }

        public Order Get(int id)
        {
            Order order1 = _mydbconnection.orders.Where(u => u.order_Id == id).FirstOrDefault();
            if (order1 != null)
            {
                return order1;
            }
            return null;
        }

        public void Add(Order order)
        {
            _mydbconnection.orders.Add(order);
            _mydbconnection.SaveChanges();
        }

        public void Remove(Order order)
        {
            Order order1 = _mydbconnection.orders.Where(u => u.order_Id == order.order_Id).FirstOrDefault();
            if (order1 != null)
            {
                var book1 = _mydbconnection.books.Find(order1.fk_book_ISBN);
                if (book1 != null)
                {
                    // Update the number of copies of the book by one
                    book1.copies--;
                    _mydbconnection.SaveChanges();


                    // Insert entry into the sales table
                    _mydbconnection.Sales.Add(new Sales
                    {
                        Application_UserId = order1.Application_UserId,
                        fk_book_ISBN = order1.fk_book_ISBN,
                        Date = DateTime.Now
                    });
                    _mydbconnection.SaveChanges();
                }
                // Remove the order
                _mydbconnection.orders.Remove(order1);
                _mydbconnection.SaveChanges();
            }
        }

        public void Edit(Order order_x)
        {
            Order? order1 = _mydbconnection.orders.Where(u => u.order_Id == order_x.order_Id).FirstOrDefault();
            if(order1 != null)
            {
                order1.Application_UserId = order_x.Application_UserId;
                order1.fk_book_ISBN = order_x.fk_book_ISBN;
                _mydbconnection.orders.Update(order1);
                _mydbconnection.SaveChanges();
            }
        }


        public bool Buy(int user, int isbn)
        {
            bool success = false;
            ApplicationUser user1 = _mydbconnection.users.Find(user);
            Book book1 = _mydbconnection.books.Find(isbn);
            if (user1 != null && book1 != null)
            {
                // Check if there's enough balance in the user_balance
                if (user1.user_Balance >= book1.price)
                {
                    // Update book copies
                    book1.copies -= 1;
                    // Decrease Balance of the customer
                    user1.user_Balance -= book1.price;
                    // Insert sale entry
                    var new_sale = new Sales
                    {
                        fk_book_ISBN = book1.book_ISBN,
                        Application_UserId = user1.Id,
                        Date = DateTime.Now
                    };
                    _mydbconnection.Sales.Add(new_sale);
                    _mydbconnection.SaveChanges();
                    var salesLastThreeMonths = _mydbconnection.Sales.Count(s => s.fk_book_ISBN == book1.book_ISBN && s.Date > DateTime.Now.AddMonths(-3));
                    if (book1.copies < salesLastThreeMonths)
                    {
                        // copies low, display error message
                        order(user, isbn);
                    }
                    _mydbconnection.SaveChanges();
                    success = true;
                }
            }
            // Return flag indicating success or failure
            return success;
        }

        public bool order(int user, int isbn)
        {
            bool success = false;
            ApplicationUser user1 = _mydbconnection.users.Find(user);
            Book book1 = _mydbconnection.books.Find(isbn);
            if (user1 != null && book1 != null)
            {
                // Check if there's enough balance in the user_balance
                if (user1.user_Balance >= book1.price)
                {
                    // Reduce user_balance value by the cost of the book
                    user1.user_Balance -= book1.price;

                    // Create a new order entry
                    var New_order = new Order
                    {
                        fk_book_ISBN = book1.book_ISBN,
                        Application_UserId = user1.Id
                    };
                    _mydbconnection.orders.Add(New_order);

                    var requstion1 = _mydbconnection.Requstions.Find(book1.book_ISBN);
                    if (requstion1 == null)
                    {
                        var new_request = new Requstion
                        {
                            fk_book_ISBN = book1.book_ISBN,
                            fk_Publisher_id = book1.fk_Publisher_id,
                            Status = "New"
                        };

                        _mydbconnection.Requstions.Add(new_request);
                    }
                    // Save changes to the database
                    _mydbconnection.SaveChanges();
                    /// Set success flag to true
                    success = true;
                }
            }
            // Return flag indicating success or failure
            return success;
        }
    }
}
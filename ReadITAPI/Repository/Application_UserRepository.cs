using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public class Application_UserRepository : IApplication_UserRepository
    {
        private readonly MyDbContext _mydbconnection;
        public Application_UserRepository(MyDbContext mycontext)
        {
            _mydbconnection = mycontext;
        }

        public List<ApplicationUser> GetAll()
        {
            var user = _mydbconnection.users.ToList();
            return user;
        }

        public ApplicationUser Get(int id)
        {
            ApplicationUser user1 = _mydbconnection.users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            if (user1 != null)
            {
                return user1;
            }
            return null;
        }

        public void Add(ApplicationUser user)
        {
            _mydbconnection.users.Add(user);
            _mydbconnection.SaveChanges();

        }

        public void Remove(ApplicationUser? user)
        {
            ApplicationUser? user1 = _mydbconnection.users.Where(u => u.Id == user.Id).FirstOrDefault();
            if (user1 != null)
            {
                _mydbconnection.users.Remove(user1);
                _mydbconnection.SaveChanges();
            }
        }

        public void Edit(ApplicationUser user_x)
        {
            ApplicationUser? user1 = _mydbconnection.users.Find(user_x.Id);
            if (user1 != null)
            {
                user1.city = user_x.city;
                user1.fk_Publisher_id = user_x.fk_Publisher_id;
                user1.state = user_x.state;
                user1.Email = user_x.Email;
                user1.name = user_x.name;
                user1.UserName = user_x.UserName;
                user1.user_Balance = user_x.user_Balance;
                user1.StreetAddress = user_x.StreetAddress;
                user1.postalcode = user_x.postalcode;
                _mydbconnection.users.Update(user1);
                _mydbconnection.SaveChanges();
            }
        }
    }
}

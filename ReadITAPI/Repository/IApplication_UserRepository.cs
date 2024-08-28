using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IApplication_UserRepository : IRepository<ApplicationUser>
    {
        public void Edit(ApplicationUser user);
    }
}

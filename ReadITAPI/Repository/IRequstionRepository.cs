using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IRequstionRepository : IRepository<Requstion>
    {
        public void Edit(Requstion requstion);
        public void CommitRequest(Requstion requstion);
        public List<Requstion> Getallrequestforparticularpublisher(int id);
    }
}

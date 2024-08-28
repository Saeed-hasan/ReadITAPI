using ReadITAPI.Models;

namespace ReadITAPI.Repository
{
    public interface IUnitOfWork
    {
        public IcategoryRepository Category { get; }
        public IbookRepository book { get; }
        public IpublisherRepository publisher { get; }
        public IorderRepository order { get; }
        public IApplication_UserRepository ApplicationUser { get; }
        public IRequstionRepository request { get; }
        public IsalesRepository sales { get; }
        public void Save();
    }
}

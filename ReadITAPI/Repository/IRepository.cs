using System.Linq.Expressions;

namespace ReadITAPI.Repository
{
    public interface IRepository<T> where T : class // da el parent class ely ba2eet el repositories 7atinheret meno fa el T 7atb2a 3ala 7asb kol class ex. category ==> badl T Get 7atb2a category Get
    {
        public T Get(int id); //method return obj from class
        public List<T> GetAll(); //method return list
        public void Remove(T entity);
        public void Add(T entity); //i.e (category category) obj from class category
    }
}

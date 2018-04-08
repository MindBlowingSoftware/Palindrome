using System.Linq;

namespace Palindrome
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        Palindrome GetBypalindrome(string paalindrome);
    }
}
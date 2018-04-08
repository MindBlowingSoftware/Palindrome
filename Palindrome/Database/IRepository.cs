using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Palindrome.Database
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        Models.Palindrome GetBypalindrome(string paalindrome);
    }
}
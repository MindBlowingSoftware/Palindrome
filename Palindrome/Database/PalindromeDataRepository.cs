using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Palindrome.Models;

namespace Palindrome.Database
{
    [ExcludeFromCodeCoverage]
    public class PalindromeDataRepository : IPalindromeDataRepository
    {
        private readonly PalindromeContext _context;

        public PalindromeDataRepository(PalindromeContext context)
        {
            _context = context;
        }
        public IQueryable<Models.Palindrome> GetAll()
        {
            return _context.Palindromes.AsQueryable();
        }

        public void Create(Models.Palindrome entity)
        {
            
            _context.Palindromes.Add(entity);
            _context.SaveChanges();
                        
        }

        public Models.Palindrome GetBypalindrome(string palindrome)
        {
            return _context.Palindromes.SingleOrDefault(a => a.PalindromeValue.ToLower() == palindrome.ToLower());
        }
    }
}

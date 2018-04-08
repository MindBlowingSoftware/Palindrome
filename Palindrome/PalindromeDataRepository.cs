using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palindrome
{
    public class PalindromeDataRepository : IPalindromeDataRepository
    {
        private readonly PalindromeContext _context;

        public PalindromeDataRepository(PalindromeContext context)
        {
            _context = context;
        }
        public IQueryable<Palindrome> GetAll()
        {
            return _context.Palindromes.AsQueryable();
        }

        public void Create(Palindrome entity)
        {
            
            _context.Palindromes.Add(entity);
            _context.SaveChanges();
                        
        }

        public Palindrome GetBypalindrome(string palindrome)
        {
            return _context.Palindromes.SingleOrDefault(a => a.PalindromeValue == palindrome);
        }
    }
}

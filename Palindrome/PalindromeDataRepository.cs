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
            try
            {
                _context.Palindromes.Add(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Palindrome.Database;

namespace Palindrome.Tests
{
    public class FakePalindromeDataRepository : IPalindromeDataRepository
    {

        public List<Models.Palindrome> samplePalindromes = new List<Models.Palindrome>()
            {
                new Models.Palindrome
                {
                    PalindromeValue = "Was it a cat I saw",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                },
                new Models.Palindrome
                {
                    PalindromeValue = "Don't nod",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                },new Models.Palindrome
                {
                    PalindromeValue = "Radar",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                },new Models.Palindrome
                {
                    PalindromeValue = "No Lemon",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                }
            };

        public FakePalindromeDataRepository()
        {
            
        }
        public IQueryable<Models.Palindrome> GetAll()
        {
            return samplePalindromes.AsQueryable();
        }

        public void Create(Models.Palindrome entity)
        {
            
            samplePalindromes.Add(entity);
        }

        public Models.Palindrome GetBypalindrome(string palindrome)
        {
            return samplePalindromes.FirstOrDefault(a => a.PalindromeValue.ToLower() == palindrome.ToLower());
        }
    }
}

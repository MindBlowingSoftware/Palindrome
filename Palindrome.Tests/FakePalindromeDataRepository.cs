
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palindrome
{
    public class FakePalindromeDataRepository : IPalindromeDataRepository
    {

        List<Palindrome> samplePalindromes = new List<Palindrome>()
            {
                new Palindrome
                {
                    PalindromeValue = "Was it a cat I saw",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                },
                new Palindrome
                {
                    PalindromeValue = "Don't nod",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                },new Palindrome
                {
                    PalindromeValue = "Radar",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                },new Palindrome
                {
                    PalindromeValue = "No Lemon",
                    CreateTS = new DateTime(2018,04,06),
                    PalindromeId = Guid.NewGuid()
                }
            };

        public FakePalindromeDataRepository()
        {
            
        }
        public IQueryable<Palindrome> GetAll()
        {
            return samplePalindromes.AsQueryable();
        }

        public void Create(Palindrome entity)
        {
            
            samplePalindromes.Add(entity);
        }
    }
}

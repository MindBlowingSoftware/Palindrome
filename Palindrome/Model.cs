using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palindrome
{
    public class Palindrome
    {
        public Guid PalindromeId { get; set; }
        public string PalindromeValue { get; set; }
        public DateTime CreateTS { get; set; }
        public DateTime UpdatedTS { get; set; }
        public DateTime InactivatedTS { get; set; }
    }

    public class PalindromeContext : DbContext
    {
        public PalindromeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Palindrome> Palindromes { get; set; }

    }

    public static class DbInitializer
    {
        public static void Initialize(PalindromeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Palindromes.Any())
            {
                return;
            }

            var samplePalindromes = new List<Palindrome>()
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

            context.Palindromes.AddRange(samplePalindromes);
            context.SaveChanges();
        }
    }
}

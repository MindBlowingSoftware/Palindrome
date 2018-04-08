using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Palindrome.Models
{

    [ExcludeFromCodeCoverage]
    public class PalindromeContext : DbContext
    {
        public PalindromeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Palindrome> Palindromes { get; set; }

    }

    [ExcludeFromCodeCoverage]
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

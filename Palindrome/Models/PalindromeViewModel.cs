using System;
using System.Diagnostics.CodeAnalysis;

namespace Palindrome.Models
{
    public class PalindromeViewModel : IPalindrome
    {
        public Guid PalindromeId { get; set; }
        public string PalindromeValue { get; set; }
        public DateTime CreateTS { get; set; }
        [ExcludeFromCodeCoverage]
        public DateTime? UpdatedTS { get; set; }
        [ExcludeFromCodeCoverage]
        public DateTime? InactivatedTS { get; set; }
    }
}
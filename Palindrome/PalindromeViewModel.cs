using System;

namespace Palindrome.Controllers
{
    public class PalindromeViewModel : IPalindrome
    {
        public Guid PalindromeId { get; set; }
        public string PalindromeValue { get; set; }
        public DateTime CreateTS { get; set; }
        public DateTime? UpdatedTS { get; set; }
        public DateTime? InactivatedTS { get; set; }
    }
}
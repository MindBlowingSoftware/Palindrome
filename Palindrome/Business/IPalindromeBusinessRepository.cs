using Palindrome.Models;

namespace Palindrome.Business
{
    public interface IPalindromeBusinessRepository : IBusinessRepository<PalindromeViewModel>
    {
        bool IsPalindrome(PalindromeViewModel model);
    }
}
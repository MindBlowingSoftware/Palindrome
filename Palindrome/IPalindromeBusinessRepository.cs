using Palindrome.Controllers;

namespace Palindrome
{
    public interface IPalindromeBusinessRepository : IBusinessRepository<PalindromeViewModel>
    {
        bool IsPalindrome(PalindromeViewModel model);
    }
}
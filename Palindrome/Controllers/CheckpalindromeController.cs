using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Palindrome.Controllers
{
    [Route("api/[controller]")]
    public class CheckPalindromeController : Controller
    {
        
        public CheckPalindromeController(PalindromeContext context)
        {
           
        }
       
        // POST api/values
        [HttpPost]
        public bool Post([FromBody]PalindromeViewModel model)
        {
            var input = model.Palindrome;
            var arr = input.ToCharArray();

            arr = Array.FindAll(arr, (c => (char.IsLetter(c))));

            var cleanedInput = new string(arr);

            if(IsPalindrome(cleanedInput))
            {
                try
                {
                    SaveToDb(input);
                }

                catch
                {
                    return true;
                }
                return true;
            }

            return false;
        }

        private void SaveToDb(string input)
        {
            RedirectToAction("Create", "Palindrome", new Palindrome
            {
               PalindromeValue = input
            });
        }

        private bool IsPalindrome(string cleanedInput)
        {
            var reversedCleanedInput = new string(cleanedInput.ToCharArray().Reverse().ToArray());
            return reversedCleanedInput.ToLower() == cleanedInput.ToLower();
        }
    }
}
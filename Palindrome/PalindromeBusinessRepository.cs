using Microsoft.EntityFrameworkCore;
using Palindrome.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palindrome
{
    public class PalindromeBusinessRepository : IPalindromeBusinessRepository
    {
        private readonly IPalindromeDataRepository _datacontext;

        public PalindromeBusinessRepository(IPalindromeDataRepository context)
        {
            _datacontext = context;
        }

        public void CreateNew(PalindromeViewModel viewmodel)
        {
            if(FetchExistingRecordByPalindrome(viewmodel.PalindromeValue) == null)
            {
                var palindrome = new Palindrome()
                {
                    PalindromeValue = viewmodel.PalindromeValue,
                    CreateTS = DateTime.Now,
                    PalindromeId = Guid.NewGuid()
                };

                _datacontext.Create(palindrome);
            }
        }

        public List<PalindromeViewModel> FetchExistingRecords()
        {
            var palindromes = _datacontext.GetAll();
            return palindromes.Select(a => new PalindromeViewModel()
            {
                PalindromeId = a.PalindromeId,
                CreateTS = a.CreateTS,
                InactivatedTS = a.InactivatedTS,
                PalindromeValue = a.PalindromeValue,
                UpdatedTS = a.UpdatedTS
            }).ToList();
        }

        private PalindromeViewModel FetchExistingRecordByPalindrome(string palindrome)
        {
            var palindromefromDb = _datacontext.GetBypalindrome(palindrome);
            if(palindromefromDb != null)
            {
                return new PalindromeViewModel
                {
                    CreateTS = palindromefromDb.CreateTS,
                    InactivatedTS = palindromefromDb.InactivatedTS,
                    PalindromeId = palindromefromDb.PalindromeId,
                    PalindromeValue = palindromefromDb.PalindromeValue,
                    UpdatedTS = palindromefromDb.UpdatedTS
                };
            }

            return null;
            
        }

        public bool IsPalindrome(PalindromeViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.PalindromeValue)
                || model.PalindromeValue.Length < 3) return false;

            var input = model.PalindromeValue;
            var arr = input.ToCharArray();

            arr = Array.FindAll(arr, (c => (char.IsLetterOrDigit(c))));

            var cleanedInput = new string(arr);

            return IsPalindrome(cleanedInput);
        }

        private bool IsPalindrome(string cleanedInput)
        {
            var reversedCleanedInput = new string(cleanedInput.ToCharArray().Reverse().ToArray());
            return reversedCleanedInput.ToLower() == cleanedInput.ToLower();
        }
    }
}

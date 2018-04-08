using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Business;
using Palindrome.Controllers;
using Palindrome.Models;

namespace Palindrome.Tests
{
    [TestClass]
    public class CheckPalindromeTests
    {
        private FakePalindromeDataRepository dataRepo;
        private PalindromeBusinessRepository businessRepo;

        public CheckPalindromeTests()
        {
            dataRepo = new FakePalindromeDataRepository();
            businessRepo = new PalindromeBusinessRepository(dataRepo);

        }


        [TestMethod]
        public void EmptyInputShouldReturnFalse()
        {
            //Arrange
            var viewmodel = new PalindromeViewModel()
            {
                PalindromeValue = ""
            };

            // Act

            var isPalindrome = businessRepo.IsPalindrome(viewmodel);

            // Assert

            Assert.IsFalse(isPalindrome);
        }

        [TestMethod]
        public void Mixed_Case_Pallindrome_Should_Be_Recognised()
        {
            //Arrange
            var viewmodel = new PalindromeViewModel()
            {
                PalindromeValue = "WasItACatISaw"
            };

            // Act

            var isPalindrome = businessRepo.IsPalindrome(viewmodel);

            // Assert

            Assert.IsTrue(isPalindrome);
        }

        [TestMethod]
        public void Numeric_Characters_Pallindrome_Should_Be_Recognised()
        {
            //Arrange
            var viewmodel = new PalindromeViewModel()
            {
                PalindromeValue = "WasItAC76767@atISaw"
            };

            // Act

            var isPalindrome = businessRepo.IsPalindrome(viewmodel);

            // Assert

            Assert.IsFalse(isPalindrome);
        }


        [TestMethod]
        public void XML_Input_should_Not_be_processed()
        {
            //Arrange
            var viewmodel = new PalindromeViewModel()
            {
                PalindromeValue = "<wasitacatisaw></wasitacatisaw>"
            };

            // Act

            var isPalindrome = businessRepo.IsPalindrome(viewmodel);

            // Assert

            Assert.IsTrue(isPalindrome);
        }

        [TestMethod]
        public void Symmetric_Numeric_Input_should_Pass()
        {
            //Arrange
            var viewmodel = new PalindromeViewModel()
            {
                PalindromeValue = "0wasitacatisaw0"
            };

            // Act

            var isPalindrome = businessRepo.IsPalindrome(viewmodel);

            // Assert

            Assert.IsTrue(isPalindrome);
        }
    }
}

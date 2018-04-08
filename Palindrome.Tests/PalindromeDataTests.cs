using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Controllers;
using System.Linq;
using Palindrome.Business;
using Palindrome.Models;
using Palindrome = Palindrome.Models.Palindrome;

namespace Palindrome.Tests
{
    [TestClass]
    public class PalindromeDataTests
    {
        private FakePalindromeDataRepository dataRepo;

        public PalindromeDataTests()
        {
            dataRepo = new FakePalindromeDataRepository();
        }

        [TestMethod]
        public void Should_Create_New_Palindrome()
        {
            // Arrange

            var uniquePallindrome = "unique";

            //Act
            dataRepo.Create(new Models.Palindrome { PalindromeValue = uniquePallindrome });

            //Assert
            Assert.IsNotNull(dataRepo.GetAll().Any(a => a.PalindromeValue == uniquePallindrome));
        }

        [TestMethod]
        public void Should_Fetch_All_Palindrome()
        {
            // Arrange

            int count = 0;
            int expectedCount = new FakePalindromeDataRepository().samplePalindromes.Count;

            //Act
            count = dataRepo.GetAll().ToList().Count;

            //Assert

            Assert.AreEqual(count, expectedCount);
        }

        

        [TestMethod]
        public void Should_Return_An_Existing_Palindrome()
        {
            // Arrange

            var uniquePallindrome = "Was it a cat I saw";

            //Act
            dataRepo.Create(new Models.Palindrome { PalindromeValue = uniquePallindrome });

            //Assert
            Assert.IsNotNull(dataRepo.GetBypalindrome(uniquePallindrome));
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Controllers;
using System.Linq;
using Palindrome.Business;
using Palindrome.Models;

namespace Palindrome.Tests
{
    [TestClass]
    public class PalindromeBusinessTests
    {
        private FakePalindromeDataRepository dataRepo;
        private PalindromeBusinessRepository businessRepo;

        public PalindromeBusinessTests()
        {
            dataRepo = new FakePalindromeDataRepository();
            businessRepo = new PalindromeBusinessRepository(dataRepo);

        }

        [TestMethod]
        public void Should_Create_New_Palindrome()
        {
            // Arrange

            var uniquePallindrome = "unique";

            //Act
            businessRepo.CreateNew(new PalindromeViewModel { PalindromeValue = uniquePallindrome });

            //Assert
            Assert.IsNotNull(businessRepo.FetchExistingRecords().Any(a => a.PalindromeValue == uniquePallindrome));
        }

        [TestMethod]
        public void Should_Fetch_All_Palindrome()
        {
            // Arrange

            int count = 0;
            int expectedCount = new FakePalindromeDataRepository().samplePalindromes.Count;

            //Act
            count = businessRepo.FetchExistingRecords().Count;

            //Assert

            Assert.AreEqual(count, expectedCount);
        }

        [TestMethod]
        public void Should_Not_Save_the_Same_Palindrome()
        {
            // Arrange

            var uniquePallindrome = "Was it a cat I saw";

            //Act
            businessRepo.CreateNew(new PalindromeViewModel { PalindromeValue = uniquePallindrome });

            //Assert
            Assert.IsTrue(businessRepo.FetchExistingRecords()
                .Count(a => a.PalindromeValue == uniquePallindrome) == 1);
        }

    }
}

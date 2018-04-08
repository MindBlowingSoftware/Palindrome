using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Controllers;
using System.Linq;
using Newtonsoft.Json;
using Palindrome.Business;
using Palindrome.Database;
using Palindrome.Models;
using Rhino.Mocks;
using Palindrome = Palindrome.Models.Palindrome;

namespace Palindrome.Tests
{
    [TestClass]
    public class CheckPalindromeControllerTests
    {
        private PalindromeBusinessRepository businessrepo;
        private CheckPalindromeController controller;

        public CheckPalindromeControllerTests()
        {
            
            var datarepo = new FakePalindromeDataRepository();

            businessrepo = new PalindromeBusinessRepository(datarepo);

            controller = new CheckPalindromeController(businessrepo);

        }

        [TestMethod]
        public void Create_Action_Returns_true_false()
        {
            //Arrange

            var input = new PalindromeViewModel
            {
                PalindromeValue = "test"
            };

            //Act
            var returnvalue = controller.Post(input);

            //Assert

            Assert.AreEqual(returnvalue.GetType(), typeof(bool));
        }

    }
}

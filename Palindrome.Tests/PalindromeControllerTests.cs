using System;
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
    public class PalindromeControllerTests
    {
        private PalindromeBusinessRepository businessrepo;
        private PalindromeController controller;
        private FakePalindromeDataRepository datarepo;

        public PalindromeControllerTests()
        {
            
            datarepo = new FakePalindromeDataRepository();

            businessrepo = new PalindromeBusinessRepository(datarepo);

            controller = new PalindromeController(businessrepo);

        }

        [TestMethod]
        public void Create_Action_Returns_JsonResult()
        {
            //Arrange

            var input = new PalindromeViewModel
            {
                PalindromeValue = "test"
            };

            //Act
            var returnvalue = controller.Post(input);

            //Assert

            Assert.IsNotNull(JsonConvert.SerializeObject(returnvalue));
        }

        [TestMethod]
        public void Fetch_Action_Returns_List()
        {
            //Arrange

            var count = 0;

            //Act
            var returnvalue = controller.Get();

            //Assert

            Assert.IsNotNull(returnvalue.Count > 0);
        }
    }
}

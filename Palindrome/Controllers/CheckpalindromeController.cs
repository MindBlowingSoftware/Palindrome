using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Business;
using Palindrome.Models;

namespace Palindrome.Controllers
{
    [Route("api/[controller]")]
    public class CheckPalindromeController : Controller
    {
        IPalindromeBusinessRepository _businessRepo;
        public CheckPalindromeController(IPalindromeBusinessRepository businessRepo)
        {
            _businessRepo = businessRepo;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]PalindromeViewModel model)
        {
            return _businessRepo.IsPalindrome(model);
        }        
    }
}
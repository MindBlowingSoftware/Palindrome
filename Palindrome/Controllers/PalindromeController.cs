using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Business;
using Palindrome.Models;

namespace Palindrome.Controllers
{
    [Route("api/[controller]")]
    public class PalindromeController : Controller
    {
        private readonly IPalindromeBusinessRepository _repo;

        public PalindromeController(IPalindromeBusinessRepository context)
        {
            _repo = context;
        }
        // GET api/values
        [HttpGet]
        public List<PalindromeViewModel> Get()
        {
            return _repo.FetchExistingRecords();
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]PalindromeViewModel input)
        {   
            try
            {
                _repo.CreateNew(input);
                return new JsonResult("Saved");
            }
            catch(Exception ex)
            {
                return new JsonResult("An error Occurred" + ex.Message);
            }
        }
    }
}
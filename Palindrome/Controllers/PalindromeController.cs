using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Palindrome.Controllers
{
    [Route("api/[controller]")]
    public class PalindromeController : Controller
    {
        private readonly PalindromeContext _context;
        public PalindromeController(PalindromeContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Palindrome> Get()
        {
            return _context.Palindromes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Palindrome Get(Guid id)
        {
            return _context.Palindromes.SingleOrDefault(a => a.PalindromeId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Palindrome palindrome)
        {
            _context.Palindromes.Add(palindrome);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Palindrome palindrome)
        {
            palindrome.UpdatedTS = DateTime.Now;
            _context.Palindromes.Update(palindrome);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var palindrome = Get(id);
            palindrome.InactivatedTS = DateTime.Now;
            _context.Palindromes.Update(palindrome);
        }
    }
}
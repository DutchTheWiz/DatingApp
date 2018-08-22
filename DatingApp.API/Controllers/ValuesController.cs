using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // localhost:5000 -> web server kestrel
    // api -> api from Route
    // [controller]  -> prefix Values of class ValuesController
    // 5 -> GET api/values/5
    //http://localhost:5000/api/values/5 

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values  
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2", "value3", "value4" };
        //}

        // instead of public ActionResult<IEnumerable<string>> Get()
        //public IActionResult GetValues() 
        //{
        //    var values = _context.Values.ToList();

        //    return Ok(values);
        //}

        [AllowAnonymous]
        [HttpGet]
        // same 2nd caall as above but async call code 
        public async Task<IActionResult> GetValues() 
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        //instead of public ActionResult<string> Get(int id)
        public async Task< IActionResult> GetValue(int id) 
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

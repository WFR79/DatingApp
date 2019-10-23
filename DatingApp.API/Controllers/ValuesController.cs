using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Models;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Data.DataContext _context;
        public ValuesController(Data.DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<List<Value>> GetValues()
        {
           var values = Task.Run( () => _context.Values.ToList());
            List<Value> Values = await values;
            return Values;
           //return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Value> GetValue(int id)
        {
            var _value = Task.Run( () => _context.Values.FirstOrDefault(x => x.Id == id));
            Value value = await _value;
            return value;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine("POST Command Value");
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

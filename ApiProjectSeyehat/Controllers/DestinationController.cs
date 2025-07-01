using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjectSeyehat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProjectSeyehat.Controllers
{
    [Route("api/[controller]")]
    public class DestinationController : Controller
    {


        private readonly AppDbContext _context;
        public DestinationController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetDestination")]
        public async Task<IEnumerable<Destination>> GetDestination()
        {
            return await _context.Destinations.ToListAsync();
        }


        [HttpGet]
        [Route("GetDestinationById/{id}")]
        public async Task<Destination> GetDestinationById(int id)
        {
            return await _context.FindAsync<Destination>(id);
        }












        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


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

        [HttpPost]
        [Route("AddDestination")]
        public async Task<Destination> AddDestination([FromBody] Destination destination)
        {
            _context.Add(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        [HttpPut]
        [Route("UpdateDestination")]
        public async Task<Destination> UpdateDestination(int id, [FromBody]Destination destination)
        {
            _context.Update(destination);
            await _context.SaveChangesAsync();
            return destination;
        }



        [HttpDelete]
        [Route("DeleteDestination/{id}")]
        public bool DeleteDestination(int id)
        {
            var islem = false;
            var result = _context.Destinations.Find(id);
            if (result != null)
            {
                islem = true;
                _context.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                return islem;
            }
            return islem;
        }



    }
}


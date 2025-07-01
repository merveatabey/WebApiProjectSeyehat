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
    public class TripDestinationController : Controller
    {

        private readonly AppDbContext _context;
        public TripDestinationController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetTripDestination")]
        public async Task<IEnumerable<TripDestination>> GetTripDestination()
        {
            return await _context.TripDestinations.ToListAsync();
        }


        [HttpGet]
        [Route("GetTripDestinationById/{id}")]
        public async Task<TripDestination> GetTripDestinationById(int id)
        {
            return await _context.FindAsync<TripDestination>(id);
        }

        [HttpPost]
        [Route("AddTripDestination")]
        public async Task<TripDestination> AddTripDestination([FromBody] TripDestination tripDestination)
        {
            _context.Add(tripDestination);
            await _context.SaveChangesAsync();
            return tripDestination;
        }

        [HttpPut]
        [Route("UpdateTripDestination")]
        public async Task<TripDestination> UpdateTripDestination(int id, [FromBody] TripDestination tripDestination)
        {
            _context.Update(tripDestination);
            await _context.SaveChangesAsync();
            return tripDestination;
        }



        [HttpDelete]
        [Route("DeleteTripDestination/{id}")]
        public bool DeleteTripDestination(int id)
        {
            var islem = false;
            var result = _context.TripDestinations.Find(id);
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


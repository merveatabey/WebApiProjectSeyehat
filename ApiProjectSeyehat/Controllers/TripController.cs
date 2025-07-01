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
    public class TripController : Controller
    {
        private readonly AppDbContext _context;
        public TripController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetTrip")]
        public async Task<IEnumerable<Trip>> GetTrip()
        {
            return await _context.Trips.ToListAsync();
        }


        [HttpGet]
        [Route("GetTripById/{id}")]
        public async Task<Trip> GetTripById(int id)
        {
            return await _context.FindAsync<Trip>(id);
        }

        [HttpPost]
        [Route("AddTrip")]
        public async Task<Trip> AddTrip([FromBody] Trip trip)
        {
            _context.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        [HttpPut]
        [Route("UpdateTrip")]
        public async Task<Trip> UpdateTrip(int id, [FromBody] Trip trip)
        {
            _context.Update(trip);
            await _context.SaveChangesAsync();
            return trip;
        }



        [HttpDelete]
        [Route("DeleteTrip/{id}")]
        public bool DeleteTrip(int id)
        {
            var islem = false;
            var result = _context.Trips.Find(id);
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


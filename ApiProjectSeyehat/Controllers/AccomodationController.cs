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
    public class AccomodationController : Controller
    {


        private readonly AppDbContext _context;
        public AccomodationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAccomodation")]
        public async Task<IEnumerable<Accomodation>> GetAccomodation()
        {
            return await _context.Accomodations.ToListAsync();
        }

        [HttpGet]
        [Route("GetAccomodationById/{id}")]
        public async Task<Accomodation> GetAccomodationById(int id)
        {
            return await _context.Accomodations.FindAsync(id);
        }

        [HttpPost]
        [Route("AddAccomodation")]
        public async Task<Accomodation> AddAccomodation([FromBody] Accomodation accomodation)
        {
             _context.Add(accomodation);
            await _context.SaveChangesAsync();
            return accomodation;
        }

        [HttpPut]
        [Route("UpdateAccomodation/{id}")]
        public async Task<Accomodation> UpdateAccomodation(int id, [FromBody]Accomodation accomodation)
        {
            _context.Update(accomodation);
            await _context.SaveChangesAsync();
            return accomodation;
        }

        [HttpDelete]
        [Route("DeleteAccomodation/{id}")]
        public bool DeleteAccomodation(int id)
        {
            var islem = false;
            var result = _context.Accomodations.Find(id);
            if(result != null)
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


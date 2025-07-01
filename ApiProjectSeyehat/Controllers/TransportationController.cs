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
    public class TransportationController : Controller
    {

        private readonly AppDbContext _context;
        public TransportationController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetTransportation")]
        public async Task<IEnumerable<Transportation>> GetTransportation()
        {
            return await _context.Transportations.ToListAsync();
        }


        [HttpGet]
        [Route("GetTransportationById/{id}")]
        public async Task<Transportation> GetTransportationById(int id)
        {
            return await _context.FindAsync<Transportation>(id);
        }

        [HttpPost]
        [Route("AddTransportation")]
        public async Task<Transportation> AddTransportation([FromBody] Transportation transportation)
        {
            _context.Add(transportation);
            await _context.SaveChangesAsync();
            return transportation;
        }

        [HttpPut]
        [Route("UpdateTransportation")]
        public async Task<Transportation> UpdateTransportation(int id, [FromBody] Transportation transportation)
        {
            _context.Update(transportation);
            await _context.SaveChangesAsync();
            return transportation;
        }



        [HttpDelete]
        [Route("DeleteTransportation/{id}")]
        public bool DeleteTransportation(int id)
        {
            var islem = false;
            var result = _context.Transportations.Find(id);
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


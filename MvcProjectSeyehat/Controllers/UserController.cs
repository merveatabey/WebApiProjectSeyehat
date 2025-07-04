using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProjectSeyehat.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class UserController : Controller
    {


        private readonly ApiProjectSeyehat.Models.AppDbContext _context;

        public UserController(ApiProjectSeyehat.Models.AppDbContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var statsViewModel = new StatsViewModel
            {
                TotalUser = await _context.Users.Where(u => u.Role == "User").CountAsync(),
                TotalTrip = await _context.Trips.CountAsync(),
                TotalDestination = await _context.Destinations.CountAsync(),
                TotalActivities = await _context.Activities.CountAsync()
            };

      
              var travels = await _context.Trips.Select(trip => new TravelViewModel
              {
                  TripId = trip.TripId,
                  TripName = trip.TripName,
                  StartDate = trip.StartDate,
                  EndDate = trip.EndDate,
                  Notes = trip.Notes,
                  TripImg = trip.TripImg
              }).ToListAsync();
     


            var compositeViewModel = new CompositeViewModel
            {
                Stats = statsViewModel,
                Travels = travels
            };

            return View(compositeViewModel);
        }

        public IActionResult UserList()
        {
            var users = _context.Users.Where(u => u.Role == "User").ToList();
            return View(users);
        }


    }
}


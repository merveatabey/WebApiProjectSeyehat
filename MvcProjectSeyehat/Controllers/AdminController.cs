using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcProjectSeyehat.Models;
using MvcProjectSeyehat.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApiProjectSeyehat.Models.AppDbContext _context;
        public AdminController(ApiProjectSeyehat.Models.AppDbContext  context)
        {
            _context = context;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {

            var admins = _context.Users.Where(u => u.Role == "Admin").Select(u => new AdminUserVM
            {
                UserId = u.UserId,
                Name = u.Name,
                CreatedTime = u.CreatedTime,
                Role = u.Role
            }).ToList();


            var startDate = DateTime.Now.AddDays(-10);

            var travels = _context.Trips.Where(t => t.StartDate >= startDate).Select(t => new TravelViewModel
            {
                TripId = t.TripId,
                TripName = t.TripName,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Notes = t.Notes
            }).ToList();



            var participants = (from tu in _context.TripUsers
                                join u in _context.Users on tu.UserId equals u.UserId
                                join tp in _context.Trips on tu.TripId equals tp.TripId
                                select new TravelPartViewModel
                                {
                                    ParticipantName = u.Name,
                                    ParticipantMail = u.Email,
                                    TripId = tp.TripId,
                                    TripName = tp.TripName,
                                    StartDate = tp.StartDate,
                                    EndDate = tp.EndDate
                                }).ToList();    



            var model = new DashboardViewModel
            {
                adminUsers = admins,
                travelViews = travels,
                travelPartViews = participants
            };


            return View(model);
        
        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApiProjectSeyehat.Models.AppDbContext _context;

        public ActivitiesController(ApiProjectSeyehat.Models.AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task <IActionResult> Index()
        {
            var activities = await _context.Activities.ToListAsync();
            return View(activities);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Create(ApiProjectSeyehat.Models.Activity activity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(activity);
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();    
            }

            var activity = await _context.Activities.FindAsync(id);
            if(activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }
        

        public async Task<IActionResult> Edit(int id, ApiProjectSeyehat.Models.Activity activity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("hata", ex);
                }
                return RedirectToAction(nameof (Index));
            }
            return View(activity);
        }
    }
}


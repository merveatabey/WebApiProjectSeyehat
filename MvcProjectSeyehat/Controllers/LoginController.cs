using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcProjectSeyehat.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApiProjectSeyehat.Models.AppDbContext _context;

        public LoginController(ApiProjectSeyehat.Models.AppDbContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if(user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View(model);
            }


            if(user.Role == "Admin")
            {
                // Admin için dashboard'a yönlendir
                return RedirectToAction("Index", "Admin");
            } else if(user.Role == "User")
            {
                return RedirectToAction("Index", "User");
            }

            // Eğer bilinmeyen bir role varsa
            ViewBag.Error = "Unknown user role.";
            return View(model);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var users = _context.Users.Where(u => u.Role == "User").ToList();
            return View(users);
        }
    }
}


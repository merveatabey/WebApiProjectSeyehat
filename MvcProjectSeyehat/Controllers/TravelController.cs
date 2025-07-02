using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class TravelController : Controller
    {
        HttpClient client = new HttpClient();


        // GET: /<controller>/
        public IActionResult Index()
        {
            var response = client.GetAsync("https://localhost:7159/api/Trip/GetTrip").Result;
            List<ApiProjectSeyehat.Models.Trip> trips = JsonConvert.DeserializeObject<List<ApiProjectSeyehat.Models.Trip>>(response.Content.ReadAsStringAsync().Result);
            return View(trips);

        }
    }
}


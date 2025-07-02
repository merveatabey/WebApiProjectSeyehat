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

        public IActionResult Create()
        {
            return View(new ApiProjectSeyehat.Models.Trip());
        }


        [HttpPost]
        public IActionResult Create(ApiProjectSeyehat.Models.Trip trip)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(trip), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7159/api/Trip/AddTrip", content).Result;
            return RedirectToAction("ındex");
        }


        public IActionResult Edit(int id)
        {
            var response = client.GetAsync($"https://localhost:7159/api/Trip/GetTripById/{id}").Result;
            var trips = JsonConvert.DeserializeObject<ApiProjectSeyehat.Models.Trip>(response.Content.ReadAsStringAsync().Result);
            return View(trips);
        }

        [HttpPost]
        public IActionResult Edit(ApiProjectSeyehat.Models.Trip trip)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(trip), System.Text.Encoding.UTF8, "aaplication/json");
            var response = client.PutAsync($"https://localhost:7159/api/Trip/UpdateTrip/{trip.TripId}", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"https://localhost:7159/api/Trip/DeleteTrip/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}


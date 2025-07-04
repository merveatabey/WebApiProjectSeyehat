using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjectSeyehat.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class DestinationsController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: /<controller>/
        public IActionResult Index()
        {
            var response = client.GetAsync("https://localhost:7159/api/Destination/GetDestination").Result;
            List<ApiProjectSeyehat.Models.Destination> destinations = JsonConvert.DeserializeObject<List<ApiProjectSeyehat.Models.Destination>>(response.Content.ReadAsStringAsync().Result);
            return View(destinations);
        }


        public IActionResult Create()
        {
            return View(new ApiProjectSeyehat.Models.Destination());
        }

        [HttpPost]
        public IActionResult Create(ApiProjectSeyehat.Models.Destination destination)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(destination), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7159/api/Destination/AddDestination", content).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var response = client.GetAsync($"https://localhost:7159/api/Trip/GetDestinationById/{id}").Result;
            var destination = JsonConvert.DeserializeObject<ApiProjectSeyehat.Models.Destination>(response.Content.ReadAsStringAsync().Result);
            return View(destination);
        }

        [HttpPost]
        public IActionResult Edit(ApiProjectSeyehat.Models.Destination destination)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(destination), System.Text.Encoding.UTF8, "application/json");
            var response = client.PutAsync($"https://localhost:7159/api/Trip/UpdateTrip/{destination.DestId}", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"https://localhost:7159/api/Destination/DeleteDestination/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}


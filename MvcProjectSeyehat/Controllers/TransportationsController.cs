using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class TransportationsController : Controller
    {

        HttpClient client = new HttpClient();


        // GET: /<controller>/
        public IActionResult Index()
        {
            var response = client.GetAsync("https://localhost:7159/api/Transportation/GetTransportation").Result;
            List<ApiProjectSeyehat.Models.Transportation> transportations = JsonConvert.DeserializeObject<List<ApiProjectSeyehat.Models.Transportation>>(response.Content.ReadAsStringAsync().Result);
            return View(transportations);

        }

        public IActionResult Create()
        {
            return View(new ApiProjectSeyehat.Models.Transportation());
        }


        [HttpPost]
        public IActionResult Create(ApiProjectSeyehat.Models.Transportation transportation)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(transportation), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7159/api/Transportation/AddTransportation", content).Result;
            return RedirectToAction("ındex");
        }


        public IActionResult Edit(int id)
        {
            var response = client.GetAsync($"https://localhost:7159/api/Trip/GetTransportationById/{id}").Result;
            var transportations = JsonConvert.DeserializeObject<ApiProjectSeyehat.Models.Transportation>(response.Content.ReadAsStringAsync().Result);
            return View(transportations);
        }

        [HttpPost]
        public IActionResult Edit(ApiProjectSeyehat.Models.Transportation transportation)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(transportation), System.Text.Encoding.UTF8, "aaplication/json");
            var response = client.PutAsync($"https://localhost:7159/api/Transportation/UpdateTransportation/{transportation.TransportationId}", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"https://localhost:7159/api/Transportation/DeleteTransportation/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}


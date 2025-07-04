using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectSeyehat.Controllers
{
    public class AccomodationsController : Controller
    {
        HttpClient client = new HttpClient();

        // GET: /<controller>/
        public IActionResult Index()
        {
            var response = client.GetAsync("https://localhost:7159/api/Accomodation/GetAccomodation").Result;
            List<ApiProjectSeyehat.Models.Accomodation> accomodations = JsonConvert.DeserializeObject<List<ApiProjectSeyehat.Models.Accomodation>>(response.Content.ReadAsStringAsync().Result);

            return View(accomodations);
        }

        public IActionResult Create()
        {
            return View(new ApiProjectSeyehat.Models.Trip());
        }


        [HttpPost]
        public IActionResult Create(ApiProjectSeyehat.Models.Accomodation accomodation)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(accomodation), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7159/api/Accomodation/AddAccomodation", content).Result;
            return RedirectToAction("ındex");
        }


        public IActionResult Edit(int id)
        {
            var response = client.GetAsync($"https://localhost:7159/api/Accomodation/GetAccomodationById/{id}").Result;
            var accomodation = JsonConvert.DeserializeObject<ApiProjectSeyehat.Models.Accomodation>(response.Content.ReadAsStringAsync().Result);
            return View(accomodation);
        }

        [HttpPost]
        public IActionResult Edit(ApiProjectSeyehat.Models.Accomodation accomodation)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(accomodation), System.Text.Encoding.UTF8, "aaplication/json");
            var response = client.PutAsync($"https://localhost:7159/api/Accomodation/UpdateAccomodation/{accomodation.AccomodationId}", content).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"https://localhost:7159/api/Accomodation/DeleteAccomodation/{id}").Result;
            return RedirectToAction("Index");
        }


    }
}


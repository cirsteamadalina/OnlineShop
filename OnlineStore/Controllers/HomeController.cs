using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            HttpClient client = new HttpClient();
            HttpResponseMessage response =await client.GetAsync("https://localhost:44363/api/values");

            var json = response.Content.ReadAsStringAsync().Result;

            string[] cv = JsonConvert.DeserializeObject<string[]>(json);

            return View();

        }
    }
}

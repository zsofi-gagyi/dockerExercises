using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace helloDocker.Controllers
{
    public class DefaultController : Controller
    {
        static int visitorCount = 0;
        private readonly HttpClient _client;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("consumer");
        }

        [HttpGet("/")]
        public  IActionResult Default()
        {
            visitorCount++;
            ViewData["visitorNumber"] = visitorCount;
            ViewData["enviromentalFlower"] = System.Environment.GetEnvironmentVariable("flower");

            NotifyConsumer();  

            return View();
        }

        private void NotifyConsumer()
        {
            var news = new { Event = "Visitor nr." + visitorCount + "has arrived!" };
            var newsJson = JsonConvert.SerializeObject(news);
            HttpContent message = new StringContent(newsJson, Encoding.UTF8, "application/json");

            _client.PostAsync("", message);
        }
    }
}

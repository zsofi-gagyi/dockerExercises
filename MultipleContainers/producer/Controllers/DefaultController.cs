using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace helloDocker.Controllers
{
    public class DefaultController : Controller
    {
        static int visitorCount = 0;
        private readonly HttpClient _client;

        public DefaultController()
        {
            _client = new HttpClient();
        }

        [HttpGet("/")]
        public  IActionResult Default()
        {
            visitorCount++;
            ViewData["visitorNumber"] = visitorCount;
            ViewData["consumerURL"] = Environment.GetEnvironmentVariable("consumerURL");

            NotifyConsumer();  

            return View();
        }

        private void NotifyConsumer()
        {
            var news = new { VisitorNr = visitorCount , Time = DateTime.Now };
            var newsJson = JsonConvert.SerializeObject(news);
            HttpContent message = new StringContent(newsJson, Encoding.UTF8, "application/json");

            _client.PostAsync(Environment.GetEnvironmentVariable("consumerURL") + "/update", message);
        }
    }
}

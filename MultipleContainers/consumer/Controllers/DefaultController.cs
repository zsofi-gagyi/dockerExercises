using consumer.Memory;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace helloDocker.Controllers
{
    public class DefaultController : Controller

    {
        [HttpGet("/")]
        public IActionResult Default()
        {
            ViewData["news"] = NewsStore.news;
            return View();
        }

        [HttpPost("/update")]
        public void NewsConsumer([FromBody] JObject newsObject)
        {
            var dateTime = newsObject["Time"].Value<DateTime>();
            var latestNews = new string[]
                {
                    dateTime.ToLongDateString() + ", " + dateTime.ToLongTimeString(),
                    newsObject["VisitorNr"].Value<int>().ToString()
                };
            NewsStore.news.AddFirst(latestNews);
        }
    }
}

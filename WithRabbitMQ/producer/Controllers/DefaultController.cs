using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using RabbitMQ.Client;
using System.Text;

namespace helloDocker.Controllers
{
    public class DefaultController : Controller
    {
        static int visitorCount = 0;

        [HttpGet("/")]
        public  IActionResult Default()
        {
            visitorCount++;
            ViewData["visitorNumber"] = visitorCount;

            NotifyConsumer();  

            return View();
        }

        private void NotifyConsumer()
        {
            var news = new { VisitorNr = visitorCount , Time = DateTime.Now };
            var newsJson = JsonConvert.SerializeObject(news);

            var factory = new ConnectionFactory() { HostName = "rabbit" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "news_from_the_producer",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null); 
                    // idempotent - repeating it is not a problem

                    var body = Encoding.UTF8.GetBytes(newsJson);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "news_from_the_producer",
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
    }
}
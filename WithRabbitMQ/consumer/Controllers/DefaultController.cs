using Microsoft.AspNetCore.Mvc;
using consumer.Memory;
using rabbitConsumer.Controllers;

namespace helloDocker.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet("/")]
        public IActionResult Default()
        {
            UpdateReceiver.ReceiveUpdates();
            ViewData["news"] = NewsStore.news;
            return View();
        }
    }
}
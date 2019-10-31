using Microsoft.AspNetCore.Mvc;
using consumer.Memory;

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
    }
}
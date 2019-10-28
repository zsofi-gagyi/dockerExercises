using Microsoft.AspNetCore.Mvc;

namespace helloDocker.Controllers
{
    public class DefaultController : Controller
    {
        static int visitorCount = 0;

        [HttpGet("/")]
        public IActionResult Default()
        {
            visitorCount++;
            ViewData["visitorNumber"] = visitorCount;
            ViewData["enviromentalFlower"] = System.Environment.GetEnvironmentVariable("flower");
            return View();
        }
    }
}

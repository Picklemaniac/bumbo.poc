using Microsoft.AspNetCore.Mvc;

namespace bumbo.poc.web.Controllers
{
    public class SchedulerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace specifiedbehavior.web.Controllers
{
    public class ResourcesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

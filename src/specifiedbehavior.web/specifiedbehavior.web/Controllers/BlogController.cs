using Microsoft.AspNetCore.Mvc;

namespace specifiedbehavior.web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ComparingGoogleBardWithChatGPT()
        {
            return View();
        }
    }
}

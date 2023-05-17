using Microsoft.AspNetCore.Mvc;

namespace specifiedbehavior.web.Controllers
{
    public class ExperimentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ComparingGoogleBardWithChatGPT()
        {
            return View();
        }

        public IActionResult PlayingWithD3JS()
        {

            return View();
        }
    }
}

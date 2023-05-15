using Microsoft.AspNetCore.Mvc;

namespace specifiedbehavior.web.Controllers
{
    public class SitemapController : Controller
    {
        public IActionResult Index()
        {
            return File("~/sitemap.xml", "text/xml");
        }
    }
}

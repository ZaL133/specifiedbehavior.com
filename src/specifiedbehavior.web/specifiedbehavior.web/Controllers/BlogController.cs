using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using specifiedbehavior.web.Data;
using specifiedbehavior.web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace specifiedbehavior.web.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogView
        public async Task<IActionResult> Index()
        {
            var posts = await _context.BlogPosts.ToListAsync();
            return View(posts);
        }

        // GET: BlogView/Post/5
        public async Task<IActionResult> Post(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.BlogPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}

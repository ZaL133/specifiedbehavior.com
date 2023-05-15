using System.Linq;
using Microsoft.AspNetCore.Mvc;
using specifiedbehavior.web.Models;
using specifiedbehavior.web.Data;

namespace YourNamespace.Controllers
{
    public class BloggerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloggerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blog
        public IActionResult Index()
        {
            return View(_context.BlogPosts.ToList());
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.DateCreated = DateTime.Now;
                _context.Add(blogPost);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Blog/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = _context.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(blogPost);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Blog/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = _context.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var blogPost = _context.BlogPosts.Find(id);
            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

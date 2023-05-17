using System.Linq;
using Microsoft.AspNetCore.Mvc;
using specifiedbehavior.web.Models;
using specifiedbehavior.web.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Author,MetaTitle,MetaDescription,MetaKeywords")] BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Load the existing entity from the database
                    var existingPost = await _context.BlogPosts.FirstOrDefaultAsync(m => m.Id == id);

                    if (existingPost == null)
                    {
                        return NotFound();
                    }

                    // Copy the updated properties from the model to the existing entity
                    existingPost.Title = blogPost.Title;
                    existingPost.Content = blogPost.Content;
                    existingPost.SEOTitle = blogPost.SEOTitle;
                    existingPost.SEODescription = blogPost.SEODescription;
                    existingPost.SEOKeywords = blogPost.SEOKeywords;

                    // Save the existing entity with the updated properties
                    _context.Update(existingPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }


        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
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

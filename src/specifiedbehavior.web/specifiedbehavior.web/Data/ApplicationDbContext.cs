using Microsoft.EntityFrameworkCore;
using specifiedbehavior.web.Models;

namespace specifiedbehavior.web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}

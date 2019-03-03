using MVCBLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCBLOG.Repositories
{
    public class PostRepository
    {
        private ApplicationDbContext _context;

        public PostRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Post> GetTypedPosts(string searchTerm = null)
        {
            var typedPosts = _context.Posts
               .Include(a => a.CreatedByUser)
               .Include(a => a.Theme)
               .Where(d => d.CreatedOn > DateTime.Now);
            if (!String.IsNullOrWhiteSpace(searchTerm))
            {
                typedPosts = typedPosts
                    .Where(g =>
                            g.CreatedByUser.Name.Contains(searchTerm) ||
                            g.Theme.Name.Contains(searchTerm) ||
                            g.Title.Contains(searchTerm));
            }

            return typedPosts.ToList();
        }
    }
}
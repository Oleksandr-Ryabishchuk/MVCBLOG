using Microsoft.AspNet.Identity;
using MVCBLOG.Models;
using MVCBLOG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBLOG.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext _context;
        public BlogController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult CreateTheme()
        {
            var viewModel = new ThemeFormViewModel
            {
                Name = "First Theme",
                CreatedOn = DateTime.Now
            };
            return View("CreateTheme", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTheme(ThemeFormViewModel viewModel)
        {
            var currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
            if (!ModelState.IsValid)
            {
                viewModel.CreatedOn = DateTime.Now;
                return RedirectToAction("Index", "Home"); //return View("ThemeForm", viewModel);
            }
            var theme = new Theme
            {
                Name = viewModel.Name,
                CreatedByUser = currentUser,
                CreatedOn = DateTime.Now
            };

            _context.Themes.Add(theme);
            _context.SaveChanges();
            return RedirectToAction("CreateTheme", "Blog");
        }

        [Authorize]

        public ActionResult CreatePost()
        {


            var viewModel = new PostFormViewModel
            {
                Title = "Add a Post",
                Body = "Describe your Post",
                Themes = _context.Themes.ToList(),
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            return View("CreatePost", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(PostFormViewModel viewModel)
        {
            try
            {
                var currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
                var theme = _context.Themes.Single(t => t.Id == viewModel.Theme);

                List<Theme> themes = _context.Themes.ToList();
                if (!ModelState.IsValid)
                {
                    viewModel.Themes = themes;
                    return RedirectToAction("CreatePost", viewModel); //return View("ThemeForm", viewModel);
                }
                var post = new Post
                {
                    Title = viewModel.Title,
                    CreatedByUser = currentUser,
                    Body = viewModel.Body,
                    CreatedOn = DateTime.Now,
                    Theme = theme,
                    ModifiedOn = DateTime.Now
                };

                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("CreatePost", "Blog");
            }
            catch (Exception e)
            {
                return RedirectToAction("CreatePost", "Blog");
            }
        }
    }
}
using MVCBLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBLOG.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> TypedPosts { get; set; }

        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}
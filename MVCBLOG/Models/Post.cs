using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBLOG.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ApplicationUser CreatedByUser { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }
        [Required]
        public Theme Theme { get; set; }

        [Required]
        public int ThemeId { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

    }
}
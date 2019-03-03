using MVCBLOG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBLOG.ViewModels
{
    public class PostFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }



        public string CreatedByUserId { get; set; }

        [Required]
        public int Theme { get; set; }
        public IEnumerable<Theme> Themes { get; set; }


        public string Body { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
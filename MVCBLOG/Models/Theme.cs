using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBLOG.Models
{
    public class Theme
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public ApplicationUser CreatedByUser { get; set; }
        [Required]
        public string CreatedByUserId { get; set; }
    }
}
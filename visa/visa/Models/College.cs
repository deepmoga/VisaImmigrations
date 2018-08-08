using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class College
    {
        [Key]
        public int Collegeid { get; set; }
        [Display(Name = "College name")]
        [Required]
        public string CollegeName { get; set; }
        [Display(Name = "Classid")]
        public int Countryid { get; set; }

        public virtual Country Countrys { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
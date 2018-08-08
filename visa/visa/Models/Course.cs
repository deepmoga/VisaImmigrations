using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class Course
    {
        [Key]
        public int Courseid { get; set; }
        [Display(Name = "Classid")]
        public int Collegeid { get; set; }

        public virtual College Colleges { get; set; }
        public string CourseName { get; set; }



      
    }
}
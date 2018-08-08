using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class Docs
    {
        public int id { get; set; }
        public string DocName { get; set; }
        public string Documents { get; set; }
       
        [Display(Name = "Student")]
        public int Preformid { get; set; }

        public virtual PreForm preforms { get; set; }
    }
}
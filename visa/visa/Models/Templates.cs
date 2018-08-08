using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace visa.Models
{
    public class Templates
    {
        [Key]
        public int Templateid { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Template { get; set; }
        public virtual ICollection<LogsDetails> LogDetails { get; set; }
    }
}
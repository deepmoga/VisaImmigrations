using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class LogsDetails
    {
        [Key]
        public int Logsid { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        [Display(Name = "Student")]
        public int Templateid { get; set; }

        public virtual Templates Templates { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        [Display(Name = "Student")]
        public int Preformid { get; set; }

        public virtual PreForm preforms { get; set; }

    }
}
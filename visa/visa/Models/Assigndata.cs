using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class Assigndata
    {

        public int id { get; set; }
        public string Serialid { get; set; }
        public int Studentid { get; set; }
        public string StudentName { get; set; }

        public string Country { get; set; }
        public string College { get; set; }
        public string Course { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
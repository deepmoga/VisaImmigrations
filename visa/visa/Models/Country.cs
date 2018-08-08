using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class Country
    {
        [Key]
        public int Countryid { get; set; }
        [Display(Name="Country name")]
        [Required]
  
        public string CountryName { get; set; }
        public virtual ICollection<College> Colleges { get; set; }


    }
}
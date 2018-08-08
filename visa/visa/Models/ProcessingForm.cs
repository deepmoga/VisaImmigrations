using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class ProcessingForm
    {
        [Key]
        public int Formid { get; set; }

        [Display(Name = "Student")]
        public int Preformid { get; set; }

        public virtual PreForm preforms { get; set; }
        [Required]
        public string OfferLetterCollege { get; set; }
        public string OfferLetterFee { get; set; }

        [Display(Name = "AppliedDate")]
        [DataType(DataType.Date)]
        public DateTime? AppliedDate { get; set; }

        [Display(Name = "RecivedDate")]
        [DataType(DataType.Date)]
        public DateTime? RecivedDate { get; set; }

        public string ProcessingFee { get; set; }

        [Display(Name = "ProcessAlertDate")]
        [DataType(DataType.Date)]
        public DateTime? ProcessAlertDate { get; set; }
      
        public string CollegeFee { get; set; }

        [Display(Name = "CollegeAlertDate")]
        [DataType(DataType.Date)]
        public DateTime? CollegeAlertDate { get; set; }
       
        public string GICFee { get; set; }
        [Display(Name = "GICAlertDate")]
        [DataType(DataType.Date)]
        public DateTime? GICAlertDate { get; set; }

        public string EmedicalFee { get; set; }
        [Display(Name = "AppointmentDate")]
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }
  
        public string EmbassyFee { get; set; }
        [Display(Name = "EmbassyAlertDate")]
        [DataType(DataType.Date)]
        public DateTime? EmbassyAlertDate { get; set; }
        public string TrackingId { get; set; }
       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace visa.Models
{
    public class PreForm
    {
        [Key]
        public int Preformid { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required (ErrorMessage ="EnterName")]

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required (ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public string ContactNo { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required (ErrorMessage ="Please Enter Email Address For Updates")]
        public string Email { get; set; }
        public string Nationality { get; set; }
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime? Dateofbirth { get; set; }
        [Required]
        public string Passport { get; set; }
        public string NationalId { get; set; }
        public string Ielts { get; set; }
       
        [Display(Name = "Preffered Country")]
        public string PrefCountry { get; set; }
        [Display(Name = "Preffered College If You Have")]
        public string PrefCollege { get; set; }
        [Display (Name ="Preffered Subject")]
        public string PrefSubject { get; set; }
        
        public string RefferedName { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }

       
        public string Qualification { get; set; }
        public virtual ICollection<ProcessingForm> Processingforms { get; set; }
        public virtual ICollection<Docs> Docs { get; set; }
        public virtual ICollection<LogsDetails> LogDetails { get; set; }


    }
    public enum Relegion
    {
        Hindu,
        Sikh,
        Muslim
    }
    public enum BirthC
    {
        Yes,No
    }
    public enum scolar
    { yes,no}
    public enum GenderType
    {
        Male = 1,
        Female = 2
    }
    public enum status
    { Pending,UnderProcessing,Rejected,Approved}

}
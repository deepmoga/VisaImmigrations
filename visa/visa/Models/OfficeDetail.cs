using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace visa.Models
{
    public class OfficeDetail
    {
        public int id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string GSTNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
        public string LicenceKey { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    
        public string AlertDays { get; set; }
 
        public string ValidKey { get; set; }
        public string smsUsername { get; set; }
        public string SenderId { get; set; }
        public string API { get; set; }
        public bool SMSActive { get; set; }



    }
}
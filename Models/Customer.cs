using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace generalapi.Models
{
    public class Customer
    {
        public int customerid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        [Required]
    
        public string identitynumber { get; set; }

        [Required]
       
        public string cellphone { get; set; }

        [Required]
       
        public string emailaddress { get; set; }
        public string postaladdress { get; set; }
        public string gender { get; set; }

       // [DataType(DataType.Date)]
        public string country { get; set; }
    }
}

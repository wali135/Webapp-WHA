using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace WHA.Models
{
    public class Drivers
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }



        [Required]
        [StringLength(20)]
        [Display(Name = "RFID Card Number")]
        public string Uid { get; set; }
        

        
        [Required]
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Invalid CNIC number must be 13 digits long")]
        public string CNIC { get; set; }


        [Display (Name="Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Only Mobile number allowed: 11 digits only")]
        public string MobileNumber {get; set;}



}
}
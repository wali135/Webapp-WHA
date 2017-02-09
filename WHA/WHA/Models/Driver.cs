using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace WHA.Models
{
    public class Driver
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        
        [Required]
       // [RegularExpression(@"^?[0-9]{5}")]
        public String CNIC { get; set; }


        [Display (Name="Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string MobileNumber {get; set;}



}
}
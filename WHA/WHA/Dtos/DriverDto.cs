using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WHA.Dtos
{
    public class DriverDto
    {

        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }



        [Required]
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Invalid CNIC number must be 13 digits long")]
        public string CNIC { get; set; }


       
        [Required(ErrorMessage = "Mobile Number Required")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Phone number seem Invalid-only Mobile number allowed")]
        public string MobileNumber { get; set; }
    }
}
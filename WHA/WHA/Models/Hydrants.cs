using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WHA.Models
{
    public class Hydrants
    {
       
        public int Id { get; set; }
       // public Supervisor Supervisor { get; set; }
       // public int SupervisorId { get; set; }
       [Required]
        public string Location { get; set; }
        [Required]
        public string SupervisorName { get; set; }    
    }
}
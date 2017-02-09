using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WHA.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public Hydrants Hydrant { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public float Consumption { get; set; }  

    }
}
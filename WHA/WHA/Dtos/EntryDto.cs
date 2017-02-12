using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WHA.Models;

namespace WHA.Dtos
{
    public class EntryDto
    {
        public int Id { get; set; }

        [Required]
        public Hydrants Hydrant { get; set; }

        [Required]
        public Drivers Driver { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public float Consumption { get; set; }
    }
}
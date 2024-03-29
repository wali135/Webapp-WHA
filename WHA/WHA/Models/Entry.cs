﻿using System;
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
        public int HydrantId { get; set; }

        [Required]
        public Drivers Driver { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public float Consumption { get; set; }  

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WHA.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public float Capacity { get; set; }

        public Drivers Driver { get; set; }

        public int DriverId { get; set; }

        public int RfId { get; set; }


    }
}
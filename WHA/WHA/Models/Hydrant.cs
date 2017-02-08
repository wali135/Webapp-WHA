using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WHA.Models
{
    public class Hydrant
    {
        public int Id { get; set; }
        public Supervisor Supervisor { get; set; }
        public int SupervisorId { get; set; }
        public string Location { get; set; }    
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WHA.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Hydrants> Hydrants { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
         
        }

        public static ApplicationDbContext Create()
        {
           
            return new ApplicationDbContext();
        }
    }
}
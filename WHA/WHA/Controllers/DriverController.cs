using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using WHA.Models;

namespace WHA.Controllers
{
    public class DriverController : Controller
    {
        private ApplicationDbContext _context;

        public DriverController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Driver
        public ActionResult Index()
        {
            var drivers = _context.Drivers.ToList();
            return View(drivers);
        }

        public ActionResult New()
        {
            var driver = new Driver();

            return View("DriverForm", driver);
        }
        public ActionResult Details(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(d => d.Id == id);
            if(driver==null)
                return HttpNotFound();

            return View(driver);
        }


        //Must pass an ID
        public ActionResult Edit(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(d => d.Id == id);
            if(driver==null)
                return HttpNotFound();

            
            return View("DriverForm", driver);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                
                return View("DriverForm", driver);
            }
            if (driver.Id == 0)
                _context.Drivers.Add(driver);

            else
            {
                var driverInDb =_context.Drivers.Single(d => d.Id == driver.Id);
                driverInDb.Name = driver.Name;
                driverInDb.CNIC = driver.CNIC;
                driverInDb.MobileNumber = driver.MobileNumber;

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Driver");
        }
    }
}
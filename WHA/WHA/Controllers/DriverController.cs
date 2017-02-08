using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using WHA.Models;

namespace WHA.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            return View();
        }


        //Must pass an ID
        public ActionResult Edit()
        {
            var driver = new Driver();
            driver.Id = 5;
            driver.Name = "Abid";
            return View(driver);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHA.Models;

namespace WHA.Controllers
{
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.Admin))
            return View();

            ViewBag.Id = 6;
            return View("IndexSuper");
        }
    }
}
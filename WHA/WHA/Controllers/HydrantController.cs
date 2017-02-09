using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WHA.Models;

namespace WHA.Controllers
{
    public class HydrantController : Controller
    {
     
   
        private ApplicationDbContext _context;

        public HydrantController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Hydrant
        public ActionResult Index()
        {
            var hydrant = _context.Hydrants.ToList();
            return View(hydrant);
        }

        public ActionResult New()
        {
            var hydrant = new Hydrant();

            return View("HydrantForm", hydrant);
        }
        public ActionResult Details(int id)
        {
            var hydrant = _context.Hydrants.SingleOrDefault(d => d.Id == id);
            if (hydrant == null)
                return HttpNotFound();

            return View(hydrant);
        }


        //Must pass an ID
        public ActionResult Edit(int id)
        {
            var hydrant = _context.Hydrants.SingleOrDefault(d => d.Id == id);
            if (hydrant == null)
                return HttpNotFound();


            return View("HydrantForm", hydrant);
        }

        [HttpPost]
        public ActionResult Save(Hydrant hydrant)
        {
            if (hydrant.Id == 0)
                _context.Hydrants.Add(hydrant);

            else
            {
                var hydrantInDb = _context.Hydrants.Single(d => d.Id == hydrant.Id);
                hydrantInDb.SupervisorId = hydrant.SupervisorId;
                hydrantInDb.Location = hydrant.Location;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Hydrant");
        }
    }
}
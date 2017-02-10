using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using WHA.Models;

namespace WHA.Controllers.Api
{
    public class DriversController : ApiController
    {
        private ApplicationDbContext _context;

        public DriversController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/drivers
        public IEnumerable<Drivers> GetDrivers()
        {
            return _context.Drivers.ToList();
        }

         // GET /api/drivers/1
        public Drivers GetDriver(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(m => m.Id == id);
            if (driver == null)
             throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return driver;
        }

        //POST /api/drivers
        [HttpPost]
        public Drivers CreateDrivers(Drivers driver)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Drivers.Add(driver);
            _context.SaveChanges();

            return driver;

        }

        //PUT /api/drivers/1
        public void UpdateDriver(int id, Drivers driver)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var driverInDb = _context.Drivers.SingleOrDefault(d => d.Id == id);
            if(driverInDb ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            driverInDb.Name = driver.Name;
            driverInDb.CNIC = driver.CNIC;
            driverInDb.MobileNumber = driver.MobileNumber;

            _context.SaveChanges();
        }


        //DELETE /api/drivers/1
        [HttpDelete]
        public void DeleteDriver(int id)
        {
            var driverInDb = _context.Drivers.SingleOrDefault(d => d.Id == id);
            if (driverInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Drivers.Remove(driverInDb);
            _context.SaveChanges();
        }
    }
}

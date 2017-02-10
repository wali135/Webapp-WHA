using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using WHA.Dtos;
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
        public IEnumerable<DriverDto> GetDrivers()
        {
            return _context.Drivers.ToList().Select(Mapper.Map<Drivers,DriverDto>);
        }

         // GET /api/drivers/1
        public DriverDto GetDriver(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(m => m.Id == id);
            if (driver == null)
             throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return Mapper.Map<Drivers,DriverDto>(driver);
        }

        //POST /api/drivers
        [HttpPost]
        public DriverDto CreateDrivers(DriverDto driverDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var driver = Mapper.Map<DriverDto, Drivers>(driverDto);
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            driverDto.Id = driver.Id;

            return driverDto;

        }

        //PUT /api/drivers/1
        [HttpPut]
        public void UpdateDriver(int id, DriverDto driverDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var driverInDb = _context.Drivers.SingleOrDefault(d => d.Id == id);
            if(driverInDb ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(driverDto, driverInDb);
          
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

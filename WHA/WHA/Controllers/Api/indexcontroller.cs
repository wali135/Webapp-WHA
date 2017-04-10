using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WHA.Dtos;
using WHA.Models;
using WHA.App_Start;

namespace WHA.Controllers.Api
{
    [JsonpFilter]
    public class IndexController : ApiController
    {
        private ApplicationDbContext _context;

        public IndexController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/pitoday
        [Route("api/pitoday")]
        public IEnumerable<Entry> GetEntries()
        {
            DateTime dn = DateTime.Today;
            
            return _context.Entries.Where(s => s.DateTime.Day == dn.Day).ToList();
           
        }

        //GET /api/weekly
        [Route("api/weekly")]
        public IEnumerable<Entry> Getweekly()
        {
            DateTime dn = DateTime.Today;
            DateTime week =  dn.AddDays(-(int)dn.DayOfWeek - 6);
            return _context.Entries.Where(s => s.DateTime.Day <= dn.Day && s.DateTime.Day >= week.Day).ToList();
        }

       /* //POST /api/entry
        
        [Route("api/entry/{id}")]
        [HttpPost]
        public IHttpActionResult CreateEntries(EntryDto entryDto,int id)
        {
            var driver = _context.Drivers.SingleOrDefault(d => d.Id == entryDto.Driver.Id);
            if(driver==null)
                return BadRequest("Invalid Driver ID.");
            var hydrant = _context.Hydrants.SingleOrDefault(h => h.Id == id);
            if(hydrant==null)
                return BadRequest("Invalid Hydrant Id.");

            var entry =new Entry();
            entry.Driver = driver;
            entry.HydrantId = id;
            entry.DateTime = entryDto.DateTime;
            entry.Consumption = entryDto.Consumption;

             
            _context.Entries.Add(entry);
            _context.SaveChanges();
            entryDto.Id = entry.Id;

            return Created(new Uri(Request.RequestUri + "/" + entry.Id), entryDto);

        }*/
    }
}

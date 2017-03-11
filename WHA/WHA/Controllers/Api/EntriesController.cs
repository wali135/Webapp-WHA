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

namespace WHA.Controllers.Api
{
    public class EntriesController : ApiController
    {
        private ApplicationDbContext _context;

        public EntriesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/entries
        public IEnumerable<Entry> GetEntries()
        {
            return _context.Entries.Include(c=>c.Driver).ToList();
        }

        //GET /api/entries/id
        [Route("api/entries/{id}")]
        public IEnumerable<Entry> GetEntries(int id)
        {
            return _context.Entries.Where(b=>b.HydrantId==id).Include(c=>c.Driver).ToList();
        }

        //POST /api/entry
        
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

        }
    }
}

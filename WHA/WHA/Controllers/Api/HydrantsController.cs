using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WHA.Dtos;
using WHA.Models;

namespace WHA.Controllers.Api
{
    public class HydrantsController : ApiController
    {
        private ApplicationDbContext _context;

        public HydrantsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/hydrants
        public IEnumerable<HydrantDto> GetHydrants()
        {
            return _context.Hydrants.ToList().Select(Mapper.Map<Hydrants, HydrantDto>);
        }

        // GET /api/hydrants/1
        public HydrantDto GetHydrant(int id)
        {
            var hydrant = _context.Hydrants.SingleOrDefault(m => m.Id == id);
            if (hydrant == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Hydrants, HydrantDto>(hydrant);
        }

        //POST /api/hydrants
        [HttpPost]
        public IHttpActionResult CreateDrivers(HydrantDto hydrantDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hydrant = Mapper.Map<HydrantDto, Hydrants>(hydrantDto);
            _context.Hydrants.Add(hydrant);
            _context.SaveChanges();
            hydrantDto.Id = hydrant.Id;

            return Created(new Uri(Request.RequestUri + "/" + hydrant.Id), hydrantDto);

        }

        //PUT /api/hydrants/1
        [HttpPut]
        public void UpdateHydrant(int id, HydrantDto hydrantDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var hydrantInDb = _context.Hydrants.SingleOrDefault(h => h.Id == id);
            if (hydrantInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(hydrantDto, hydrantInDb);

            _context.SaveChanges();
        }


        //DELETE /api/hydrants/1
        [HttpDelete]
        public void DeleteHydrant(int id)
        {
            var hydrantInDb = _context.Hydrants.SingleOrDefault(d => d.Id == id);
            if (hydrantInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Hydrants.Remove(hydrantInDb);
            _context.SaveChanges();
        }
    }
}

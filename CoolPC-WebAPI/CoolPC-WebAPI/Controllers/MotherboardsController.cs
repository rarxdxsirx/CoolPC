using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CoolPC_WebAPI;
using CoolPC_WebAPI.Dto;

namespace CoolPC_WebAPI.Controllers
{
    public class MotherboardsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Motherboards
        public IHttpActionResult GetMotherboards()
        {
            return Ok(db.Motherboards.ToList().ConvertAll(a => new MotherboardsDto(a)));
        }

        // GET: api/Motherboards/5
        [ResponseType(typeof(Motherboards))]
        public IHttpActionResult GetMotherboards(long id)
        {
            Motherboards motherboards = db.Motherboards.Find(id);
            if (motherboards == null)
            {
                return NotFound();
            }

            return Ok(new MotherboardsDto(motherboards));
        }

        // PUT: api/Motherboards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotherboards(long id, Motherboards motherboards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motherboards.motherbroad_id)
            {
                return BadRequest();
            }

            db.Entry(motherboards).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotherboardsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Motherboards
        [ResponseType(typeof(Motherboards))]
        public IHttpActionResult PostMotherboards(Motherboards motherboards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Motherboards.Add(motherboards);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MotherboardsExists(motherboards.motherbroad_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = motherboards.motherbroad_id }, motherboards);
        }

        // DELETE: api/Motherboards/5
        [ResponseType(typeof(Motherboards))]
        public IHttpActionResult DeleteMotherboards(long id)
        {
            Motherboards motherboards = db.Motherboards.Find(id);
            if (motherboards == null)
            {
                return NotFound();
            }

            db.Motherboards.Remove(motherboards);
            db.SaveChanges();

            return Ok(motherboards);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotherboardsExists(long id)
        {
            return db.Motherboards.Count(e => e.motherbroad_id == id) > 0;
        }
    }
}
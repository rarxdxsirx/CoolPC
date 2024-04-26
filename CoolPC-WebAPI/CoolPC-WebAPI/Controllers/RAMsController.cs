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
    public class RAMsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/RAMs
        public IHttpActionResult GetRAMs()
        {
            return Ok(db.RAMs.ToList().ConvertAll(a => new RAMsDto(a)));
        }

        // GET: api/RAMs/5
        [ResponseType(typeof(RAMs))]
        public IHttpActionResult GetRAMs(long id)
        {
            RAMs rAMs = db.RAMs.Find(id);
            if (rAMs == null)
            {
                return NotFound();
            }

            return Ok(new RAMsDto(rAMs));
        }

        // PUT: api/RAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRAMs(long id, RAMs rAMs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rAMs.ram_id)
            {
                return BadRequest();
            }

            db.Entry(rAMs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RAMsExists(id))
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

        // POST: api/RAMs
        [ResponseType(typeof(RAMs))]
        public IHttpActionResult PostRAMs(RAMs rAMs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RAMs.Add(rAMs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RAMsExists(rAMs.ram_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rAMs.ram_id }, rAMs);
        }

        // DELETE: api/RAMs/5
        [ResponseType(typeof(RAMs))]
        public IHttpActionResult DeleteRAMs(long id)
        {
            RAMs rAMs = db.RAMs.Find(id);
            if (rAMs == null)
            {
                return NotFound();
            }

            db.RAMs.Remove(rAMs);
            db.SaveChanges();

            return Ok(rAMs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RAMsExists(long id)
        {
            return db.RAMs.Count(e => e.ram_id == id) > 0;
        }
    }
}
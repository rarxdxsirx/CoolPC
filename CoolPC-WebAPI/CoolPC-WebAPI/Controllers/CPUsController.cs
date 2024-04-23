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

namespace CoolPC_WebAPI.Controllers
{
    public class CPUsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/CPUs
        public IQueryable<CPUs> GetCPUs()
        {
            return db.CPUs;
        }

        // GET: api/CPUs/5
        [ResponseType(typeof(CPUs))]
        public IHttpActionResult GetCPUs(long id)
        {
            CPUs cPUs = db.CPUs.Find(id);
            if (cPUs == null)
            {
                return NotFound();
            }

            return Ok(cPUs);
        }

        // PUT: api/CPUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCPUs(long id, CPUs cPUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPUs.cpu_id)
            {
                return BadRequest();
            }

            db.Entry(cPUs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPUsExists(id))
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

        // POST: api/CPUs
        [ResponseType(typeof(CPUs))]
        public IHttpActionResult PostCPUs(CPUs cPUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPUs.Add(cPUs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CPUsExists(cPUs.cpu_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cPUs.cpu_id }, cPUs);
        }

        // DELETE: api/CPUs/5
        [ResponseType(typeof(CPUs))]
        public IHttpActionResult DeleteCPUs(long id)
        {
            CPUs cPUs = db.CPUs.Find(id);
            if (cPUs == null)
            {
                return NotFound();
            }

            db.CPUs.Remove(cPUs);
            db.SaveChanges();

            return Ok(cPUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPUsExists(long id)
        {
            return db.CPUs.Count(e => e.cpu_id == id) > 0;
        }
    }
}
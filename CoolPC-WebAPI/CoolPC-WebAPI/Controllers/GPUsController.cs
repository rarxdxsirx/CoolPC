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
    public class GPUsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/GPUs
        public IHttpActionResult GetGPUs()
        {
            return Ok(db.GPUs.ToList().ConvertAll(a => new GPUsDto(a)));
        }

        // GET: api/GPUs/5
        [ResponseType(typeof(GPUs))]
        public IHttpActionResult GetGPUs(long id)
        {
            GPUs gPUs = db.GPUs.Find(id);
            if (gPUs == null)
            {
                return NotFound();
            }

            return Ok(new GPUsDto(gPUs));
        }

        // PUT: api/GPUs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGPUs(long id, GPUs gPUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gPUs.gpu_id)
            {
                return BadRequest();
            }

            db.Entry(gPUs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPUsExists(id))
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

        // POST: api/GPUs
        [ResponseType(typeof(GPUs))]
        public IHttpActionResult PostGPUs(GPUs gPUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GPUs.Add(gPUs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GPUsExists(gPUs.gpu_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gPUs.gpu_id }, gPUs);
        }

        // DELETE: api/GPUs/5
        [ResponseType(typeof(GPUs))]
        public IHttpActionResult DeleteGPUs(long id)
        {
            GPUs gPUs = db.GPUs.Find(id);
            if (gPUs == null)
            {
                return NotFound();
            }

            db.GPUs.Remove(gPUs);
            db.SaveChanges();

            return Ok(gPUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GPUsExists(long id)
        {
            return db.GPUs.Count(e => e.gpu_id == id) > 0;
        }
    }
}
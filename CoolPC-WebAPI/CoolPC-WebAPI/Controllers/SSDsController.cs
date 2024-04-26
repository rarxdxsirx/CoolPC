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
    public class SSDsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/SSDs
        public IHttpActionResult GetSSDs()
        {
            return Ok(db.SSDs.ToList().ConvertAll(a => new SSDsDto(a)));
        }

        // GET: api/SSDs/5
        [ResponseType(typeof(SSDs))]
        public IHttpActionResult GetSSDs(long id)
        {
            SSDs sSDs = db.SSDs.Find(id);
            if (sSDs == null)
            {
                return NotFound();
            }

            return Ok(new SSDsDto(sSDs));
        }

        // PUT: api/SSDs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSSDs(long id, SSDs sSDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sSDs.ssd_id)
            {
                return BadRequest();
            }

            db.Entry(sSDs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SSDsExists(id))
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

        // POST: api/SSDs
        [ResponseType(typeof(SSDs))]
        public IHttpActionResult PostSSDs(SSDs sSDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SSDs.Add(sSDs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SSDsExists(sSDs.ssd_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sSDs.ssd_id }, sSDs);
        }

        // DELETE: api/SSDs/5
        [ResponseType(typeof(SSDs))]
        public IHttpActionResult DeleteSSDs(long id)
        {
            SSDs sSDs = db.SSDs.Find(id);
            if (sSDs == null)
            {
                return NotFound();
            }

            db.SSDs.Remove(sSDs);
            db.SaveChanges();

            return Ok(sSDs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SSDsExists(long id)
        {
            return db.SSDs.Count(e => e.ssd_id == id) > 0;
        }
    }
}
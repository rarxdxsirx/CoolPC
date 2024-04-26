using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CoolPC_WebAPI;
using CoolPC_WebAPI.Dto;

namespace CoolPC_WebAPI.Controllers
{
    public class HDDsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/HDDs
        public IHttpActionResult GetHDDs()
        {
            return Ok(db.HDDs.ToList().ConvertAll(a => new HDDsDto(a)));
        }

        // GET: api/HDDs/5
        [ResponseType(typeof(HDDs))]
        public IHttpActionResult GetHDDs(long id)
        {
            HDDs hDDs = db.HDDs.Find(id);
            if (hDDs == null)
            {
                return NotFound();
            }

            return Ok(new HDDsDto(hDDs));
        }

        // PUT: api/HDDs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHDDs(long id, HDDs hDDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hDDs.hdd_id)
            {
                return BadRequest();
            }

            db.Entry(hDDs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HDDsExists(id))
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

        // POST: api/HDDs
        [ResponseType(typeof(HDDs))]
        public IHttpActionResult PostHDDs(HDDs hDDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HDDs.Add(hDDs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HDDsExists(hDDs.hdd_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hDDs.hdd_id }, hDDs);
        }

        // DELETE: api/HDDs/5
        [ResponseType(typeof(HDDs))]
        public IHttpActionResult DeleteHDDs(long id)
        {
            HDDs hDDs = db.HDDs.Find(id);
            if (hDDs == null)
            {
                return NotFound();
            }

            db.HDDs.Remove(hDDs);
            db.SaveChanges();

            return Ok(hDDs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HDDsExists(long id)
        {
            return db.HDDs.Count(e => e.hdd_id == id) > 0;
        }
    }
}
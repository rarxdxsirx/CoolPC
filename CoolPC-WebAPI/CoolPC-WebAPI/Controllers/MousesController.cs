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
    public class MousesController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Mouses
        public IHttpActionResult GetMouses()
        {
            return Ok(db.Mouses.ToList().ConvertAll(a=> new MousesDto(a)));
        }

        // GET: api/Mouses/5
        [ResponseType(typeof(Mouses))]
        public IHttpActionResult GetMouses(long id)
        {
            Mouses mouses = db.Mouses.Find(id);
            if (mouses == null)
            {
                return NotFound();
            }

            return Ok(new MousesDto(mouses));
        }

        // PUT: api/Mouses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMouses(long id, Mouses mouses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mouses.mouse_id)
            {
                return BadRequest();
            }

            db.Entry(mouses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MousesExists(id))
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

        // POST: api/Mouses
        [ResponseType(typeof(Mouses))]
        public IHttpActionResult PostMouses(Mouses mouses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mouses.Add(mouses);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MousesExists(mouses.mouse_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mouses.mouse_id }, mouses);
        }

        // DELETE: api/Mouses/5
        [ResponseType(typeof(Mouses))]
        public IHttpActionResult DeleteMouses(long id)
        {
            Mouses mouses = db.Mouses.Find(id);
            if (mouses == null)
            {
                return NotFound();
            }

            db.Mouses.Remove(mouses);
            db.SaveChanges();

            return Ok(mouses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MousesExists(long id)
        {
            return db.Mouses.Count(e => e.mouse_id == id) > 0;
        }
    }
}
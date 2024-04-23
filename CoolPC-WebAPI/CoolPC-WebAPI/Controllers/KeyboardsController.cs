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
    public class KeyboardsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Keyboards
        public IQueryable<Keyboards> GetKeyboards()
        {
            return db.Keyboards;
        }

        // GET: api/Keyboards/5
        [ResponseType(typeof(Keyboards))]
        public IHttpActionResult GetKeyboards(long id)
        {
            Keyboards keyboards = db.Keyboards.Find(id);
            if (keyboards == null)
            {
                return NotFound();
            }

            return Ok(keyboards);
        }

        // PUT: api/Keyboards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKeyboards(long id, Keyboards keyboards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyboards.keyboard_id)
            {
                return BadRequest();
            }

            db.Entry(keyboards).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyboardsExists(id))
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

        // POST: api/Keyboards
        [ResponseType(typeof(Keyboards))]
        public IHttpActionResult PostKeyboards(Keyboards keyboards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keyboards.Add(keyboards);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KeyboardsExists(keyboards.keyboard_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = keyboards.keyboard_id }, keyboards);
        }

        // DELETE: api/Keyboards/5
        [ResponseType(typeof(Keyboards))]
        public IHttpActionResult DeleteKeyboards(long id)
        {
            Keyboards keyboards = db.Keyboards.Find(id);
            if (keyboards == null)
            {
                return NotFound();
            }

            db.Keyboards.Remove(keyboards);
            db.SaveChanges();

            return Ok(keyboards);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyboardsExists(long id)
        {
            return db.Keyboards.Count(e => e.keyboard_id == id) > 0;
        }
    }
}
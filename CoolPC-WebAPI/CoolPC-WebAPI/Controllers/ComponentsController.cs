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
    public class ComponentsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Components
        public IQueryable<Components> GetComponents()
        {
            return db.Components;
        }

        // GET: api/Components/5
        [ResponseType(typeof(Components))]
        public IHttpActionResult GetComponents(long id)
        {
            Components components = db.Components.Find(id);
            if (components == null)
            {
                return NotFound();
            }

            return Ok(components);
        }

        // PUT: api/Components/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComponents(long id, Components components)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != components.component_id)
            {
                return BadRequest();
            }

            db.Entry(components).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentsExists(id))
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

        // POST: api/Components
        [ResponseType(typeof(Components))]
        public IHttpActionResult PostComponents(Components components)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Components.Add(components);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComponentsExists(components.component_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = components.component_id }, components);
        }

        // DELETE: api/Components/5
        [ResponseType(typeof(Components))]
        public IHttpActionResult DeleteComponents(long id)
        {
            Components components = db.Components.Find(id);
            if (components == null)
            {
                return NotFound();
            }

            db.Components.Remove(components);
            db.SaveChanges();

            return Ok(components);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComponentsExists(long id)
        {
            return db.Components.Count(e => e.component_id == id) > 0;
        }
    }
}
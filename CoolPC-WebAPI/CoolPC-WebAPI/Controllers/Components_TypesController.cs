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
    public class Components_TypesController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Components_Types
        public IHttpActionResult GetComponents_Types()
        {
            return Ok(db.Components_Types.ToList().ConvertAll(a => new Components_TypesDto(a)));
        }

        // GET: api/Components_Types/5
        [ResponseType(typeof(Components_Types))]
        public IHttpActionResult GetComponents_Types(long id)
        {
            Components_Types components_Types = db.Components_Types.Find(id);
            if (components_Types == null)
            {
                return NotFound();
            }

            return Ok(new Components_TypesDto(components_Types));
        }

        // PUT: api/Components_Types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComponents_Types(long id, Components_Types components_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != components_Types.component_type_id)
            {
                return BadRequest();
            }

            db.Entry(components_Types).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Components_TypesExists(id))
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

        // POST: api/Components_Types
        [ResponseType(typeof(Components_Types))]
        public IHttpActionResult PostComponents_Types(Components_Types components_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Components_Types.Add(components_Types);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Components_TypesExists(components_Types.component_type_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = components_Types.component_type_id }, components_Types);
        }

        // DELETE: api/Components_Types/5
        [ResponseType(typeof(Components_Types))]
        public IHttpActionResult DeleteComponents_Types(long id)
        {
            Components_Types components_Types = db.Components_Types.Find(id);
            if (components_Types == null)
            {
                return NotFound();
            }

            db.Components_Types.Remove(components_Types);
            db.SaveChanges();

            return Ok(components_Types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Components_TypesExists(long id)
        {
            return db.Components_Types.Count(e => e.component_type_id == id) > 0;
        }
    }
}
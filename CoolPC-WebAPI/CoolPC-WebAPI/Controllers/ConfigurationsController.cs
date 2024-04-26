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
    public class ConfigurationsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Configurations
        public IHttpActionResult GetConfigurations()
        {
            return Ok(db.Configurations.ToList().ConvertAll(a => new ConfigurationsDto(a)));
        }

        // GET: api/Configurations/5
        [ResponseType(typeof(Configurations))]
        public IHttpActionResult GetConfigurations(long id)
        {
            Configurations configurations = db.Configurations.Find(id);
            if (configurations == null)
            {
                return NotFound();
            }

            return Ok(new ConfigurationsDto(configurations));
        }

        // PUT: api/Configurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfigurations(long id, Configurations configurations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configurations.configuration_id)
            {
                return BadRequest();
            }

            db.Entry(configurations).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationsExists(id))
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

        // POST: api/Configurations
        [ResponseType(typeof(Configurations))]
        public IHttpActionResult PostConfigurations(Configurations configurations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Configurations.Add(configurations);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ConfigurationsExists(configurations.configuration_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = configurations.configuration_id }, configurations);
        }

        // DELETE: api/Configurations/5
        [ResponseType(typeof(Configurations))]
        public IHttpActionResult DeleteConfigurations(long id)
        {
            Configurations configurations = db.Configurations.Find(id);
            if (configurations == null)
            {
                return NotFound();
            }

            db.Configurations.Remove(configurations);
            db.SaveChanges();

            return Ok(configurations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfigurationsExists(long id)
        {
            return db.Configurations.Count(e => e.configuration_id == id) > 0;
        }
    }
}
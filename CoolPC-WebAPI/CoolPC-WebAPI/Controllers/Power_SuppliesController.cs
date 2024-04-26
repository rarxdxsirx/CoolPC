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
    public class Power_SuppliesController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Power_Supplies
        public IHttpActionResult GetPower_Supplies()
        {
            return Ok(db.Power_Supplies.ToList().ConvertAll(a => new Power_SuppliesDto(a)));
        }

        // GET: api/Power_Supplies/5
        [ResponseType(typeof(Power_Supplies))]
        public IHttpActionResult GetPower_Supplies(long id)
        {
            Power_Supplies power_Supplies = db.Power_Supplies.Find(id);
            if (power_Supplies == null)
            {
                return NotFound();
            }

            return Ok(new Power_SuppliesDto(power_Supplies));
        }

        // PUT: api/Power_Supplies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPower_Supplies(long id, Power_Supplies power_Supplies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != power_Supplies.power_supply_id)
            {
                return BadRequest();
            }

            db.Entry(power_Supplies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Power_SuppliesExists(id))
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

        // POST: api/Power_Supplies
        [ResponseType(typeof(Power_Supplies))]
        public IHttpActionResult PostPower_Supplies(Power_Supplies power_Supplies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Power_Supplies.Add(power_Supplies);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Power_SuppliesExists(power_Supplies.power_supply_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = power_Supplies.power_supply_id }, power_Supplies);
        }

        // DELETE: api/Power_Supplies/5
        [ResponseType(typeof(Power_Supplies))]
        public IHttpActionResult DeletePower_Supplies(long id)
        {
            Power_Supplies power_Supplies = db.Power_Supplies.Find(id);
            if (power_Supplies == null)
            {
                return NotFound();
            }

            db.Power_Supplies.Remove(power_Supplies);
            db.SaveChanges();

            return Ok(power_Supplies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Power_SuppliesExists(long id)
        {
            return db.Power_Supplies.Count(e => e.power_supply_id == id) > 0;
        }
    }
}
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
    public class Deliveries_DetailsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Deliveries_Details
        public IQueryable<Deliveries_Details> GetDeliveries_Details()
        {
            return db.Deliveries_Details;
        }

        // GET: api/Deliveries_Details/5
        [ResponseType(typeof(Deliveries_Details))]
        public IHttpActionResult GetDeliveries_Details(long id)
        {
            Deliveries_Details deliveries_Details = db.Deliveries_Details.Find(id);
            if (deliveries_Details == null)
            {
                return NotFound();
            }

            return Ok(deliveries_Details);
        }

        // PUT: api/Deliveries_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliveries_Details(long id, Deliveries_Details deliveries_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveries_Details.delivery_details_id)
            {
                return BadRequest();
            }

            db.Entry(deliveries_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Deliveries_DetailsExists(id))
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

        // POST: api/Deliveries_Details
        [ResponseType(typeof(Deliveries_Details))]
        public IHttpActionResult PostDeliveries_Details(Deliveries_Details deliveries_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deliveries_Details.Add(deliveries_Details);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Deliveries_DetailsExists(deliveries_Details.delivery_details_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deliveries_Details.delivery_details_id }, deliveries_Details);
        }

        // DELETE: api/Deliveries_Details/5
        [ResponseType(typeof(Deliveries_Details))]
        public IHttpActionResult DeleteDeliveries_Details(long id)
        {
            Deliveries_Details deliveries_Details = db.Deliveries_Details.Find(id);
            if (deliveries_Details == null)
            {
                return NotFound();
            }

            db.Deliveries_Details.Remove(deliveries_Details);
            db.SaveChanges();

            return Ok(deliveries_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Deliveries_DetailsExists(long id)
        {
            return db.Deliveries_Details.Count(e => e.delivery_details_id == id) > 0;
        }
    }
}
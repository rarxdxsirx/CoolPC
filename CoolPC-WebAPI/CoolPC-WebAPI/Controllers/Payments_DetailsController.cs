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
    public class Payments_DetailsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Payments_Details
        public IQueryable<Payments_Details> GetPayments_Details()
        {
            return db.Payments_Details;
        }

        // GET: api/Payments_Details/5
        [ResponseType(typeof(Payments_Details))]
        public IHttpActionResult GetPayments_Details(long id)
        {
            Payments_Details payments_Details = db.Payments_Details.Find(id);
            if (payments_Details == null)
            {
                return NotFound();
            }

            return Ok(payments_Details);
        }

        // PUT: api/Payments_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPayments_Details(long id, Payments_Details payments_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payments_Details.payment_details_id)
            {
                return BadRequest();
            }

            db.Entry(payments_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Payments_DetailsExists(id))
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

        // POST: api/Payments_Details
        [ResponseType(typeof(Payments_Details))]
        public IHttpActionResult PostPayments_Details(Payments_Details payments_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payments_Details.Add(payments_Details);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Payments_DetailsExists(payments_Details.payment_details_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = payments_Details.payment_details_id }, payments_Details);
        }

        // DELETE: api/Payments_Details/5
        [ResponseType(typeof(Payments_Details))]
        public IHttpActionResult DeletePayments_Details(long id)
        {
            Payments_Details payments_Details = db.Payments_Details.Find(id);
            if (payments_Details == null)
            {
                return NotFound();
            }

            db.Payments_Details.Remove(payments_Details);
            db.SaveChanges();

            return Ok(payments_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Payments_DetailsExists(long id)
        {
            return db.Payments_Details.Count(e => e.payment_details_id == id) > 0;
        }
    }
}
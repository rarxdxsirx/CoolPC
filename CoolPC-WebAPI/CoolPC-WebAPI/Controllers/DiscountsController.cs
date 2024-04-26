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
    public class DiscountsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Discounts
        public IHttpActionResult GetDiscounts()
        {
            return Ok(db.Discounts.ToList().ConvertAll(a => new DiscountsDto(a)));
        }

        // GET: api/Discounts/5
        [ResponseType(typeof(Discounts))]
        public IHttpActionResult GetDiscounts(long id)
        {
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return NotFound();
            }

            return Ok(new DiscountsDto(discounts));
        }

        // PUT: api/Discounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiscounts(long id, Discounts discounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discounts.discount_id)
            {
                return BadRequest();
            }

            db.Entry(discounts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountsExists(id))
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

        // POST: api/Discounts
        [ResponseType(typeof(Discounts))]
        public IHttpActionResult PostDiscounts(Discounts discounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Discounts.Add(discounts);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DiscountsExists(discounts.discount_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = discounts.discount_id }, discounts);
        }

        // DELETE: api/Discounts/5
        [ResponseType(typeof(Discounts))]
        public IHttpActionResult DeleteDiscounts(long id)
        {
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return NotFound();
            }

            db.Discounts.Remove(discounts);
            db.SaveChanges();

            return Ok(discounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiscountsExists(long id)
        {
            return db.Discounts.Count(e => e.discount_id == id) > 0;
        }
    }
}
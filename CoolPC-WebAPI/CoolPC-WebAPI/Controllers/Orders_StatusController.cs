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
    public class Orders_StatusController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Orders_Status
        public IQueryable<Orders_Status> GetOrders_Status()
        {
            return db.Orders_Status;
        }

        // GET: api/Orders_Status/5
        [ResponseType(typeof(Orders_Status))]
        public IHttpActionResult GetOrders_Status(long id)
        {
            Orders_Status orders_Status = db.Orders_Status.Find(id);
            if (orders_Status == null)
            {
                return NotFound();
            }

            return Ok(orders_Status);
        }

        // PUT: api/Orders_Status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrders_Status(long id, Orders_Status orders_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders_Status.order_status_id)
            {
                return BadRequest();
            }

            db.Entry(orders_Status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Orders_StatusExists(id))
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

        // POST: api/Orders_Status
        [ResponseType(typeof(Orders_Status))]
        public IHttpActionResult PostOrders_Status(Orders_Status orders_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders_Status.Add(orders_Status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Orders_StatusExists(orders_Status.order_status_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orders_Status.order_status_id }, orders_Status);
        }

        // DELETE: api/Orders_Status/5
        [ResponseType(typeof(Orders_Status))]
        public IHttpActionResult DeleteOrders_Status(long id)
        {
            Orders_Status orders_Status = db.Orders_Status.Find(id);
            if (orders_Status == null)
            {
                return NotFound();
            }

            db.Orders_Status.Remove(orders_Status);
            db.SaveChanges();

            return Ok(orders_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Orders_StatusExists(long id)
        {
            return db.Orders_Status.Count(e => e.order_status_id == id) > 0;
        }
    }
}
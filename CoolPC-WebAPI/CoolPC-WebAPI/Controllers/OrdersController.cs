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
using System.Web.WebSockets;
using CoolPC_WebAPI;
using CoolPC_WebAPI.Dto;

namespace CoolPC_WebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Orders
        public IHttpActionResult GetOrders()
        {
            return Ok(db.Orders.ToList().ConvertAll(a => new OrdersDto(a)));
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Orders))]
        public IHttpActionResult GetOrders(long id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(new OrdersDto(orders));
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrders(long id, Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders.order_id)
            {
                return BadRequest();
            }

            db.Entry(orders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(Orders))]
        public IHttpActionResult PostOrders(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(orders);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrdersExists(orders.order_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orders.order_id }, orders);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Orders))]
        public IHttpActionResult DeleteOrders(long id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            db.Orders.Remove(orders);
            db.SaveChanges();

            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdersExists(long id)
        {
            return db.Orders.Count(e => e.order_id == id) > 0;
        }
    }
}
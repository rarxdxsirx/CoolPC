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
    public class Configuration_In_OrdersController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/Configuration_In_Orders
        public IQueryable<Configuration_In_Orders> GetConfiguration_In_Orders()
        {
            return db.Configuration_In_Orders;
        }

        // GET: api/Configuration_In_Orders/5
        [ResponseType(typeof(Configuration_In_Orders))]
        public IHttpActionResult GetConfiguration_In_Orders(long id)
        {
            Configuration_In_Orders configuration_In_Orders = db.Configuration_In_Orders.Find(id);
            if (configuration_In_Orders == null)
            {
                return NotFound();
            }

            return Ok(configuration_In_Orders);
        }

        // PUT: api/Configuration_In_Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfiguration_In_Orders(long id, Configuration_In_Orders configuration_In_Orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuration_In_Orders.order_id)
            {
                return BadRequest();
            }

            db.Entry(configuration_In_Orders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Configuration_In_OrdersExists(id))
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

        // POST: api/Configuration_In_Orders
        [ResponseType(typeof(Configuration_In_Orders))]
        public IHttpActionResult PostConfiguration_In_Orders(Configuration_In_Orders configuration_In_Orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Configuration_In_Orders.Add(configuration_In_Orders);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Configuration_In_OrdersExists(configuration_In_Orders.order_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = configuration_In_Orders.order_id }, configuration_In_Orders);
        }

        // DELETE: api/Configuration_In_Orders/5
        [ResponseType(typeof(Configuration_In_Orders))]
        public IHttpActionResult DeleteConfiguration_In_Orders(long id)
        {
            Configuration_In_Orders configuration_In_Orders = db.Configuration_In_Orders.Find(id);
            if (configuration_In_Orders == null)
            {
                return NotFound();
            }

            db.Configuration_In_Orders.Remove(configuration_In_Orders);
            db.SaveChanges();

            return Ok(configuration_In_Orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Configuration_In_OrdersExists(long id)
        {
            return db.Configuration_In_Orders.Count(e => e.order_id == id) > 0;
        }
    }
}
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
using AutoMapper;
using CoolPC_WebAPI;
using CoolPC_WebAPI.Dto;

namespace CoolPC_WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        //todo: add password hashing

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(db.Customers.ToList().ConvertAll(e => new CustomersDto(e)));
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(long id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(new CustomersDto(customers));
        }

        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(string login)
        {
            Customers customers = db.Customers.ToList().First(e => e.login == login);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(new CustomersDto(customers));
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomers(long id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.customer_id)
            {
                return BadRequest();
            }

            db.Entry(customers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers(Customers customers)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomersExists(customers.customer_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customers.customer_id }, customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(long id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customers);
            db.SaveChanges();

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(long id)
        {
            return db.Customers.Count(e => e.customer_id == id) > 0;
        }
    }
}
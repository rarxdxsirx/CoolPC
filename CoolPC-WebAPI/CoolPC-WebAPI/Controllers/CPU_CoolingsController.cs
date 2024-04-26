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
    public class CPU_CoolingsController : ApiController
    {
        private CoolPCEntities db = new CoolPCEntities();

        // GET: api/CPU_Coolings
        public IHttpActionResult GetCPU_Coolings()
        {
            return Ok(db.CPU_Coolings.ToList().ConvertAll(a=> new CPU_CoolingsDto(a)));
        }

        // GET: api/CPU_Coolings/5
        [ResponseType(typeof(CPU_Coolings))]
        public IHttpActionResult GetCPU_Coolings(long id)
        {
            CPU_Coolings cPU_Coolings = db.CPU_Coolings.Find(id);
            if (cPU_Coolings == null)
            {
                return NotFound();
            }

            return Ok(new CPU_CoolingsDto(cPU_Coolings));
        }

        // PUT: api/CPU_Coolings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCPU_Coolings(long id, CPU_Coolings cPU_Coolings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPU_Coolings.cpu_cooling_id)
            {
                return BadRequest();
            }

            db.Entry(cPU_Coolings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPU_CoolingsExists(id))
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

        // POST: api/CPU_Coolings
        [ResponseType(typeof(CPU_Coolings))]
        public IHttpActionResult PostCPU_Coolings(CPU_Coolings cPU_Coolings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPU_Coolings.Add(cPU_Coolings);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CPU_CoolingsExists(cPU_Coolings.cpu_cooling_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cPU_Coolings.cpu_cooling_id }, cPU_Coolings);
        }

        // DELETE: api/CPU_Coolings/5
        [ResponseType(typeof(CPU_Coolings))]
        public IHttpActionResult DeleteCPU_Coolings(long id)
        {
            CPU_Coolings cPU_Coolings = db.CPU_Coolings.Find(id);
            if (cPU_Coolings == null)
            {
                return NotFound();
            }

            db.CPU_Coolings.Remove(cPU_Coolings);
            db.SaveChanges();

            return Ok(cPU_Coolings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPU_CoolingsExists(long id)
        {
            return db.CPU_Coolings.Count(e => e.cpu_cooling_id == id) > 0;
        }
    }
}
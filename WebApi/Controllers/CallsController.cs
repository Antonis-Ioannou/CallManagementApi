using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CallsController : ApiController
    {
        private CallManagementEntities db = new CallManagementEntities();

        // GET: api/Products
        public IQueryable<Calls> GetCalls()
        {
            return db.Calls;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Calls))]
        public IHttpActionResult GetProduct(int id)
        {
            Calls call = db.Calls.Find(id);
            if (call == null)
            {
                return NotFound();
            }

            return Ok(call);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Calls call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != call.CallsId)
            {
                return BadRequest();
            }

            db.Entry(call).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Calls))]
        public IHttpActionResult PostProduct(Calls call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calls.Add(call);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = call.CallsId }, call);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Calls))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Calls call = db.Calls.Find(id);
            if (call == null)
            {
                return NotFound();
            }

            db.Calls.Remove(call);
            db.SaveChanges();

            return Ok(call);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Calls.Count(e => e.CallsId == id) > 0;
        }

    }
}

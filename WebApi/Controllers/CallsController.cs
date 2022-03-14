using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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


    }
}

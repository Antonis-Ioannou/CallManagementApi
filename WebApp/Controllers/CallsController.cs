using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace WebApp.Controllers
{
    public class CallsController : Controller
    {
        // GET: Calls
        public ActionResult Index()
        {
            return View();
        }
    }
}
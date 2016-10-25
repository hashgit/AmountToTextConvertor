using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmountToText.Web.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
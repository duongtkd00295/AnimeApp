using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class UnauthorisedController : Controller
    {
        // GET: Admin/Unauthorised
        public ActionResult Index()
        {
            return View();
        }
    }
}
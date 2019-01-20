using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           DatabaseContext context = new DatabaseContext();
            ViewBag.Title = context.UserPasswords.FirstOrDefault().User.UserId;

            return View();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ActionFilters;
using Repositories;
using Services.Interfaces;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        [AuthorizationUser]
        public ActionResult Index()
        {
            return View();
        }
    }
}

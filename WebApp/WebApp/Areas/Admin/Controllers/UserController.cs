using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionFilters;
using Constants;
using Helpers;
using Repositories;
using Services.Interfaces;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Admin/Login
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public JsonResult CheckLogin(AdminLoginViewModel login)
        {
            var result = _userService.CheckLogin(login.Username, login.Password);
            if (result!=null)
            {
                SessionHelper.SetSession(new UserLogged(){Username = result.UserName},AppSetting.AdminLogged);
            }
            return Json(result!=null);
        }

        public JsonResult ForgotPassword(string email)
        {
            var result = _userService.ForgotPassword(email);
            return Json(false);
        }
    }
}
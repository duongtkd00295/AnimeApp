using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Constants;
using Helpers;

namespace ActionFilters
{
    public class AuthorizationUserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var name = string.Empty;
            var redirect = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "user" }, { "area", "admin" }, { "returnUrl", filterContext.HttpContext.Request.Url } });
            string requiredPermission = string.Format("{0}-{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
            if (SessionHelper.IsExist(AppSetting.AdminLogged))
            {
                UserLogged logged = SessionHelper.GetSession(AppSetting.AdminLogged) as UserLogged;
                name = logged.Username;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "user" }, { "area", "admin" }, { "returnUrl", filterContext.HttpContext.Request.Url } });
            }
            AuthorizationUser authorizationUser = new AuthorizationUser(name);
            if (!authorizationUser.HasPermission(requiredPermission) & !authorizationUser.IsSysAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "user" }, { "area", "admin" }, { "returnUrl", filterContext.HttpContext.Request.Url } });
            }
        }
    }
}

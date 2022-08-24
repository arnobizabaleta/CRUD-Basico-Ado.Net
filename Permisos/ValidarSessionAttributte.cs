using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto7.Permisos
{
    public class ValidarSessionAttributte : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)//Si no se ha iniciado Sesión
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");//Redirecciona al login session
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;

namespace cmrhao.Controllers
{
    public class CustomAuthFilterAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            if (HttpContext.Current.Session["userRole"]==null ||  HttpContext.Current.Session["userRole"].ToString() !="Admin")
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }


    public class CustomAuthFilterStudent : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["userRole"] == null ||  HttpContext.Current.Session["userRole"].ToString() != "Student")
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }


    public class CustomAuthFilterInstructor : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["userRole"] == null ||  HttpContext.Current.Session["userRole"].ToString() != "Instructor")
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
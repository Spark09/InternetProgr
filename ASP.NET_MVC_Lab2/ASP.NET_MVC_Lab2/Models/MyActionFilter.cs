using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_Lab2.Models
{
    public class MyActionFilter : ActionFilterAttribute
    {
        dbModel db;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db = new dbModel();
            var param = filterContext.ActionParameters.Values;
            string par = "";
            if (param.Count() != 0)
            {
                var paramArr = param.ToArray();
                par = paramArr[0].ToString();
                db.Insert(filterContext.ActionDescriptor.ActionName, par);
            }
            else
            {
                db.Insert(filterContext.ActionDescriptor.ActionName, "");
            }
        }
    }
}
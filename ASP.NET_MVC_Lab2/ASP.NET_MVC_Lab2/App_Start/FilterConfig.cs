using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_Lab2.Models;

namespace ASP.NET_MVC_Lab2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyActionFilter());
        }
    }
}
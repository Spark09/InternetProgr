using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET_MVC_Lab2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //для задания про маршруты
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "сreateNote",
                url: "notepad/create",
                defaults: new { controller = "Home", action = "CreateNote" }
            );
            routes.MapRoute(
                name: "Show",
                url: "notepad/{nameNotepad}",
                defaults: new { controller = "Home", action = "ShowNotepad", nameNotepad = UrlParameter.Optional }
            );

            //для работы методов контроллера
            routes.MapRoute(
                name: "createNote",
                url: "Home/CreateNotepad",
                defaults: new { controller = "Home", action = "CreateNotepad" }
            );
            routes.MapRoute(
                name: "loadNotes",
                url: "Home/LoadNotepads",
                defaults: new { controller = "Home", action = "LoadNotepads" }
            );
            routes.MapRoute(
                name: "loadnote",
                url: "Home/LoadNotepad",
                defaults: new { controller = "Home", action = "LoadNotepad" }
            );
            routes.MapRoute(
                name: "createImage",
                url: "Home/CreateImage",
                defaults: new { controller = "Home", action = "CreateImage" }
            );
            routes.MapRoute(
                name: "deleteNotes",
                url: "Home/DeleteNotepads",
                defaults: new { controller = "Home", action = "DeleteNotepads" }
            );
            routes.MapRoute(
                name: "changeContentNote",
                url: "Home/ChangeContentNotepad",
                defaults: new { controller = "Home", action = "ChangeContentNotepad" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
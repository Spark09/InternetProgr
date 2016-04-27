using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using ASP.NET_MVC_Lab2.Models;

namespace ASP.NET_MVC_Lab2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateNote()
        {
            return View("Create");
        }
        public ActionResult ShowNotepad(string nameNotepad)
        {
            ViewBag.Name = nameNotepad;
            return View("Create");
        }
        
        MyModel model = new MyModel();

        public void CreateNotepad(MyData notepad)
        {
            model.CreateNotepad(notepad.NameNotepad);
        }
        public JsonResult LoadNotepads()
        {
            return Json(model.LoadNotepads(), JsonRequestBehavior.AllowGet);
        }
        public string LoadNotepad(string notepad)
        {
            if (notepad != "")
            {
                return model.LoadNotepad(notepad);
            }
            return null;
        }
        public void ChangeContentNotepad(string notepad, string content)
        {
            model.ChangeContentNotepad(notepad, content);
        }
        public void DeleteNotepads()
        {
            model.DeleteNotepads();
        }
        public void CreateImage(string notepad)
        {
            model.CreateImage(notepad);
        }

        public class MyData
        {
            public string NameNotepad { get; set; }
            public int Count { get; set; }
        }
        public class MyDataBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var request = controllerContext.HttpContext.Request;
                if (request.Form["notepad"] != null)
                {
                    return new MyData
                    {
                        NameNotepad = request.Form["notepad"]
                    };
                }
                return null;
            }
        }

        MyActionFilter filter = new MyActionFilter();
    }
}
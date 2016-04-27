using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Drawing;
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

        public void CreateNotepad(string notepad)
        {
            model.CreateNotepad(notepad);
        }
        public JsonResult LoadNotepads()
        {
            return Json(model.LoadNotepads(), JsonRequestBehavior.AllowGet);
        }
        public string LoadNotepad(string notepad)
        {
            return model.LoadNotepad(notepad);
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
    }
}
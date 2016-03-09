using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "File1.txt");

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About(string tb1)
        {
            ViewBag.textLine = String.Format("{0}", tb1);
            System.IO.File.AppendAllText(myPath, ViewBag.textLine + Environment.NewLine);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.myText = System.IO.File.ReadAllLines(myPath);

            return View();
        }
    }
}
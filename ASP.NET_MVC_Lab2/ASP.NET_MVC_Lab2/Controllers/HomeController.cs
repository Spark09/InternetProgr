using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ASP.NET_MVC_Lab2.Controllers
{
    public class HomeController : Controller
    {
        //string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "File1.txt");

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        List<string> notepadList = new List<string>();

        public void CreateNotepad(string notepad)
        {
            //var array = padList.ToArray();

            //string myPath = Server.MapPath("~/ASP.NET_MVC_Lab2/App_Data");
            //ViewBag.nameNotepad = nameNotepad as string;
            string notePad = String.Format("{0}", notepad);
            //string myPath1 = Server.MapPath("/App_Data/" + ViewBag.nameNotepad);
            if (!string.IsNullOrWhiteSpace(notepad))
            {
                System.IO.File.Create(myPath + @"\" + notepad);
            }
        }

        public IEnumerable<string> LoadNotepads()  //загрузка всех блокнотов из папки в формате "имя.расширение"
        {
            //List<string> files = new List<string>(Directory.GetFiles(myPath));
            
            List<string> notepadList = new List<string>(Directory.EnumerateFiles(myPath).Select(Path.GetFileName));
            return notepadList as List<string>;

            //string str = files1.Find(x => x == "abc"); //ищем такой x, который равен "abc"
        }

        public string LoadNotepad(string notepad)
        {
            string item = notepadList.Find(x => x == notepad);
            return item;
        }
        public void ChangeContentNotepad(string notepad)    //изменение содержимого блокнота
        {
            if (!string.IsNullOrWhiteSpace(notepad))
            {
                System.IO.File.AppendAllText(myPath + @"\" + notepad, Environment.NewLine);
            }
        }
        public void DeleteNotepads()    //удаление всех файлов из папки
        {
            foreach (var file in Directory.EnumerateFiles(myPath))
            {
                System.IO.File.Delete(file);
            }
        }
        public void DeleteCurrentNotepad(string notepad)    //удаление конкретного файла из папки
        {
            foreach (var filePath in Directory.EnumerateFiles(myPath))
            {
                string fileName = Path.GetFileName(filePath);
                if (fileName == notepad)
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }
    }
}
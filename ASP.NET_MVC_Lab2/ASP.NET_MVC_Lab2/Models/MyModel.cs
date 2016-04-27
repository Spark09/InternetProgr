using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace ASP.NET_MVC_Lab2.Models
{
    public class MyModel
    {
        public string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\");
        public string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\");
        
        // создание файла-блокнота в папке
        public void CreateNotepad(string notepad)
        {
            if (!string.IsNullOrWhiteSpace(notepad))
            {
                System.IO.File.Create(myPath + notepad).Close();
            }
        }
        public List<string> LoadNotepads()
        {
            List<string> notepadList = new List<string>(Directory.EnumerateFiles(myPath).Select(Path.GetFileName));
            return notepadList;
        }
        // загрузка блокнота
        public string LoadNotepad(string notepad)
        {
            string item = System.IO.File.ReadAllText(myPath + notepad);
            return item;
        }
        // изменение содержимого блокнота
        public void ChangeContentNotepad(string notepad, string content)
        {
            if (!string.IsNullOrWhiteSpace(notepad))
            {
                System.IO.File.WriteAllText(myPath + notepad, content + Environment.NewLine);
            }
        }
        // удаление всех файлов из папки
        public void DeleteNotepads()
        {
            foreach (var file in Directory.EnumerateFiles(myPath))
            {
                System.IO.File.Delete(file);
            }
        }
        // удаление конкретного файла из папки
        public void DeleteCurrentNotepad(string notepad)
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
        // генерация картинки с именем блокнота
        public void CreateImage(string nameNotepad)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            int width = 0;
            int height = 0;

            // Создаем объект Font для "рисования" им текста.
            Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

            // Создаем объект Graphics для вычисления высоты и ширины текста.
            Graphics graphics = Graphics.FromImage(bitmap);

            // Определение размеров изображения.
            width = (int)graphics.MeasureString(nameNotepad, font).Width;
            height = (int)graphics.MeasureString(nameNotepad, font).Height;

            // Пересоздаем объект Bitmap с откорректированными размерами под текст и шрифт.
            bitmap = new Bitmap(bitmap, new Size(width, height));

            // Пересоздаем объект Graphics
            graphics = Graphics.FromImage(bitmap);

            // Задаем цвет фона.
            graphics.Clear(Color.White);
            // Задаем параметры анти-алиасинга
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            // Пишем (рисуем) текст
            graphics.DrawString(nameNotepad, font, new SolidBrush(Color.Green), 0, 0);
            graphics.Flush();

            bitmap.Save(imagePath + "NotepadImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
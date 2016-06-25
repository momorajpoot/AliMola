using momii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace momii.Controllers
{
    public class StudentController : Controller
    {
        // GET: First
        public ActionResult Action1()
        {
            get
            {
                IList<Student> students = new List<Student>();
}

        //
        // GET: /Student/
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {

            foreach (string f in Request.Files)
            {
                string RootPath = AppDomain.CurrentDomain.BaseDirectory;

                if (!Directory.Exists(RootPath + "StudentImages"))
                {
                    Directory.CreateDirectory(RootPath + "StudentImages");
                }
                if (!Directory.Exists(RootPath + "StudentCv"))
                {
                    Directory.CreateDirectory(RootPath + "StudentCv");
                }


                string fileextension = Path.GetExtension(Request.Files[f].FileName);
                string filenamewithouextension = Path.GetFileNameWithoutExtension(Request.Files[f].FileName);
                if (fileextension == ".jpg")
                {
                    String finalpath = RootPath + "StudentImages\\" + s.Roll_Num + fileextension;
                    Request.Files[f].SaveAs(finalpath);
                    String path = "~/StudentImages/" + s.Roll_Num + fileextension;
                    s.imagePath = path;
                }
                if (fileextension == ".pdf")
                {
                    String finalpath = RootPath + "StudentCv\\" + s.Roll_Num + fileextension;
                    Request.Files[f].SaveAs(finalpath);
                    s.cvPath = "~/Content/images/" + s.Roll_Num + fileextension;
                }

            }
            if (Session["list"] != null)
            {
                IList<Student> students = Session["list"] as IList<Student>;
                int id = s.Roll_Num;
                students.Add(s);
                Session["list"] = students;
            }
            else
            {
                int id = s.Roll_Num;
                students.Add(s);
                Session["list"] = students;
            }
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(Student search)
        {
            if (Session != null)
            {
                IList<Student> students = Session["list"] as IList<Student>;
                foreach (Student s in students)
                {
                    if (s.Roll_Num == search.Roll_Num)
                    {
                        return View(s);
                    }
                }
            }

            ViewBag.message = "No Record Found";

            return View();

        }
        public ActionResult DownloadFile(string filename)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "StudentCv/" + filename;
            return File(filepath, MimeMapping.GetMimeMapping(filename), "yourCv" + Path.GetExtension(filename));
        }

    }
}
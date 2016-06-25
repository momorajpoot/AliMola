using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace momii.Controllers
{ 
 public class FirstController : Controller
{
    // GET: First
    public ActionResult Action1()
    {
        string datafromdatabase = "this data is coming from DB";
        int a = 16;

        ViewBag.abc = datafromdatabase;
        ViewBag.a = a;

        Session["abc"] = datafromdatabase;
        Session["a"] = a;

        return View();
    }

    public ActionResult Action2()
    {
        return View();
    }

    [HttpGet]
    public ActionResult CreateStudent()
    {
        return View();
    }

    [HttpPost]
    public ActionResult CreateStudent(Student S)
    {
        return View();
    }

    [HttpGet]
    public ActionResult Action3(string abc)
    {
        Session.Remove("abc");
        //Session.RemoveAll();
        return View();
    }

    [HttpPost]
    public ActionResult Action3(string studentname, string email)
    {
        return View();
    }

    [HttpGet]
    public ActionResult Action4()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Action4(Student _student)
    {
        string name = _student.studentname;
        string email = _student.email;

        return View();
    }


    public ActionResult Action5()
    {
        Student S = new Student();
        S.studentname = "Nawaz Sharif";
        S.email = "";
        S.address = "Pakistan";

        Student T = new Student();
        T.studentname = "Shahbaz Sharif1";
        T.email = "";
        T.address = "Pakistan";

        Student U = new Student();
        U.studentname = "Shahbaz Sharif2";
        U.email = "";
        U.address = "Saudia";

        Student V = new Student();
        V.studentname = "Shahbaz Sharif3";
        V.email = "";
        V.address = "UK";

        IList<Student> OurIlist = new List<Student>();
        OurIlist.Add(S);
        OurIlist.Add(T);
        OurIlist.Add(U);
        OurIlist.Add(V);

        return View(OurIlist);
    }
}
}
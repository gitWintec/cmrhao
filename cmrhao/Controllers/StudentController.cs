using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cmrhao.Controllers
{
    [CustomAuthFilterStudent]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Module1()
        {

            return View("Module1");
        }

    
        public ActionResult Module2()
        {

            return View("Module2");
        }

        
        public ActionResult Module3()
        {

            return View("Module3");
        }

        public ActionResult Quiz()
        {

            return View("Quiz");
        }

        public ActionResult MyAccount()
        {

            return View("MyAccount");
        }

    }
}
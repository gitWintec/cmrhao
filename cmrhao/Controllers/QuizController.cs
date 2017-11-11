using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cmrhao.Controllers
{
    public class QuizController : Controller
    {
        [CustomAuthFilterStudent]
        // GET: Quiz
        [HttpGet]
        public ActionResult StudentQuiz()
        {
            return View();
        }

        // Post: Quiz,
        [HttpPost]
        public ActionResult QuizResult(string rating1, string rating2, string rating3, bool Cbx1, bool Cbx2, bool Cbx3, bool Cbx4, bool Cbx5, bool Cbx6)
        {
            var v = 0;
            ViewBag.Q1 = rating1;
            if (ViewBag.Q1 == "true")
            {
                v = v + 1;
            }

            ViewBag.Q2 = rating2;
            if (ViewBag.Q2 =="true")
            {
                v = v + 1;
            }

            ViewBag.Q3 = rating3;
            if (ViewBag.Q3 == "true")
            {
                v = v + 1;
            }

            ViewBag.Q4 = Cbx1;
            ViewBag.Q4a = Cbx2;
            ViewBag.Q4b = Cbx3;
            if (ViewBag.Q4 == true && ViewBag.Q4a == true && ViewBag.Q4b != true )
                
            {
                v = v + 1;
            }


            ViewBag.Q5 = Cbx4;
            ViewBag.Q5a = Cbx5;
            ViewBag.Q5b = Cbx6;
            if (ViewBag.Q5 == true && ViewBag.Q5a != true && ViewBag.Q5b == true)

            {
                v = v + 1;
            }

            ViewBag.Result = v;
            
            return View();
        }


    }
}
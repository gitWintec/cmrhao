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
        [ValidateInput(false)]

        public ActionResult QuizResult(string Question1, string Question2, string Question3, string Question4, string Question5)
        {
            var v = 0;



            ViewBag.Q1 = Question1;
            if (ViewBag.Q1 == "Plug-ins")
            {
                v = v + 1;
            }

            ViewBag.Q2 = Question2;
            if (ViewBag.Q2 == "Youtube")
            {
                v = v + 1;
            }

            ViewBag.Q3 = Question3;
            if (ViewBag.Q3 == "<iframe>")
            {
                v = v + 1;
            }

            ViewBag.Q4 = Question4;
            if (ViewBag.Q4 == "Videos")
            {
                v = v + 1;
            }

            ViewBag.Q5 = Question5;
            if (ViewBag.Q5 == "avi")
            {
                v = v + 1;
            }

            ViewBag.Result = v;

            return View();
        }


    }
}
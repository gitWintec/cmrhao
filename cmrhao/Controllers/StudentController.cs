using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cmrhao.Models;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity;

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
            using (DbConnect db = new DbConnect())
            {

                int uid = (int)Session["UserID"];
                return View(db.Users.Where(x => x.UserId == uid).FirstOrDefault<User>());
            }
        }


        [HttpPost]
        public ActionResult MyAccount(User usr)
        {
            using (DbConnect db = new DbConnect())
            {
                var currentUser = db.Users.Where(x => x.UserId == usr.UserId).FirstOrDefault<User>();
                currentUser.UserFullName = usr.UserFullName;
                currentUser.UserTheme = usr.UserTheme;
                db.SaveChanges();
                Session["userTheme"] = usr.UserTheme;
                ViewBag.SuccessMessage = "Changes Updated Successfully";
                return View("MyAccount");
            }
        }

    }
}
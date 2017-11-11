using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cmrhao.Models;

namespace cmrhao.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Authorize(cmrhao.Models.User userModel)
        {
            using (DbConnect db = new DbConnect())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.UserPass == userModel.UserPass).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Login", userModel);
                }
                else
                {
                    var announement = db.Announcements.OrderByDescending(x => x.aOrder).FirstOrDefault();
                    if (announement != null)
                    {
                        Session["announcemnt"] = announement.Announcement1.ToString();
                    }
                    Session["userID"] = userDetails.UserId;
                    Session["userName"] = userDetails.UserFullName;
                    Session["userRole"] = userDetails.UserRole;
                    Session["userTheme"] = userDetails.UserTheme;

                    switch (userDetails.UserRole)
                    {
                        case "Admin":
                        return RedirectToAction("Index", "Admin");
                        case "Student":
                            return RedirectToAction("Index", "Student");
                        case "Instructor":
                            return RedirectToAction("Index", "Instrutor");
                        default:
                            return RedirectToAction("Index", "Home");

                    }
                  
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
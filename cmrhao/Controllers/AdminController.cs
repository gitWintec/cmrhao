using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cmrhao.Models;
using System.Data.Entity;

namespace cmrhao.Controllers
{
    [CustomAuthFilterAdmin]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            using (Entities db = new Entities())
            {
                List<User> userList = db.Users.Where(x => x.UserRole!="Admin").ToList<User>();
                return Json(new { data = userList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
            {
                using (Entities db = new Entities())
                {
                    return View(db.Users.Where(x => x.UserId == id).FirstOrDefault<User>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(User usr)
        {
            using (Entities db = new Entities())
            {
                if (usr.UserId == 0)
                {
                    db.Users.Add(usr);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(usr).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Entities db = new Entities())
            {
                User usr = db.Users.Where(x => x.UserId == id).FirstOrDefault<User>();
                db.Users.Remove(usr);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
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


        public ActionResult GetGroupData()
        {
            using (Entities db = new Entities())
            {
                List<Group> GroupList = db.Groups.ToList<Group>();
                return Json(new { data = GroupList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEditGroup(int id = 0)
        {
            if (id == 0)
                return View(new Group());
            else
            {
                using (Entities db = new Entities())
                {
                    return View(db.Groups.Where(x => x.GroupId == id).FirstOrDefault<Group>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditGroup(Group grp)
        {
            using (Entities db = new Entities())
            {
                if (grp.GroupId == 0)
                {
                    db.Groups.Add(grp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(grp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult DeleteGroup(int id)
        {
            using (Entities db = new Entities())
            {
                Group grp = db.Groups.Where(x => x.GroupId == id).FirstOrDefault<Group>();
                db.Groups.Remove(grp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetAncmntData()
        {
            using (Entities db = new Entities())
            {
                List<Announcement> AncmntList = db.Announcements.ToList<Announcement>();
                return Json(new { data = AncmntList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEditAnsmnt(int id = 0)
        {
            if (id == 0)
                return View(new Group());
            else
            {
                using (Entities db = new Entities())
                {
                    return View(db.Announcements.Where(x => x.Id == id).FirstOrDefault<Announcement>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditAnsmnt(Announcement ancmnt)
        {
            using (Entities db = new Entities())
            {
                if (ancmnt.Id == 0)
                {
                    db.Announcements.Add(ancmnt);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(ancmnt).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult DeleteAnsmnt(int id)
        {
            using (Entities db = new Entities())
            {
                Announcement ancmnt = db.Announcements.Where(x => x.Id == id).FirstOrDefault<Announcement>();
                db.Announcements.Remove(ancmnt);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}
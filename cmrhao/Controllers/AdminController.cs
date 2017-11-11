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
        private DbConnect db;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Groups()
        {
            return View("Groups");
        }

        public ActionResult Announcements()
        {
            return View("Announcements");
        }



        public ActionResult GroupUserListView(int Id=0)
        {
            ViewBag.GID = Id;
            return View("GroupUserList");
        }
             
        public ActionResult GetData()
        {
          
            using ( db = new DbConnect())
            {
                //  List<User> userList = db.Users.Where(x => x.UserRole!="Admin").ToList<User>();
                /*  List<Group> GroupList = db.Groups.ToList<Group>();
                  List<GroupUser> GroupUsers = db.GroupUsers.ToList<GroupUser>();

                  var output = userList.Join(userList, userList => userList.UserId, 
                      User => User.UserId,
                      (GroupUser, User) => new { Name = User.UserFullName, Role = User.UserRole });
                  return Json(new { data = output }, JsonRequestBehavior.AllowGet);*/

                 var output = (from u in db.Users where u.UserRole != "Admin"
                              join gu in db.GroupUsers on u.UserId equals gu.UserId
                              join g in db.Groups on gu.GroupId equals g.GroupId
                              select new { UserId=u.UserId,UserFullName = u.UserFullName,
                              UserName = u.UserName, UserRole = u.UserRole, UserTheme = u.UserTheme,
                              GroupName= g.GroupName} ).ToList();
                              
                return Json(new { data = output }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
            {
                using (DbConnect db = new DbConnect())
                {
                    return View(db.Users.Where(x => x.UserId == id).FirstOrDefault<User>());

                    /*return View ((from u in db.Users
                     join gu in db.GroupUsers on u.UserId equals gu.UserId
                     join g in db.Groups on gu.GroupId equals g.GroupId
                     select new
                     {   UserId = u.UserId,
                         UserFullName = u.UserFullName,
                         UserName = u.UserName,
                         UserRole = u.UserRole,
                         UserTheme = u.UserTheme,
                         UserGroup = g.GroupName
                     }).Where(x => x.UserId == id).ToList(User));*/
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(User usr)
        {
            using (DbConnect db = new DbConnect())
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
            using (DbConnect db = new DbConnect())
            {
                User usr = db.Users.Where(x => x.UserId == id).FirstOrDefault<User>();
                db.Users.Remove(usr);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetGroupData()
        {
            using (DbConnect db = new DbConnect())
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
                using (DbConnect db = new DbConnect())
                {
                    return View(db.Groups.Where(x => x.GroupId == id).FirstOrDefault<Group>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditGroup(Group grp)
        {
            using (DbConnect db = new DbConnect())
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
            using (DbConnect db = new DbConnect())
            {
                Group grp = db.Groups.Where(x => x.GroupId == id).FirstOrDefault<Group>();
                db.Groups.Remove(grp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


       public ActionResult GetGroupUsers(int id)
        {
            using (DbConnect db = new DbConnect())
            {
                List<GroupUser> GroupList = db.GroupUsers.Where(x => x.GroupId == id).ToList<GroupUser>();
                List<User> UserList = db.Users.ToList<User>();
                var output = GroupList.Join(UserList, GroupUser => GroupUser.UserId, User => User.UserId, (GroupUser, User) => new { Name = User.UserFullName, Role = User.UserRole });
                return Json(new { data = output }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult AddOrEditGroupUsers(GroupUser grpU)
        {
            using (DbConnect db = new DbConnect())
            {
                if (grpU.Id == 0)
                {
                    db.GroupUsers.Add(grpU);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(grpU).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        public ActionResult GetAncmntData()
        {
            using (DbConnect db = new DbConnect())
            {
                List<Announcement> AncmntList = db.Announcements.ToList<Announcement>();
                return Json(new { data = AncmntList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEditAnsmnt(int id = 0)
        {
            if (id == 0)
                return View(new Announcement());
            else
            {
                using (DbConnect db = new DbConnect())
                {
                    return View(db.Announcements.Where(x => x.AId == id).FirstOrDefault<Announcement>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEditAnsmnt(Announcement ancmnt)
        {
            using (DbConnect db = new DbConnect())
            {
                if (ancmnt.AId == 0)
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
            using (DbConnect db = new DbConnect())
            {
                Announcement ancmnt = db.Announcements.Where(x => x.AId == id).FirstOrDefault<Announcement>();
                db.Announcements.Remove(ancmnt);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}
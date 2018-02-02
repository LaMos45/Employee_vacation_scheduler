using EmployeeVacationScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeVacationScheduler.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        VacationDBEntities3 Db = new VacationDBEntities3();

        public String Index() 
        {
            return "hello word";
        }


        public ActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration(User userdet )
        {

            if(ModelState.IsValid)
            {
                Login log = new Login();
                log.Usename = userdet.Username;
                log.password = userdet.Password;
                log.RoleId = 2;
                log.Isdeleted = false;
                log.CreatedOn = DateTime.Today.Date;
                Db.Logins.Add(log);
                Db.SaveChanges();
                userdet.LoginId = Db.Logins.Max(a => a.LoginId);
                Db.Users.Add(userdet);
                Db.SaveChanges();

                return RedirectToAction("UserRegistration");
            }

            return View(userdet);
        }
        public JsonResult IsUserNameAvailabler(String Username)
        {

            return Json(!Db.Logins.Any(x=> x.Usename == Username),JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserList()
        {
            var users= Db.Users.ToList();
            return View(users);
        }
    }









}
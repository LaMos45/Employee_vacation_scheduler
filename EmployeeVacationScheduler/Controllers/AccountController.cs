using EmployeeVacationScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeVacationScheduler.Controllers
{
    public class AccountController : Controller
    {
        VacationDBEntities3 Db = new VacationDBEntities3();
        // GET: Account
        public ActionResult Login()
        {
            return View();
             ViewBag.Message = "";
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var result = Db.Logins.Where(a => a.Usename == login.Usename && a.password == login.password).ToList();
            if (result.Count() > 0)
            {
                Session["LoginId"] = result[0].LoginId;
                FormsAuthentication.SetAuthCookie(result[0].Usename, false);

                if (result[0].RoleId == 1)
                {
                    return RedirectToAction("../Admin/Index");
                }

                else if (result[0].RoleId == 2)
                {
                    return RedirectToAction("../Employee/Index");


                }

            }
            else ViewBag.Message = "incorrect username or password";
                return View();
        }
        public ActionResult Logout()
        {
            Session["LoginID"] = 0;
            FormsAuthentication.SignOut();
            return RedirectToAction("login");

        }
    }
}
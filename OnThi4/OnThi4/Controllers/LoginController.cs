using OnThi4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnThi4.Controllers
{
    public class LoginController : Controller
    {

        private Model1 db = new Model1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var user = db.tblUsers.Where(u => u.username == userName && u.password == password).FirstOrDefault();
            if(user == null)
            {
                ViewBag.errorLogin = "Sai ten dang nhap hoac mat khau";
                return View("Login");
            } else {
                Session["userName"] = userName;
                return RedirectToAction("Index", "NhanVien");
            }
        }

        public ActionResult Logout()
        {
            Session["userName"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}
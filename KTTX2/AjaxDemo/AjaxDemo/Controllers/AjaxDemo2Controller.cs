using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxDemo.Controllers
{
    public class AjaxDemo2Controller : Controller
    {
        // GET: AjaxDemo2
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Login(string userName, string password)
        {
            string rs = "";
            if(userName.Equals(password))
            {
                rs = "Login successfully, Hello " + userName;
            } else
            {
                rs = "Invalid userName or Password";
            }

            return rs;
        }
    }
}
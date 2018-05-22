using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MahasiswaService.MahasiswaClient mhs = new MahasiswaService.MahasiswaClient();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string ID, string password)
        {
            bool log = mhs.login(ID, password);
            if (log != false)
            {
                Session["ID"] = ID;
                return RedirectToAction("UserPage");
            }
            else
            {
                ViewBag.Message = "Wrong!";
                return View();
            }
                
        }

        public ActionResult UserPage()
        {
            if (Session["ID"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
    }
}
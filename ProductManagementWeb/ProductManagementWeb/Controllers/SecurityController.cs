using ProductManagementWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductManagementWeb.Controllers
{
    public class SecurityController : Controller
    {
        DataContext db=new DataContext();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {
            var user=db.User.FirstOrDefault(x => x.Email == Email && x.Password==Password);
            if(user!=null)
            {
                FormsAuthentication.SetAuthCookie(Email, false);//Giriş Yapma işlemi

                return RedirectToAction("Index", "Panel");

            }
            else
            {
                ViewData["Message"] = "Kullanıcı Bilgileri Uyuşmuyor.";
                return View();
            }
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
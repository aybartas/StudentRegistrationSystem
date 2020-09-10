using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;

using System.Web.Security;

namespace StudentRegistrationSystem.Controllers
{
    
    public class HomeController : Controller
    {
        StudentRegistrationContext src = new StudentRegistrationContext();
        // GET: Login
        public ActionResult Login()
        {
           // admin ve kullanıcı listleri gönderilecek
           // viewmodel kullan

            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userInDb = src.Users.FirstOrDefault(x => x.UserID == user.UserID && x.Password == user.Password);
            if (userInDb!=null)
            {
                
                FormsAuthentication.SetAuthCookie((userInDb.UserID).ToString(),false);
                return RedirectToAction("Index","SearchCourse");
            }
            else
            {
                ViewBag.Message = "Kullanıcı Adı veya Şifre Hatalı!";
                return View();
            } 
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return View("Login");
        }

    }
}
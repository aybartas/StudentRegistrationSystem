using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;

namespace StudentRegistrationSystem.Controllers
{
    
    public class LoginController : Controller
    {
        StudentRegistrationContext src = new StudentRegistrationContext();
        // GET: Login
        public ActionResult Index()
        {
           // admin ve kullanıcı listleri gönderilecek
           // viewmodel kullan

            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var userInDb = src.Users.FirstOrDefault(x => x.UserID == user.UserID && x.Password == user.Password);
            if (userInDb!=null)
            {
                return RedirectToAction("Index","SearchCourse");
            }
            else
            {
                ViewBag.Message = "Kullanıcı Adı veya Şifre Hatalı!";
                return View();
            }
           
        }
    }
}
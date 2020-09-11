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
        [AllowAnonymous]
        public ActionResult Login()
        {
            //DataAccessHelper dataAccessHelper = new DataAccessHelper();
            //List<Enrollment> enlist = dataAccessHelper.GetEnrollments(21626424);
            //System.Diagnostics.Debug.WriteLine(enlist[0].Grade);
            //System.Collections.Generic.List`1[StudentRegistrationSystem.Models.Entity.Enrollment]

            // admin ve kullanıcı listleri gönderilecek
            // viewmodel kullan

            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            var userInDb = src.Users.FirstOrDefault(x => x.UserID == user.UserID && x.Password == user.Password);
            if (userInDb!=null)
            {
                
                FormsAuthentication.SetAuthCookie((userInDb.UserID).ToString(),false);
                return RedirectToAction("Index","SearchCourse",userInDb);
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
            return RedirectToAction("Login");
        }

    }
}
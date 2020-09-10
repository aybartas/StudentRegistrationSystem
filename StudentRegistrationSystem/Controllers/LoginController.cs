using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Models.Entity;

namespace StudentRegistrationSystem.Controllers
{
    
    public class LoginController : Controller
    {
        
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
            if ()
            {

            }
            return View();
        }
    }
}
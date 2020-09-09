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
           Admin admin = new Admin();
            //{
            //    Username = "123",
            //    Password = "pass"
            //};
            Student student = new Student();
            //{ StudentID = 46, LecturerID = 6, Name = "umur" };

            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
    }
}
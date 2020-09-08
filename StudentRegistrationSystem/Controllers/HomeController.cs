using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            using (var db = new StudentRegistrationContext())
            {

                var student = new Student {StudentID= 41 ,LecturerID = 6, Name = "umur" };
                db.Students.Add(student);
                db.SaveChanges();

            }
            return View();
        }
    }
}
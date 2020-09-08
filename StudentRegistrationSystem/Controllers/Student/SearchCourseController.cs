using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Student
{
    public class SearchCourseController : Controller
    {
        // GET: SearchCourse
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
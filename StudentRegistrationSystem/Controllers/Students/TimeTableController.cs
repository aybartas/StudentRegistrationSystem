using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class TimeTableController : Controller
    {
        // GET: Timetable
        public ActionResult Index()
        {
            return View();
        }
    }
}
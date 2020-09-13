﻿using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class SearchCourseController : Controller
    {
        // GET: SearchCourse
        [Authorize]
        public ActionResult Index(User user)
        {
            ViewBag.message = "Hoşgeldiniz" + user.Name;
            return View();
        }
    }
}
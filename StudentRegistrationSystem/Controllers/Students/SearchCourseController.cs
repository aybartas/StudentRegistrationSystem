using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class SearchCourseController : Controller
    {
        LectureHelper lectureHelper = new LectureHelper();
        // GET: SearchCourse
        [Authorize]
        public ActionResult List(User user)
        {
            ViewBag.message = "Hoşgeldiniz" + user.Name;
            List<Lecture> lectures = lectureHelper._dbContext.Lectures.Include(m => m.Sections.Select(s=>s.Lecturer)).Include(m=>m.Department).ToList();
            SearchLectureViewModel searchLectureViewModel = new SearchLectureViewModel(lectures);

            return View(searchLectureViewModel);
        }




    }
}
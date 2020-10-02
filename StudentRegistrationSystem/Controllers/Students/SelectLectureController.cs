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
    public class SelectLectureController : Controller
    {
        LectureHelper lectureHelper = new LectureHelper();
        StudentHelper studentHelper = new StudentHelper();
        SectionHelper sectionHelper = new SectionHelper();
        EnrollmentHelper enrollmentHelper = new EnrollmentHelper();
        // GET: SelectLecture
        public ActionResult Index()
        {
            int UserID = int.Parse(User.Identity.Name.Split(',')[0]);
            User user = studentHelper._dbContext.Users.Include(u=>u.Enrollments.Select(e=>e.Section)).FirstOrDefault(u=>u.UserID == UserID);

            List<Lecture> lectures = lectureHelper._dbContext.Lectures.
                Include(l => l.Sections.Select(s => s.Enrollments)).
                Include(l=>l.Sections.Select(s=>s.Lecturer))
                .Where(l => l.DepartmentCode.Equals(user.DepartmentCode) && l.EducationType.Equals(user.EducationType)).ToList();

            List<Lecture> lecturesToShow = lectureHelper.lecturesToShowInSelectLecture(lectures, user.Enrollments.ToList());

            List<Enrollment> currentlySelected = enrollmentHelper._dbContext.Enrollments.Include(e => e.Section).Where(e => e.UserID == UserID && e.Grade == null).ToList();

            SelectLectureViewModel selectLectureViewModel = new SelectLectureViewModel(lecturesToShow,currentlySelected);


            return View(selectLectureViewModel);
        }

        public ActionResult AddSection(int SectionID)
        {
            int UserID = int.Parse(User.Identity.Name.Split(',')[0]);
            Section section = sectionHelper._dbContext.Sections.Include(s => s.Lecture).Include(s => s.Lecturer).FirstOrDefault(s => s.SectionID == SectionID);

            User user = studentHelper._dbContext.Users.Include(u => u.Enrollments.Select(e => e.Section)).FirstOrDefault(u => u.UserID == UserID);
            return null;
        }
    }
}
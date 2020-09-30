using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class TranscriptController : Controller
    {
        EnrollmentHelper  enrollmentHelper = new EnrollmentHelper();
        LectureHelper lectureHelper = new LectureHelper();
        // GET: Transcript
        public ActionResult Transcript()
        {
            int UserID = int.Parse(User.Identity.Name.Split(',')[0]);
            
            List<Enrollment> enrollments = enrollmentHelper._dbContext.Enrollments.Where(e => e.UserID == UserID).Include(e => e.Section).ToList();
            foreach(Enrollment enrollment in enrollments)
            {
                enrollment.Section.Lecture = lectureHelper._dbContext.Lectures.Find(enrollment.Section.LectureID);
            }
            enrollments.OrderBy(l => l.Section.LectureID);
         

            TranscriptViewModel transcriptViewModel = new TranscriptViewModel(enrollments,Math.Round(enrollmentHelper.calculateCGPA(enrollments),2));

            return View(transcriptViewModel);
        }
    }
}
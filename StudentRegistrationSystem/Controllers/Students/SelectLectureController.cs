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
        LecturerHelper lecturerHelper = new LecturerHelper();
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
            foreach(Enrollment enrollment in currentlySelected)
            {
                enrollment.Section.Lecture = lectureHelper._dbContext.Lectures.Find(enrollment.Section.LectureID);
                enrollment.Section.Lecturer = lecturerHelper._dbContext.Lecturers.Find(enrollment.Section.LecturerID);
            }
            SelectLectureViewModel selectLectureViewModel = new SelectLectureViewModel(lecturesToShow,currentlySelected);

            return View(selectLectureViewModel);
        }

        public ActionResult AddSection(int SectionID)
        {
            int UserID = int.Parse(User.Identity.Name.Split(',')[0]);

            // new enrollment
            Enrollment enrollment = new Enrollment
            {
                SectionID = SectionID,
                UserID = UserID
            };

            Section currentSelectedSection = sectionHelper._dbContext.Sections.Include(s => s.Enrollments)
                .FirstOrDefault(s=>s.SectionID == SectionID);

            List<Enrollment> currentEnrollmentsOfStudent = enrollmentHelper.GetEnrollments().Where(m => m.UserID == UserID).ToList();
            List<Section> currentSectionsOfStudent = sectionHelper.GetSectionsOfEnrollments(currentEnrollmentsOfStudent);
            User currentUser = studentHelper._dbContext.Users.Include(u => u.Enrollments).FirstOrDefault(u => u.UserID == UserID);

            if(!(currentSelectedSection.Enrollments.Count() < currentSelectedSection.Quota))
            {
                TempData["EnrollmentStatus"] = "QuotaIsFull";
                return RedirectToAction("Index", "SelectLecture");

            }

            foreach (Enrollment e in currentUser.Enrollments)
            {
                if (e.SectionID == enrollment.SectionID)
                {
                    // aynı ders aynı şube
                    TempData["EnrollmentStatus"] = "SameSectionSameNumber";
                    return RedirectToAction("Index", "SelectLecture");
                }

            }

            foreach (Section section in currentSectionsOfStudent)
            {
                if (section.LectureID == currentSelectedSection.LectureID)
                {
                    // ders zaten seçilmiş
                    TempData["EnrollmentStatus"] = "DifferentSectionSameLesson";
                    return RedirectToAction("Index", "SelectLecture");
                }
            }

            // derslerde çakışma var mı ?
            // tüm enrollmentların sectionını al , sectionından gün ve başlangıç - bitiş zamanlarına eriş, birinin başlangıç zamanı diğerinin içinde mi kontrol et 

            foreach (Section tempSection in currentSectionsOfStudent)
            {
                if (tempSection.Day.Equals(currentSelectedSection.Day))
                {
                    double startTimeOfExistingSection = Convert.ToDouble(tempSection.Time.Replace(".", ","));
                    double endTimeOfExistingSection = Convert.ToDouble(tempSection.EndTime.Replace(".", ","));
                    double startTimeOfNewSection = Convert.ToDouble(currentSelectedSection.Time.Replace(".", ","));
                    double endTimeOfNewSection = Convert.ToDouble(currentSelectedSection.EndTime.Replace(".", ","));
                    if (!((startTimeOfExistingSection.CompareTo(endTimeOfNewSection) >= 0) || (endTimeOfExistingSection.CompareTo(startTimeOfNewSection) <= 0)))
                    {
                        // sıkıntı var çakışma oldu

                        TempData["EnrollmentStatus"] = "DifferentLessonSameTime";
                        return RedirectToAction("Index", "SelectLecture");

                    }
                }
            }

            enrollmentHelper.AddEnrollment(enrollment);
            TempData["EnrollmentStatus"] = "EnrollmentSuccessful";
            return RedirectToAction("Index", "SelectLecture");

        }

        public ActionResult DeleteSection(int SectionID)
        {
            int UserID = int.Parse(User.Identity.Name.Split(',')[0]);

            Enrollment currentEnrollment = enrollmentHelper._dbContext.Enrollments.Where(e => e.SectionID == SectionID && e.UserID == UserID).FirstOrDefault();
            enrollmentHelper._dbContext.Enrollments.Remove(currentEnrollment);
            enrollmentHelper._dbContext.SaveChanges();
            TempData["DropSectionStatus"] = "Success";

            return RedirectToAction("Index", "SelectLecture");
        }

    }
}
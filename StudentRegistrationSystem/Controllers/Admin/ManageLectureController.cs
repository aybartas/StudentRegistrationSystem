using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels.AdminLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ManageLectureController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();
        DepartmentHelper departmentHelper = new DepartmentHelper();
        LecturerHelper lecturerHelper = new LecturerHelper();
        SectionHelper sectionHelper = new SectionHelper();
        EnrollmentHelper enrollmentHelper = new EnrollmentHelper();
        LectureHelper lectureHelper = new LectureHelper();

        // GET: ManageLecture
        public ActionResult List()
        {
            List<DepartmentLecturesViewModel> departmentLectures = new List<DepartmentLecturesViewModel>();

            List<Department> departments = departmentHelper.GetDepartments();
            foreach(Department department in departments)
            {
                List<Lecture> lecturesOfDepartment = lectureHelper.GetLectures().Where(m => m.DepartmentCode.Equals(department.DepartmentCode)).ToList();
                DepartmentLecturesViewModel departmentLecturesViewModel = new DepartmentLecturesViewModel(department, lecturesOfDepartment);
                departmentLectures.Add(departmentLecturesViewModel);
            }

            ListLecturesViewModel listLecturesViewModel = new ListLecturesViewModel(departmentLectures);

            return View(listLecturesViewModel);
        }

        public ActionResult AddLecture()
        {

            return View();
        }

        public ActionResult AddSection()
        {


            return View();
        }
    }
}
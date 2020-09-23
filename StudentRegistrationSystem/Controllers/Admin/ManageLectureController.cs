using StudentRegistrationSystem.Helpers;
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

        // GET: ManageLecture
        public ActionResult List()
        {

            return View();
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
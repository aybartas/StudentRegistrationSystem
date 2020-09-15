using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ManageStudentController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();
        DepartmentHelper departmentHelper = new DepartmentHelper();

        // GET: ManageStudent
        public ActionResult List()
        {
            List<User> students = studentHelper.GetOnlyStudents();
            List<StudentRecordViewModel> studentRecords = new List<StudentRecordViewModel>();


            foreach(User user in students)
            {
                
                StudentRecordViewModel studentRecord = new StudentRecordViewModel(user.UserID,
                    user.Name,
                    user.LastName,
                    user.EducationType,departmentHelper.);

            }

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }


    }
}
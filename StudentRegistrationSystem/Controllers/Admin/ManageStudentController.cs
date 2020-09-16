﻿using StudentRegistrationSystem.Helpers;
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
        LecturerHelper lecturerHelper = new LecturerHelper();

        // GET: ManageStudent
        public ActionResult List()
        {
            List<User> students = studentHelper.GetOnlyStudents();
            List<StudentRecordViewModel> studentRecords = new List<StudentRecordViewModel>();
          

            foreach(User user in students)
            {

                StudentRecordViewModel studentRecord = new StudentRecordViewModel(
                    user.UserID,
                    user.Name,
                    user.LastName,
                    user.EducationType,
                    departmentHelper.DepNameFinder(user.DepartmentCode),
                    studentHelper.GetAdvisor(user.UserID).Name +" "+ studentHelper.GetAdvisor(user.UserID).LastName);

                studentRecords.Add(studentRecord);
            }

            StudentListViewModel studentListViewModel = new StudentListViewModel(studentRecords);


            return View(studentListViewModel);
        }

        public ActionResult Form()
        {

            AddStudentViewModel addStudentViewModel = new AddStudentViewModel(departmentHelper.GetDepartments());


            return View(addStudentViewModel);
        }




        [HttpPost]
        public ActionResult AddStudentForm(string departmentCode)
        {

            List<Lecturer> templecturers = lecturerHelper.GetLecturer().Where(x => x.DepartmentCode.Equals(departmentCode)).ToList();

            SelectList lecturers = new SelectList(templecturers, "departmentCode", "advisorName", 0);
            return Json(lecturers);
        }


    }
}
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

            List<DropdownAdvisorViewModel> dropdownAdvisors = new List<DropdownAdvisorViewModel>();

            foreach(Lecturer temp in templecturers)
            {
                DropdownAdvisorViewModel dropdownAdvisor = new DropdownAdvisorViewModel
                {
                    Id = temp.LecturerID,
                    FullName = temp.Name +" "+ temp.LastName,
                    DeptCode = temp.DepartmentCode
                };
                dropdownAdvisors.Add(dropdownAdvisor);
            }

            SelectList lecturers = new SelectList(dropdownAdvisors, "Id", "FullName", 0);
            return Json(lecturers);
        }

        [HttpPost]
        public ActionResult Form(AddStudentViewModel addStudentViewModel,int ddlAdvisor)
        {
            //System.Diagnostics.Debug.WriteLine(lecturer.LecturerID);
            //addStudentViewModel.user.Password = "adasdaads02";
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //System.Diagnostics.Debug.WriteLine(errors);
            if (ModelState.IsValid)
            {
                //Lecturer lecturer = lecturerHelper._dbContext.Lecturers.Find(ddlAdvisor);
                //addStudentViewModel.user.Lecturer = lecturer;
                addStudentViewModel.user.LecturerID = ddlAdvisor;
                addStudentViewModel.user.Role = "U";
                //addStudentViewModel.user.Password = addStudentViewModel.user.CitizenshipNo.ToString().Substring(0, 4);

                studentHelper._dbContext.Users.Add(addStudentViewModel.user);
               
                
                
                studentHelper._dbContext.SaveChanges();       
                return RedirectToAction("List", "ManageStudent");
             

            }

            return RedirectToAction("Form", "ManageStudent");
        }


    }
}
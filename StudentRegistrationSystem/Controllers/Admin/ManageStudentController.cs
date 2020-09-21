using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ManageStudentController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();
        DepartmentHelper departmentHelper = new DepartmentHelper();
        LecturerHelper lecturerHelper = new LecturerHelper();
        SectionHelper sectionHelper = new SectionHelper();
        EnrollmentHelper enrollmentHelper = new EnrollmentHelper();

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
                    departmentHelper._dbContext.Departments.Find(user.DepartmentCode).Name,
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

            List<Lecturer> templecturers = lecturerHelper.GetLecturers().Where(x => x.DepartmentCode.Equals(departmentCode)).ToList();

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
                TempData["Success"] = "Not Null";
                return RedirectToAction("List", "ManageStudent");
            }

            return RedirectToAction("Form", "ManageStudent");
        }

        public ActionResult Delete(int UserID)
        {
            TempData["DeleteSuccess"] = "Not Null";
            studentHelper._dbContext.Users.Remove(studentHelper._dbContext.Users.Find(UserID));
            studentHelper._dbContext.SaveChanges();
            return RedirectToAction("List", "ManageStudent");
        }
        
        public ActionResult Update(int UserID)
        {
            User user = studentHelper._dbContext.Users.Find(UserID);
            UpdateStudentViewModel updateStudentViewModel = new UpdateStudentViewModel(user, lecturerHelper.GetLecturers().Where(x => x.DepartmentCode.Equals(user.DepartmentCode)).ToList());
            return View(updateStudentViewModel);
        }
        [HttpPost]
        public ActionResult Update(UpdateStudentViewModel updateStudentViewModel)
        {
            User user = studentHelper.FindUserByID(updateStudentViewModel.userID);
            user.Name = updateStudentViewModel.Name;
            user.LastName = updateStudentViewModel.LastName;
            user.Gender = updateStudentViewModel.Gender;
            user.EducationType = updateStudentViewModel.EducationType;
            user.Phone = updateStudentViewModel.Phone;
            user.LecturerID = updateStudentViewModel.LecturerID;
            if (ModelState.IsValid)
            {
                TempData["UpdateSuccess"] = "Not Null";
                studentHelper._dbContext.Users.AddOrUpdate<User>(user);
                studentHelper._dbContext.SaveChanges();
                return RedirectToAction("List", "ManageStudent");
            }
            else
            {
                return RedirectToAction("Update", "ManageStudent");
            }
        }
        public ActionResult Courses(int UserID)
        {

            UpdateStudentCourseViewModel updateStudentCourseViewModel = new UpdateStudentCourseViewModel
            {
                user = studentHelper._dbContext.Users.Find(UserID),
                departmentalLectures = studentHelper.GetAllLecturesOfUsersDepartmentDependingOnEducationType(UserID),
                sections = studentHelper.GetSyllabusSec(UserID)
            };
            return View(updateStudentCourseViewModel);
        }


        public ActionResult DeleteSection(int UserID,int SectionID)
        {
            TempData["DeleteSectionSuccess"] = "Not Null";

            enrollmentHelper.DeleteEnrollment(UserID, SectionID);

            return RedirectToAction("Courses", "ManageStudent", new { UserID });
           
        }


        [HttpPost]
        public ActionResult UpdatePassword(UpdateStudentViewModel updateStudentViewModel,int UserID)
        {

            User user = studentHelper.FindUserByID(UserID);
            user.Password = updateStudentViewModel.Password;

            if (ModelState.IsValid)
            {
                TempData["PasswordSuccess"] = "Not Null";
                studentHelper._dbContext.Users.AddOrUpdate<User>(user);
                studentHelper._dbContext.SaveChanges();
                return RedirectToAction("Update", "ManageStudent",new {user.UserID });
            }
            else
            {
                return RedirectToAction("Update", "ManageStudent",new { user.UserID});
            }
            
        }





        [HttpPost]
        public ActionResult AddSection(int UserID, int ddlSection)
        {


            Enrollment enrollment = new Enrollment
            {
                SectionID = ddlSection,
                UserID = UserID
            };


            // kontrolleri yapılacak şimdilik deneme bu 

            enrollmentHelper.AddEnrollment(enrollment);

            TempData["AddSectionSuccess"] = "Not Null";
            return RedirectToAction("Courses", "ManageStudent", new { UserID });
        }


        [HttpPost]
        public ActionResult GetSectionsFromLectures(int LectureID)
        {

            List<Section> dropdownSections = sectionHelper.GetSectionsOfLecture(LectureID);

            SelectList sections = new SelectList(dropdownSections, "SectionID", "Number", 0);
            return Json(sections);
        }

    }
}
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
    public class ManageLecturerController : Controller
    {
        LecturerHelper lecturerHelper = new LecturerHelper();
        DepartmentHelper departmentHelper = new DepartmentHelper();
        public ActionResult List()
        {
            LecturerListViewModel lecturerListViewModel = new LecturerListViewModel();
            lecturerListViewModel.lecturerlist = lecturerHelper.GetLecturers();
            lecturerListViewModel.departmentList = departmentHelper.GetDepartments();
            return View(lecturerListViewModel);
        }
        [HttpPost]
        public ActionResult AddLecturer(LecturerListViewModel lecturerListViewModel)
        {
            if (ModelState.IsValid)
            {

                Lecturer lecturer = new Lecturer
                {
                    Name = lecturerListViewModel.Name,
                    LastName = lecturerListViewModel.LastName,
                    Phone = lecturerListViewModel.Phone,
                    Email = lecturerListViewModel.Email,
                    DepartmentCode = lecturerListViewModel.DepartmentCode
                };
                lecturerHelper._dbContext.Lecturers.Add(lecturer);
                lecturerHelper._dbContext.SaveChanges();
                TempData["LecturerAddSuccess"] = "Not Null";
                return RedirectToAction("List", "ManageLecturer");
            }

            return RedirectToAction("List", "ManageLecturer");
        }
        public ActionResult Delete(int LecturerID)
        {
            TempData["LecturerDeleteSuccess"] = "Not Null";
            lecturerHelper._dbContext.Lecturers.Remove(lecturerHelper._dbContext.Lecturers.Find(LecturerID));
            lecturerHelper._dbContext.SaveChanges();
            return RedirectToAction("List", "ManageLecturer");
        }
    }
}

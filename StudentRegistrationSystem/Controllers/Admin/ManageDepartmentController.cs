using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using StudentRegistrationSystem.ViewModels.AdminLecture;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ManageDepartmentController : Controller
    {
        DepartmentHelper departmentHelper = new DepartmentHelper();
        StudentHelper studentHelper = new StudentHelper();
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(Department department)
        {
            departmentHelper._dbContext.Departments.Add(department);
            departmentHelper._dbContext.SaveChanges();
            TempData["DepartmentAddSuccess"] = "Not Null";
            return RedirectToAction("List", "ManageDepartment");
        }
        public ActionResult Update(string DepartmentCode)
        {
            Department department = departmentHelper._dbContext.Departments.Find(DepartmentCode);
            UpdateDepartmentViewModel updateDepartmentViewModel = new UpdateDepartmentViewModel
            {
                Department = department,
                DepartmentCode = DepartmentCode,

            };
            return View(updateDepartmentViewModel);
        }
        [HttpPost]
        public ActionResult Update(UpdateDepartmentViewModel updateDepartmentViewModel)
        {
            Department department = departmentHelper._dbContext.Departments.Find(updateDepartmentViewModel.DepartmentCode);
            department.Name = updateDepartmentViewModel.Name;
            department.Phone = updateDepartmentViewModel.Phone;
            updateDepartmentViewModel.Department = department;
            if (ModelState.IsValid)
            {
                TempData["DepartmentUpdateSuccess"] = "Not Null";
                departmentHelper._dbContext.Departments.AddOrUpdate<Department>(department);
                departmentHelper._dbContext.SaveChanges();
                return RedirectToAction("List", "ManageDepartment");
               
            }
            else
            {
                return View(updateDepartmentViewModel);
            }
        }
        public ActionResult Delete(string DepartmentCode)
        {
            foreach (User s in studentHelper.GetOnlyStudents())
            {
                if (s.DepartmentCode!=null && s.DepartmentCode.Equals(DepartmentCode))
                {
                    TempData["DeleteStatus"] = "There are students in the deleted department";
                    s.DepartmentCode = null;
                    departmentHelper._dbContext.Users.AddOrUpdate<User>(s);
                    departmentHelper._dbContext.SaveChanges();
                }
            }
            departmentHelper._dbContext.Departments.Remove(departmentHelper._dbContext.Departments.Find(DepartmentCode));
            departmentHelper._dbContext.SaveChanges();
            TempData["DepartmentDeleteSuccess"] = "Not Null";
            return RedirectToAction("List", "ManageDepartment");
        }
    }
}
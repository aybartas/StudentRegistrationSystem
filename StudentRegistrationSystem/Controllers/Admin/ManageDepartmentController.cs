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
    public class ManageDepartmentController : Controller
    {
        DepartmentHelper departmentHelper = new DepartmentHelper();
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
    }
}
using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels.AdminLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class DepartmentInfoController: Controller
    {

        public ActionResult All()
        {

            return View();
        }
    }
}
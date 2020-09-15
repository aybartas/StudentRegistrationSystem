using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ManageStudentController : Controller
    {
        // GET: ManageStudent
        public ActionResult List()
        {

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }


    }
}
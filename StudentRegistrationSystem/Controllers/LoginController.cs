using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;

namespace StudentRegistrationSystem.Controllers
{
    
    public class LoginController : Controller
    {
       
        // GET: Login
        public ActionResult Index()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            return View();
           
        }
    }
}
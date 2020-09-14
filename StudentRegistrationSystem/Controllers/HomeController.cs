using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;

using System.Web.Security;

namespace StudentRegistrationSystem.Controllers
{
    
    public class HomeController : Controller
    {
        GetAddHelper GetAddHelper = new GetAddHelper();
        LectureHelper LectureHelper = new LectureHelper();
        StudentHelper studentHelper = new StudentHelper();

        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            User userInDb = studentHelper.FindUserByID(user.UserID);
            if (userInDb != null && user.UserID == userInDb.UserID && user.Password == userInDb.Password && user.Role == userInDb.Role)
            {

                FormsAuthentication.SetAuthCookie((userInDb.UserID).ToString(), false);
                return RedirectToAction("Index", "SearchCourse", userInDb);
            }
            else
            {
                TempData["data"] = "Kullanıcı Adı veya Şifre Hatalı!";
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
    //Lecturer l = dataAccessHelper.GetAdvisor(21226224);
    //System.Diagnostics.Debug.WriteLine(l.Name + l.LastName);
    //List<Lecture> abc = dataAccessHelper.GetDeptAll(21226224);

    //List<Lecture> abc = dataAccessHelper.GetTranscript(21226224);
    //List<Lecture> abc2 = dataAccessHelper.GetSyllabus(21226224);
    //System.Diagnostics.Debug.WriteLine(abc[0].LectureCode + abc[1].LectureCode);
    //System.Diagnostics.Debug.WriteLine(abc[0].LectureCode, abc[1].LectureCode);
    //System.Diagnostics.Debug.WriteLine(abc2[0].Name);
    //List<Enrollment> enlist = dataAccessHelper.GetEnrollments(21626424);
    //System.Diagnostics.Debug.WriteLine(enlist[0].Grade);
    //System.Collections.Generic.List`1[StudentRegistrationSystem.Models.Entity.Enrollment]

    // admin ve kullanıcı listleri gönderilecek
    // viewmodel kullan
    //Lecturer l = dataAccessHelper.LecturerFinderBySection(7);
    //System.Diagnostics.Debug.WriteLine(l.Name + l.LastName);
    //List<Section> l = dataAccessHelper.GetSectionsOfLecture(4);
    //foreach (Section s in l)
    //{
    //    System.Diagnostics.Debug.WriteLine(s.Time);
    //}

}